using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.ML.DataOperationsCatalog;

namespace Feedback
{
    public partial class frmShowFeedback : Form
    {
        FeedbackDataContext dbContext = new FeedbackDataContext();

        private MLContext mlContext = new MLContext(42);
        IDataView dataView;
        private TrainTestData splitDataView;
        private ITransformer model;
        string folder = "Model";
        BackgroundWorker worker = null;
        private object modelSchema;

        public frmShowFeedback()
        {
            InitializeComponent();

            this.btnHomeShowFeedback.Click += new System.EventHandler(this.btnHome_Click);

            Font vietnameseFont = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point, 0x01);
            cboClass.Font = vietnameseFont;
            cboSubject.Font = vietnameseFont;
            cboFaculty.Font = vietnameseFont;

            // Gán sự kiện Click cho combobox cboClass
            cboClass.Click += cboClass_Click;

            // Gán sự kiện DropDown cho combobox cboSubject
            cboSubject.Click += cboSubject_Click;


        }




        private void cboSubject_Click(object sender, EventArgs e)
        {
            if (cboClass.SelectedValue != null)
            {
                // Lấy ClassCode từ combobox cboClass
                string selectedClassCode = cboClass.SelectedValue.ToString();

                // Truy vấn dữ liệu các môn học tương ứng với ClassCode đã chọn
                var subjectData = (from course in dbContext.Courses
                                   join subject in dbContext.Subjects on course.SubjectCode equals subject.SubjectCode
                                   where course.ClassCode == selectedClassCode
                                   select subject).ToList();

                if (subjectData.Any())
                {
                    // Gán dữ liệu cho combobox cboSubject từ kết quả truy vấn
                    cboSubject.DataSource = subjectData;
                    cboSubject.DisplayMember = "SubjectName";
                    cboSubject.ValueMember = "SubjectCode";

                    // Hiển thị nội dung combobox cboSubject
                    cboSubject.DroppedDown = true;
                }
                else
                {
                    MessageBox.Show("Không có môn học nào cho lớp này.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn lớp trước khi chọn môn học.");
            }
        }

        private void cboClass_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu cho combobox cboClass từ bảng Class
            var classData = dbContext.Classes.ToList();
            cboClass.DataSource = classData;
            cboClass.DisplayMember = "ClassName";
            cboClass.ValueMember = "ClassCode";

            // Hiển thị nội dung combobox cboClass
            cboClass.DroppedDown = true;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            // Tắt frmShowFeedback
            this.Hide();

            // Tìm và tắt frmLectures nếu nó đang hiển thị
            Form frmLectures = Application.OpenForms["frmLectures"];
            if (frmLectures != null)
            {
                frmLectures.Close();
            }

            // Tìm và hiển thị frmHome nếu nó đã được tạo
            Form frmHome = Application.OpenForms["frmHome"];
            if (frmHome != null)
            {
                frmHome.Show();
            }
            else
            {
                // Nếu frmHome chưa được tạo, bạn có thể tạo mới như sau:
                frmHome = new frmHome();
                frmHome.Show();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (cboClass.SelectedValue != null && cboSubject.SelectedValue != null)
            {
                string selectedClassCode = cboClass.SelectedValue.ToString();
                string selectedSubjectCode = cboSubject.SelectedValue.ToString();

                var feedbackData = (from feedback in dbContext.Feedbacks
                                    join course in dbContext.Courses on feedback.CourseCode equals course.CourseCode
                                    join subject in dbContext.Subjects on course.SubjectCode equals subject.SubjectCode
                                    where course.ClassCode == selectedClassCode && subject.SubjectCode == selectedSubjectCode
                                    select feedback.Text).ToList();

                lvFeedBack.Items.Clear();

                foreach (var feedbackText in feedbackData)
                {
                    ListViewItem item = new ListViewItem(feedbackText);
                    lvFeedBack.Items.Add(item);
                }

            }

            // Load and display text file content based on the subject name
            string subjectName = cboSubject.Text; // Get the selected subject name



            string filePath = ""; // Path to the text file


            if (subjectName == "An toàn và bảo mật hệ thống thông tin")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\An toàn và bảo mật hệ thống thông tin.txt";
            }
            else if (subjectName == "An toàn và bảo mật thương mại điện tử")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\An toàn và bảo mật thương mại điện tử.txt";
            }
            else if (subjectName == "Chuyển đổi số trong kinh doanh")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Chuyển đổi số trong kinh doanh.txt";
            }
            else if (subjectName == "Hệ khuyến nghị")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Hệ khuyến nghị.txt";
            }
            else if (subjectName == "Hệ thống thông tin kế toán")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Hệ thống thông tin kế toán.txt";
            }
            else if (subjectName == "Học máy trong phân tích kinh doanh")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Học máy trong phân tích kinh doanh.txt";
            }
            else if (subjectName == "Học sâu trong phân tích kinh doanh")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Học sâu trong phân tích kinh doanh.txt";
            }
            else if (subjectName == "Khai phá dữ liệu văn bản")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Khai phá dữ liệu văn bản.txt";
            }
            else if (subjectName == "Kiến tập")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Kiến tập.txt";
            }
            else if (subjectName == "Lý thuyết kiểm toán")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Lý thuyết kiểm toán.txt";
            }
            else if (subjectName == "Nghệ thuật lãnh đạo")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Nghệ thuật lãnh đạo.txt";
            }
            else if (subjectName == "Nghiên cứu thị trường trực tuyến")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Nghiên cứu thị trường trực tuyến.txt";
            }
            else if (subjectName == "Nhà kho dữ liệu và khai phá dữ liệu")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Nhà kho dữ liệu và khai phá dữ liệu.txt";
            }
            else if (subjectName == "Phân tích chuỗi thời gian trong tài chính")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Phân tích chuỗi thời gian trong tài chính.txt";
            }
            else if (subjectName == "Phân tích dữ liệu chuỗi thời gian và dự báo")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Phân tích dữ liệu chuỗi thời gian và dự báo.txt";
            }
            else if (subjectName == "Phân tích dữ liệu với Rpython")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Phân tích dữ liệu với Rpython.txt";
            }
            else if (subjectName == "Phân tích dữ liệu WEB")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Phân tích dữ liệu WEB.txt";
            }
            else if (subjectName == "Pháp luật về thương mại điện tử")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Pháp luật về thương mại điện tử.txt";
            }
            else if (subjectName == "Phát triển ERP mã nguồn mở")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Phát triển ERP mã nguồn mở.txt";
            }
            else if (subjectName == "Phát triển thương mại di động nâng cao")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Phát triển thương mại di động nâng cao.txt";
            }
            else if (subjectName == "Phát triển Thương mại di động")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Phát triển Thương mại di động.txt";
            }
            else if (subjectName == "Phát triển Web kinh doanh nâng cao")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Phát triển Web kinh doanh nâng cao.txt";
            }
            else if (subjectName == "Quản lý dự án Hệ thống thông tin")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Quản lý dự án Hệ thống thông tin.txt";
            }
            else if (subjectName == "Quản trị bán lẻ trực tuyến")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Quản trị bán lẻ trực tuyến.txt";
            }
            else if (subjectName == "Thanh toán điện tử")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Thanh toán điện tử.txt";
            }
            else if (subjectName == "Thống kê trong Quản trị kinh doanh và Marketing")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Thống kê trong Quản trị kinh doanh và Marketing.txt";
            }
            else if (subjectName == "Thương mại trên mạng xã hội")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Thương mại trên mạng xã hội.txt";
            }
            else if (subjectName == "Tích hợp qui trình KDoanh với các hệ thống ERP2")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Tích hợp qui trình KDoanh với các hệ thống ERP2.txt";
            }
            else if (subjectName == "Trí tuệ doanh nghiệp và hệ hỗ trợ ra quyết định")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Trí tuệ doanh nghiệp và hệ hỗ trợ ra quyết định.txt";
            }
            else if (subjectName == "Trực quan hóa dữ liệu.txt")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Trực quan hóa dữ liệu.txt";
            }
            else if (subjectName == "Văn hóa doanh nghiệp")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Văn hóa doanh nghiệp.txt";
            }

            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                string fileContent = File.ReadAllText(filePath);
                ListViewItem fileItem = new ListViewItem(fileContent);
                lvFeedBack.Items.Add(fileItem);
            }

            else
            {
                MessageBox.Show("Vui lòng chọn lớp và môn học trước khi xác nhận.");
            }

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += Worker_DoWork; //chạy longtime nhưng k truy xuất vào bất kỳ biến Ctrl nào. K cập nhật thời gian thiện ở đây nhé!          
            worker.RunWorkerAsync(); //hàm chạy bất đồng bộ

            if (Directory.Exists(folder) == false)
            {
                Directory.CreateDirectory(folder);
            }
            string path = folder + "\\ML.Emotion-" + DateTime.Now.ToString("ddMMyyyy-hhmmss");
            try
            {
                if (mlContext == null || model == null || splitDataView.TrainSet == null)
                    return;
                mlContext.Model.Save(
                    model,
                    splitDataView.TrainSet.Schema,
                    path);
                LoadModelIntoCombo();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void LoadModelIntoCombo()
        {
            cboModel.Items.Clear();
            if (Directory.Exists(folder) == false)
                return;
            string[] files = Directory.GetFiles(folder);
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                cboModel.Items.Add(fi.Name);
            }
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string filePath = @"D:\TextMiningProject\feedbacks.txt"; // Specify the correct file path

                IDataView dataView = mlContext.Data.LoadFromTextFile<FeedbackData>(
                    path: filePath,
                    separatorChar: '\t', // Specify the correct separator character used in your file
                    hasHeader: false,
                    allowQuoting: true,
                    allowSparse: false
                );
                double testFraction = 0.2;
                splitDataView = mlContext.Data.TrainTestSplit(dataView, 
                    testFraction: testFraction);
                var estimator = mlContext.Transforms.Text
                    .FeaturizeText(outputColumnName: "Features",
                    inputColumnName: nameof(FeedbackData.Data))
                    .Append(mlContext.BinaryClassification.Trainers
                    .SdcaLogisticRegression(labelColumnName: "Label",
                    featureColumnName: "Features"));
                model = estimator.Fit(splitDataView.TrainSet);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        private void btnDetails_Click(object sender, EventArgs e)
        {
            
        }

        private void lvFeedBack_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboModel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cboModel.SelectedIndex == -1)
                return;
            string modelFileName = folder + "\\" + cboModel.Text;
            try
            {
                if (mlContext == null)
                    return;
                DataViewSchema modelSchema;
                model = mlContext.Model.Load(modelFileName, out modelSchema);
                MessageBox.Show("Load OK");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            // Load and display text file content based on the subject name
            string subjectName = cboSubject.Text; // Get the selected subject name

            string filePath = ""; // Path to the text file


            if (subjectName == "An toàn và bảo mật hệ thống thông tin")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\An toàn và bảo mật hệ thống thông tin.txt";
            }
            else if (subjectName == "An toàn và bảo mật thương mại điện tử")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\An toàn và bảo mật thương mại điện tử.txt";
            }
            else if (subjectName == "Chuyển đổi số trong kinh doanh")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Chuyển đổi số trong kinh doanh.txt";
            }
            else if (subjectName == "Hệ khuyến nghị")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Hệ khuyến nghị.txt";
            }
            else if (subjectName == "Hệ thống thông tin kế toán")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Hệ thống thông tin kế toán.txt";
            }
            else if (subjectName == "Học máy trong phân tích kinh doanh")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Học máy trong phân tích kinh doanh.txt";
            }
            else if (subjectName == "Học sâu trong phân tích kinh doanh")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Học sâu trong phân tích kinh doanh.txt";
            }
            else if (subjectName == "Khai phá dữ liệu văn bản")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Khai phá dữ liệu văn bản.txt";
            }
            else if (subjectName == "Kiến tập")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Kiến tập.txt";
            }
            else if (subjectName == "Lý thuyết kiểm toán")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Lý thuyết kiểm toán.txt";
            }
            else if (subjectName == "Nghệ thuật lãnh đạo")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Nghệ thuật lãnh đạo.txt";
            }
            else if (subjectName == "Nghiên cứu thị trường trực tuyến")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Nghiên cứu thị trường trực tuyến.txt";
            }
            else if (subjectName == "Nhà kho dữ liệu và khai phá dữ liệu")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Nhà kho dữ liệu và khai phá dữ liệu.txt";
            }
            else if (subjectName == "Phân tích chuỗi thời gian trong tài chính")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Phân tích chuỗi thời gian trong tài chính.txt";
            }
            else if (subjectName == "Phân tích dữ liệu chuỗi thời gian và dự báo")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Phân tích dữ liệu chuỗi thời gian và dự báo.txt";
            }
            else if (subjectName == "Phân tích dữ liệu với Rpython")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Phân tích dữ liệu với Rpython.txt";
            }
            else if (subjectName == "Phân tích dữ liệu WEB")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Phân tích dữ liệu WEB.txt";
            }
            else if (subjectName == "Pháp luật về thương mại điện tử")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Pháp luật về thương mại điện tử.txt";
            }
            else if (subjectName == "Phát triển ERP mã nguồn mở")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Phát triển ERP mã nguồn mở.txt";
            }
            else if (subjectName == "Phát triển thương mại di động nâng cao")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Phát triển thương mại di động nâng cao.txt";
            }
            else if (subjectName == "Phát triển Thương mại di động")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Phát triển Thương mại di động.txt";
            }
            else if (subjectName == "Phát triển Web kinh doanh nâng cao")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Phát triển Web kinh doanh nâng cao.txt";
            }
            else if (subjectName == "Quản lý dự án Hệ thống thông tin")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Quản lý dự án Hệ thống thông tin.txt";
            }
            else if (subjectName == "Quản trị bán lẻ trực tuyến")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Quản trị bán lẻ trực tuyến.txt";
            }
            else if (subjectName == "Thanh toán điện tử")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Thanh toán điện tử.txt";
            }
            else if (subjectName == "Thống kê trong Quản trị kinh doanh và Marketing")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Thống kê trong Quản trị kinh doanh và Marketing.txt";
            }
            else if (subjectName == "Thương mại trên mạng xã hội")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Thương mại trên mạng xã hội.txt";
            }
            else if (subjectName == "Tích hợp qui trình KDoanh với các hệ thống ERP2")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Tích hợp qui trình KDoanh với các hệ thống ERP2.txt";
            }
            else if (subjectName == "Trí tuệ doanh nghiệp và hệ hỗ trợ ra quyết định")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Trí tuệ doanh nghiệp và hệ hỗ trợ ra quyết định.txt";
            }
            else if (subjectName == "Trực quan hóa dữ liệu.txt")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Trực quan hóa dữ liệu.txt";
            }
            else if (subjectName == "Văn hóa doanh nghiệp")
            {
                filePath = @"D:\TextMiningProject\Feedback_Tach\Văn hóa doanh nghiệp.txt";
            }

            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                string fileContent = File.ReadAllText(filePath); // Read the entire content of the file
                string[] feedbacks = fileContent.Split('\n'); // Split the content into individual feedbacks

                int totalFeedbacks = feedbacks.Length;
                int positiveCount = 0;
                int negativeCount = 0;

                foreach (var feedbackText in feedbacks)
                {
                    if (!string.IsNullOrWhiteSpace(feedbackText))
                    {
                        FeedbackData feedback = new FeedbackData { Data = feedbackText.Trim() };
                        try
                        {
                            PredictionEngine<FeedbackData, FeedbackSentiment> predictionFunction =
                                mlContext.Model.CreatePredictionEngine<FeedbackData, FeedbackSentiment>(model);
                            var resultPrediction = predictionFunction.Predict(feedback);

                            if (resultPrediction.PredictedLabel) // Prediction is true for positive sentiment
                            {
                                positiveCount++;
                            }
                            else // Prediction is false for negative sentiment
                            {
                                negativeCount++;
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle exception if prediction fails for a specific feedback
                            Console.WriteLine($"Prediction error: {ex.Message}");
                        }
                    }
                }

                double percentPositive = (double)positiveCount / totalFeedbacks * 100;
                double percentNegative = (double)negativeCount / totalFeedbacks * 100;

                lblPositiveProb.Text = $"{percentPositive:F2}%";
                lblNegativeProb.Text = $"{percentNegative:F2}%";
            }
            else
            {
                MessageBox.Show("Chọn file để xem % đánh giá");
            }


        }
    }
}

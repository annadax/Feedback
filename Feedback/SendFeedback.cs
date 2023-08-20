using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Feedback
{
    public partial class frmSendFeedback : Form
    {
        FeedbackDataContext dbContext = new FeedbackDataContext();

        public frmSendFeedback()
        {
            InitializeComponent();

            Font vietnameseFont = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point, 0x01);
            cboClass.Font = vietnameseFont;
            cboSubject.Font = vietnameseFont;
            cboFaculty.Font = vietnameseFont;

            // Gán sự kiện Click cho combobox cboClass
            cboClass.Click += cboClass_Click;

            // Gán sự kiện DropDown cho combobox cboSubject
            cboSubject.Click += cboSubject_Click;

            // Gán sự kiện click cho button btnSen
            btnSend.Click += BtnSend_Click;

        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            string studentCode = txtCode.Text.Trim();
            string email = txtEmail.Text.Trim();
            string feedbackText = txtFeedback.Text.Trim();

            // Check if student with the provided studentCode and email exists
            var student = dbContext.Students.FirstOrDefault(s => s.StudentCode == studentCode && s.Email == email);

            if (student == null)
            {
                MessageBox.Show("Mã Sinh Viên và Email không trùng khớp !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if selected SubjectName and ClassName exist in their respective tables
            string selectedClassName = cboClass.SelectedItem?.ToString();

            var classExists = dbContext.Classes.Any(cls => cls.ClassName == selectedClassName);

            if (classExists)
            {
                MessageBox.Show(" Class.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get CourseRegister entry for the provided studentCode
            var courseRegisterEntry = dbContext.CourseRegisters.FirstOrDefault(cr => cr.StudentCode == studentCode);

            if (courseRegisterEntry == null)
            {
                MessageBox.Show("Sinh viên chưa đăng kí khóa học nào", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Generate a new FeedbackCode
            string newFeedbackCode = Guid.NewGuid().ToString("N").Substring(0, 12);

            // Create a new Feedback entry
            Feedback newFeedback = new Feedback
            {
                FeedbackCode = newFeedbackCode,
                StudentCode = studentCode,
                CourseCode = courseRegisterEntry.CourseCode,
                Text = feedbackText
            };

            // Add and submit changes to the database
            dbContext.Feedbacks.InsertOnSubmit(newFeedback);
            dbContext.SubmitChanges();

            // Clear input fields after sending feedback
            txtCode.Text = "";
            txtEmail.Text = "";
            txtFeedback.Text = "";
            cboFaculty.SelectedIndex = -1; // Clear selection
            cboClass.SelectedIndex = -1;
            cboSubject.SelectedIndex = -1;

            MessageBox.Show("Cảm ơn bạn đã gửi FeedBack", "Điểm cộng của bạn đã được ghi lại", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Xóa dữ liệu hiện tại của combobox cboSubject
            cboSubject.DataSource = null;
        }

    }
}

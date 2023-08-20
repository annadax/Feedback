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
    public partial class frmLectures : Form
    {
        FeedbackDataContext dbContext = new FeedbackDataContext();
        private int loginAttempts = 0;
        public frmLectures()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string lecturerCode = txtLecturerCode.Text.Trim();
            string secretCode = txtSecretCode.Text.Trim();

            // Kiểm tra thông tin đăng nhập trong bảng Lecturer
            Lecturer lecturer = dbContext.Lecturers
                .FirstOrDefault(l => l.LecturerCode == lecturerCode && l.SecretCode == secretCode);

            if (lecturer != null)
            {
                // Mở frmShowFeedback nếu thông tin đúng
                frmShowFeedback frmShowFeedback = new frmShowFeedback();
                frmShowFeedback.ShowDialog();
            }
            else
            {
                loginAttempts++;

                if (loginAttempts >= 3)
                {
                    MessageBox.Show("Đăng nhập không thành công. Số lần đăng nhập sai đã vượt quá giới hạn");
                    this.Close(); // Đóng frmLectures
                    frmHome frmHome = new frmHome();
                    frmHome.Show(); // Mở frmHome
                }
                else
                {
                    MessageBox.Show("Đăng nhập không thành công. Vui lòng kiểm tra lại thông tin đăng nhập.");
                    
                }
            }
        }
    }
}

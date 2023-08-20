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
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void btnLectures_Click(object sender, EventArgs e)
        {
            frmLectures frmLectures = new frmLectures();

            frmLectures.ShowDialog();
        }

        private void btnSendFeedback_Click_1(object sender, EventArgs e)
        {
            frmSendFeedback frmSendFeedback = new frmSendFeedback();

            frmSendFeedback.ShowDialog();
        }
    }
}

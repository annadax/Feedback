namespace Feedback
{
    partial class frmHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHome));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ptbSend = new System.Windows.Forms.PictureBox();
            this.btnSendFeedback = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLecturesOnly = new System.Windows.Forms.Button();
            this.ptbNenDuoi = new System.Windows.Forms.PictureBox();
            this.ptbHomeTren = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbNenDuoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbHomeTren)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 419);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ptbSend);
            this.splitContainer1.Panel1.Controls.Add(this.btnSendFeedback);
            this.splitContainer1.Panel1.ForeColor = System.Drawing.Color.White;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel2.Controls.Add(this.btnLecturesOnly);
            this.splitContainer1.Panel2.ForeColor = System.Drawing.Color.White;
            this.splitContainer1.Size = new System.Drawing.Size(1090, 171);
            this.splitContainer1.SplitterDistance = 560;
            this.splitContainer1.TabIndex = 3;
            // 
            // ptbSend
            // 
            this.ptbSend.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ptbSend.Image = ((System.Drawing.Image)(resources.GetObject("ptbSend.Image")));
            this.ptbSend.Location = new System.Drawing.Point(352, 50);
            this.ptbSend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ptbSend.Name = "ptbSend";
            this.ptbSend.Size = new System.Drawing.Size(36, 35);
            this.ptbSend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbSend.TabIndex = 4;
            this.ptbSend.TabStop = false;
            // 
            // btnSendFeedback
            // 
            this.btnSendFeedback.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSendFeedback.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSendFeedback.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendFeedback.Location = new System.Drawing.Point(161, 50);
            this.btnSendFeedback.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSendFeedback.Name = "btnSendFeedback";
            this.btnSendFeedback.Size = new System.Drawing.Size(215, 64);
            this.btnSendFeedback.TabIndex = 2;
            this.btnSendFeedback.Text = "Send Feedback";
            this.btnSendFeedback.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSendFeedback.UseVisualStyleBackColor = false;
            this.btnSendFeedback.Click += new System.EventHandler(this.btnSendFeedback_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(344, 50);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // btnLecturesOnly
            // 
            this.btnLecturesOnly.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLecturesOnly.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLecturesOnly.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLecturesOnly.Location = new System.Drawing.Point(152, 50);
            this.btnLecturesOnly.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLecturesOnly.Name = "btnLecturesOnly";
            this.btnLecturesOnly.Size = new System.Drawing.Size(215, 64);
            this.btnLecturesOnly.TabIndex = 10;
            this.btnLecturesOnly.Text = "Lecturers Only";
            this.btnLecturesOnly.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLecturesOnly.UseVisualStyleBackColor = false;
            this.btnLecturesOnly.Click += new System.EventHandler(this.btnLectures_Click);
            // 
            // ptbNenDuoi
            // 
            this.ptbNenDuoi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ptbNenDuoi.Image = ((System.Drawing.Image)(resources.GetObject("ptbNenDuoi.Image")));
            this.ptbNenDuoi.Location = new System.Drawing.Point(0, 590);
            this.ptbNenDuoi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ptbNenDuoi.Name = "ptbNenDuoi";
            this.ptbNenDuoi.Size = new System.Drawing.Size(1090, 69);
            this.ptbNenDuoi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbNenDuoi.TabIndex = 2;
            this.ptbNenDuoi.TabStop = false;
            // 
            // ptbHomeTren
            // 
            this.ptbHomeTren.Dock = System.Windows.Forms.DockStyle.Top;
            this.ptbHomeTren.Image = ((System.Drawing.Image)(resources.GetObject("ptbHomeTren.Image")));
            this.ptbHomeTren.Location = new System.Drawing.Point(0, 0);
            this.ptbHomeTren.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ptbHomeTren.Name = "ptbHomeTren";
            this.ptbHomeTren.Size = new System.Drawing.Size(1090, 419);
            this.ptbHomeTren.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbHomeTren.TabIndex = 1;
            this.ptbHomeTren.TabStop = false;
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 659);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.ptbNenDuoi);
            this.Controls.Add(this.ptbHomeTren);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHorm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbNenDuoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbHomeTren)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbHomeTren;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnSendFeedback;
        private System.Windows.Forms.PictureBox ptbSend;
        private System.Windows.Forms.PictureBox ptbNenDuoi;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLecturesOnly;
    }
}


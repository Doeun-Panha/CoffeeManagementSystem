namespace CoffeeManagementSystem
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlBanner = new System.Windows.Forms.Panel();
            this.pnlBannerTitle = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.btnLogo = new System.Windows.Forms.Button();
            this.picBanner = new System.Windows.Forms.PictureBox();
            this.pnlNavigations = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.pnlBanner.SuspendLayout();
            this.pnlBannerTitle.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).BeginInit();
            this.pnlForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBanner
            // 
            this.pnlBanner.Controls.Add(this.pnlBannerTitle);
            this.pnlBanner.Controls.Add(this.pnlLogo);
            this.pnlBanner.Controls.Add(this.picBanner);
            this.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBanner.Location = new System.Drawing.Point(0, 0);
            this.pnlBanner.Name = "pnlBanner";
            this.pnlBanner.Size = new System.Drawing.Size(1902, 100);
            this.pnlBanner.TabIndex = 4;
            // 
            // pnlBannerTitle
            // 
            this.pnlBannerTitle.BackColor = System.Drawing.Color.Wheat;
            this.pnlBannerTitle.Controls.Add(this.labelTitle);
            this.pnlBannerTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBannerTitle.Location = new System.Drawing.Point(200, 0);
            this.pnlBannerTitle.Name = "pnlBannerTitle";
            this.pnlBannerTitle.Size = new System.Drawing.Size(1702, 100);
            this.pnlBannerTitle.TabIndex = 3;
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(745, 25);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(104, 46);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "Sales";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLogo
            // 
            this.pnlLogo.Controls.Add(this.btnLogo);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(200, 100);
            this.pnlLogo.TabIndex = 1;
            // 
            // btnLogo
            // 
            this.btnLogo.BackColor = System.Drawing.Color.Wheat;
            this.btnLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogo.FlatAppearance.BorderSize = 0;
            this.btnLogo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Wheat;
            this.btnLogo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Wheat;
            this.btnLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogo.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogo.Image = global::CoffeeManagementSystem.Properties.Resources.AcquireLogo;
            this.btnLogo.Location = new System.Drawing.Point(0, 0);
            this.btnLogo.Name = "btnLogo";
            this.btnLogo.Size = new System.Drawing.Size(200, 100);
            this.btnLogo.TabIndex = 2;
            this.btnLogo.Text = "Coffee";
            this.btnLogo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogo.UseVisualStyleBackColor = false;
            // 
            // picBanner
            // 
            this.picBanner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBanner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBanner.Location = new System.Drawing.Point(0, 0);
            this.picBanner.Name = "picBanner";
            this.picBanner.Size = new System.Drawing.Size(1902, 100);
            this.picBanner.TabIndex = 0;
            this.picBanner.TabStop = false;
            // 
            // pnlNavigations
            // 
            this.pnlNavigations.BackColor = System.Drawing.SystemColors.Control;
            this.pnlNavigations.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNavigations.Location = new System.Drawing.Point(0, 100);
            this.pnlNavigations.Name = "pnlNavigations";
            this.pnlNavigations.Size = new System.Drawing.Size(200, 933);
            this.pnlNavigations.TabIndex = 5;
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(200, 100);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1702, 933);
            this.pnlMain.TabIndex = 6;
            // 
            // pnlForm
            // 
            this.pnlForm.Controls.Add(this.pnlMain);
            this.pnlForm.Controls.Add(this.pnlNavigations);
            this.pnlForm.Controls.Add(this.pnlBanner);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(1902, 1033);
            this.pnlForm.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.pnlForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlBanner.ResumeLayout(false);
            this.pnlBannerTitle.ResumeLayout(false);
            this.pnlBannerTitle.PerformLayout();
            this.pnlLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).EndInit();
            this.pnlForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlBanner;
        private System.Windows.Forms.PictureBox picBanner;
        private System.Windows.Forms.Panel pnlNavigations;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Button btnLogo;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel pnlBannerTitle;
    }
}


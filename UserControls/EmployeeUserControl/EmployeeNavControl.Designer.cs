namespace CoffeeManagementSystem.UserControls.EmployeeUserControls
{
    partial class EmployeeNavControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeNavControl));
            this.tPnlNavBot = new System.Windows.Forms.TableLayoutPanel();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.tPnlNavTop = new System.Windows.Forms.TableLayoutPanel();
            this.btnPOS = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.tPnlNavBot.SuspendLayout();
            this.tPnlNavTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tPnlNavBot
            // 
            this.tPnlNavBot.ColumnCount = 1;
            this.tPnlNavBot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tPnlNavBot.Controls.Add(this.btnLogOut, 0, 0);
            this.tPnlNavBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tPnlNavBot.Location = new System.Drawing.Point(5, 878);
            this.tPnlNavBot.Name = "tPnlNavBot";
            this.tPnlNavBot.RowCount = 1;
            this.tPnlNavBot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tPnlNavBot.Size = new System.Drawing.Size(190, 50);
            this.tPnlNavBot.TabIndex = 6;
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.LightGray;
            this.btnLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogOut.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Image = ((System.Drawing.Image)(resources.GetObject("btnLogOut.Image")));
            this.btnLogOut.Location = new System.Drawing.Point(3, 3);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(184, 44);
            this.btnLogOut.TabIndex = 3;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogOut.UseVisualStyleBackColor = false;
            // 
            // tPnlNavTop
            // 
            this.tPnlNavTop.ColumnCount = 1;
            this.tPnlNavTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tPnlNavTop.Controls.Add(this.btnReport, 0, 0);
            this.tPnlNavTop.Controls.Add(this.btnInventory, 0, 2);
            this.tPnlNavTop.Controls.Add(this.btnPOS, 0, 1);
            this.tPnlNavTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.tPnlNavTop.Location = new System.Drawing.Point(5, 5);
            this.tPnlNavTop.Name = "tPnlNavTop";
            this.tPnlNavTop.RowCount = 5;
            this.tPnlNavTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tPnlNavTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tPnlNavTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tPnlNavTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tPnlNavTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tPnlNavTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tPnlNavTop.Size = new System.Drawing.Size(190, 417);
            this.tPnlNavTop.TabIndex = 6;
            // 
            // btnPOS
            // 
            this.btnPOS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPOS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPOS.FlatAppearance.BorderSize = 0;
            this.btnPOS.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPOS.Image = ((System.Drawing.Image)(resources.GetObject("btnPOS.Image")));
            this.btnPOS.Location = new System.Drawing.Point(3, 86);
            this.btnPOS.Name = "btnPOS";
            this.btnPOS.Size = new System.Drawing.Size(184, 77);
            this.btnPOS.TabIndex = 2;
            this.btnPOS.Text = "POS";
            this.btnPOS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPOS.UseVisualStyleBackColor = true;
            // 
            // btnInventory
            // 
            this.btnInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInventory.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventory.Image = global::CoffeeManagementSystem.Properties.Resources.ProductsIcon;
            this.btnInventory.Location = new System.Drawing.Point(3, 169);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(184, 77);
            this.btnInventory.TabIndex = 0;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInventory.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            this.btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReport.FlatAppearance.BorderSize = 0;
            this.btnReport.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.Location = new System.Drawing.Point(3, 3);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(184, 77);
            this.btnReport.TabIndex = 3;
            this.btnReport.Text = "Report";
            this.btnReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReport.UseVisualStyleBackColor = true;
            // 
            // EmployeeNavControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tPnlNavTop);
            this.Controls.Add(this.tPnlNavBot);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "EmployeeNavControl";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(200, 933);
            this.tPnlNavBot.ResumeLayout(false);
            this.tPnlNavTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tPnlNavBot;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.TableLayoutPanel tPnlNavTop;
        private System.Windows.Forms.Button btnPOS;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnReport;
    }
}

using System.Drawing;
using System.Windows.Forms;

namespace CoffeeManagementSystem.Forms
{
    partial class OrderConfirmationForm
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
            this.pnlForm = new System.Windows.Forms.Panel();
            this.pnlDgvOrder = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbTotal = new System.Windows.Forms.Label();
            this.lbTotalNumber = new System.Windows.Forms.Label();
            this.lbCashReceived = new System.Windows.Forms.Label();
            this.tbCashReceived = new System.Windows.Forms.TextBox();
            this.lbChangesNumber = new System.Windows.Forms.Label();
            this.lbChanges = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lbDate = new System.Windows.Forms.Label();
            this.lbOrder = new System.Windows.Forms.Label();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.pnlForm.SuspendLayout();
            this.pnlDgvOrder.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlForm
            // 
            this.pnlForm.Controls.Add(this.pnlDgvOrder);
            this.pnlForm.Controls.Add(this.pnlFooter);
            this.pnlForm.Controls.Add(this.pnlHeader);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(658, 689);
            this.pnlForm.TabIndex = 0;
            // 
            // pnlDgvOrder
            // 
            this.pnlDgvOrder.Controls.Add(this.dgvOrders);
            this.pnlDgvOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDgvOrder.Location = new System.Drawing.Point(0, 44);
            this.pnlDgvOrder.Name = "pnlDgvOrder";
            this.pnlDgvOrder.Padding = new System.Windows.Forms.Padding(17, 0, 17, 0);
            this.pnlDgvOrder.Size = new System.Drawing.Size(658, 479);
            this.pnlDgvOrder.TabIndex = 14;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.tableLayoutPanel1);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 523);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(658, 166);
            this.pnlFooter.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lbTotal, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbTotalNumber, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbCashReceived, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbCashReceived, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbChangesNumber, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbChanges, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnSubmit, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(658, 166);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // lbTotal
            // 
            this.lbTotal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbTotal.AutoSize = true;
            this.lbTotal.BackColor = System.Drawing.Color.Transparent;
            this.lbTotal.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Location = new System.Drawing.Point(13, 4);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(64, 26);
            this.lbTotal.TabIndex = 0;
            this.lbTotal.Text = "Total:";
            // 
            // lbTotalNumber
            // 
            this.lbTotalNumber.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbTotalNumber.AutoSize = true;
            this.lbTotalNumber.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalNumber.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalNumber.Location = new System.Drawing.Point(550, 4);
            this.lbTotalNumber.Name = "lbTotalNumber";
            this.lbTotalNumber.Size = new System.Drawing.Size(95, 26);
            this.lbTotalNumber.TabIndex = 0;
            this.lbTotalNumber.Text = "$0000.00";
            this.lbTotalNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbCashReceived
            // 
            this.lbCashReceived.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbCashReceived.AutoSize = true;
            this.lbCashReceived.BackColor = System.Drawing.Color.Transparent;
            this.lbCashReceived.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCashReceived.Location = new System.Drawing.Point(13, 39);
            this.lbCashReceived.Name = "lbCashReceived";
            this.lbCashReceived.Size = new System.Drawing.Size(155, 26);
            this.lbCashReceived.TabIndex = 0;
            this.lbCashReceived.Text = "Cash Received:";
            // 
            // tbCashReceived
            // 
            this.tbCashReceived.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tbCashReceived.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCashReceived.Location = new System.Drawing.Point(515, 38);
            this.tbCashReceived.Name = "tbCashReceived";
            this.tbCashReceived.Size = new System.Drawing.Size(130, 34);
            this.tbCashReceived.TabIndex = 1;
            this.tbCashReceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbChangesNumber
            // 
            this.lbChangesNumber.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbChangesNumber.AutoSize = true;
            this.lbChangesNumber.BackColor = System.Drawing.Color.Transparent;
            this.lbChangesNumber.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChangesNumber.Location = new System.Drawing.Point(550, 74);
            this.lbChangesNumber.Name = "lbChangesNumber";
            this.lbChangesNumber.Size = new System.Drawing.Size(95, 26);
            this.lbChangesNumber.TabIndex = 0;
            this.lbChangesNumber.Text = "$0000.00";
            this.lbChangesNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbChanges
            // 
            this.lbChanges.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbChanges.AutoSize = true;
            this.lbChanges.BackColor = System.Drawing.Color.Transparent;
            this.lbChanges.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChanges.Location = new System.Drawing.Point(13, 74);
            this.lbChanges.Name = "lbChanges";
            this.lbChanges.Size = new System.Drawing.Size(97, 26);
            this.lbChanges.TabIndex = 0;
            this.lbChanges.Text = "Changes:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.BackColor = System.Drawing.Color.Salmon;
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(13, 108);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 45);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSubmit.BackColor = System.Drawing.Color.YellowGreen;
            this.btnSubmit.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(515, 108);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(130, 45);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lbDate);
            this.pnlHeader.Controls.Add(this.lbOrder);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(658, 44);
            this.pnlHeader.TabIndex = 13;
            // 
            // lbDate
            // 
            this.lbDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbDate.AutoSize = true;
            this.lbDate.BackColor = System.Drawing.Color.Transparent;
            this.lbDate.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDate.Location = new System.Drawing.Point(405, 9);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(236, 26);
            this.lbDate.TabIndex = 0;
            this.lbDate.Text = "dd/MM/yyyy h:mm:ss tt";
            this.lbDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbOrder
            // 
            this.lbOrder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbOrder.AutoSize = true;
            this.lbOrder.BackColor = System.Drawing.Color.Transparent;
            this.lbOrder.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOrder.Location = new System.Drawing.Point(12, 9);
            this.lbOrder.Name = "lbOrder";
            this.lbOrder.Size = new System.Drawing.Size(85, 26);
            this.lbOrder.TabIndex = 1;
            this.lbOrder.Text = "Order #";
            // 
            // dgvOrders
            // 
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.Location = new System.Drawing.Point(17, 0);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowHeadersWidth = 51;
            this.dgvOrders.RowTemplate.Height = 24;
            this.dgvOrders.Size = new System.Drawing.Size(624, 479);
            this.dgvOrders.TabIndex = 26;
            // 
            // OrderConfirmationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 689);
            this.Controls.Add(this.pnlForm);
            this.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "OrderConfirmationForm";
            this.Text = "Order Confirmation Form";
            this.pnlForm.ResumeLayout(false);
            this.pnlDgvOrder.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlForm;
        private Label lbOrder;
        private Label lbTotal;
        private Label lbCashReceived;
        private Label lbChanges;
        private Button btnSubmit;
        private Button btnCancel;
        private TextBox tbCashReceived;
        private Label lbDate;
        private Label lbTotalNumber;
        private Label lbChangesNumber;
        private Panel pnlHeader;
        private Panel pnlFooter;
        private Panel pnlDgvOrder;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dgvOrders;
    }
}
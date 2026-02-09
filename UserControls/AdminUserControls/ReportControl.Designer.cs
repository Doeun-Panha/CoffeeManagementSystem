using System.Drawing;
using System.Windows.Forms;

namespace CoffeeManagementSystem
{
    partial class ReportControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tPnlActions = new System.Windows.Forms.TableLayoutPanel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlRightBot = new System.Windows.Forms.Panel();
            this.lbSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbEmployee = new System.Windows.Forms.ComboBox();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.lbTo = new System.Windows.Forms.Label();
            this.lbFrom = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dataGridReport = new System.Windows.Forms.DataGridView();
            this.pnlDataGridView = new System.Windows.Forms.Panel();
            this.dataGridReportDetail = new System.Windows.Forms.DataGridView();
            this.pnlOverviews = new System.Windows.Forms.Panel();
            this.tblOverviews = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbTotalSalesNumber = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlTotalRevenues = new System.Windows.Forms.Panel();
            this.lbTotalRevenuesNumber = new System.Windows.Forms.Label();
            this.lbTotalRevenues = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tPnlActions.SuspendLayout();
            this.pnlRightBot.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReport)).BeginInit();
            this.pnlDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReportDetail)).BeginInit();
            this.pnlOverviews.SuspendLayout();
            this.tblOverviews.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlTotalRevenues.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tPnlActions
            // 
            this.tPnlActions.BackColor = System.Drawing.SystemColors.Control;
            this.tPnlActions.ColumnCount = 1;
            this.tPnlActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tPnlActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tPnlActions.Controls.Add(this.btnExport, 0, 0);
            this.tPnlActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tPnlActions.Location = new System.Drawing.Point(0, 0);
            this.tPnlActions.Name = "tPnlActions";
            this.tPnlActions.RowCount = 1;
            this.tPnlActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tPnlActions.Size = new System.Drawing.Size(200, 73);
            this.tPnlActions.TabIndex = 23;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.YellowGreen;
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(3, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(194, 67);
            this.btnExport.TabIndex = 25;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(1369, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 38);
            this.btnRefresh.TabIndex = 23;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // pnlRightBot
            // 
            this.pnlRightBot.Controls.Add(this.tPnlActions);
            this.pnlRightBot.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRightBot.Location = new System.Drawing.Point(1500, 0);
            this.pnlRightBot.Name = "pnlRightBot";
            this.pnlRightBot.Size = new System.Drawing.Size(200, 73);
            this.pnlRightBot.TabIndex = 24;
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSearch.Location = new System.Drawing.Point(15, 23);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(81, 26);
            this.lbSearch.TabIndex = 16;
            this.lbSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(102, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(248, 34);
            this.txtSearch.TabIndex = 15;
            // 
            // pnlSearch
            // 
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.panel1);
            this.pnlSearch.Controls.Add(this.pnlRightBot);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1702, 75);
            this.pnlSearch.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbEmployee);
            this.panel1.Controls.Add(this.dateTimePickerTo);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.lbTo);
            this.panel1.Controls.Add(this.lbFrom);
            this.panel1.Controls.Add(this.dateTimePickerFrom);
            this.panel1.Controls.Add(this.lbSearch);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1550, 73);
            this.panel1.TabIndex = 25;
            // 
            // cbEmployee
            // 
            this.cbEmployee.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEmployee.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbEmployee.FormattingEnabled = true;
            this.cbEmployee.Location = new System.Drawing.Point(1194, 20);
            this.cbEmployee.Name = "cbEmployee";
            this.cbEmployee.Size = new System.Drawing.Size(160, 34);
            this.cbEmployee.TabIndex = 31;
            this.cbEmployee.Text = "Employee";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.CalendarFont = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTo.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTo.Location = new System.Drawing.Point(831, 19);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(346, 34);
            this.dateTimePickerTo.TabIndex = 30;
            // 
            // lbTo
            // 
            this.lbTo.AutoSize = true;
            this.lbTo.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTo.Location = new System.Drawing.Point(783, 23);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(42, 26);
            this.lbTo.TabIndex = 29;
            this.lbTo.Text = "To:";
            // 
            // lbFrom
            // 
            this.lbFrom.AutoSize = true;
            this.lbFrom.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFrom.Location = new System.Drawing.Point(356, 23);
            this.lbFrom.Name = "lbFrom";
            this.lbFrom.Size = new System.Drawing.Size(69, 26);
            this.lbFrom.TabIndex = 27;
            this.lbFrom.Text = "From:";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.CalendarFont = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFrom.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFrom.Location = new System.Drawing.Point(431, 19);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(346, 34);
            this.dateTimePickerFrom.TabIndex = 26;
            // 
            // dataGridReport
            // 
            this.dataGridReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridReport.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridReport.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridReport.Location = new System.Drawing.Point(0, 80);
            this.dataGridReport.Name = "dataGridReport";
            this.dataGridReport.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridReport.RowHeadersWidth = 51;
            this.dataGridReport.RowTemplate.Height = 24;
            this.dataGridReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridReport.Size = new System.Drawing.Size(1702, 389);
            this.dataGridReport.TabIndex = 5;
            // 
            // pnlDataGridView
            // 
            this.pnlDataGridView.Controls.Add(this.dataGridReport);
            this.pnlDataGridView.Controls.Add(this.dataGridReportDetail);
            this.pnlDataGridView.Controls.Add(this.pnlOverviews);
            this.pnlDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataGridView.Location = new System.Drawing.Point(0, 75);
            this.pnlDataGridView.Name = "pnlDataGridView";
            this.pnlDataGridView.Size = new System.Drawing.Size(1702, 858);
            this.pnlDataGridView.TabIndex = 7;
            // 
            // dataGridReportDetail
            // 
            this.dataGridReportDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridReportDetail.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridReportDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridReportDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridReportDetail.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridReportDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridReportDetail.Location = new System.Drawing.Point(0, 469);
            this.dataGridReportDetail.Name = "dataGridReportDetail";
            this.dataGridReportDetail.ReadOnly = true;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridReportDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridReportDetail.RowHeadersWidth = 51;
            this.dataGridReportDetail.RowTemplate.Height = 24;
            this.dataGridReportDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridReportDetail.Size = new System.Drawing.Size(1702, 389);
            this.dataGridReportDetail.TabIndex = 7;
            // 
            // pnlOverviews
            // 
            this.pnlOverviews.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOverviews.Controls.Add(this.tblOverviews);
            this.pnlOverviews.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOverviews.Location = new System.Drawing.Point(0, 0);
            this.pnlOverviews.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlOverviews.Name = "pnlOverviews";
            this.pnlOverviews.Size = new System.Drawing.Size(1702, 80);
            this.pnlOverviews.TabIndex = 6;
            // 
            // tblOverviews
            // 
            this.tblOverviews.ColumnCount = 5;
            this.tblOverviews.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblOverviews.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblOverviews.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblOverviews.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblOverviews.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblOverviews.Controls.Add(this.panel3, 1, 0);
            this.tblOverviews.Controls.Add(this.pnlTotalRevenues, 0, 0);
            this.tblOverviews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblOverviews.Location = new System.Drawing.Point(0, 0);
            this.tblOverviews.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tblOverviews.Name = "tblOverviews";
            this.tblOverviews.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.tblOverviews.RowCount = 1;
            this.tblOverviews.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblOverviews.Size = new System.Drawing.Size(1700, 78);
            this.tblOverviews.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lbTotalSalesNumber);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(349, 10);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(330, 58);
            this.panel3.TabIndex = 1;
            // 
            // lbTotalSalesNumber
            // 
            this.lbTotalSalesNumber.AutoSize = true;
            this.lbTotalSalesNumber.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalSalesNumber.Location = new System.Drawing.Point(292, 18);
            this.lbTotalSalesNumber.Name = "lbTotalSalesNumber";
            this.lbTotalSalesNumber.Size = new System.Drawing.Size(23, 26);
            this.lbTotalSalesNumber.TabIndex = 32;
            this.lbTotalSalesNumber.Text = "0";
            this.lbTotalSalesNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 26);
            this.label2.TabIndex = 31;
            this.label2.Text = "Total Sales:";
            // 
            // pnlTotalRevenues
            // 
            this.pnlTotalRevenues.BackColor = System.Drawing.Color.Transparent;
            this.pnlTotalRevenues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTotalRevenues.Controls.Add(this.lbTotalRevenuesNumber);
            this.pnlTotalRevenues.Controls.Add(this.lbTotalRevenues);
            this.pnlTotalRevenues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTotalRevenues.Location = new System.Drawing.Point(13, 10);
            this.pnlTotalRevenues.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlTotalRevenues.Name = "pnlTotalRevenues";
            this.pnlTotalRevenues.Size = new System.Drawing.Size(330, 58);
            this.pnlTotalRevenues.TabIndex = 0;
            // 
            // lbTotalRevenuesNumber
            // 
            this.lbTotalRevenuesNumber.AutoSize = true;
            this.lbTotalRevenuesNumber.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalRevenuesNumber.Location = new System.Drawing.Point(230, 18);
            this.lbTotalRevenuesNumber.Name = "lbTotalRevenuesNumber";
            this.lbTotalRevenuesNumber.Size = new System.Drawing.Size(95, 26);
            this.lbTotalRevenuesNumber.TabIndex = 32;
            this.lbTotalRevenuesNumber.Text = "$0000.00";
            this.lbTotalRevenuesNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbTotalRevenues
            // 
            this.lbTotalRevenues.AutoSize = true;
            this.lbTotalRevenues.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalRevenues.Location = new System.Drawing.Point(3, 18);
            this.lbTotalRevenues.Name = "lbTotalRevenues";
            this.lbTotalRevenues.Size = new System.Drawing.Size(160, 26);
            this.lbTotalRevenues.TabIndex = 31;
            this.lbTotalRevenues.Text = "Total Revenues:";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlDataGridView);
            this.pnlMain.Controls.Add(this.pnlSearch);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1702, 933);
            this.pnlMain.TabIndex = 7;
            // 
            // ReportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "ReportControl";
            this.Size = new System.Drawing.Size(1702, 933);
            this.tPnlActions.ResumeLayout(false);
            this.pnlRightBot.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReport)).EndInit();
            this.pnlDataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReportDetail)).EndInit();
            this.pnlOverviews.ResumeLayout(false);
            this.tblOverviews.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlTotalRevenues.ResumeLayout(false);
            this.pnlTotalRevenues.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tPnlActions;
        private System.Windows.Forms.Panel pnlRightBot;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.DataGridView dataGridReport;
        private System.Windows.Forms.Panel pnlDataGridView;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label lbFrom;
        private System.Windows.Forms.Label lbTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private Button btnExport;
        private Panel pnlOverviews;
        private TableLayoutPanel tblOverviews;
        private Panel pnlTotalRevenues;
        private Label lbTotalRevenuesNumber;
        private Label lbTotalRevenues;
        private Panel panel3;
        private Label lbTotalSalesNumber;
        private Label label2;
        private DataGridView dataGridReportDetail;
        private ComboBox cbEmployee;
    }
}

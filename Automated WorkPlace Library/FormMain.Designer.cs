namespace Automated_WorkPlace_Library
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.DatabaseData = new System.Windows.Forms.TabControl();
            this.TP_Books = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DGV_Books = new System.Windows.Forms.DataGridView();
            this.DGV_Kinds = new System.Windows.Forms.DataGridView();
            this.TP_Authors = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.DGV_Book_Authors = new System.Windows.Forms.DataGridView();
            this.DGV_Authors = new System.Windows.Forms.DataGridView();
            this.TP_Reader = new System.Windows.Forms.TabPage();
            this.DGV_Reader = new System.Windows.Forms.DataGridView();
            this.TP_Book_issue = new System.Windows.Forms.TabPage();
            this.DGV_BIssue = new System.Windows.Forms.DataGridView();
            this.TP_Booking = new System.Windows.Forms.TabPage();
            this.DGV_Booking = new System.Windows.Forms.DataGridView();
            this.TP_Address = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.DGV_City = new System.Windows.Forms.DataGridView();
            this.DGV_Street = new System.Windows.Forms.DataGridView();
            this.TP_Publishers = new System.Windows.Forms.TabPage();
            this.DGV_Publisher = new System.Windows.Forms.DataGridView();
            this.TP_Users = new System.Windows.Forms.TabPage();
            this.DGV_Users = new System.Windows.Forms.DataGridView();
            this.DB_DataSet = new System.Data.DataSet();
            this.DatabaseData.SuspendLayout();
            this.TP_Books.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Books)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Kinds)).BeginInit();
            this.TP_Authors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Book_Authors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Authors)).BeginInit();
            this.TP_Reader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Reader)).BeginInit();
            this.TP_Book_issue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_BIssue)).BeginInit();
            this.TP_Booking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Booking)).BeginInit();
            this.TP_Address.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_City)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Street)).BeginInit();
            this.TP_Publishers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Publisher)).BeginInit();
            this.TP_Users.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Users)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DB_DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // DatabaseData
            // 
            this.DatabaseData.Controls.Add(this.TP_Books);
            this.DatabaseData.Controls.Add(this.TP_Authors);
            this.DatabaseData.Controls.Add(this.TP_Reader);
            this.DatabaseData.Controls.Add(this.TP_Book_issue);
            this.DatabaseData.Controls.Add(this.TP_Booking);
            this.DatabaseData.Controls.Add(this.TP_Address);
            this.DatabaseData.Controls.Add(this.TP_Publishers);
            this.DatabaseData.Controls.Add(this.TP_Users);
            this.DatabaseData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatabaseData.Location = new System.Drawing.Point(0, 0);
            this.DatabaseData.Name = "DatabaseData";
            this.DatabaseData.SelectedIndex = 0;
            this.DatabaseData.Size = new System.Drawing.Size(586, 326);
            this.DatabaseData.TabIndex = 0;
            // 
            // TP_Books
            // 
            this.TP_Books.Controls.Add(this.splitContainer1);
            this.TP_Books.Location = new System.Drawing.Point(4, 22);
            this.TP_Books.Name = "TP_Books";
            this.TP_Books.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Books.Size = new System.Drawing.Size(578, 300);
            this.TP_Books.TabIndex = 0;
            this.TP_Books.Text = "Книги";
            this.TP_Books.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DGV_Books);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DGV_Kinds);
            this.splitContainer1.Size = new System.Drawing.Size(572, 294);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 1;
            // 
            // DGV_Books
            // 
            this.DGV_Books.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Books.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Books.Location = new System.Drawing.Point(0, 0);
            this.DGV_Books.Name = "DGV_Books";
            this.DGV_Books.Size = new System.Drawing.Size(400, 294);
            this.DGV_Books.TabIndex = 1;
            this.DGV_Books.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Books_CellValueChanged);
            this.DGV_Books.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DGV_Books_DataError);
            this.DGV_Books.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DGV_Books_UserDeletingRow);
            // 
            // DGV_Kinds
            // 
            this.DGV_Kinds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Kinds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Kinds.Location = new System.Drawing.Point(0, 0);
            this.DGV_Kinds.Name = "DGV_Kinds";
            this.DGV_Kinds.Size = new System.Drawing.Size(168, 294);
            this.DGV_Kinds.TabIndex = 0;
            this.DGV_Kinds.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Kinds_CellValueChanged);
            this.DGV_Kinds.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DGV_Kinds_DataError);
            this.DGV_Kinds.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DGV_Kinds_UserDeletingRow);
            // 
            // TP_Authors
            // 
            this.TP_Authors.Controls.Add(this.splitContainer2);
            this.TP_Authors.Location = new System.Drawing.Point(4, 22);
            this.TP_Authors.Name = "TP_Authors";
            this.TP_Authors.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Authors.Size = new System.Drawing.Size(578, 300);
            this.TP_Authors.TabIndex = 1;
            this.TP_Authors.Text = "Авторы";
            this.TP_Authors.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.DGV_Book_Authors);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.DGV_Authors);
            this.splitContainer2.Size = new System.Drawing.Size(572, 294);
            this.splitContainer2.SplitterDistance = 400;
            this.splitContainer2.TabIndex = 0;
            // 
            // DGV_Book_Authors
            // 
            this.DGV_Book_Authors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Book_Authors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Book_Authors.Location = new System.Drawing.Point(0, 0);
            this.DGV_Book_Authors.Name = "DGV_Book_Authors";
            this.DGV_Book_Authors.Size = new System.Drawing.Size(400, 294);
            this.DGV_Book_Authors.TabIndex = 1;
            this.DGV_Book_Authors.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Book_Authors_CellValueChanged);
            this.DGV_Book_Authors.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DGV_Book_Authors_UserDeletingRow);
            // 
            // DGV_Authors
            // 
            this.DGV_Authors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Authors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Authors.Location = new System.Drawing.Point(0, 0);
            this.DGV_Authors.Name = "DGV_Authors";
            this.DGV_Authors.Size = new System.Drawing.Size(168, 294);
            this.DGV_Authors.TabIndex = 1;
            this.DGV_Authors.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Authors_CellValueChanged);
            this.DGV_Authors.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DGV_Authors_UserDeletingRow);
            // 
            // TP_Reader
            // 
            this.TP_Reader.Controls.Add(this.DGV_Reader);
            this.TP_Reader.Location = new System.Drawing.Point(4, 22);
            this.TP_Reader.Name = "TP_Reader";
            this.TP_Reader.Size = new System.Drawing.Size(578, 300);
            this.TP_Reader.TabIndex = 2;
            this.TP_Reader.Text = "Читатели";
            this.TP_Reader.UseVisualStyleBackColor = true;
            // 
            // DGV_Reader
            // 
            this.DGV_Reader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Reader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Reader.Location = new System.Drawing.Point(0, 0);
            this.DGV_Reader.Name = "DGV_Reader";
            this.DGV_Reader.Size = new System.Drawing.Size(578, 300);
            this.DGV_Reader.TabIndex = 0;
            this.DGV_Reader.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Reader_CellValueChanged);
            this.DGV_Reader.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DGV_Reader_DataError);
            this.DGV_Reader.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DGV_Reader_UserDeletingRow);
            // 
            // TP_Book_issue
            // 
            this.TP_Book_issue.Controls.Add(this.DGV_BIssue);
            this.TP_Book_issue.Location = new System.Drawing.Point(4, 22);
            this.TP_Book_issue.Name = "TP_Book_issue";
            this.TP_Book_issue.Size = new System.Drawing.Size(578, 300);
            this.TP_Book_issue.TabIndex = 4;
            this.TP_Book_issue.Text = "Выдача книги";
            this.TP_Book_issue.UseVisualStyleBackColor = true;
            // 
            // DGV_BIssue
            // 
            this.DGV_BIssue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_BIssue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_BIssue.Location = new System.Drawing.Point(0, 0);
            this.DGV_BIssue.Name = "DGV_BIssue";
            this.DGV_BIssue.Size = new System.Drawing.Size(578, 300);
            this.DGV_BIssue.TabIndex = 0;
            this.DGV_BIssue.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_BIssue_CellValueChanged);
            this.DGV_BIssue.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DGV_BIssue_DataError);
            this.DGV_BIssue.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DGV_BIssue_UserDeletingRow);
            // 
            // TP_Booking
            // 
            this.TP_Booking.Controls.Add(this.DGV_Booking);
            this.TP_Booking.Location = new System.Drawing.Point(4, 22);
            this.TP_Booking.Name = "TP_Booking";
            this.TP_Booking.Size = new System.Drawing.Size(578, 300);
            this.TP_Booking.TabIndex = 3;
            this.TP_Booking.Text = "Бронирование";
            this.TP_Booking.UseVisualStyleBackColor = true;
            // 
            // DGV_Booking
            // 
            this.DGV_Booking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Booking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Booking.Location = new System.Drawing.Point(0, 0);
            this.DGV_Booking.Name = "DGV_Booking";
            this.DGV_Booking.Size = new System.Drawing.Size(578, 300);
            this.DGV_Booking.TabIndex = 0;
            this.DGV_Booking.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Booking_CellValueChanged);
            this.DGV_Booking.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DGV_Booking_DataError);
            this.DGV_Booking.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DGV_Booking_UserDeletingRow);
            // 
            // TP_Address
            // 
            this.TP_Address.Controls.Add(this.splitContainer3);
            this.TP_Address.Location = new System.Drawing.Point(4, 22);
            this.TP_Address.Name = "TP_Address";
            this.TP_Address.Size = new System.Drawing.Size(578, 300);
            this.TP_Address.TabIndex = 5;
            this.TP_Address.Text = "Города и улицы";
            this.TP_Address.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.DGV_City);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.DGV_Street);
            this.splitContainer3.Size = new System.Drawing.Size(578, 300);
            this.splitContainer3.SplitterDistance = 285;
            this.splitContainer3.TabIndex = 0;
            // 
            // DGV_City
            // 
            this.DGV_City.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_City.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_City.Location = new System.Drawing.Point(0, 0);
            this.DGV_City.Name = "DGV_City";
            this.DGV_City.Size = new System.Drawing.Size(285, 300);
            this.DGV_City.TabIndex = 0;
            this.DGV_City.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_City_CellValueChanged);
            this.DGV_City.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DGV_City_UserDeletingRow);
            // 
            // DGV_Street
            // 
            this.DGV_Street.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Street.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Street.Location = new System.Drawing.Point(0, 0);
            this.DGV_Street.Name = "DGV_Street";
            this.DGV_Street.Size = new System.Drawing.Size(289, 300);
            this.DGV_Street.TabIndex = 0;
            this.DGV_Street.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Street_CellValueChanged);
            this.DGV_Street.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DGV_Street_UserDeletingRow);
            // 
            // TP_Publishers
            // 
            this.TP_Publishers.Controls.Add(this.DGV_Publisher);
            this.TP_Publishers.Location = new System.Drawing.Point(4, 22);
            this.TP_Publishers.Name = "TP_Publishers";
            this.TP_Publishers.Size = new System.Drawing.Size(578, 300);
            this.TP_Publishers.TabIndex = 6;
            this.TP_Publishers.Text = "Издательства";
            this.TP_Publishers.UseVisualStyleBackColor = true;
            // 
            // DGV_Publisher
            // 
            this.DGV_Publisher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Publisher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Publisher.Location = new System.Drawing.Point(0, 0);
            this.DGV_Publisher.Name = "DGV_Publisher";
            this.DGV_Publisher.Size = new System.Drawing.Size(578, 300);
            this.DGV_Publisher.TabIndex = 0;
            this.DGV_Publisher.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Publisher_CellValueChanged);
            this.DGV_Publisher.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DGV_Publisher_DataError);
            this.DGV_Publisher.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DGV_Publisher_UserDeletingRow);
            // 
            // TP_Users
            // 
            this.TP_Users.Controls.Add(this.DGV_Users);
            this.TP_Users.Location = new System.Drawing.Point(4, 22);
            this.TP_Users.Name = "TP_Users";
            this.TP_Users.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Users.Size = new System.Drawing.Size(578, 300);
            this.TP_Users.TabIndex = 7;
            this.TP_Users.Text = "Пользователи";
            this.TP_Users.UseVisualStyleBackColor = true;
            // 
            // DGV_Users
            // 
            this.DGV_Users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Users.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Users.Location = new System.Drawing.Point(3, 3);
            this.DGV_Users.Name = "DGV_Users";
            this.DGV_Users.Size = new System.Drawing.Size(572, 294);
            this.DGV_Users.TabIndex = 0;
            this.DGV_Users.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DGV_Users_UserDeletingRow);
            // 
            // DB_DataSet
            // 
            this.DB_DataSet.DataSetName = "DS_name";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 326);
            this.Controls.Add(this.DatabaseData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormMain";
            this.Text = "Добро пожаловать";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.DatabaseData.ResumeLayout(false);
            this.TP_Books.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Books)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Kinds)).EndInit();
            this.TP_Authors.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Book_Authors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Authors)).EndInit();
            this.TP_Reader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Reader)).EndInit();
            this.TP_Book_issue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_BIssue)).EndInit();
            this.TP_Booking.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Booking)).EndInit();
            this.TP_Address.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_City)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Street)).EndInit();
            this.TP_Publishers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Publisher)).EndInit();
            this.TP_Users.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Users)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DB_DataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl DatabaseData;
        private System.Windows.Forms.TabPage TP_Books;
        private System.Windows.Forms.TabPage TP_Authors;
        private System.Windows.Forms.TabPage TP_Reader;
        private System.Windows.Forms.TabPage TP_Book_issue;
        private System.Windows.Forms.TabPage TP_Booking;
        private System.Windows.Forms.TabPage TP_Address;
        private System.Windows.Forms.TabPage TP_Publishers;
        private System.Windows.Forms.TabPage TP_Users;
        private System.Data.DataSet DB_DataSet;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView DGV_Books;
        private System.Windows.Forms.DataGridView DGV_Kinds;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView DGV_Book_Authors;
        private System.Windows.Forms.DataGridView DGV_Authors;
        private System.Windows.Forms.DataGridView DGV_Reader;
        private System.Windows.Forms.DataGridView DGV_BIssue;
        private System.Windows.Forms.DataGridView DGV_Booking;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView DGV_City;
        private System.Windows.Forms.DataGridView DGV_Street;
        private System.Windows.Forms.DataGridView DGV_Users;
        private System.Windows.Forms.DataGridView DGV_Publisher;
    }
}


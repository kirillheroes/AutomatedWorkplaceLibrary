using System;
using System.Data;
using System.Windows.Forms;
using static Automated_WorkPlace_Library.Functions;
using Npgsql;

namespace Automated_WorkPlace_Library
{
    public partial class FormMain : Form
    {
        public string login { set; get; } = ""; //для вывода имени на экран
        public bool guest_mode { get; set; } = true;
        public bool admin { get; set; } = false;
        public NpgsqlConnection connection { get; set; } = null;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (connection == null)
            {
                if (new FormAuth().ShowDialog(this) == DialogResult.Cancel)
                Application.Exit();
            }

            if (guest_mode) this.Text = "Добро пожаловать, гость";
            else this.Text = "Добро пожаловать, " + login;

            connection.Open();

            Set_All_Adapters();
            Load_TP_Books();
            Load_TP_Authors();
            Load_TP_Readers();
            Load_TP_Books_issue();
            Load_TP_Booking();
            Load_TP_Publishers();
            Load_TP_Address();

            if (admin)
                Load_TP_Users();
            else 
                DatabaseData.TabPages[7].Parent = null; //TagPages[7] это Пользователи

            connection.Close();
        }

        private void Set_All_Adapters()
        {
            var adapter_Books = new NpgsqlDataAdapter("select * from books", connection);
            adapter_Books.Fill(DB_DataSet, "books");
            var adapter_Kinds = new NpgsqlDataAdapter("select * from kinds", connection);
            adapter_Kinds.Fill(DB_DataSet, "kinds");
            var adapter_Publisher = new NpgsqlDataAdapter("select * from publisher", connection);
            adapter_Publisher.Fill(DB_DataSet, "publisher");
            var adapter_Authors = new NpgsqlDataAdapter("select * from authors", connection);
            adapter_Authors.Fill(DB_DataSet, "authors");
            var adapter_Book_Authors = new NpgsqlDataAdapter("select * from book_authors", connection);
            adapter_Book_Authors.Fill(DB_DataSet, "book_authors");
            var adapter_Readers = new NpgsqlDataAdapter("select * from reader", connection);
            adapter_Readers.Fill(DB_DataSet, "reader");
            var adapter_Street = new NpgsqlDataAdapter("select * from street", connection);
            adapter_Street.Fill(DB_DataSet, "street");
            var adapter_City = new NpgsqlDataAdapter("select * from city", connection);
            adapter_City.Fill(DB_DataSet, "city");
            var adapter_Booking = new NpgsqlDataAdapter("select * from booking", connection);
            adapter_Booking.Fill(DB_DataSet, "booking");
            var adapter_Books_issue = new NpgsqlDataAdapter("select * from books_issue", connection);
            adapter_Books_issue.Fill(DB_DataSet, "books_issue");

            if (admin)
            {
                var adapter_Users = new NpgsqlDataAdapter("select usename from pg_user", connection);
                adapter_Users.Fill(DB_DataSet, "users");
            }
        }

        private void Load_TP_Books()
        {
            //загружаем таблицу Книги
            DGV_Books.DataSource = DB_DataSet;
            DGV_Books.DataMember = "books";
            DGV_Books.Columns["id"].ReadOnly = true;
            DGV_Books.Columns["kind"].Visible = false;
            DGV_Books.Columns["publisher"].Visible = false;
            DGV_Books.Columns["code"].HeaderText = "шифр";
            DGV_Books.Columns["language"].HeaderText = "язык";
            DGV_Books.Columns["year"].HeaderText = "год издания";
            DGV_Books.Columns["name"].HeaderText = "название";

            var DGVCBC_BooksKinds = new DataGridViewComboBoxColumn();
            DGVCBC_BooksKinds.DataSource = DB_DataSet.Tables["kinds"];
            DGVCBC_BooksKinds.DataPropertyName = "kind"; //внешний ключ
            DGVCBC_BooksKinds.DisplayMember = "name";
            DGVCBC_BooksKinds.ValueMember = "id"; //первичный ключ
            DGVCBC_BooksKinds.HeaderText = "жанр";
           
            var DGVCBC_BooksPublishers = new DataGridViewComboBoxColumn();
            DGVCBC_BooksPublishers.DataSource = DB_DataSet.Tables["publisher"];
            DGVCBC_BooksPublishers.DataPropertyName = "publisher";
            DGVCBC_BooksPublishers.DisplayMember = "name";
            DGVCBC_BooksPublishers.ValueMember = "id"; 
            DGVCBC_BooksPublishers.HeaderText = "издатель";
        
            //загружаем таблицу Жанры
            DGV_Kinds.DataSource = DB_DataSet;
            DGV_Kinds.DataMember = "kinds";
            DGV_Kinds.Columns["id"].Visible = false;
            DGV_Kinds.Columns["name"].HeaderText = "все жанры";

            if (guest_mode)
            {
                DGVCBC_BooksKinds.ReadOnly = true;
                DGVCBC_BooksPublishers.ReadOnly = true;
                DGV_Books.Columns["code"].ReadOnly = true;
                DGV_Books.Columns["name"].ReadOnly = true;
                DGV_Books.Columns["language"].ReadOnly = true;
                DGV_Books.Columns["year"].ReadOnly = true;
                DGV_Kinds.Columns["name"].ReadOnly = true;
                DGV_Books.AllowUserToDeleteRows = false;
                DGV_Kinds.AllowUserToDeleteRows = false;
                DGV_Kinds.AllowUserToAddRows = false;
            }

            DGV_Books.Columns.Add(DGVCBC_BooksKinds);
            DGV_Books.Columns.Add(DGVCBC_BooksPublishers);
        }

        private void Load_TP_Authors()
        {
            //загружаем таблицу Авторы книг
            DGV_Book_Authors.DataSource = DB_DataSet;
            DGV_Book_Authors.DataMember = "book_authors";
            DGV_Book_Authors.Columns["id"].ReadOnly = true;
            DGV_Book_Authors.Columns["author"].Visible = false;
            DGV_Book_Authors.Columns["book"].Visible = false;
            DGV_Book_Authors.Columns["editor"].HeaderText = "является издательством?";

            var DGVCBC_Authors_of_Book = new DataGridViewComboBoxColumn();
            DGVCBC_Authors_of_Book.DataSource = DB_DataSet.Tables["authors"];
            DGVCBC_Authors_of_Book.DataPropertyName = "author";
            DGVCBC_Authors_of_Book.DisplayMember = "name";
            DGVCBC_Authors_of_Book.ValueMember = "id"; 
            DGVCBC_Authors_of_Book.HeaderText = "автор";

            var DGVCBC_Book_of_this_Authors = new DataGridViewComboBoxColumn();
            DGVCBC_Book_of_this_Authors.DataSource = DB_DataSet.Tables["books"];
            DGVCBC_Book_of_this_Authors.DataPropertyName = "book";
            DGVCBC_Book_of_this_Authors.DisplayMember = "name";
            DGVCBC_Book_of_this_Authors.ValueMember = "id";
            DGVCBC_Book_of_this_Authors.HeaderText = "книга";
        
            //загружаем таблицу Авторы
            DGV_Authors.DataSource = DB_DataSet;
            DGV_Authors.DataMember = "authors";
            DGV_Authors.Columns["id"].Visible = false;
            DGV_Authors.Columns["name"].HeaderText = "все авторы";


            if (guest_mode)
            {
                DGVCBC_Authors_of_Book.ReadOnly = true;
                DGVCBC_Book_of_this_Authors.ReadOnly = true;
                DGV_Book_Authors.Columns["editor"].ReadOnly = true;
                DGV_Authors.Columns["name"].ReadOnly = true;
                DGV_Authors.AllowUserToDeleteRows = false;
                DGV_Book_Authors.AllowUserToDeleteRows = false;
            }

            DGV_Book_Authors.Columns.Add(DGVCBC_Authors_of_Book);
            DGV_Book_Authors.Columns.Add(DGVCBC_Book_of_this_Authors);
        }

        private void Load_TP_Readers()
        {
            //загружаем таблицу Читатели
            DGV_Reader.DataSource = DB_DataSet;
            DGV_Reader.DataMember = "reader";
            DGV_Reader.Columns["number"].ReadOnly = true;
            if (!admin) DGV_Reader.Columns["user_login"].ReadOnly = true;
            DGV_Reader.Columns["street"].Visible = false;
            DGV_Reader.Columns["number"].HeaderText = "читательский номер";
            DGV_Reader.Columns["passport"].HeaderText = "паспорт";
            DGV_Reader.Columns["telephone"].HeaderText = "телефон";
            DGV_Reader.Columns["house"].HeaderText = "номер дома";
            DGV_Reader.Columns["apartment"].HeaderText = "квартира";
            DGV_Reader.Columns["user_login"].HeaderText = "логин пользователя";
            DGV_Reader.Columns["name"].HeaderText = "ФИО";
            
            var DGVCBC_Reader_Street = new DataGridViewComboBoxColumn();
            DGVCBC_Reader_Street.DataSource = DB_DataSet.Tables["street"];
            DGVCBC_Reader_Street.DataPropertyName = "street";
            DGVCBC_Reader_Street.DisplayMember = "name";
            DGVCBC_Reader_Street.ValueMember = "id";
            DGVCBC_Reader_Street.HeaderText = "улица";

            /*var DGVCBC_Reader_City = new DataGridViewComboBoxColumn();
            //DGVCBC_Reader_City.DataSource = DB_DataSet.Tables["city"];
            //DGVCBC_Reader_City.DataPropertyName = "street";
            //DGVCBC_Reader_City.DisplayMember = "name";
            //DGVCBC_Reader_City.ValueMember = "id";
            DGVCBC_Reader_City.HeaderText = "город";

            for (int i = 0; i < DB_DataSet.Tables["reader"].Rows.Count; i++)
            {
                string cmd_text = "";
                cmd_text = "select ";
                NpgsqlCommand select = new NpgsqlCommand(cmd_text, connection);
                select.Parameters.AddWithValue("@read_value", row.Cells["reader"].Value);
            }*/
           
            if (guest_mode)
            {
                DGVCBC_Reader_Street.ReadOnly = true;
                DGV_Reader.Columns["number"].ReadOnly = true;
                DGV_Reader.Columns["passport"].ReadOnly = true;
                DGV_Reader.Columns["telephone"].ReadOnly = true;
                DGV_Reader.Columns["house"].ReadOnly = true;
                DGV_Reader.Columns["apartment"].ReadOnly = true;
                DGV_Reader.Columns["name"].ReadOnly = true;
                DGV_Reader.AllowUserToDeleteRows = false;
            }

            DGV_Reader.Columns.Add(DGVCBC_Reader_Street);
        }

        private void Load_TP_Books_issue()
        {
            //загружаем таблицу Выдача книг
            DGV_BIssue.DataSource = DB_DataSet;
            DGV_BIssue.DataMember = "books_issue";
            DGV_BIssue.Columns["id"].ReadOnly = true;
            DGV_BIssue.Columns["reader"].Visible = false;
            DGV_BIssue.Columns["book"].Visible = false;
            DGV_BIssue.Columns["date"].HeaderText = "дата выдачи";
            DGV_BIssue.Columns["return"].HeaderText = "дата возврата";

            var DGVCBC_Book_of_issue = new DataGridViewComboBoxColumn();
            DGVCBC_Book_of_issue.DataSource = DB_DataSet.Tables["books"];
            DGVCBC_Book_of_issue.DataPropertyName = "book";
            DGVCBC_Book_of_issue.DisplayMember = "name";
            DGVCBC_Book_of_issue.ValueMember = "id"; 
            DGVCBC_Book_of_issue.HeaderText = "книга";
            
            var DGVCBC_Reader_of_issue = new DataGridViewComboBoxColumn();
            DGVCBC_Reader_of_issue.DataSource = DB_DataSet.Tables["reader"];
            DGVCBC_Reader_of_issue.DataPropertyName = "reader";
            DGVCBC_Reader_of_issue.DisplayMember = "name";
            DGVCBC_Reader_of_issue.ValueMember = "number";
            DGVCBC_Reader_of_issue.HeaderText = "читатель";

            if (guest_mode)
            {
                DGVCBC_Book_of_issue.ReadOnly = true;
                DGVCBC_Reader_of_issue.ReadOnly = true;
                DGV_BIssue.Columns["date"].ReadOnly = true;
                DGV_BIssue.Columns["return"].ReadOnly = true;
                DGV_BIssue.AllowUserToDeleteRows = false;
            }

            DGV_BIssue.Columns.Add(DGVCBC_Reader_of_issue);
            DGV_BIssue.Columns.Add(DGVCBC_Book_of_issue);
        }

        private void Load_TP_Booking()
        {
            //загружаем таблицу Бронирование книг
            DGV_Booking.DataSource = DB_DataSet;
            DGV_Booking.DataMember = "booking";
            DGV_Booking.Columns["id"].ReadOnly = true;
            DGV_Booking.Columns["reader"].Visible = false;
            DGV_Booking.Columns["book"].Visible = false;
            DGV_Booking.Columns["date"].HeaderText = "дата выдачи";

            var DGVCBC_Book_of_booking = new DataGridViewComboBoxColumn();
            DGVCBC_Book_of_booking.DataSource = DB_DataSet.Tables["books"];
            DGVCBC_Book_of_booking.DataPropertyName = "book";
            DGVCBC_Book_of_booking.DisplayMember = "name";
            DGVCBC_Book_of_booking.ValueMember = "id";
            DGVCBC_Book_of_booking.HeaderText = "книга";
          
            var DGVCBC_Reader_of_booking = new DataGridViewComboBoxColumn();
            DGVCBC_Reader_of_booking.DataSource = DB_DataSet.Tables["reader"];
            DGVCBC_Reader_of_booking.DataPropertyName = "reader";
            DGVCBC_Reader_of_booking.DisplayMember = "name";
            DGVCBC_Reader_of_booking.ValueMember = "number";
            DGVCBC_Reader_of_booking.HeaderText = "читатель";

            if (guest_mode)
            {
                DGVCBC_Book_of_booking.ReadOnly = true;
                DGVCBC_Reader_of_booking.ReadOnly = true;
                DGV_Booking.Columns["date"].ReadOnly = true;
                DGV_Booking.AllowUserToDeleteRows = false;
            }
            DGV_Booking.Columns.Add(DGVCBC_Book_of_booking);
            DGV_Booking.Columns.Add(DGVCBC_Reader_of_booking);
        }

        private void Load_TP_Publishers()
        {
            //загружаем таблицу Издательства
            DGV_Publisher.DataSource = DB_DataSet;
            DGV_Publisher.DataMember = "publisher";
            DGV_Publisher.Columns["id"].Visible = false;
            DGV_Publisher.Columns["street"].Visible = false;
            DGV_Publisher.Columns["name"].HeaderText = "наименование";
            DGV_Publisher.Columns["telephone"].HeaderText = "телефон";
            DGV_Publisher.Columns["house"].HeaderText = "номер дома";

            var DGVCBC_Publisher_Street = new DataGridViewComboBoxColumn();
            DGVCBC_Publisher_Street.DataSource = DB_DataSet.Tables["street"];
            DGVCBC_Publisher_Street.DataPropertyName = "street";
            DGVCBC_Publisher_Street.DisplayMember = "name";
            DGVCBC_Publisher_Street.ValueMember = "id";
            DGVCBC_Publisher_Street.HeaderText = "улица";

            if (guest_mode)
            {
                DGVCBC_Publisher_Street.ReadOnly = true;
                DGV_Publisher.Columns["name"].ReadOnly = true;
                DGV_Publisher.Columns["telephone"].ReadOnly = true;
                DGV_Publisher.Columns["house"].ReadOnly = true;
                DGV_Publisher.AllowUserToDeleteRows = false;
            }

            DGV_Publisher.Columns.Add(DGVCBC_Publisher_Street);
        }

        private void Load_TP_Address()
        {
            //загружаем таблицу Города
            DGV_City.DataSource = DB_DataSet;
            DGV_City.DataMember = "city";
            DGV_City.Columns["id"].Visible = false;
            DGV_City.Columns["name"].HeaderText = "все города";

            //загружаем таблицу Улицы
            DGV_Street.DataSource = DB_DataSet;
            DGV_Street.DataMember = "street";
            DGV_Street.Columns["id"].Visible = false;
            DGV_Street.Columns["city_id"].Visible = false;
            DGV_Street.Columns["name"].HeaderText = "все улицы";

            var DGVCBC_City_of_Street = new DataGridViewComboBoxColumn();
            DGVCBC_City_of_Street.DataSource = DB_DataSet.Tables["city"];
            DGVCBC_City_of_Street.DataPropertyName = "city_id";
            DGVCBC_City_of_Street.DisplayMember = "name";
            DGVCBC_City_of_Street.ValueMember = "id";
            DGVCBC_City_of_Street.HeaderText = "город данной улицы";

            if (guest_mode)
            {
                DGVCBC_City_of_Street.ReadOnly = true;
                DGV_City.Columns["name"].ReadOnly = true;
                DGV_Street.Columns["name"].ReadOnly = true;
            }
            DGV_Street.Columns.Add(DGVCBC_City_of_Street);
        }

        private void Load_TP_Users()
        {
            if (admin)
            {
                //загружаем таблицу Пользователи
                DGV_Users.DataSource = DB_DataSet;
                DGV_Users.DataMember = "users";
            }
        }

        private void Error_Msg(string error_type)
        {
            string error_text;
            switch (error_type)
            {
                case "DateTime":
                    error_text = "Неправильный ввод данных!\nВведите номер месяца, номер дня и год";
                    break;
                case "Int32":
                    error_text = "Введите число!";
                    break;
                case "Int64":
                    error_text = "Введите число!";
                    break;
                case "unique":
                    error_text = "Данная запись уже существует!\nНарушение уникальности";
                    break;
                case "big_year":
                    error_text = "Слишком большой год!";
                    break;
                case "invalid_year":
                    error_text = "Некорректный ввод года!";
                    break;
                case "invalid telephone":
                    error_text = "Некорректный ввод номера телефона!";
                    break;
                case "invalid passport":
                    error_text = "Некорректный ввод серии-номера паспорта!";
                    break;
                case "null":
                    error_text = "Ячейка не должна быть пустой!";
                    break;
                case "error":
                    error_text = "Произошла ошибка при выполнении запроса...";
                    break;
                case "del fk kinds":
                    error_text = "Нельзя удалить жанр, который уже используется книгами!";
                    break;
                case "del fk authors":
                    error_text = "Нельзя удалить автора, книги которого есть на полках!";
                    break;
                case "del fk city":
                    error_text = "Нельзя удалить город, улицы которого уже используются в адресах!";
                    break;
                case "del fk street":
                    error_text = "Нельзя удалить улицу, которая уже используется в адресах!";
                    break;
                case "del fk publisher":
                    error_text = "Нельзя удалить издательство, книги которого есть на полках!";
                    break;
                default:
                    error_text = "Ошибка ввода!";
                    break;
            }
            MessageBox.Show(error_text);
        }

        //блок функций для операций в таблице Книги

        private void DGV_Books_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = DGV_Books.Rows[e.RowIndex];//DB_DataSet.Tables["books"].Rows[e.RowIndex];

            if (e.RowIndex >= DB_DataSet.Tables["books"].Rows.Count)
            {
                if (row.Cells["code"].Value is DBNull || row.Cells["name"].Value is DBNull ||
                    row.Cells["kind"].Value is DBNull || row.Cells["language"].Value is DBNull ||
                    row.Cells["publisher"].Value is DBNull)
                    return;
            }

            if (!(row.Cells["year"].Value is DBNull))
            {
                int year = 0;
                try
                {
                    year = (int)row.Cells["year"].Value;
                }
                catch (Exception err)
                {
                    Error_Msg("Int32");
                }
                if (year > 3000)
                {
                    Error_Msg("big_year");
                    return;
                }
                if (year < 0)
                {
                    Error_Msg("invalid_year");
                    return;
                }
            }

            connection.Open();

            string cmd_text = "";
            int id = 0;

            if (e.RowIndex >= DB_DataSet.Tables["books"].Rows.Count) //DGV_Books.RowCount)
            {
                cmd_text = "insert into books (code, name, kind, language, publisher, year)" +
                    "values (@code_value, @name_value, @kind_value, @lang_value, @publ_value, @year_value)";
            }
            else
            {
                cmd_text = "update books set code = @code_value, name = @name_value, kind = @kind_value," +
                "language = @lang_value, publisher = @publ_value, year = @year_value where id = @id_value";
            }
            NpgsqlCommand cmd = new NpgsqlCommand(cmd_text, connection);
            cmd.Parameters.AddWithValue("@code_value", row.Cells["code"].Value);
            cmd.Parameters.AddWithValue("@name_value", row.Cells["name"].Value);
            cmd.Parameters.AddWithValue("@kind_value", row.Cells["kind"].Value);
            cmd.Parameters.AddWithValue("@lang_value", row.Cells["language"].Value);
            cmd.Parameters.AddWithValue("@publ_value", row.Cells["publisher"].Value);
            cmd.Parameters.AddWithValue("@year_value", row.Cells["year"].Value);

            if (e.RowIndex < DB_DataSet.Tables["books"].Rows.Count)
                cmd.Parameters.AddWithValue("@id_value", row.Cells["id"].Value);

            int result = -1;
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch(PostgresException err)
            {
                switch (err.Code)
                {
                    case "23505":
                        Error_Msg("unique");
                        break;
                    /*case "23502":
                        Error_Msg("некоторые ячейки не заполнены!");
                        break;*/
                }
            }
            if (result == 0) Error_Msg("error");
            connection.Close();
        }

        private void DGV_Books_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var row = e.Row;
            connection.Open();
            NpgsqlCommand delete = new NpgsqlCommand("delete from books where id = @id_value", connection);
            delete.Parameters.AddWithValue("@id_value", row.Cells["id"].Value);

            if (delete.ExecuteNonQuery() == 0)
            {
                Error_Msg("error");
                e.Cancel = true;
            }
            else
                Load_TP_Authors();
            connection.Close();
        }

        private void DGV_Books_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var column = DGV_Books.Columns[e.ColumnIndex].Name;
            var type = DB_DataSet.Tables["books"].Columns[column].DataType.Name;
            Error_Msg(type);
        }

        //блок функций для операций в таблице Жанры

        private void DGV_Kinds_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = DGV_Kinds.Rows[e.RowIndex];

            if (e.RowIndex >= DB_DataSet.Tables["kinds"].Rows.Count)
            {
                if (row.Cells["name"].Value is DBNull)
                return;
            }

            connection.Open();
            string cmd_text = "";
            if (e.RowIndex >= DB_DataSet.Tables["kinds"].Rows.Count)
                cmd_text = "insert into kinds (name) values (@name_value)";
            else
                cmd_text = "update kinds set name = @name_value where id = @id_value";
            NpgsqlCommand update = new NpgsqlCommand(cmd_text, connection);
            update.Parameters.AddWithValue("@name_value", row.Cells["name"].Value);
            if (e.RowIndex < DB_DataSet.Tables["kinds"].Rows.Count)
                update.Parameters.AddWithValue("@id_value", row.Cells["id"].Value);

            int result = -1;
            try
            {
                result = update.ExecuteNonQuery();
            }
            catch (PostgresException err)
            {
                switch (err.Code)
                {
                    case "23505":
                        Error_Msg("unique");
                        break;
                }
            }
            if (result == 0) Error_Msg("error");
            connection.Close();
        }

        private void DGV_Kinds_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var row = e.Row;
            connection.Open();
            NpgsqlCommand delete = new NpgsqlCommand("delete from kinds where id = @id_value", connection);
            delete.Parameters.AddWithValue("@id_value", row.Cells["id"].Value);

            int result = -1;
            try
            {
                result = delete.ExecuteNonQuery();
            }
            catch (PostgresException err)
            {
                switch (err.Code)
                {
                    case "23503":
                        Error_Msg("del fk kinds");
                        break;
                }
                e.Cancel = true;
            }
            if (result == 0)
            {
                Error_Msg("error");
                e.Cancel = true;
            }
            connection.Close();
        }

        private void DGV_Kinds_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var column = DGV_Kinds.Columns[e.ColumnIndex].Name;
            var type = DB_DataSet.Tables["kinds"].Columns[column].DataType.Name;
            Error_Msg(type);
        }

        //блок функций для операций в таблице Авторы

        private void DGV_Authors_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = DGV_Authors.Rows[e.RowIndex];

            if (e.RowIndex >= DB_DataSet.Tables["authors"].Rows.Count)
            {
                if (row.Cells["name"].Value is DBNull)
                    return;
            }

            connection.Open();
            string cmd_text = "";
            if (e.RowIndex >= DB_DataSet.Tables["authors"].Rows.Count)
                cmd_text = "insert into authors (name) values (@name_value)";
            else
                cmd_text = "update authors set name = @name_value where id = @id_value";
            
            NpgsqlCommand update = new NpgsqlCommand(cmd_text, connection);
            update.Parameters.AddWithValue("@name_value", row.Cells["name"].Value);
            if (e.RowIndex < DB_DataSet.Tables["authors"].Rows.Count)
                update.Parameters.AddWithValue("@id_value", row.Cells["id"].Value);

            int result = -1;
            try
            {
                result = update.ExecuteNonQuery();
            }
            catch (PostgresException err)
            {
                switch (err.Code)
                {
                    case "23505":
                        Error_Msg("unique");
                        break;
                }
            }
            if (result == 0) Error_Msg("error");
            connection.Close();
        }

        private void DGV_Authors_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var row = e.Row;
            connection.Open();
            NpgsqlCommand delete = new NpgsqlCommand("delete from authors where id = @id_value", connection);
            delete.Parameters.AddWithValue("@id_value", row.Cells["id"].Value);

            int result = -1;
            try
            {
                result = delete.ExecuteNonQuery();
            }
            catch (PostgresException err)
            {
                switch (err.Code)
                {
                    case "23503":
                        Error_Msg("del fk authors");
                        break;
                }
                e.Cancel = true;
            }
            if (result == 0)
            {
                Error_Msg("error");
                e.Cancel = true;
            }
            connection.Close();
        }

        //блок функций для операций в таблице Авторы книг

        private void DGV_Book_Authors_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = DGV_Book_Authors.Rows[e.RowIndex];

            if (e.RowIndex >= DB_DataSet.Tables["book_authors"].Rows.Count)
            {
                if (row.Cells["book"].Value is DBNull || row.Cells["author"].Value is DBNull)
                return;
            }

            connection.Open();
            string cmd_text = "";
            if (e.RowIndex >= DB_DataSet.Tables["book_authors"].Rows.Count)
                cmd_text = "insert into book_authors (book, author, editor)" +
                    "values (@book_value, @auth_value, @edit_value)";
            else
                cmd_text = "update book_authors set book = @book_value," +
                "author = @auth_value, editor = @edit_value where id = @id_value";
            NpgsqlCommand update = new NpgsqlCommand(cmd_text, connection);
            update.Parameters.AddWithValue("@book_value", row.Cells["book"].Value);
            update.Parameters.AddWithValue("@auth_value", row.Cells["author"].Value);
            update.Parameters.AddWithValue("@edit_value", row.Cells["editor"].Value);
            if (e.RowIndex < DB_DataSet.Tables["book_authors"].Rows.Count)
                update.Parameters.AddWithValue("@id_value",   row.Cells["id"].Value);

            if (update.ExecuteNonQuery() == 0) Error_Msg("error");
            connection.Close();
        }

        private void DGV_Book_Authors_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            MessageBox.Show("Нельзя удалить запись \"автор-книга\" без удаления самой книги!" +
                "\nУдалите соответствующую запись в таблице \"Книги\"");
            e.Cancel = true;
        }

        //блок функций для операций в таблице Выдача книг

        private void DGV_BIssue_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = DGV_BIssue.Rows[e.RowIndex];

            if (e.RowIndex >= DB_DataSet.Tables["books_issue"].Rows.Count)
            {
                if (row.Cells["reader"].Value is DBNull || row.Cells["book"].Value is DBNull ||
                    row.Cells["date"].Value is DBNull)
                return;
            }

            connection.Open();
            string cmd_text = "";
            if (e.RowIndex >= DB_DataSet.Tables["books_issue"].Rows.Count)
                cmd_text = "insert into books_issue (reader, book, date, return)" +
                    "values (@read_value, @book_value, @date_value, @retu_value)";
            else
                cmd_text = "update books_issue set reader = @read_value," +
           "book = @book_value, date = @date_value, return = @retu_value where id = @id_value";
            NpgsqlCommand update = new NpgsqlCommand(cmd_text, connection);
            update.Parameters.AddWithValue("@read_value", row.Cells["reader"].Value);
            update.Parameters.AddWithValue("@book_value", row.Cells["book"].Value);
            update.Parameters.AddWithValue("@date_value", row.Cells["date"].Value);
            update.Parameters.AddWithValue("@retu_value", row.Cells["return"].Value);
            if (e.RowIndex < DB_DataSet.Tables["books_issue"].Rows.Count)
                update.Parameters.AddWithValue("@id_value", row.Cells["id"].Value);

            if (update.ExecuteNonQuery() == 0) Error_Msg("error");
            connection.Close();
        }

        private void DGV_BIssue_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var row = e.Row;
            connection.Open();
            NpgsqlCommand delete = new NpgsqlCommand("delete from books_issue where id = @id_value", connection);
            delete.Parameters.AddWithValue("@id_value", row.Cells["id"].Value);

            if (delete.ExecuteNonQuery() == 0)
            {
                Error_Msg("error");
                e.Cancel = true;
            }
            connection.Close();
        }

        private void DGV_BIssue_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var column = DGV_BIssue.Columns[e.ColumnIndex].Name;
            var type = DB_DataSet.Tables["books_issue"].Columns[column].DataType.Name;
            Error_Msg(type);
        }

        //блок функций для операций в таблице Бронирование

        private void DGV_Booking_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = DGV_Booking.Rows[e.RowIndex];

            if (e.RowIndex >= DB_DataSet.Tables["booking"].Rows.Count)
            {
                if (row.Cells["reader"].Value is DBNull || row.Cells["book"].Value is DBNull ||
                    row.Cells["date"].Value is DBNull)
                    return;
            }

            connection.Open();
            string cmd_text = "";
            if (e.RowIndex >= DB_DataSet.Tables["booking"].Rows.Count)
                cmd_text = "insert into booking (reader, book, date)" +
                    "values (@read_value, @book_value, @date_value)";
            else
                cmd_text = "update booking set reader = @read_value," +
           "book = @book_value, date = @date_value where id = @id_value";
            NpgsqlCommand update = new NpgsqlCommand(cmd_text, connection);
            update.Parameters.AddWithValue("@read_value", row.Cells["reader"].Value);
            update.Parameters.AddWithValue("@book_value", row.Cells["book"].Value);
            update.Parameters.AddWithValue("@date_value", row.Cells["date"].Value);
            if (e.RowIndex < DB_DataSet.Tables["booking"].Rows.Count)
                update.Parameters.AddWithValue("@id_value", row.Cells["id"].Value);

            if (update.ExecuteNonQuery() == 0) Error_Msg("error");
            connection.Close();
        }

        private void DGV_Booking_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var row = e.Row;
            connection.Open();
            NpgsqlCommand delete = new NpgsqlCommand("delete from booking where id = @id_value", connection);
            delete.Parameters.AddWithValue("@id_value", row.Cells["id"].Value);

            if (delete.ExecuteNonQuery() == 0)
            {
                Error_Msg("error");
                e.Cancel = true;
            }
            connection.Close();
        }

        private void DGV_Booking_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var column = DGV_Booking.Columns[e.ColumnIndex].Name;
            var type = DB_DataSet.Tables["booking"].Columns[column].DataType.Name;
            Error_Msg(type);
        }

        //блок функций для операций в таблице Города

        private void DGV_City_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = DGV_City.Rows[e.RowIndex];

            if (e.RowIndex >= DB_DataSet.Tables["city"].Rows.Count)
            {
                if (row.Cells["name"].Value is DBNull)
                    return;
            }

            connection.Open();
            string cmd_text = "";
            if (e.RowIndex >= DB_DataSet.Tables["city"].Rows.Count)
                cmd_text = "insert into city (name) values (@name_value)";
            else
                cmd_text = "update city set name = @name_value where id = @id_value";
            NpgsqlCommand update = new NpgsqlCommand(cmd_text, connection);
            update.Parameters.AddWithValue("@name_value", row.Cells["name"].Value);
            if (e.RowIndex < DB_DataSet.Tables["city"].Rows.Count)
                update.Parameters.AddWithValue("@id_value", row.Cells["id"].Value);

            int result = -1;
            try
            {
                result = update.ExecuteNonQuery();
            }
            catch (PostgresException err)
            {
                switch (err.Code)
                {
                    case "23505":
                        Error_Msg("unique");
                        break;
                }
            }
            if (result == 0) Error_Msg("error");
            connection.Close();
        }

        private void DGV_City_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var row = e.Row;
            connection.Open();
            NpgsqlCommand delete = new NpgsqlCommand("delete from city where id = @id_value", connection);
            delete.Parameters.AddWithValue("@id_value", row.Cells["id"].Value);

            int result = -1;
            try
            {
                result = delete.ExecuteNonQuery();
            }
            catch (PostgresException err)
            {
                switch (err.Code)
                {
                    case "23503":
                        Error_Msg("del fk city");
                        break;
                }
                e.Cancel = true;
            }
            if (result == 0)
            {
                Error_Msg("error");
                e.Cancel = true;
            }
            connection.Close();
        }

        //блок функций для операций в таблице Улицы

        private void DGV_Street_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = DGV_Street.Rows[e.RowIndex];

            if (e.RowIndex >= DB_DataSet.Tables["street"].Rows.Count)
            {
                if (row.Cells["name"].Value is DBNull || row.Cells["city_id"].Value is DBNull)
                    return;
            }

            connection.Open();
            string cmd_text = "";
            if (e.RowIndex >= DB_DataSet.Tables["street"].Rows.Count)
                cmd_text = "insert into street (city_id, name) values (@city_value, @name_value)";
            else
                cmd_text = "update street set city_id = @city_value, " +
                "name = @name_value where id = @id_value";
            NpgsqlCommand update = new NpgsqlCommand(cmd_text, connection);
            update.Parameters.AddWithValue("@city_value", row.Cells["city_id"].Value);
            update.Parameters.AddWithValue("@name_value", row.Cells["name"].Value);
            if (e.RowIndex < DB_DataSet.Tables["street"].Rows.Count)
                update.Parameters.AddWithValue("@id_value", row.Cells["id"].Value);

            int result = -1;
            try
            {
                result = update.ExecuteNonQuery();
            }
            catch (PostgresException err)
            {
                switch (err.Code)
                {
                    case "23505":
                        Error_Msg("unique");
                        break;
                }
            }
            if (result == 0) Error_Msg("error");
            connection.Close();
        }

        private void DGV_Street_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var row = e.Row;
            connection.Open();
            NpgsqlCommand delete = new NpgsqlCommand("delete from street where id = @id_value", connection);
            delete.Parameters.AddWithValue("@id_value", row.Cells["id"].Value);

            int result = -1;
            try
            {
                result = delete.ExecuteNonQuery();
            }
            catch (PostgresException err)
            {
                switch (err.Code)
                {
                    case "23503":
                        Error_Msg("del fk street");
                        break;
                }
                e.Cancel = true;
            }
            if (result == 0)
            {
                Error_Msg("error");
                e.Cancel = true;
            }
            connection.Close();
        }

        //блок функций для операций в таблице Читатели

        private void DGV_Reader_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = DGV_Reader.Rows[e.RowIndex];

            if (e.RowIndex >= DB_DataSet.Tables["reader"].Rows.Count)
            {
                if (row.Cells["passport"].Value is DBNull || row.Cells["name"].Value is DBNull ||
                    row.Cells["telephone"].Value is DBNull || row.Cells["street"].Value is DBNull ||
                    row.Cells["house"].Value is DBNull || row.Cells["apartment"].Value is DBNull)
                    return;
            }

            if (!(row.Cells["passport"].Value is DBNull))
                if (row.Cells["passport"].Value.ToString().Length != 10)
                {
                    Error_Msg("invalid passport");
                    return;
                }

            if (!(row.Cells["telephone"].Value is DBNull))
                if (row.Cells["telephone"].Value.ToString().Length != 11)
                {
                    Error_Msg("invalid telephone");
                    return;
                }

            connection.Open();
            string cmd_text = "";
            if (e.RowIndex >= DB_DataSet.Tables["reader"].Rows.Count)
                cmd_text = "insert into reader (passport, name, telephone, street, house, apartment)" +
                    "values (@pass_value, @name_value, @tele_value, @stre_value, @hous_value, @apat_value)";
            else
                cmd_text = "update reader set passport = @pass_value, " +
                "name = @name_value, telephone = @tele_value, street = @stre_value," +
                "house = @hous_value, apartment = @apat_value, user_login = @user_value where number = @id_value";
            NpgsqlCommand update = new NpgsqlCommand(cmd_text, connection);
            update.Parameters.AddWithValue("@pass_value", row.Cells["passport"].Value);
            update.Parameters.AddWithValue("@name_value", row.Cells["name"].Value);
            update.Parameters.AddWithValue("@tele_value", row.Cells["telephone"].Value);
            update.Parameters.AddWithValue("@stre_value", row.Cells["street"].Value);
            update.Parameters.AddWithValue("@hous_value", row.Cells["house"].Value);
            update.Parameters.AddWithValue("@apat_value", row.Cells["apartment"].Value);
            update.Parameters.AddWithValue("@user_value", row.Cells["user_login"].Value);
            if (e.RowIndex < DB_DataSet.Tables["reader"].Rows.Count)
                update.Parameters.AddWithValue("@id_value", row.Cells["number"].Value);

            int result = -1;
            try
            {
                result = update.ExecuteNonQuery();
            }
            catch (PostgresException err)
            {
                switch (err.Code)
                {
                    case "23505":
                        Error_Msg("unique");
                        break;
                }
            }
            if (result == 0) Error_Msg("error");
            connection.Close();
        }

        private void DGV_Reader_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var row = e.Row;
            connection.Open();
            NpgsqlCommand delete = new NpgsqlCommand("delete from reader where number = @id_value", connection);
            delete.Parameters.AddWithValue("@id_value", row.Cells["number"].Value);

            if (delete.ExecuteNonQuery() == 0)
            {
                Error_Msg("error");
                e.Cancel = true;
            }
            connection.Close();
        }

        private void DGV_Reader_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var column = DGV_Reader.Columns[e.ColumnIndex].Name;
            var type = DB_DataSet.Tables["reader"].Columns[column].DataType.Name;
            Error_Msg(type);
        }

        //блок функций для операций в таблице Издательства

        private void DGV_Publisher_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = DGV_Publisher.Rows[e.RowIndex];

            if (e.RowIndex >= DB_DataSet.Tables["publisher"].Rows.Count)
            {
                if (row.Cells["name"].Value is DBNull)
                    return;
            }

            if (!(row.Cells["telephone"].Value is DBNull))
                if (row.Cells["telephone"].Value.ToString().Length != 11)
                {
                    Error_Msg("invalid telephone");
                    return;
                }

            connection.Open();

            string cmd_text = "";
            if (e.RowIndex >= DB_DataSet.Tables["publisher"].Rows.Count)
                cmd_text = "insert into publisher (name, telephone, street, house)" +
                    "values (@name_value, @tele_value, @stre_value, @hous_value)";
            else
                cmd_text = "update publisher set name = @name_value, " +
                "telephone = @tele_value, street = @stre_value, house = @hous_value where id = @id_value";
            NpgsqlCommand update = new NpgsqlCommand(cmd_text, connection);
            update.Parameters.AddWithValue("@name_value", row.Cells["name"].Value);
            update.Parameters.AddWithValue("@tele_value", row.Cells["telephone"].Value);
            update.Parameters.AddWithValue("@stre_value", row.Cells["street"].Value);
            update.Parameters.AddWithValue("@hous_value", row.Cells["house"].Value);
            if (e.RowIndex < DB_DataSet.Tables["publisher"].Rows.Count)
                update.Parameters.AddWithValue("@id_value", row.Cells["id"].Value);

            int result = -1;
            try
            {
                result = update.ExecuteNonQuery();
            }
            catch (PostgresException err)
            {
                switch (err.Code)
                {
                    case "23505":
                        Error_Msg("unique");
                        break;
                }
            }
            if (result == 0) Error_Msg("error");
            connection.Close();
        }

        private void DGV_Publisher_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var row = e.Row;
            connection.Open();
            NpgsqlCommand delete = new NpgsqlCommand("delete from publisher where id = @id_value", connection);
            delete.Parameters.AddWithValue("@id_value", row.Cells["id"].Value);

            int result = -1;
            try
            {
                result = delete.ExecuteNonQuery();
            }
            catch (PostgresException err)
            {
                switch (err.Code)
                {
                    case "23503":
                        Error_Msg("del fk publisher");
                        break;
                }
                e.Cancel = true;
            }
            if (result == 0)
            {
                Error_Msg("error");
                e.Cancel = true;
            }
            connection.Close();
        }

        private void DGV_Publisher_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var column = DGV_Publisher.Columns[e.ColumnIndex].Name;
            var type = DB_DataSet.Tables["publisher"].Columns[column].DataType.Name;
            Error_Msg(type);
        }

        //блок функций для операций в таблице Пользователи

        private void DGV_Users_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (admin)
            {
                var row = e.Row;
                connection.Open();
                NpgsqlCommand delete = new NpgsqlCommand("select delete_user (@user_name)", connection);
                delete.Parameters.AddWithValue("@user_name", row.Cells["usename"].Value);
                delete.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
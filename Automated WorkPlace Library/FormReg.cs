using System;
using System.Windows.Forms;
using static Automated_WorkPlace_Library.Functions;
using Npgsql;

namespace Automated_WorkPlace_Library
{
    public partial class FormReg : Form
    {
        public FormReg()
        {
            InitializeComponent();
        }

        private void FormReg_Load(object sender, EventArgs e)
        {

        }

        private void RegButton_Click(object sender, EventArgs e)
        {
           if (LoginCreate.Text == "" || PasswordCreate.Text == "" || PasswordRepeat.Text == "")
            {
                MessageBox.Show("Не введён логин или пароль");
                return;
            }
            
            if (PasswordCreate.Text != PasswordRepeat.Text)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            var temp_conn = ConnectToDB("postgres", "19kirill98");
            temp_conn.Open();

            //string sql_cmd = "create user @param_login with login password @param_pass in role normal_user";
            string cmd_text = "select new_user (@param_login, @param_pass)";
            //CREATE or replace FUNCTION new_user(varchar, varchar) RETURNS void AS $$
            //BEGIN
            //execute 'CREATE USER ' || quote_ident($1) || ' WITH LOGIN PASSWORD ' || quote_literal($2) || ' IN ROLE normal_user ';
           // END;
            //$$ language plpgsql;

            //create role normal_user;
            //grant select, insert, update, delete on all tables in schema public to normal_user;
            //create role admin_user with superuser login password 'admin_password';
            var command = new NpgsqlCommand(cmd_text, temp_conn);
            command.Parameters.AddWithValue("@param_login", LoginCreate.Text);
            command.Parameters.AddWithValue("@param_pass", PasswordCreate.Text);

            int result = command.ExecuteNonQuery();
            temp_conn.Close();
            if (result == 0)
            {
                MessageBox.Show("произошла ошибка при добавлении нового пользователя");
            }
            else
            {
                ((FormMain)Owner).connection = ConnectToDB(LoginCreate.Text, PasswordCreate.Text);
                try
                {
                    ((FormMain)Owner).connection.Open();
                    ((FormMain)Owner).connection.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("ОШИБКА! Проверьте правильность ввода логина и/или пароля");
                    return;
                }
                ((FormMain)Owner).login = LoginCreate.Text;
                ((FormMain)Owner).guest_mode = false;
                MessageBox.Show("Вы успешно зарегистрированы!");
                DialogResult = DialogResult.OK;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

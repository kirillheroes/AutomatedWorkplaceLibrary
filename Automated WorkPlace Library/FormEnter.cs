using System;
using System.Windows.Forms;
using System.Text;
using static Automated_WorkPlace_Library.Functions;
using Npgsql;

namespace Automated_WorkPlace_Library
{
    public partial class FormEnter : Form
    {
        public FormEnter()
        {
            InitializeComponent();
        }

        private void FormEnter_Load(object sender, EventArgs e)
        {

        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            if (LoginEnter.Text == "" || PasswordEnter.Text == "")
            {
                MessageBox.Show("Не введён логин или пароль");
                return;
            }

            ((FormMain)Owner).connection = ConnectToDB(LoginEnter.Text, PasswordEnter.Text);
            try
            {
                ((FormMain)Owner).connection.Open();
            }
            catch (Exception error)
            {
                MessageBox.Show("ОШИБКА! Проверьте правильность ввода логина и/или пароля");
                return;
            }
            string cmd_text = "select current_user";
            var command = new NpgsqlCommand(cmd_text, ((FormMain)Owner).connection);
            var reader = command.ExecuteReader(); string cur_user = "";
            while (reader.Read())
            {
                cur_user = Convert.ToString(reader["current_user"]);
            }
            ((FormMain)Owner).connection.Close();

            if (cur_user == "admin_user") ((FormMain)Owner).admin = true;
            
            MessageBox.Show("Вы успешно вошли в систему");
            ((FormMain)Owner).login = LoginEnter.Text;
            ((FormMain)Owner).guest_mode = false;
            DialogResult = DialogResult.OK;
        }

        private void checkBoxPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPassword.Checked)
                PasswordEnter.UseSystemPasswordChar = false;
            else
                PasswordEnter.UseSystemPasswordChar = true;
        }
    }
}

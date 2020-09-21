using System;
using System.Windows.Forms;
using static Automated_WorkPlace_Library.Functions;

namespace Automated_WorkPlace_Library
{
    public partial class FormAuth : Form
    {
        public FormAuth()
        {
            InitializeComponent();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (new FormEnter().ShowDialog(Owner) == DialogResult.OK)
                DialogResult = DialogResult.OK;
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            if (new FormReg().ShowDialog(Owner) == DialogResult.OK)
                DialogResult = DialogResult.OK;
        }

        private void buttonGuest_Click(object sender, EventArgs e)
        {
            ((FormMain)Owner).connection = ConnectToDB("guest_user", "guest_password");
            try
            {
                ((FormMain)Owner).connection.Open();
                ((FormMain)Owner).connection.Close();
            }
            catch (Exception error)
            {
                //ДОДЕЛАТЬ, слетела кодировка

                //string error_decoded = Encoding.GetEncoding(1251).GetString(Encoding.GetEncoding(866).GetBytes(error.Message));
                MessageBox.Show("ОШИБКА! Не удалось войти как гость! Сообщите об данной ошибке администраторуЁ " + error.Message);
                return;
            }
            DialogResult = DialogResult.OK;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Security.Cryptography;
using System.Text;

namespace Automated_WorkPlace_Library
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }

    public static class Functions
    {
        public static NpgsqlConnection ConnectToDB(string user, string pass)
        {
            string conn_str = new NpgsqlConnectionStringBuilder()
            {
                Host = "localhost",
                Port = 5432,
                Username = user,
                Password = pass,
                Database = "library"
            }.ConnectionString;
            return new NpgsqlConnection(conn_str);
        }
    }
}

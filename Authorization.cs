using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Modes;
using PersonalCard.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using ZstdSharp.Unsafe;

namespace PersonalCard
{
    public partial class Authorization : Form
    {
        public Authorization()
        {

            InitializeComponent();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConfigConnection cnf = ConfigReader.ReadConfig();
            MySqlConnection conn = new MySqlConnection(cnf.ToString());
            conn.Open();
            string sql = $"SELECT  * from `Users` where `login` = @login";
           
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@login", textBox1.Text);
            string connectionString="";
            string name="";
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    MessageBox.Show("Данные для входа неверны!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (reader.Read())
                {
                    if (!PwdHash.VerifyPassword(textBox2.Text, reader.GetString("password")))
                    {
                        MessageBox.Show("Данные для входа неверны!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (reader.GetInt32("lock") == 1)
                    {
                        MessageBox.Show("Пользователь заблокировани!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    connectionString= cnf.Server+cnf.Database+"UID="+reader.GetString("role") +";Pwd=;";
                    name = $"Пользователь {reader.GetString("Name")} {reader.GetString("LastName")}";
                }
            }
            conn.Close();
            MainWindow mainWindow = new MainWindow(connectionString,name);
            this.Hide();
            mainWindow.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Authorization_Load(object sender, EventArgs e)
        {
            ConfigConnection cc = ConfigReader.ReadConfig();
            if (checkDatabase() == false)
            {
                if (MessageBox.Show($"База данных c именем '{cc.Database.Substring(cc.Database.IndexOf('=') + 1, cc.Database.Substring(cc.Database.IndexOf('=')).Length - 2)}' отсутствует на сервере. Если база есть на сервере, нажмите отмена и проверьте соответствие имени в файле config.ini. Если вы хотите создать базу данных с таким именем, нажмите ок ",
                    "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    createDB();
                }
            }
        }



        private bool checkDatabase()
        {
            ConfigConnection cc = ConfigReader.ReadConfig();

            MySqlConnection conn = new MySqlConnection(cc.Server + cc.Uid + cc.Password);
            conn.Open();
            string sql = $"SHOW DATABASES";
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))

            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.GetString(0) == cc.Database.Substring(cc.Database.IndexOf('=') + 1, cc.Database.Substring(cc.Database.IndexOf('=')).Length - 2))
                        {
                            conn.Close();
                            return true;
                        }
                    }
                }

            }
            conn.Close();
            return false;
        }
        private void createPerson()
        {
            ConfigConnection cc = ConfigReader.ReadConfig();

            MySqlConnection conn = new MySqlConnection(cc.Server + cc.Uid + cc.Password);
            conn.Open();

            string sql = $"CREATE USER IF NOT EXISTS 'AdminHR'@'localhost' \r\nWITH MAX_QUERIES_PER_HOUR 0 \r\nMAX_CONNECTIONS_PER_HOUR 0 \r\nMAX_UPDATES_PER_HOUR 0 \r\nMAX_USER_CONNECTIONS 0;\r\n\r\nGRANT ALL PRIVILEGES ON {cc.Database.Substring(cc.Database.IndexOf('=') + 1, cc.Database.Substring(cc.Database.IndexOf('=')).Length - 2)}.* TO 'AdminHR'@'localhost';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            sql = $"CREATE USER IF NOT EXISTS 'ManagerHR'@'localhost'\r\nWITH MAX_QUERIES_PER_HOUR 0 \r\nMAX_CONNECTIONS_PER_HOUR 0 \r\nMAX_UPDATES_PER_HOUR 0 \r\nMAX_USER_CONNECTIONS 0;\r\n\r\nGRANT SELECT, INSERT, UPDATE, DELETE, EXECUTE \r\nON {cc.Database.Substring(cc.Database.IndexOf('=') + 1, cc.Database.Substring(cc.Database.IndexOf('=')).Length - 2)}.* TO 'ManagerHR'@'localhost';";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            sql = $"CREATE USER IF NOT EXISTS 'UserHR'@'localhost'\r\nWITH MAX_QUERIES_PER_HOUR 0 \r\nMAX_CONNECTIONS_PER_HOUR 0 \r\nMAX_UPDATES_PER_HOUR 0 \r\nMAX_USER_CONNECTIONS 0;\r\n\r\nGRANT SELECT, SHOW VIEW \r\nON {cc.Database.Substring(cc.Database.IndexOf('=') + 1, cc.Database.Substring(cc.Database.IndexOf('=')).Length - 2)}.* TO 'UserHR'@'localhost';";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        private void createDB()
        {
            ConfigConnection cc = ConfigReader.ReadConfig();

            MySqlConnection conn = new MySqlConnection(cc.Server + cc.Uid + cc.Password);
            conn.Open();

            string sql = $"Create database {cc.Database.Substring(cc.Database.IndexOf('=') + 1, cc.Database.Substring(cc.Database.IndexOf('=')).Length - 2)}";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            conn = new MySqlConnection(cc.ToString());
            conn.Open();
            sql =File.ReadAllText(@"..\..\..\Struct_Bd.txt");
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            sql = $"INSERT INTO `Users` (`id_User`, `Name`, `LastName`, `Surname`, `login`, `password`, `role`,`lock`) VALUES (NULL, 'admin', 'admin', 'admin', 'admin', '{PwdHash.HashPassword("admin")}', 'AdminHR',0); ";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            sql = "\r\nCREATE FUNCTION CalculateWorkExperience(\r\n    start_date DATE, \r\n    end_date DATE\r\n) \r\nRETURNS INT\r\nDETERMINISTIC\r\nBEGIN\r\n    DECLARE years_worked INT;\r\n    \r\n    IF end_date IS NULL THEN\r\n        SET end_date = CURDATE();\r\n    END IF;\r\n    \r\n    SET years_worked = TIMESTAMPDIFF(YEAR, start_date, end_date);\r\n    RETURN years_worked;\r\nEND;";
            cmd.CommandText=sql;
            cmd.ExecuteNonQuery();
            conn.Close();
            createPerson();
        }

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }
    }
}

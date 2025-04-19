using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalCard
{
    public partial class ListEmployee : Form
    {
        public ListEmployee()
        {
            InitializeComponent();
        }
        MySqlCommand cmd;
        int var = 0;
        string connection;
        Action<int> action;
        public ListEmployee(MySqlCommand cmd, int var, string connection, Action<int> action)
        {
            InitializeComponent();
            this.cmd = cmd;
            this.var = var;
            this.connection = connection;
            this.action = action;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListEmployee_Load(object sender, EventArgs e)
        {
            if (var == 0) { return; }
            dataGridView1.Columns.Clear();
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {

                if (var == 1)
                {

                    int a = 0;
                    dataGridView1.Columns.Add("clm0", "id");
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns.Add("clm1", "Фамилия");
                    dataGridView1.Columns.Add("clm2", "Имя");
                    dataGridView1.Columns.Add("clm3", "Дата приема на работу");
                    while (reader.Read())
                    {
                        GeneralInformation generalInformation = GeneralInformation.LoadAllEmployeeData(connection, reader.GetInt32(0));
                        if (MainWindow.HasData(generalInformation.Dismissal)) continue;
                        dataGridView1.Rows.Add(1);
                        dataGridView1.Rows[a].Cells[0].Value = reader.GetInt32(0);
                        dataGridView1.Rows[a].Cells[1].Value = reader.GetString(1);
                        dataGridView1.Rows[a].Cells[2].Value = reader.GetString(2);
                        dataGridView1.Rows[a].Cells[3].Value = reader.GetDateTime(3).ToString("dd.MM.yyyy");
                        a++;
                    }
                }
                else if (var == 2)
                {
                    int a = 0;
                    dataGridView1.Columns.Add("clm0", "id");
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns.Add("clm1", "Фамилия");
                    dataGridView1.Columns.Add("clm2", "Имя");
                    dataGridView1.Columns.Add("clm3", "Дата последней аттестации");
                    GeneralInformation emploee;
                    while (reader.Read())
                    {
                        DateTime dt = reader.GetDateTime(3);
                        emploee = GeneralInformation.LoadAllEmployeeData(connection, reader.GetInt32(0));
                        if (emploee.Certifications.Count != 0)
                        {
                            dt = emploee.Certifications[0].Date_att;
                            foreach (CertificationInf i in emploee.Certifications)
                            {
                                if (dt < i.Date_att) dt = i.Date_att;
                            }
                            if (dt > emploee.Hirring_date)
                            {
                                if (CalculateFullYears(dt, DateTime.Now) < 3) continue;
                            }
                            else
                            {
                                dt = emploee.Hirring_date;
                            }
                        }
                        dataGridView1.Rows.Add(1);
                        dataGridView1.Rows[a].Cells[0].Value = reader.GetInt32(0);
                        dataGridView1.Rows[a].Cells[1].Value = reader.GetString(1);
                        dataGridView1.Rows[a].Cells[2].Value = reader.GetString(2);
                        dataGridView1.Rows[a].Cells[3].Value = dt.ToString("dd.MM.yyyy");
                        a++;
                    }
                }
                else if (var == 3)
                {
                    int a = 0;
                    dataGridView1.Columns.Add("clm0", "id");
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns.Add("clm1", "Фамилия");
                    dataGridView1.Columns.Add("clm2", "Имя");
                    dataGridView1.Columns.Add("clm3", "Дата приема ");
                    dataGridView1.Columns.Add("clm4", "Дата увольнения ");
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(1);
                        dataGridView1.Rows[a].Cells[0].Value = reader.GetInt32(0);
                        dataGridView1.Rows[a].Cells[1].Value = reader.GetString(1);
                        dataGridView1.Rows[a].Cells[2].Value = reader.GetString(2);
                        dataGridView1.Rows[a].Cells[3].Value = reader.GetDateTime(3).ToString("dd.MM.yyyy");
                        dataGridView1.Rows[a].Cells[4].Value = reader.GetDateTime(4).ToString("dd.MM.yyyy");
                        a++;
                    }

                }
                else if (var == 4)
                {
                    int a = 0;
                    dataGridView1.Columns.Add("clm0", "id");
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns.Add("clm1", "Фамилия");
                    dataGridView1.Columns.Add("clm2", "Имя");
                    dataGridView1.Columns.Add("clm3", "Общий стаж");

                    GeneralInformation emploee;
                    while (reader.Read())
                    {
                        emploee = GeneralInformation.LoadAllEmployeeData(connection, reader.GetInt32(0));
                        dataGridView1.Rows.Add(1);
                        dataGridView1.Rows[a].Cells[0].Value = reader.GetInt32(0);
                        dataGridView1.Rows[a].Cells[1].Value = reader.GetString(1);
                        dataGridView1.Rows[a].Cells[2].Value = reader.GetString(2);
                        dataGridView1.Rows[a].Cells[3].Value = $"{emploee.WorkExperience.Common_year} {(emploee.WorkExperience.Common_year % 10 > 0 && emploee.WorkExperience.Common_year % 10 < 5 ? "год" : "лет")} " +
                            $"{emploee.WorkExperience.Common_month} {(emploee.WorkExperience.Common_month % 10 != 1 ? (emploee.WorkExperience.Common_month % 10 > 0 && emploee.WorkExperience.Common_month % 10 < 5 ? "месяцa" : "месяцев") : "месяц")} " +
                            $"{emploee.WorkExperience.Common_day} {(emploee.WorkExperience.Common_day % 10 != 1 ? (emploee.WorkExperience.Common_day % 10 > 1 && emploee.WorkExperience.Common_day % 10 < 5 ? "дня" : "дней") : "день")}";

                        a++;
                    }
                }
                else
                {
                    int a = 0;
                    dataGridView1.Columns.Add("clm0", "id");
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns.Add("clm1", "Фамилия");
                    dataGridView1.Columns.Add("clm2", "Имя");
                    dataGridView1.Columns.Add("clm3", "Кол-во несовершеннолетних детей");

                    GeneralInformation emploee;
                    while (reader.Read())
                    {
                        emploee = GeneralInformation.LoadAllEmployeeData(connection, reader.GetInt32(0));
                        dataGridView1.Rows.Add(1);
                        dataGridView1.Rows[a].Cells[0].Value = reader.GetInt32(0);
                        dataGridView1.Rows[a].Cells[1].Value = reader.GetString(1);
                        dataGridView1.Rows[a].Cells[2].Value = reader.GetString(2);
                        dataGridView1.Rows[a].Cells[3].Value = reader.GetInt32(3);
                        a++;
                    }
                }
            }
        }
        public static int CalculateFullYears(DateTime startDate, DateTime endDate)
        {
            int years = endDate.Year - startDate.Year;
            if (endDate.Month < startDate.Month ||
                (endDate.Month == startDate.Month && endDate.Day < startDate.Day))
            {
                years--;
            }
            return years < 0 ? 0 : years;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count == 0) {return; }
            action?.Invoke(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
            this.Close();
        }
    }
}

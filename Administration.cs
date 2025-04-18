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
    public partial class Administration : Form
    {
        string Connection;
        UserInf user;
        public Administration(string Connection)
        {
            InitializeComponent();
            this.Connection = Connection;
            fillTable();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserInf user = new UserInf();
            new AddUser(user, (UserInf user) =>
            {
                new UserRepository(Connection).Insert(user);
            }).ShowDialog();
            fillTable();
        }

        private void fillTable()
        {
            dataGridView1.Rows.Clear();
            MySqlConnection conn = new MySqlConnection(Connection);
            string sql = $"Select * from Users";
            MySqlCommand cmd = new(sql, conn);
            conn.Open();
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {

                int a = 0;
                while (reader.Read())
                {
                    if(reader.GetInt32("id_User")==1) continue;
                    dataGridView1.Rows.Add(1);
                    dataGridView1.Rows[a].Cells[0].Value = reader.GetInt32("id_User");
                    dataGridView1.Rows[a].Cells[1].Value = reader["LastName"].ToString();
                    dataGridView1.Rows[a].Cells[2].Value = reader["Name"].ToString();
                    dataGridView1.Rows[a].Cells[3].Value = reader["Surname"].ToString();
                    dataGridView1.Rows[a].Cells[4].Value = reader["role"].ToString();
                    a++;
                }

            }
            lookLockUser();
            conn.Close();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            new AddUser(user, (UserInf user) =>
            {
                new UserRepository(Connection).Update(user);
            }).ShowDialog();
            fillTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserInf user = UserInf.GetById(Connection, Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
            if (user.Lock != 0)
            {
                user.Lock = 0;
            }
            else
            {
                user.Lock = 1;
            }
            new UserRepository(Connection).Update(user);
            lookLockUser();
        }

        private void lookLockUser()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                user = UserInf.GetById(Connection, Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value));
                if (user.Lock != 0)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                    dataGridView1.Rows[i].DefaultCellStyle.SelectionBackColor = Color.LightCoral;
                }
                else
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Azure;
                    dataGridView1.Rows[i].DefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;
                }
            }
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            user = UserInf.GetById(Connection, Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Подтвердите удаление пользователя {user.LastName} {user.Name}", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel) return;
            new UserRepository(Connection).Delete(user.Id_User);
            fillTable();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            toolTip1.Show("Заблокированные пользователи подсвечиваются красным!", button4,  0, 0,2000);
        }
    }
}

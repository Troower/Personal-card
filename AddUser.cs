using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalCard
{
    public partial class AddUser : Form
    {
        UserInf user;
        Action<UserInf> action;
        public AddUser(UserInf user, Action<UserInf> action)
        {
            InitializeComponent();
            this.user = user;
            this.action = action;
            
            if (String.IsNullOrEmpty(user.LastName))
            {
                button1.Text = "Добавить";
                this.Text = "Добавить пользователя";
            }
            else { 
            this.Text = "Редактирование пользователя";
            }
            textBox1.Text = user.LastName;
            textBox2.Text = user.Name;
            textBox3.Text = user.Surname;
            textBox4.Text = user.Login;
            checkBox1.Checked = user.Lock == 1 ? true : false;
            comboBox1.Text = String.IsNullOrEmpty(user.Role) ? comboBox1.Text : user.Role;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || 
                String.IsNullOrEmpty(textBox2.Text) ||
                String.IsNullOrEmpty(textBox4.Text) ||
                String.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Заполните все необходимые поля!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите роль пользователю!", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!new Regex("^[a-zA-Z0-9]{6,}$").IsMatch(textBox5.Text))
            {
                MessageBox.Show("Пароль не соответсвует требованиям! Требования: цифры+латинские буквы, минимум 6 символов", "Ошибка",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            user.LastName = textBox1.Text;
            user.Name = textBox2.Text;
            user.Surname = textBox3.Text;
            user.Login = textBox4.Text;
            user.Password=PwdHash.HashPassword(textBox5.Text);
            user.Lock = checkBox1.Checked ? (short)1 : (short)0;
            user.Role=comboBox1.Text;
            action?.Invoke(user);
            MessageBox.Show("Операция прошла успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class Vacation : Form
    {
        VacationInf vacation;
        Action<VacationInf> action;
        public Vacation()
        {
            InitializeComponent();
        }
        public Vacation(VacationInf vacation, Action<VacationInf> action)
        {
            InitializeComponent();
            this.vacation = vacation;
            this.action = action;
            if (vacation.Period_work_start <= DateTime.MinValue)
            {
                button1.Text = "Добавить";
            }
            dateTimePicker2.Value = vacation.Period_work_end ?? DateTime.Now;
            dateTimePicker1.Value = vacation.Period_work_start > DateTime.MinValue ? vacation.Period_work_start : DateTime.Now;
            dateTimePicker4.Value = vacation.Date_end ?? DateTime.Now;
            dateTimePicker3.Value = vacation.Date_start > DateTime.MinValue ? vacation.Date_start : DateTime.Now;
            textBox1.Text = vacation.Type_vacation;
            textBox2.Text = vacation.Quantity_day.ToString();
            textBox3.Text = vacation.Reason;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 0;
            if (String.IsNullOrEmpty(textBox1.Text) ||
           String.IsNullOrEmpty(textBox2.Text) ||
           String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Заполните все необходимые поля!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dateTimePicker1.Value >= dateTimePicker2.Value)
            {
                MessageBox.Show("Начало рабочего периода должно быть раньше!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dateTimePicker3.Value >= dateTimePicker4.Value)
            {
                MessageBox.Show("Начало отпуска должно быть раньше!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Int32.TryParse(textBox2.Text, out a))
            {
                MessageBox.Show("Кол-во дней должно быть числом!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            vacation.Type_vacation = textBox1.Text;
            vacation.Quantity_day = a;
            vacation.Reason = textBox3.Text;
            vacation.Period_work_start = dateTimePicker1.Value;
            vacation.Period_work_end = dateTimePicker2.Value;
            vacation.Date_start = dateTimePicker3.Value;
            vacation.Date_end = dateTimePicker4.Value;
            action?.Invoke(vacation);
            MessageBox.Show("Операция прошла успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PersonalCard
{
    public partial class HiringTransfer : Form
    {
        HiringTransferInf hiringTransfer;
        Action<HiringTransferInf> action;
        public HiringTransfer()
        {
            InitializeComponent();
        }
        public HiringTransfer(HiringTransferInf hiringTransfer, Action<HiringTransferInf> action)
        {
            InitializeComponent();
            this.action = action;
            this.hiringTransfer = hiringTransfer;
            if(hiringTransfer.Date > DateTime.MinValue)
            {
                dateTimePicker1.Value = hiringTransfer.Date;
            }
            else
            {
                dateTimePicker1.Value = DateTime.Now;
                button1.Text = "Добавить";
            }
            textBox1.Text = hiringTransfer.Struct;
            textBox3.Text = hiringTransfer.Position_category;
            textBox4.Text = hiringTransfer.Tariff_rate.ToString();
            textBox5.Text = hiringTransfer.Reason;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal  a = 0;
            if (String.IsNullOrEmpty(textBox1.Text) ||
            String.IsNullOrEmpty(textBox3.Text) ||
            String.IsNullOrEmpty(textBox4.Text) ||
            String.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Заполните все необходимые поля!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(textBox4.Text, out a)) {
                MessageBox.Show("Тарифная ставка должна быть указанна числом без букв!", "Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            hiringTransfer.Date = dateTimePicker1.Value ;
            hiringTransfer.Struct = textBox1.Text ;
            hiringTransfer.Position_category = textBox3.Text ;
            hiringTransfer.Tariff_rate = a;
            hiringTransfer.Reason = textBox5.Text;
            action?.Invoke(hiringTransfer);
            MessageBox.Show("Операция прошла успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
        }
    }
}

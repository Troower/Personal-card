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
    public partial class Additional : Form
    {
        AdditionalInformationInf additional;
        Action<AdditionalInformationInf> action;
        public Additional()
        {
            InitializeComponent();
        }
        public Additional(AdditionalInformationInf additional, Action<AdditionalInformationInf> action)
        {
            InitializeComponent();
            this.additional = additional;
            this.action = action;
            if (String.IsNullOrEmpty(additional.Information)) button1.Text = "Добавить";
            else textBox1.Text = additional.Information;
        }
        public Additional(AdditionalInformationInf additional)
        {
            InitializeComponent();
            this.additional = additional;
            textBox1.Text = additional.Information;
            textBox1.Enabled=false;
            tableLayoutPanel1.Visible = false;
            this.Size = new System.Drawing.Size(this.Width, this.Height - tableLayoutPanel1.Height);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Заполните все необходимые поля!", "Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
          additional.Information=textBox1.Text;
            action?.Invoke(additional);
            MessageBox.Show("Операция прошла успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
        }
    }
}

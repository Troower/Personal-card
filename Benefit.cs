using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace PersonalCard
{
    public partial class Benefit : Form
    {
        SocialBenefitInf benefit;
        Action<SocialBenefitInf> action;
        public Benefit()
        {
            InitializeComponent();
        }
        public Benefit(SocialBenefitInf benefit)
        {
            InitializeComponent();
            dateTimePicker1.Value = benefit.Date_give_doc > DateTime.MinValue ? benefit.Date_give_doc : DateTime.Now;
            textBox1.Text = benefit.Name_benefit;
            textBox2.Text = benefit.Num_doc;
            textBox3.Text = benefit.Reason;
            dateTimePicker1.Enabled = false;
            textBox3 .Enabled = false;
            textBox1 .Enabled = false;  
            textBox2 .Enabled = false; 
            tableLayoutPanel1.Visible = false;
            this.Size = new System.Drawing.Size(this.Width, this.Height - tableLayoutPanel1.Height);
        }
        public Benefit(SocialBenefitInf benefit, Action<SocialBenefitInf> action)
        {
            InitializeComponent();
            this.benefit = benefit;
            this.action = action;
            if (benefit.Date_give_doc <= DateTime.MinValue)
            {
                button1.Text = "Добавить";
            }
            dateTimePicker1.Value = benefit.Date_give_doc > DateTime.MinValue ? benefit.Date_give_doc : DateTime.Now;
            textBox1.Text = benefit.Name_benefit;
            textBox2.Text = benefit.Num_doc;
            textBox3.Text = benefit.Reason;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) ||
           String.IsNullOrEmpty(textBox2.Text) ||
           String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Заполните все необходимые поля!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            benefit.Date_give_doc = dateTimePicker1.Value;
            benefit.Name_benefit = textBox1.Text;
            benefit.Num_doc = textBox2.Text;
            benefit.Reason = textBox3.Text;
            action?.Invoke(benefit);
            MessageBox.Show("Операция прошла успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
        }
    }
}

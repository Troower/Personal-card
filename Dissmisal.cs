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
    public partial class Dissmisal : Form
    {
        DismissalInf dismissal;
        Action<DismissalInf> action;
        public Dissmisal()
        {
            InitializeComponent();
        }
        public Dissmisal(DismissalInf dismissal, Action<DismissalInf> action)
        {
            InitializeComponent();
            this.dismissal = dismissal;
            this.action = action;
            textBox1.Text = dismissal.Reason;
            textBox2.Text = dismissal.Num_order;
            dateTimePicker1.Value = dismissal.Date_dismiss;
            dateTimePicker2.Value = dismissal.Date_order;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) ||
           String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Заполните все необходимые поля!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dismissal.Date_dismiss=dateTimePicker1.Value;
            dismissal.Date_order=dateTimePicker2.Value;
            dismissal.Reason=textBox1.Text;
            dismissal.Num_order=textBox2.Text;
            action?.Invoke(dismissal);
            MessageBox.Show("Операция прошла успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
        }
    }
}

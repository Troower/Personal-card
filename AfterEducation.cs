using Google.Protobuf.WellKnownTypes;
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
    public partial class AfterEducation : Form
    {
        AfterEducationInf afterEducation;
        Action<AfterEducationInf> action;
        public AfterEducation(AfterEducationInf afterEducation, Action<AfterEducationInf> action)
        {
            InitializeComponent();
            this.afterEducation = afterEducation;
            this.action = action;
            comboBox1.Text = afterEducation.Type_education;
            textBox7.Text = afterEducation.Name_organisation;
            textBox1.Text=afterEducation.Name_education_docAfter;
            textBox3.Text = afterEducation.Num_doc_education;
            dateTimePicker1.Value=afterEducation.Date_give_doc;
            textBox6.Text=afterEducation.Year_end.ToString();
            textBox5.Text = afterEducation.Direction_or_speciality;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

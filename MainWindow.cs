using MySql.Data.MySqlClient;
using System.Linq;

namespace PersonalCard
{
    public partial class MainWindow : Form
    {
        string connectionString;
        public MainWindow(string connectionString)
        {
            InitializeComponent();
            toolStripStatusLabel3.Alignment = ToolStripItemAlignment.Right;
            toolStripStatusLabel2.Alignment = ToolStripItemAlignment.Right;
            toolStripButton5.Text = "Настройки поиска и\n готовые списки";
            this.connectionString = connectionString;
            fillPersonTable();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem1_DropDownOpened(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).ForeColor = Color.Black;
        }

        private void toolStripMenuItem1_DropDownClosed(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).ForeColor = Color.White;
        }





        private void button2_Click(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = this.Width * 25 / 100;
            splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (splitContainer1.Panel1.Width < 250) splitContainer1.Panel1Collapsed = true;
        }


        private void button5_Click(object sender, EventArgs e)
        {
            new Sections((int a, int b, int c) =>
            {
                tabControl1.SelectTab(a);
                if (b == -1) return;
                if (b == 2) { tabControl2.SelectTab(c); return; }
                if (b == 3) { tabControl3.SelectTab(c); return; }
                if (b == 4) { tabControl4.SelectTab(c); return; }

            }).ShowDialog();

        }


        private void общиеСведенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);

        }
        private void сведенияОВоинскомУчетеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }
        private void приемПереводНаРаботуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);

        }
        private void кадровоеРазвитиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);

        }
        private void льготыОтпускаИНаградыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(4);

        }
        private void дополнительныеСведенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(5);

        }
        private void увольнениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(6);

        }




        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            splitContainer5.SplitterDistance = (splitContainer1.Panel1Collapsed ? this.Width - (this.Width * 15 / 100) : this.Width - (this.Width * 15 / 100) - splitContainer1.Panel1.Width);
            splitContainer5.Panel2Collapsed = !splitContainer5.Panel2Collapsed;
        }

        private void splitContainer5_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            splitContainer5.SplitterDistance = (splitContainer1.Panel1Collapsed ? this.Width - (this.Width * 15 / 100) : this.Width - (this.Width * 15 / 100) - splitContainer1.Panel1.Width);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            new ListEmployee().ShowDialog();
        }





        private void button1_Click(object sender, EventArgs e)
        {
            EditNavigation();
        }

        private void EditNavigation()
        {
            if (tabControl1.SelectedIndex == 0 && tabControl2.SelectedIndex == 0)
            {
                new EditPersonalInfo().ShowDialog();
                return;
            }
            if (tabControl1.SelectedIndex == 0 && tabControl2.SelectedIndex == 1)
            {
                new Education().ShowDialog();
                return;
            }
            if (tabControl1.SelectedIndex == 0 && tabControl2.SelectedIndex == 2)
            {
                new Profesion().ShowDialog();
                return;
            }
            if (tabControl1.SelectedIndex == 0 && tabControl2.SelectedIndex == 3)
            {
                new Family().ShowDialog();
                return;
            }
            if (tabControl1.SelectedIndex == 1)
            {
                new Military().ShowDialog();
                return;
            }
            if (tabControl1.SelectedIndex == 2)
            {
                new HiringTransfer().ShowDialog();
                return;
            }
            if (tabControl1.SelectedIndex == 3 && tabControl3.SelectedIndex == 0)
            {
                new Сertification().ShowDialog();
                return;
            }
            if (tabControl1.SelectedIndex == 3 && tabControl3.SelectedIndex == 1)
            {
                new AdvTraining().ShowDialog();
                return;
            }
            if (tabControl1.SelectedIndex == 3 && tabControl3.SelectedIndex == 2)
            {
                new ProfTraining().ShowDialog();
                return;
            }
            if (tabControl1.SelectedIndex == 4 && tabControl4.SelectedIndex == 0)
            {
                new Award().ShowDialog();
                return;
            }
            if (tabControl1.SelectedIndex == 4 && tabControl4.SelectedIndex == 1)
            {
                new Vacation().ShowDialog();
                return;
            }
            if (tabControl1.SelectedIndex == 4 && tabControl4.SelectedIndex == 2)
            {
                new Benefit().ShowDialog();
                return;
            }
            if (tabControl1.SelectedIndex == 5)
            {
                new Additional().ShowDialog();
                return;
            }
            if (tabControl1.SelectedIndex == 6)
            {
                new Dissmisal().ShowDialog();
                return;
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0 && tabControl2.SelectedIndex == 1 ||
                tabControl1.SelectedIndex == 0 && tabControl2.SelectedIndex == 3 ||
                tabControl1.SelectedIndex == 2 ||
                tabControl1.SelectedIndex == 3 ||
                 tabControl1.SelectedIndex == 4) button12.Visible = true;
            else button12.Visible = false;
        }

        private void управлениеПользователямиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Administration().ShowDialog();
        }

        private void основнаяИнформацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FAQ().ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new EditPersonalInfo(1).ShowDialog();
        }


        struct Person
        {
            public int id;
            public string name;
            public string lastName;
            public string surname;
            public string numCard;
        }

        private List<Person> giveAllPerson()
        {
            List<Person> AllPerson = new List<Person>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            string sql = $"Select `ID_empl`, `last_Name`, `Name`, `Surname`, `T_num_card` From `General_information`";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            Person person;
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    person = new Person();
                    person.id = reader.GetInt32(0);
                    person.name = reader.GetString(2);
                    person.lastName = reader.GetString(1);
                    person.surname = reader.GetString(3);
                    person.numCard = reader.GetString(4);
                    AllPerson.Add(person);
                }


            }
            conn.Close();
            return AllPerson;
        }

        private void fillPersonTable()
        {
            List<Person> persons = giveAllPerson();
            dataGridView1.Rows.Add(persons.Count);
            for (int i = 0; i < persons.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = persons[i].id;
                dataGridView1.Rows[i].Cells[1].Value = persons[i].lastName;
                dataGridView1.Rows[i].Cells[2].Value = persons[i].name;
                dataGridView1.Rows[i].Cells[3].Value = persons[i].surname;
                dataGridView1.Rows[i].Cells[4].Value = persons[i].numCard;
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            GeneralInformation generalInformation = GeneralInformation.LoadAllEmployeeData(connectionString, Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
            loadInformationUI(generalInformation);


        }

        private void loadInformationUI(GeneralInformation generalInformation)
        {
            //Личная информация
            label45.Text = generalInformation.Name;
            label44.Text = generalInformation.Last_name;
            label46.Text = generalInformation.Surname;
            label47.Text = generalInformation.Birthday.ToString().Split(' ')[0];
            label48.Text = generalInformation.Place_birth;
            label49.Text = generalInformation.Citizenship;
            label50.Text = generalInformation.Male_Female;
            label51.Text = generalInformation.Nature_work;
            label52.Text = generalInformation.Type_work;
            label53.Text = generalInformation.Nam_passport;
            label54.Text = generalInformation.Serial_passport;
            label55.Text = generalInformation.Date_give_passport.ToString().Split(' ')[0];
            label56.Text = generalInformation.Who_give;
            label57.Text = generalInformation.INN;
            label58.Text = generalInformation.Num_pensia;
            label59.Text = generalInformation.Address.Actual;
            label41.Text = generalInformation.Address.By_registration;
            label20.Text = $"Индекс: {generalInformation.Address.Index_actual}";
            label19.Text = $"Индекс: {generalInformation.Address.Index_by_register}";
            flowLayoutPanel7.Controls.Clear();
            foreach (LanguageInf l in generalInformation.Languages)
            {
                Label label = new Label();
                label.BackColor = Color.FromArgb(45, 50, 80);
                label.BorderStyle = BorderStyle.Fixed3D;
                label.AutoSize = true;
                label.Text = $"{l.Language_name} {l.Degree_of_knowledge}";
                label.ForeColor = Color.White;
                flowLayoutPanel7.Controls.Add(label);
            }

            //Образование
            dataGridView2.Rows.Clear();
            if (generalInformation.Educations.Count >= 1)
            {
                dataGridView2.Rows.Add(generalInformation.Educations.Count);

                for (int i = 0; i < generalInformation.Educations.Count; i++)
                {


                    dataGridView2.Rows[i].Cells[0].Value = generalInformation.Educations[i].Type_education;
                    dataGridView2.Rows[i].Cells[1].Value = generalInformation.Educations[i].Name_doc_education;
                    dataGridView2.Rows[i].Cells[2].Value = generalInformation.Educations[i].Serial_doc_education;
                    dataGridView2.Rows[i].Cells[3].Value = generalInformation.Educations[i].Num_doc_education;
                    dataGridView2.Rows[i].Cells[4].Value = generalInformation.Educations[i].Year_end.ToString().Split(' ')[0];
                    dataGridView2.Rows[i].Cells[5].Value = generalInformation.Educations[i].Qualification_doc_education;
                    dataGridView2.Rows[i].Cells[6].Value = generalInformation.Educations[i].Direction_or_specialty;
                }
            }
            if (HasData(generalInformation.AfterEducation))
            {
                dataGridView2.Rows.Add(1);
                dataGridView2.Rows[generalInformation.Educations.Count].Cells[0].Value = generalInformation.AfterEducation.Type_education;
                dataGridView2.Rows[generalInformation.Educations.Count].Cells[1].Value = generalInformation.AfterEducation.Name_education_docAfter;
                dataGridView2.Rows[generalInformation.Educations.Count].Cells[2].Value = generalInformation.AfterEducation.Serial_doc_education;
                dataGridView2.Rows[generalInformation.Educations.Count].Cells[3].Value = generalInformation.AfterEducation.Num_doc_education;
                dataGridView2.Rows[generalInformation.Educations.Count].Cells[4].Value = generalInformation.AfterEducation.Year_end.ToString().Split(' ')[0];
                dataGridView2.Rows[generalInformation.Educations.Count].Cells[6].Value = generalInformation.AfterEducation.Direction_or_speciality;
            }

            //Профессия
            label60.Text = generalInformation.Profession.Basic;
            label61.Text = generalInformation.Profession.Another;

            //Стаж
            if (HasData(generalInformation.WorkExperience))
            {
                if (generalInformation.WorkExperience.Common_day != 0) label64.Text = $"{generalInformation.WorkExperience.Common_day}D"; else label64.Text = $"0D";
                if (generalInformation.WorkExperience.Common_month != 0) label63.Text = $"{generalInformation.WorkExperience.Common_month}M"; else label63.Text = $"0M";
                if (generalInformation.WorkExperience.Common_year != 0) label62.Text = $"{generalInformation.WorkExperience.Common_year}Y"; else label62.Text = $"0Y";
                if (generalInformation.WorkExperience.Continuous_day != 0) label67.Text = $"{generalInformation.WorkExperience.Continuous_day}D"; else label67.Text = $"0D";
                if (generalInformation.WorkExperience.Continuous_month != 0) label66.Text = $"{generalInformation.WorkExperience.Continuous_month}M"; else label66.Text = $"0M";
                if (generalInformation.WorkExperience.Continuous_year != 0) label65.Text = $"{generalInformation.WorkExperience.Continuous_year}Y"; else label65.Text = $"0Y";
                if (generalInformation.WorkExperience.Giver_day != 0) label70.Text = $"{generalInformation.WorkExperience.Giver_day}D"; else label70.Text = $"0D";
                if (generalInformation.WorkExperience.Giver_month != 0) label69.Text = $"{generalInformation.WorkExperience.Giver_month}M"; else label69.Text = $"0M";
                if (generalInformation.WorkExperience.Giver_year != 0) label68.Text = $"{generalInformation.WorkExperience.Giver_year}Y"; else label68.Text = $"0Y";
            }
            else
            {
                label64.Text = $"0D"; label63.Text = $"0M"; label62.Text = $"0Y"; label67.Text = $"0D"; label66.Text = $"0M"; label65.Text = $"0Y"; label70.Text = $"0D"; label69.Text = $"0M"; label68.Text = $"0Y";
            }

            //Семья
            if (!String.IsNullOrEmpty(generalInformation.Marital_status)) label15.Text = $"Состояние в браке: {generalInformation.Marital_status}";
            else label15.Text = $"Состояние в браке: ";
            dataGridView3.Rows.Clear();
            if (generalInformation.FamilyCompositions.Count >= 1)
            {
                dataGridView3.Rows.Add(generalInformation.FamilyCompositions.Count);
                for (int i = 0; i < generalInformation.FamilyCompositions.Count; i++)
                {
                    dataGridView3.Rows[i].Cells[0].Value = generalInformation.FamilyCompositions[i].Degree_of_kinship;
                    dataGridView3.Rows[i].Cells[1].Value = generalInformation.FamilyCompositions[i].FIO;
                    dataGridView3.Rows[i].Cells[2].Value = generalInformation.FamilyCompositions[i].Date_birth.ToString().Split(' ')[0];
                }
            }

            //Воинский учет
            if (HasData(generalInformation.MilitaryRegistration))
            {
                label71.Text = generalInformation.MilitaryRegistration.Category;
                label72.Text = generalInformation.MilitaryRegistration.Military_rank;
                label73.Text = generalInformation.MilitaryRegistration.Structure;
                label74.Text = generalInformation.MilitaryRegistration.Code_mas;
                label75.Text = generalInformation.MilitaryRegistration.Category_life;
                label76.Text = generalInformation.MilitaryRegistration.Military_commissariat_name;
                label77.Text = generalInformation.MilitaryRegistration.Name_type;
                label78.Text = generalInformation.MilitaryRegistration.Additional_information;
                label79.Text = generalInformation.MilitaryRegistration.De_registration;

            }
            else
            {
                label71.Text = "";
                label72.Text = "";
                label73.Text = "";
                label74.Text = "";
                label75.Text = "";
                label76.Text = "";
                label77.Text = "";
                label78.Text = "";
                label79.Text = "";
            }

            //Прием\перевод
            dataGridView4.Rows.Clear();
            if (generalInformation.HiringTransfers.Count >= 1)
            {
                dataGridView4.Rows.Add(generalInformation.HiringTransfers.Count);
                for (int i = 0; i < generalInformation.HiringTransfers.Count; i++)
                {
                    dataGridView4.Rows[i].Cells[0].Value = generalInformation.HiringTransfers[i].Date.ToString().Split(' ')[0];
                    dataGridView4.Rows[i].Cells[1].Value = generalInformation.HiringTransfers[i].Struct;
                    dataGridView4.Rows[i].Cells[2].Value = generalInformation.HiringTransfers[i].Position_category;
                    dataGridView4.Rows[i].Cells[3].Value = generalInformation.HiringTransfers[i].Tariff_rate;
                    dataGridView4.Rows[i].Cells[4].Value = generalInformation.HiringTransfers[i].Reason;
                }
            }

            //Аттестация
            dataGridView6.Rows.Clear();
            if (generalInformation.Certifications.Count >= 1)
            {
                dataGridView6.Rows.Add(generalInformation.Certifications.Count);
                for (int i = 0; i < generalInformation.Certifications.Count; i++)
                {
                    dataGridView6.Rows[i].Cells[0].Value = generalInformation.Certifications[i].Date_att.ToString().Split(' ')[0];
                    dataGridView6.Rows[i].Cells[1].Value = generalInformation.Certifications[i].Decision;
                    dataGridView6.Rows[i].Cells[2].Value = generalInformation.Certifications[i].Num_doc;
                    dataGridView6.Rows[i].Cells[3].Value = generalInformation.Certifications[i].Date_doc.ToString().Split(' ')[0];
                    dataGridView6.Rows[i].Cells[4].Value = generalInformation.Certifications[i].Reason;
                }
            }

            //Повышение квалификации
            dataGridView5.Rows.Clear();
            if (generalInformation.ProfessionalDevelopments.Count >= 1)
            {
                dataGridView5.Rows.Add(generalInformation.ProfessionalDevelopments.Count);
                for (int i = 0; i < generalInformation.ProfessionalDevelopments.Count; i++)
                {
                    dataGridView5.Rows[i].Cells[0].Value = generalInformation.ProfessionalDevelopments[i].Date_start.ToString().Split(' ')[0];
                    dataGridView5.Rows[i].Cells[1].Value = generalInformation.ProfessionalDevelopments[i].Date_end.ToString().Split(' ')[0];
                    dataGridView5.Rows[i].Cells[2].Value = generalInformation.ProfessionalDevelopments[i].Type_cvalification;
                    dataGridView5.Rows[i].Cells[3].Value = generalInformation.ProfessionalDevelopments[i].Name_education_company;
                    dataGridView5.Rows[i].Cells[4].Value = generalInformation.ProfessionalDevelopments[i].Name_doc;
                    dataGridView5.Rows[i].Cells[5].Value = generalInformation.ProfessionalDevelopments[i].Ser_doc;
                    dataGridView5.Rows[i].Cells[6].Value = generalInformation.ProfessionalDevelopments[i].Date_give_doc.ToString().Split(' ')[0];
                    dataGridView5.Rows[i].Cells[7].Value = generalInformation.ProfessionalDevelopments[i].Reason;
                }
            }

            //Проф. переподготовка
            dataGridView7.Rows.Clear();
            if (generalInformation.ProfessionalRetrainings.Count >= 1)
            {
                dataGridView7.Rows.Add(generalInformation.ProfessionalRetrainings.Count);
                for (int i = 0; i < generalInformation.ProfessionalRetrainings.Count; i++)
                {
                    dataGridView7.Rows[i].Cells[0].Value = generalInformation.ProfessionalRetrainings[i].Date_start.ToString().Split(' ')[0];
                    dataGridView7.Rows[i].Cells[1].Value = generalInformation.ProfessionalRetrainings[i].Date_end.ToString().Split(' ')[0];
                    dataGridView7.Rows[i].Cells[2].Value = generalInformation.ProfessionalRetrainings[i].Speciality;
                    dataGridView7.Rows[i].Cells[3].Value = generalInformation.ProfessionalRetrainings[i].Name_doc;
                    dataGridView7.Rows[i].Cells[4].Value = generalInformation.ProfessionalRetrainings[i].Num_doc;
                    dataGridView7.Rows[i].Cells[5].Value = generalInformation.ProfessionalRetrainings[i].Date_give_doc.ToString().Split(' ')[0];
                    dataGridView7.Rows[i].Cells[6].Value = generalInformation.ProfessionalRetrainings[i].Reason;

                }
            }

            //Награды
            dataGridView9.Rows.Clear();
            if (generalInformation.Awards.Count >= 1)
            {
                dataGridView9.Rows.Add(generalInformation.Awards.Count);
                for (int i = 0; i < generalInformation.Awards.Count; i++)
                {
                    dataGridView9.Rows[i].Cells[0].Value = generalInformation.Awards[i].Name_reward;
                    dataGridView9.Rows[i].Cells[1].Value = generalInformation.Awards[i].Name_doc;
                    dataGridView9.Rows[i].Cells[2].Value = generalInformation.Awards[i].Num_doc;
                    dataGridView9.Rows[i].Cells[3].Value = generalInformation.Awards[i].Date_give_doc.ToString().Split(' ')[0];
                }
            }

            //Отпуска
            dataGridView8.Rows.Clear();
            if (generalInformation.Vacations.Count >= 1)
            {
                dataGridView8.Rows.Add(generalInformation.Vacations.Count);
                for (int i = 0; i < generalInformation.Vacations.Count; i++)
                {
                    dataGridView8.Rows[i].Cells[0].Value = generalInformation.Vacations[i].Type_vacation;
                    dataGridView8.Rows[i].Cells[1].Value = generalInformation.Vacations[i].Period_work_start.ToString().Split(' ')[0];
                    dataGridView8.Rows[i].Cells[2].Value = generalInformation.Vacations[i].Period_work_end == (DateTime?)null ? generalInformation.Vacations[i].Period_work_end : generalInformation.Vacations[i].Period_work_end.ToString().Split(' ')[0];
                    dataGridView8.Rows[i].Cells[3].Value = generalInformation.Vacations[i].Quantity_day;
                    dataGridView8.Rows[i].Cells[4].Value = generalInformation.Vacations[i].Date_start.ToString().Split(' ')[0];
                    dataGridView8.Rows[i].Cells[5].Value = generalInformation.Vacations[i].Date_end == (DateTime?)null ? generalInformation.Vacations[i].Date_end : generalInformation.Vacations[i].Date_end.ToString().Split(' ')[0];
                    dataGridView8.Rows[i].Cells[6].Value = generalInformation.Vacations[i].Reason;

                }
            }

            //Льготы
            dataGridView10.Rows.Clear();
            if (generalInformation.SocialBenefits.Count >= 1)
            {
                dataGridView10.Rows.Add(generalInformation.SocialBenefits.Count);
                for (int i = 0; i < generalInformation.SocialBenefits.Count; i++)
                {
                    dataGridView10.Rows[i].Cells[0].Value = generalInformation.SocialBenefits[i].Name_benefit;
                    dataGridView10.Rows[i].Cells[1].Value = generalInformation.SocialBenefits[i].Num_doc;
                    dataGridView10.Rows[i].Cells[2].Value = generalInformation.SocialBenefits[i].Date_give_doc.ToString().Split(' ')[0];
                    dataGridView10.Rows[i].Cells[3].Value = generalInformation.SocialBenefits[i].Reason;
                }
            }

            //Дополнительные сведения
            dataGridView11.Rows.Clear();
            if (generalInformation.AdditionalInformations.Count >= 1)
            {
                dataGridView11.Rows.Add(generalInformation.AdditionalInformations.Count);
                for (int i = 0; i < generalInformation.AdditionalInformations.Count; i++)
                {
                    dataGridView11.Rows[i].Cells[0].Value = generalInformation.AdditionalInformations[i].ID_mixing;
                    dataGridView11.Rows[i].Cells[1].Value = generalInformation.AdditionalInformations[i].Information;
                }

            }

            //Увольнение
            if (HasData(generalInformation.Dismissal)) {
                label40.Text = generalInformation.Dismissal.Reason;
                label80.Text =generalInformation.Dismissal.Date_dismiss.ToString().Split(' ')[0];
                label81.Text =generalInformation.Dismissal.Num_order;
                label82.Text =generalInformation.Dismissal.Date_order.ToString().Split(' ')[0];
            }
            else {
                label40.Text ="";
                label80.Text ="";
                label81.Text ="";
                label82.Text ="";
            }

        }

        public static bool HasData(object obj)
        {
            if (obj == null)
                return false;
            var type = obj.GetType();
            var properties = type.GetProperties();

            foreach (var property in properties)
            {

                if (property.Name == "ID_empl") continue;
                var value = property.GetValue(obj);
                if (value is string str && !string.IsNullOrEmpty(str)) return true;
                if (value is DateTime date && date != default(DateTime)) return true;
                if (value is int intValue && intValue != 0) return true;

            }
            return false;
        }

        
    }
}

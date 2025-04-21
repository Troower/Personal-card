using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Linq;
using Xceed.Document.NET;
using Xceed.Words.NET;
using ZstdSharp.Unsafe;

namespace PersonalCard
{
    public partial class MainWindow : Form
    {
        string connectionString;

        public MainWindow(string connectionString, string name, string role)
        {
            InitializeComponent();
            this.connectionString = connectionString;
            toolStripStatusLabel1.Text = name;
            controlRole(role);
            fillPersonTable();

        }

        private void controlRole(string role)
        {
            if (role == "UserHR")
            {
                администрированиеToolStripMenuItem.Visible = false;
                toolStripButton1.Visible = false;
                toolStripButton3.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton4.Visible = false;
                добапвитьСотрудникаToolStripMenuItem.Visible = false;
                редактироватьСотрудникаToolStripMenuItem.Visible = false;
                удалитьСотрудникаToolStripMenuItem.Visible = false;
                уволитьСотрудникаToolStripMenuItem.Visible = false;
                contextMenuStrip1.Enabled = false;
                contextMenuStrip2.Enabled = false;
                contextMenuStrip2.Visible = false;
                contextMenuStrip1.Visible = false;
                button4.Visible = false;
                button3.Visible = false;
                button11.Visible = false;
                button12.Enabled = false;
                button12.Dispose();
                button15.Visible = false;
                button13.Visible = false;
                button16.Visible = false;
                button17.Visible = false;
                button1.Visible = false;

            }
            else if (role == "ManagerHR")
            {
                администрированиеToolStripMenuItem.Visible = false;
            }
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

        //Переход секции
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







        private void button1_Click(object sender, EventArgs e)
        {
            EditNavigation();
        }

        private void AddNavigation()
        {
            //образование
            if (tabControl1.SelectedIndex == 0 && tabControl2.SelectedIndex == 1)
            {
                var inf = new EducationInf();
                new Education(inf, (EducationInf inf) =>
                {
                    inf.ID_empl = generalInformation.ID_empl;
                    new EducationRepository(connectionString).Insert(inf);
                }).ShowDialog();
                reLoadPerson();
            }
            //Семья
            if (tabControl1.SelectedIndex == 0 && tabControl2.SelectedIndex == 3)
            {
                var family = new FamilyCompositionInf();
                new Family(family, (FamilyCompositionInf family) =>
                {
                    family.ID_empl = generalInformation.ID_empl;
                    new FamilyCompositionRepository(connectionString).Insert(family);
                }).ShowDialog();
                reLoadPerson();
                return;
            }
            //Прием/Перевод на работу
            if (tabControl1.SelectedIndex == 2)
            {
                HiringTransferInf hiringTransfer = new HiringTransferInf();
                new HiringTransfer(hiringTransfer, (HiringTransferInf inf) =>
                {
                    inf.ID_empl = generalInformation.ID_empl;
                    new HiringTransferRepository(connectionString).Insert(inf);
                }).ShowDialog();
                reLoadPerson();
                return;
            }
            //Аттестация
            if (tabControl1.SelectedIndex == 3 && tabControl3.SelectedIndex == 0)
            {
                CertificationInf certification = new();
                new Сertification(certification, (CertificationInf cer) =>
                {
                    cer.ID_empl = generalInformation.ID_empl;
                    new CertificationRepository(connectionString).Insert(cer);
                }).ShowDialog();
                reLoadPerson();
                return;
            }
            //Повышение квалификации
            if (tabControl1.SelectedIndex == 3 && tabControl3.SelectedIndex == 1)
            {
                ProfessionalDevelopmentInf professional = new();
                new AdvTraining(professional, (ProfessionalDevelopmentInf prof) =>
                {
                    prof.ID_empl = generalInformation.ID_empl;
                    new ProfessionalDevelopmentRepository(connectionString).Insert(prof);
                }).ShowDialog();
                reLoadPerson();
                return;
            }
            //Проф. переподготовка
            if (tabControl1.SelectedIndex == 3 && tabControl3.SelectedIndex == 2)
            {
                ProfessionalRetrainingInf professional = new();
                new ProfTraining(professional, (ProfessionalRetrainingInf prof) =>
                {
                    prof.ID_empl = generalInformation.ID_empl;
                    new ProfessionalRetrainingRepository(connectionString).Insert(prof);
                }).ShowDialog();
                reLoadPerson();
                return;
            }
            //награды
            if (tabControl1.SelectedIndex == 4 && tabControl4.SelectedIndex == 0)
            {
                AwardInf award = new();
                new Award(award, (AwardInf award) =>
                {
                    award.ID_empl = generalInformation.ID_empl;
                    new AwardRepository(connectionString).Insert(award);
                }).ShowDialog();
                reLoadPerson();
                return;
            }
            //отпуск
            if (tabControl1.SelectedIndex == 4 && tabControl4.SelectedIndex == 1)
            {
                VacationInf vacation = new();
                new Vacation(vacation, (VacationInf vacation) =>
                {
                    vacation.ID_empl = generalInformation.ID_empl;
                    new VacationRepository(connectionString).Insert(vacation);
                }).ShowDialog();
                reLoadPerson();
                return;
            }
            //льготы
            if (tabControl1.SelectedIndex == 4 && tabControl4.SelectedIndex == 2)
            {
                SocialBenefitInf benefit = new();
                new Benefit(benefit, (SocialBenefitInf benefit) =>
                {
                    benefit.ID_empl = generalInformation.ID_empl;
                    new SocialBenefitRepository(connectionString).Insert(benefit);
                }).ShowDialog();
                reLoadPerson();
                return;
            }
            //дополнительные сведения
            if (tabControl1.SelectedIndex == 5)
            {
                AdditionalInformationInf additional = new();
                new Additional(additional, (AdditionalInformationInf additional) =>
                {
                    additional.ID_empl = generalInformation.ID_empl;
                    new AdditionalInformationRepository(connectionString).Insert(additional);
                }).ShowDialog();
                reLoadPerson();
                return;
            }


        }
        private void EditNavigation()
        {
            //основная информация
            if (tabControl1.SelectedIndex == 0 && tabControl2.SelectedIndex == 0)
            {
                new EditPersonalInfo(generalInformation, (GeneralInformation inf) =>
                {
                    new GeneralInformationRepository(connectionString).Update(inf);
                    MySqlConnection connection = new MySqlConnection(connectionString);
                    string sql = $"DELETE FROM Language WHERE ID_empl ={inf.ID_empl}";
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                    sql= $"DELETE FROM Address_Of_Residence WHERE ID_empl ={inf.ID_empl}";
                    cmd.CommandText=sql;
                    cmd.ExecuteNonQuery();
                    connection.Clone();
                    inf.Address.ID_empl = inf.ID_empl;
                    new AddressOfResidenceRepository(connectionString).Insert(inf.Address);
                    foreach (LanguageInf lg in inf.Languages)
                        new LanguageRepository(connectionString).Insert(lg);
                    
                }).ShowDialog();
                reLoadPerson();
                return;
            }
            //образование           
            if (tabControl1.SelectedIndex == 0 && tabControl2.SelectedIndex == 1)
            {
                foreach (EducationInf education in generalInformation.Educations)
                {
                    if (education.ID_education == Convert.ToUInt32(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[7].Value))
                    {
                        new Education(education, (EducationInf inf) =>
                        {
                            new EducationRepository(connectionString).Update(inf);
                        }).ShowDialog();
                        break;
                    }

                }
                reLoadPerson();
                return;
            }
            //Профессия+стаж
            if (tabControl1.SelectedIndex == 0 && tabControl2.SelectedIndex == 2)
            {
                new Profesion(generalInformation.Profession, generalInformation.WorkExperience, (ProfessionInf profession, WorkExperienceInf work) =>
                {
                    if (profession.ID_empl == 0)
                    {
                        profession.ID_empl = generalInformation.ID_empl;
                        new ProfessionRepository(connectionString).Insert(profession);
                    }
                    else
                    {
                        new ProfessionRepository(connectionString).Update(profession);
                    }
                    if (work.ID_empl == 0)
                    {
                        work.ID_empl = generalInformation.ID_empl;
                        new WorkExperienceRepository(connectionString).Insert(work);

                    }
                    else
                    {
                        new WorkExperienceRepository(connectionString).Update(work);
                    }

                }).ShowDialog();
                reLoadPerson();
                return;
            }

            //семья
            if (tabControl1.SelectedIndex == 0 && tabControl2.SelectedIndex == 3)
            {
                foreach (FamilyCompositionInf famaly in generalInformation.FamilyCompositions)
                {
                    if (famaly.ID_person == Convert.ToUInt32(dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[3].Value))
                    {
                        new Family(famaly, (FamilyCompositionInf family) =>
                        {
                            new FamilyCompositionRepository(connectionString).Update(family);
                        }).ShowDialog();
                        break;
                    }

                }
                reLoadPerson();
                return;
            }

            //Воинский учет
            if (tabControl1.SelectedIndex == 1)
            {
                if (HasData(generalInformation.MilitaryRegistration))
                {
                    new Military(generalInformation.MilitaryRegistration, (MilitaryRegistrationInf military) =>
                    {
                        new MilitaryRegistrationRepository(connectionString).Update(military);
                    }).ShowDialog();
                }
                else
                {
                    new Military(generalInformation.MilitaryRegistration, (MilitaryRegistrationInf military) =>
                    {
                        military.ID_empl = generalInformation.ID_empl;
                        new MilitaryRegistrationRepository(connectionString).Insert(military);
                    }).ShowDialog();

                }
                reLoadPerson();
                return;
            }

            //Прием/Перевод на работу
            if (tabControl1.SelectedIndex == 2)
            {
                foreach (HiringTransferInf hiring in generalInformation.HiringTransfers)
                {
                    if (hiring.ID_ht == Convert.ToUInt32(dataGridView4.Rows[dataGridView4.CurrentRow.Index].Cells[5].Value))
                    {
                        new HiringTransfer(hiring, (HiringTransferInf inf) =>
                        {
                            new HiringTransferRepository(connectionString).Update(inf);
                        }).ShowDialog();
                        break;
                    }
                }
                reLoadPerson();
                return;
            }

            //Атестация
            if (tabControl1.SelectedIndex == 3 && tabControl3.SelectedIndex == 0)
            {
                foreach (CertificationInf certification in generalInformation.Certifications)
                {
                    if (certification.ID_att == Convert.ToUInt32(dataGridView6.Rows[dataGridView6.CurrentRow.Index].Cells[5].Value))
                    {
                        new Сertification(certification, (CertificationInf cer) =>
                        {
                            new CertificationRepository(connectionString).Update(cer);
                        }).ShowDialog();
                        break;
                    }
                }
                reLoadPerson();
                return;
            }

            //Повышение квалификации
            if (tabControl1.SelectedIndex == 3 && tabControl3.SelectedIndex == 1)
            {
                foreach (ProfessionalDevelopmentInf professional in generalInformation.ProfessionalDevelopments)
                {
                    if (professional.ID_cval == Convert.ToUInt32(dataGridView5.Rows[dataGridView5.CurrentRow.Index].Cells[8].Value))
                    {
                        new AdvTraining(professional, (ProfessionalDevelopmentInf prof) =>
                        {
                            new ProfessionalDevelopmentRepository(connectionString).Update(prof);
                        }).ShowDialog();
                        break;
                    }
                }
                reLoadPerson();
                return;
            }
            //Проф. переподготовка
            if (tabControl1.SelectedIndex == 3 && tabControl3.SelectedIndex == 2)
            {
                foreach (ProfessionalRetrainingInf professional in generalInformation.ProfessionalRetrainings)
                {
                    if (professional.ID_retr == Convert.ToUInt32(dataGridView7.Rows[dataGridView7.CurrentRow.Index].Cells[7].Value))
                    {
                        new ProfTraining(professional, (ProfessionalRetrainingInf prof) =>
                        {
                            new ProfessionalRetrainingRepository(connectionString).Update(prof);
                        }).ShowDialog();
                        break;
                    }
                }
                reLoadPerson();
                return;

            }
            //награды
            if (tabControl1.SelectedIndex == 4 && tabControl4.SelectedIndex == 0)
            {
                foreach (AwardInf award in generalInformation.Awards)
                {
                    if (award.ID_reward == Convert.ToUInt32(dataGridView9.Rows[dataGridView9.CurrentRow.Index].Cells[4].Value))
                    {
                        new Award(award, (AwardInf award) =>
                        {
                            new AwardRepository(connectionString).Update(award);
                        }).ShowDialog();
                        break;
                    }
                }
                reLoadPerson();
                return;
            }

            //Отпуск
            if (tabControl1.SelectedIndex == 4 && tabControl4.SelectedIndex == 1)
            {
                foreach (VacationInf vacation in generalInformation.Vacations)
                {
                    if (vacation.ID_vac == Convert.ToUInt32(dataGridView8.Rows[dataGridView8.CurrentRow.Index].Cells[7].Value))
                    {
                        new Vacation(vacation, (VacationInf vacation) =>
                        {
                            new VacationRepository(connectionString).Update(vacation);
                        }).ShowDialog();
                        break;
                    }
                }
                reLoadPerson();
                return;
            }

            //льготы
            if (tabControl1.SelectedIndex == 4 && tabControl4.SelectedIndex == 2)
            {
                foreach (SocialBenefitInf benefit in generalInformation.SocialBenefits)
                {
                    if (benefit.ID_ben == Convert.ToUInt32(dataGridView10.Rows[dataGridView10.CurrentRow.Index].Cells[4].Value))
                    {
                        new Benefit(benefit, (SocialBenefitInf benefit) =>
                        {
                            new SocialBenefitRepository(connectionString).Update(benefit);
                        }).ShowDialog();
                        break;
                    }
                }
                reLoadPerson();
                return;
            }

            //дополнительные сведения
            if (tabControl1.SelectedIndex == 5)
            {
                foreach (AdditionalInformationInf additional in generalInformation.AdditionalInformations)
                {
                    if (additional.ID_mixing == Convert.ToUInt32(dataGridView11.Rows[dataGridView11.CurrentRow.Index].Cells[0].Value))
                    {
                        new Additional(additional, (AdditionalInformationInf additional) =>
                        {
                            new AdditionalInformationRepository(connectionString).Update(additional);
                        }).ShowDialog();
                        break;
                    }
                }
                reLoadPerson();
                return;
            }

            //Увольнение
            if (tabControl1.SelectedIndex == 6)
            {
                if (HasData(generalInformation.Dismissal))
                {
                    new Dissmisal(generalInformation.Dismissal, (DismissalInf dismissal) =>
                    {
                        new DismissalRepository(connectionString).Update(dismissal);
                    }).ShowDialog();
                    reLoadPerson();
                }
                else
                {
                    MessageBox.Show("Для редактирования сперва надо уволить сотрудника. Нажмите на кнопку увольнение которая находится на панели инструментов!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

        }

        private void DeleteNavigation()
        {
            //образование           
            if (tabControl1.SelectedIndex == 0 && tabControl2.SelectedIndex == 1)
            {
                foreach (EducationInf education in generalInformation.Educations)
                {
                    if (education.ID_education == Convert.ToUInt32(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[7].Value))
                    {
                        if (MessageBox.Show("Подтвердите удаление выделенной записи", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel) return;
                        new EducationRepository(connectionString).Delete(education.ID_education);
                        break;
                    }

                }
                reLoadPerson();
                return;
            }
            //семья
            if (tabControl1.SelectedIndex == 0 && tabControl2.SelectedIndex == 3)
            {
                foreach (FamilyCompositionInf famaly in generalInformation.FamilyCompositions)
                {
                    if (famaly.ID_person == Convert.ToUInt32(dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[3].Value))
                    {
                        if (MessageBox.Show("Подтвердите удаление выделенной записи", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel) return;
                        new FamilyCompositionRepository(connectionString).Delete(famaly.ID_person);
                        break;
                    }

                }
                reLoadPerson();
                return;
            }
            //Прием/Перевод на работу
            if (tabControl1.SelectedIndex == 2)
            {
                foreach (HiringTransferInf hiring in generalInformation.HiringTransfers)
                {
                    if (hiring.ID_ht == Convert.ToUInt32(dataGridView4.Rows[dataGridView4.CurrentRow.Index].Cells[5].Value))
                    {
                        if (MessageBox.Show("Подтвердите удаление выделенной записи", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel) return;
                        new HiringTransferRepository(connectionString).Delete(hiring.ID_ht);
                        break;
                    }
                }
                reLoadPerson();
                return;
            }
            //Атестация
            if (tabControl1.SelectedIndex == 3 && tabControl3.SelectedIndex == 0)
            {
                foreach (CertificationInf certification in generalInformation.Certifications)
                {
                    if (certification.ID_att == Convert.ToUInt32(dataGridView6.Rows[dataGridView6.CurrentRow.Index].Cells[5].Value))
                    {
                        if (MessageBox.Show("Подтвердите удаление выделенной записи", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel) return;
                        new CertificationRepository(connectionString).Delete(certification.ID_att);
                        break;
                    }
                }
                reLoadPerson();
                return;
            }
            //Повышение квалификации
            if (tabControl1.SelectedIndex == 3 && tabControl3.SelectedIndex == 1)
            {
                foreach (ProfessionalDevelopmentInf professional in generalInformation.ProfessionalDevelopments)
                {
                    if (professional.ID_cval == Convert.ToUInt32(dataGridView5.Rows[dataGridView5.CurrentRow.Index].Cells[8].Value))
                    {
                        if (MessageBox.Show("Подтвердите удаление выделенной записи", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel) return;
                        new ProfessionalDevelopmentRepository(connectionString).Delete(professional.ID_cval);
                        break;
                    }
                }
                reLoadPerson();
                return;
            }
            //Проф. переподготовка
            if (tabControl1.SelectedIndex == 3 && tabControl3.SelectedIndex == 2)
            {
                foreach (ProfessionalRetrainingInf professional in generalInformation.ProfessionalRetrainings)
                {
                    if (professional.ID_retr == Convert.ToUInt32(dataGridView7.Rows[dataGridView7.CurrentRow.Index].Cells[7].Value))
                    {
                        if (MessageBox.Show("Подтвердите удаление выделенной записи", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel) return;
                        new ProfessionalRetrainingRepository(connectionString).Delete(professional.ID_retr);
                        break;
                    }
                }
                reLoadPerson();
                return;

            }
            //награды
            if (tabControl1.SelectedIndex == 4 && tabControl4.SelectedIndex == 0)
            {
                foreach (AwardInf award in generalInformation.Awards)
                {
                    if (award.ID_reward == Convert.ToUInt32(dataGridView9.Rows[dataGridView9.CurrentRow.Index].Cells[4].Value))
                    {
                        if (MessageBox.Show("Подтвердите удаление выделенной записи", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel) return;
                        new AwardRepository(connectionString).Delete(award.ID_reward);
                        break;
                    }
                }
                reLoadPerson();
                return;
            }

            //Отпуск
            if (tabControl1.SelectedIndex == 4 && tabControl4.SelectedIndex == 1)
            {
                foreach (VacationInf vacation in generalInformation.Vacations)
                {
                    if (vacation.ID_vac == Convert.ToUInt32(dataGridView8.Rows[dataGridView8.CurrentRow.Index].Cells[7].Value))
                    {
                        if (MessageBox.Show("Подтвердите удаление выделенной записи", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel) return;
                        new VacationRepository(connectionString).Delete(vacation.ID_vac);
                        break;
                    }
                }
                reLoadPerson();
                return;
            }

            //льготы
            if (tabControl1.SelectedIndex == 4 && tabControl4.SelectedIndex == 2)
            {
                foreach (SocialBenefitInf benefit in generalInformation.SocialBenefits)
                {
                    if (benefit.ID_ben == Convert.ToUInt32(dataGridView10.Rows[dataGridView10.CurrentRow.Index].Cells[4].Value))
                    {
                        if (MessageBox.Show("Подтвердите удаление выделенной записи", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel) return;
                        new SocialBenefitRepository(connectionString).Delete(benefit.ID_ben);
                        break;
                    }
                }
                reLoadPerson();
                return;
            }

            //дополнительные сведения
            if (tabControl1.SelectedIndex == 5)
            {
                foreach (AdditionalInformationInf additional in generalInformation.AdditionalInformations)
                {
                    if (additional.ID_mixing == Convert.ToUInt32(dataGridView11.Rows[dataGridView11.CurrentRow.Index].Cells[0].Value))
                    {
                        if (MessageBox.Show("Подтвердите удаление выделенной записи", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel) return;
                        new AdditionalInformationRepository(connectionString).Delete(additional.ID_mixing);
                        break;
                    }
                }
                reLoadPerson();
                return;
            }

        }
        private void reLoadPerson()
        {
            generalInformation = GeneralInformation.LoadAllEmployeeData(connectionString, generalInformation.ID_empl);
            loadInformationUI(generalInformation);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0 && tabControl2.SelectedIndex == 1 ||
                tabControl1.SelectedIndex == 0 && tabControl2.SelectedIndex == 3 ||
                tabControl1.SelectedIndex == 2 ||
                tabControl1.SelectedIndex == 3 ||
                tabControl1.SelectedIndex == 4 ||
                tabControl1.SelectedIndex == 5) button12.Visible = true;
            else button12.Visible = false;
        }

        private void управлениеПользователямиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Administration(connectionString).ShowDialog();
        }

        private void основнаяИнформацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FAQ().ShowDialog();
        }

        //Транзакция
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            new EditPersonalInfo(1, (GeneralInformation general) =>
            {
                int idEm = 0;
                MySqlConnection connection = new(connectionString);
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var cmd = connection.CreateCommand();
                        cmd.Transaction = transaction;
                        new GeneralInformationRepository(connectionString).Insert(general, cmd);
                        cmd.CommandText = "SELECT LAST_INSERT_ID()";
                        idEm = Convert.ToInt32(cmd.ExecuteScalar());
                        general.ID_empl = idEm;
                        cmd.Parameters.Clear();
                        string sql = $"DELETE FROM Language WHERE ID_empl ={general.ID_empl}";
                        cmd.ExecuteNonQuery();
                        sql = $"DELETE FROM Address_Of_Residence WHERE ID_empl ={general.ID_empl}";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                        general.Address.ID_empl = general.ID_empl;
                        new AddressOfResidenceRepository(connectionString).Insert(general.Address,cmd);
                        cmd.Parameters.Clear();
                        foreach (LanguageInf lg in general.Languages) {
                            lg.ID_empl = general.ID_empl;
                            new LanguageRepository(connectionString).Insert(lg,cmd);
                            cmd.Parameters.Clear();
                        }
                        cmd.Parameters.Clear();
                        if (general.Profession != null)
                        {
                            general.Profession.ID_empl = general.ID_empl;
                            new ProfessionRepository(connectionString).Insert(general.Profession, cmd);
                            cmd.Parameters.Clear();
                            general.WorkExperience.ID_empl = general.ID_empl;
                            new WorkExperienceRepository(connectionString).Insert(general.WorkExperience, cmd);
                            cmd.Parameters.Clear();
                        }
                        if (general.SocialBenefits != null)
                        {
                            foreach (SocialBenefitInf i in general.SocialBenefits)
                            {
                                i.ID_empl = general.ID_empl;
                                new SocialBenefitRepository(connectionString).Insert(i, cmd);
                                cmd.Parameters.Clear();
                            }

                        }
                        if (general.Vacations != null)
                        {
                            foreach (VacationInf i in general.Vacations)
                            {
                                i.ID_empl = general.ID_empl;
                                new VacationRepository(connectionString).Insert(i, cmd);
                                cmd.Parameters.Clear();
                            }
                        }
                        if (general.MilitaryRegistration != null)
                        {
                            general.MilitaryRegistration.ID_empl = general.ID_empl;
                            new MilitaryRegistrationRepository(connectionString).Insert(general.MilitaryRegistration, cmd);
                            cmd.Parameters.Clear();
                        }
                        if (general.AfterEducation != null)
                        {
                            general.AfterEducation.ID_empl = general.ID_empl;
                            new AfterEducationRepository(connectionString).Insert(general.AfterEducation, cmd);
                            cmd.Parameters.Clear();
                        }
                        if (general.HiringTransfers != null)
                        {
                            foreach (HiringTransferInf i in general.HiringTransfers)
                            {
                                i.ID_empl = general.ID_empl;
                                new HiringTransferRepository(connectionString).Insert(i, cmd);
                                cmd.Parameters.Clear();
                            }
                        }
                        if (general.FamilyCompositions != null)
                        {
                            foreach (FamilyCompositionInf i in general.FamilyCompositions)
                            {
                                i.ID_empl = general.ID_empl;
                                new FamilyCompositionRepository(connectionString).Insert(i, cmd);
                                cmd.Parameters.Clear();
                            }
                        }
                        if (general.ProfessionalDevelopments != null)
                        {
                            foreach (ProfessionalDevelopmentInf i in general.ProfessionalDevelopments)
                            {
                                i.ID_empl = general.ID_empl;
                                new ProfessionalDevelopmentRepository(connectionString).Insert(i, cmd);
                                cmd.Parameters.Clear();
                            }
                        }
                        if (general.Educations != null)
                        {
                            foreach (EducationInf i in general.Educations)
                            {
                                i.ID_empl = general.ID_empl;
                                new EducationRepository(connectionString).Insert(i, cmd);
                                cmd.Parameters.Clear();
                            }
                        }
                        if (general.ProfessionalRetrainings != null)
                        {
                            foreach (ProfessionalRetrainingInf i in general.ProfessionalRetrainings)
                            {
                                i.ID_empl = general.ID_empl;
                                new ProfessionalRetrainingRepository(connectionString).Insert(i, cmd);
                                cmd.Parameters.Clear();
                            }
                        }
                        if (general.Certifications != null)
                        {
                            foreach (CertificationInf i in general.Certifications)
                            {
                                i.ID_empl = general.ID_empl;
                                new CertificationRepository(connectionString).Insert(i, cmd);
                                cmd.Parameters.Clear();
                            }
                        }
                        if (general.Awards != null)
                        {
                            foreach (AwardInf i in general.Awards)
                            {
                                i.ID_empl = general.ID_empl;
                                new AwardRepository(connectionString).Insert(i, cmd);
                                cmd.Parameters.Clear();
                            }
                        }
                        if (general.AdditionalInformations != null)
                        {
                            foreach (AdditionalInformationInf i in general.AdditionalInformations)
                            {
                                i.ID_empl = general.ID_empl;
                                new AdditionalInformationRepository(connectionString).Insert(i, cmd);
                                cmd.Parameters.Clear();
                            }
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); transaction.Rollback(); }
                }
                connection.Close();
            }).ShowDialog();
            fillPersonTable();
        }


        GeneralInformation generalInformation;
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
            string sql = $"Select `ID_empl`, `last_Name`, `Name`, `Surname`, `T_num_card` From `General_information` where {(radioButton1.Checked ? "Last_Name like @lastName" : "T_num_card like @numCard")}";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@lastName", $"%{toolStripTextBox1.Text}%");
            cmd.Parameters.AddWithValue("@numCard", $"%{toolStripTextBox1.Text}%");
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
            dataGridView1.Rows.Clear();
            List<Person> persons = giveAllPerson();
            if (persons.Count < 1) return;
            dataGridView1.Rows.Add(persons.Count);
            for (int i = 0; i < persons.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = persons[i].id;
                dataGridView1.Rows[i].Cells[1].Value = persons[i].lastName;
                dataGridView1.Rows[i].Cells[2].Value = persons[i].name;
                dataGridView1.Rows[i].Cells[3].Value = persons[i].surname;
                dataGridView1.Rows[i].Cells[4].Value = persons[i].numCard;
            }
            viewDismissedEmpl();
            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            fillPersonTable();
            if (dataGridView1.Rows.Count <= 0) return;
            generalInformation = GeneralInformation.LoadAllEmployeeData(connectionString, Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value));
            loadInformationUI(generalInformation);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            generalInformation = GeneralInformation.LoadAllEmployeeData(connectionString, Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
            loadInformationUI(generalInformation);


        }

        private void loadInformationUI(GeneralInformation generalInformation)
        {
            toolStripLabel2.Text = $"Сотрудник: {generalInformation.Name} {generalInformation.Last_name}";
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
            label92.Text = generalInformation.Number_phone;
            label94.Text = generalInformation.Hirring_date.ToString().Split(' ')[0];
            label20.Text = $"Индекс: {generalInformation.Address.Index_actual}";
            label19.Text = $"Индекс: {generalInformation.Address.Index_by_register}";
            flowLayoutPanel7.Controls.Clear();
            foreach (LanguageInf l in generalInformation.Languages)
            {
                Label label = new Label();
                label.BackColor = Color.FromArgb(45, 50, 80);
                label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                label.AutoSize = true;
                label.Text = $"{l.Language_name} - {l.Degree_of_knowledge}";
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
                    dataGridView2.Rows[i].Cells[4].Value = generalInformation.Educations[i].Year_end;
                    dataGridView2.Rows[i].Cells[5].Value = generalInformation.Educations[i].Qualification_doc_education;
                    dataGridView2.Rows[i].Cells[6].Value = generalInformation.Educations[i].Direction_or_specialty;
                    dataGridView2.Rows[i].Cells[7].Value = generalInformation.Educations[i].ID_education;
                }
            }


            label84.Text = generalInformation.AfterEducation.Type_education;
            label86.Text = generalInformation.AfterEducation.Name_education_docAfter;
            label88.Text = generalInformation.AfterEducation.Year_end.ToString().Split(' ')[0];
            label90.Text = generalInformation.AfterEducation.Direction_or_speciality;



            //Профессия

            label60.Text = generalInformation.Profession.Basic;
            label61.Text = generalInformation.Profession.Another;

            //Стаж
            if (HasData(generalInformation.WorkExperience))
            {
                if (generalInformation.WorkExperience.Common_day != 0) label64.Text = $"{generalInformation.WorkExperience.Common_day}\nДень"; else label64.Text = $"0\nДень";
                if (generalInformation.WorkExperience.Common_month != 0) label63.Text = $"{generalInformation.WorkExperience.Common_month}\nМесяц"; else label63.Text = $"0\nМесяц";
                if (generalInformation.WorkExperience.Common_year != 0) label62.Text = $"{generalInformation.WorkExperience.Common_year}\nГод"; else label62.Text = $"0\nГод";
                if (generalInformation.WorkExperience.Continuous_day != 0) label67.Text = $"{generalInformation.WorkExperience.Continuous_day}\nДень"; else label67.Text = $"0\nДень";
                if (generalInformation.WorkExperience.Continuous_month != 0) label66.Text = $"{generalInformation.WorkExperience.Continuous_month}\nМесяц"; else label66.Text = $"0\nМесяц";
                if (generalInformation.WorkExperience.Continuous_year != 0) label65.Text = $"{generalInformation.WorkExperience.Continuous_year}\nГод"; else label65.Text = $"0\nГод";
                if (generalInformation.WorkExperience.Giver_day != 0) label70.Text = $"{generalInformation.WorkExperience.Giver_day}\nДень"; else label70.Text = $"0\nДень";
                if (generalInformation.WorkExperience.Giver_month != 0) label69.Text = $"{generalInformation.WorkExperience.Giver_month}\nМесяц"; else label69.Text = $"0\nМесяц";
                if (generalInformation.WorkExperience.Giver_year != 0) label68.Text = $"{generalInformation.WorkExperience.Giver_year}\nГод"; else label68.Text = $"0\nГод";
            }
            else
            {
                label64.Text = $"0\nДень"; label63.Text = $"0\nМесяц"; label62.Text = $"0\nГод"; label67.Text = $"0\nДень"; label66.Text = $"0\nМесяц"; label65.Text = $"0\nГод"; label70.Text = $"0\nДень"; label69.Text = $"0\nМесяц"; label68.Text = $"0\nГод";
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
                    dataGridView3.Rows[i].Cells[3].Value = generalInformation.FamilyCompositions[i].ID_person;
                }
            }

            //Воинский учет

            label71.Text = generalInformation.MilitaryRegistration.Category;
            label72.Text = generalInformation.MilitaryRegistration.Military_rank;
            label73.Text = generalInformation.MilitaryRegistration.Structure;
            label74.Text = generalInformation.MilitaryRegistration.Code_mas;
            label75.Text = generalInformation.MilitaryRegistration.Category_life;
            label76.Text = generalInformation.MilitaryRegistration.Military_commissariat_name;
            label77.Text = generalInformation.MilitaryRegistration.Name_type;
            label78.Text = generalInformation.MilitaryRegistration.Additional_information;
            label79.Text = generalInformation.MilitaryRegistration.De_registration;




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
                    dataGridView4.Rows[i].Cells[5].Value = generalInformation.HiringTransfers[i].ID_ht;
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
                    dataGridView6.Rows[i].Cells[5].Value = generalInformation.Certifications[i].ID_att;
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
                    dataGridView5.Rows[i].Cells[8].Value = generalInformation.ProfessionalDevelopments[i].ID_cval;
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
                    dataGridView7.Rows[i].Cells[7].Value = generalInformation.ProfessionalRetrainings[i].ID_retr;
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
                    dataGridView9.Rows[i].Cells[4].Value = generalInformation.Awards[i].ID_reward;
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
                    dataGridView8.Rows[i].Cells[7].Value = generalInformation.Vacations[i].ID_vac;

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
                    dataGridView10.Rows[i].Cells[4].Value = generalInformation.SocialBenefits[i].ID_ben;
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
            if (HasData(generalInformation.Dismissal))
            {
                label40.Text = generalInformation.Dismissal.Reason;
                label80.Text = generalInformation.Dismissal.Date_dismiss.ToString().Split(' ')[0];
                label81.Text = generalInformation.Dismissal.Num_order;
                label82.Text = generalInformation.Dismissal.Date_order.ToString().Split(' ')[0];
            }
            else
            {

                label40.Text = "";
                label80.Text = "";
                label81.Text = "";
                label82.Text = "";
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

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (EducationInf education in generalInformation.Educations)
            {
                if (education.ID_education == Convert.ToUInt32(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[7].Value))
                {
                    new Education(education).Show();
                    break;
                }

            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            new AfterEducation(generalInformation.AfterEducation).Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (HasData(generalInformation.AfterEducation))
                new AfterEducation(generalInformation.AfterEducation, (AfterEducationInf after) =>
                {
                    new AfterEducationRepository(connectionString).Update(after);
                }).ShowDialog();
            else new AfterEducation(generalInformation.AfterEducation, (AfterEducationInf after) =>
            {
                after.ID_empl = generalInformation.ID_empl;
                new AfterEducationRepository(connectionString).Insert(after);
            }).ShowDialog();
            reLoadPerson();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            AddNavigation();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteNavigation();
        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (HiringTransferInf hiring in generalInformation.HiringTransfers)
            {
                if (hiring.ID_ht == Convert.ToUInt32(dataGridView4.Rows[dataGridView4.CurrentRow.Index].Cells[5].Value))
                {
                    new HiringTransfer(hiring).Show();
                    break;
                }
            }
        }

        private void dataGridView6_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (CertificationInf certification in generalInformation.Certifications)
            {
                if (certification.ID_att == Convert.ToUInt32(dataGridView6.Rows[dataGridView6.CurrentRow.Index].Cells[5].Value))
                {
                    new Сertification(certification).Show();
                    break;
                }
            }
        }

        private void dataGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (ProfessionalDevelopmentInf professional in generalInformation.ProfessionalDevelopments)
            {
                if (professional.ID_cval == Convert.ToUInt32(dataGridView5.Rows[dataGridView5.CurrentRow.Index].Cells[8].Value))
                {
                    new AdvTraining(professional).Show();
                    break;
                }
            }
        }

        private void dataGridView7_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (ProfessionalRetrainingInf professional in generalInformation.ProfessionalRetrainings)
            {
                if (professional.ID_retr == Convert.ToUInt32(dataGridView7.Rows[dataGridView7.CurrentRow.Index].Cells[7].Value))
                {
                    new ProfTraining(professional).Show();
                    break;
                }
            }
        }

        private void dataGridView9_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (AwardInf award in generalInformation.Awards)
            {
                if (award.ID_reward == Convert.ToUInt32(dataGridView9.Rows[dataGridView9.CurrentRow.Index].Cells[4].Value))
                {
                    new Award(award).Show();
                    break;
                }
            }
        }

        private void dataGridView8_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (VacationInf vacation in generalInformation.Vacations)
            {
                if (vacation.ID_vac == Convert.ToUInt32(dataGridView8.Rows[dataGridView8.CurrentRow.Index].Cells[7].Value))
                {
                    new Vacation(vacation).Show();
                    break;
                }
            }
        }

        private void dataGridView10_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (SocialBenefitInf benefit in generalInformation.SocialBenefits)
            {
                if (benefit.ID_ben == Convert.ToUInt32(dataGridView10.Rows[dataGridView10.CurrentRow.Index].Cells[4].Value))
                {
                    new Benefit(benefit).Show();
                    break;
                }
            }
        }

        private void dataGridView11_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (AdditionalInformationInf additional in generalInformation.AdditionalInformations)
            {
                if (additional.ID_mixing == Convert.ToUInt32(dataGridView11.Rows[dataGridView11.CurrentRow.Index].Cells[0].Value))
                {
                    new Additional(additional).Show();
                    break;
                }
            }
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (FamilyCompositionInf famaly in generalInformation.FamilyCompositions)
            {
                if (famaly.ID_person == Convert.ToUInt32(dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[3].Value))
                {
                    new Family(famaly).Show();
                    break;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = $"Время: {DateTime.Now.ToString("HH:mm")}";
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = $"Время: {DateTime.Now.ToString("HH:mm")}";
            toolStripStatusLabel2.Text = $"Дата: {DateTime.Now.ToString("dd.MM.yyyy")}";
            timer1.Start();
            toolStripStatusLabel3.Alignment = ToolStripItemAlignment.Right;
            toolStripStatusLabel2.Alignment = ToolStripItemAlignment.Right;
            toolStripButton5.Text = "Настройки поиска и\n готовые списки";

        }

        //удаление воиского учета
        private void button16_Click(object sender, EventArgs e)

        {
            if (HasData(generalInformation.MilitaryRegistration))
            {
                if (MessageBox.Show("Подтвердите удаление", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel) return;

                new MilitaryRegistrationRepository(connectionString).Delete(generalInformation.ID_empl);
            }
            reLoadPerson();
        }

        //удаление послевуз. образования
        private void button15_Click(object sender, EventArgs e)
        {
            if (HasData(generalInformation.AfterEducation))
            {

                if (MessageBox.Show("Подтвердите удаление", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel) { return; }
                new AfterEducationRepository(connectionString).Delete(generalInformation.ID_empl);
            }
            reLoadPerson();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

            if (HasData(generalInformation.Dismissal))
            {
                MessageBox.Show("Работник уже уволен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DismissalInf dismissal = new DismissalInf();
            new Dissmisal(dismissal, (DismissalInf dismissal) =>
            {
                dismissal.ID_empl = generalInformation.ID_empl;
                new DismissalRepository(connectionString).Insert(dismissal);
            }).ShowDialog();
            reLoadPerson();
            viewDismissedEmpl();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Подтвердите востановление сотрудника", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel) { return; }
            if (!HasData(generalInformation.Dismissal))
            {
                MessageBox.Show("Работник не уволен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            new DismissalRepository(connectionString).Delete(generalInformation.ID_empl);
            MessageBox.Show("Работник востановлен!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            viewDismissedEmpl();
        }

        private void viewDismissedEmpl()
        {
            DismissalInf dismissal;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dismissal = DismissalInf.GetByEmployeeId(connectionString, Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value));
                if (HasData(dismissal))
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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            new EditPersonalInfo(generalInformation, (GeneralInformation inf) =>
            {
                new GeneralInformationRepository(connectionString).Update(inf);
                MySqlConnection connection = new MySqlConnection(connectionString);
                string sql = $"DELETE FROM Language WHERE ID_empl ={inf.ID_empl}";
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Clone();
                foreach (LanguageInf lg in inf.Languages)
                    new LanguageRepository(connectionString).Insert(lg);
            }).ShowDialog();
            reLoadPerson();
            return;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = false;
            if (MessageBox.Show($"Подтвердите удаление сотрудника {generalInformation.Name} {generalInformation.Last_name}", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel) { return; }
            new GeneralInformationRepository(connectionString).Delete(generalInformation.ID_empl);
            fillPersonTable();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new(connectionString);
            string sql = $"Select ID_empl, Last_name, name, hirring_date from general_information where CalculateWorkExperience(hirring_date,now())>=3 and CalculateWorkExperience(hirring_date,now())";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            new ListEmployee(cmd, 2, connectionString, selectCard).ShowDialog();
            conn.Close();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new(connectionString);
            string sql = $"Select ID_empl, Last_name, name, hirring_date from general_information where CalculateWorkExperience(hirring_date,now())>=8";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            new ListEmployee(cmd, 1, connectionString, selectCard).ShowDialog();
            conn.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new(connectionString);
            string sql = $"Select general_information.ID_empl, Last_name, name, hirring_date, dismissal.date_dismiss from general_information inner join dismissal on general_information.id_empl=dismissal.id_empl where EXISTS (SELECT 1 FROM dismissal WHERE dismissal.id_empl = general_information.id_empl);";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            new ListEmployee(cmd, 3, connectionString, selectCard).ShowDialog();
            conn.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new(connectionString);
            string sql = $"Select general_information.ID_empl, Last_name, name from general_information inner join work_experience on general_information.id_empl=work_experience.id_empl where common_year>=25";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            new ListEmployee(cmd, 4, connectionString, selectCard).ShowDialog();
            conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new(connectionString);
            string sql = $"Select general_information.ID_empl, Last_name, name, count(family_composition.id_person) from general_information inner join family_composition on general_information.id_empl=family_composition.id_empl where CalculateWorkExperience(family_composition.date_birth,now())<18 GROUP BY general_information.ID_empl, general_information.Last_name, general_information.name;";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            new ListEmployee(cmd, 5, connectionString, selectCard).ShowDialog();
            conn.Close();
        }
        private void selectCard(int id)
        {
            toolStripTextBox1.Text = "";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value) == id)
                {
                    dataGridView1.Rows[i].Cells[1].Selected = true;
                    generalInformation = GeneralInformation.LoadAllEmployeeData(connectionString, Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
                    loadInformationUI(generalInformation);
                    tabControl1.SelectTab(0);
                    tabControl2.SelectTab(0);
                    return;
                }
                splitContainer1.Panel1Collapsed = false;
            }
        }

        private void созданиеРезервнойКопииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "SQL files (*.sql)|*.sql";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            string outFile = saveFileDialog1.FileName;
            ExportBD(connectionString, outFile);
        }
        private void восстановленияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "SQL files (*.sql)|*.sql";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            string inFile = openFileDialog1.FileName;
            ImportBD(connectionString, inFile);
        }

        private void ExportBD(string connectionString, string outfile)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                var export = new MySqlBackup(cmd);
                export.ExportInfo.AddCreateDatabase = false;
                export.ExportInfo.ExportTableStructure = true;
                export.ExportInfo.ExportRows = true;
                export.ExportInfo.ExportFunctions = true;
                export.ExportInfo.ExportProcedures = true;
                export.ExportToFile(outfile);
            }
        }
        private void ImportBD(string connectionString, string infile)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                ConfigConnection cc = ConfigReader.ReadConfig();
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                var import = new MySqlBackup(cmd);
                import.ImportInfo.IgnoreSqlError = true;
                import.ImportFromFile(infile);
                string sql = "\r\nDROP FUNCTION IF EXISTS CalculateWorkExperience ; CREATE FUNCTION CalculateWorkExperience(\r\n    start_date DATE, \r\n    end_date DATE\r\n) \r\nRETURNS INT\r\nDETERMINISTIC\r\nBEGIN\r\n    DECLARE years_worked INT;\r\n    \r\n    IF end_date IS NULL THEN\r\n        SET end_date = CURDATE();\r\n    END IF;\r\n    \r\n    SET years_worked = TIMESTAMPDIFF(YEAR, start_date, end_date);\r\n    RETURN years_worked;\r\nEND;";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                fillPersonTable();
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "doc file (*.docx)|*.docx";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return; 
            FillTemplate(generalInformation, saveFileDialog1.FileName);
        }
        public void FillTemplate(GeneralInformation employee,  string outputPath)
        {
            System.Globalization.CultureInfo russianCulture = new System.Globalization.CultureInfo("ru-RU");
            string templatePath = @"..\..\..\T2.docx";

            if (!File.Exists(templatePath))
                throw new FileNotFoundException($"Шаблон не найден.");

            // Загружаем документ
            using (var doc = DocX.Load(templatePath))
            {
                // Замена простых полей

                doc.ReplaceText("[lastName]", employee.Last_name);
                doc.ReplaceText("[name]", employee.Name);
                doc.ReplaceText("[surname]", employee.Surname ?? "");
                doc.ReplaceText("[dateBirth]", employee.Birthday.ToString("dd.MM.yyyy"));
                doc.ReplaceText("[placeBirth]", employee.Place_birth);
                doc.ReplaceText("[citynship]", employee.Citizenship);
                doc.ReplaceText("[dateCreate]", employee.Date_create_card.ToString("dd.MM.yyyy"));
                doc.ReplaceText("[numCard]", employee.T_num_card);
                doc.ReplaceText("[inn]", employee.INN);
                doc.ReplaceText("[snils]", employee.Num_pensia ?? "");
                doc.ReplaceText("[alf]", employee.First_char_lastname);
                doc.ReplaceText("[haracterWork]", employee.Nature_work);
                doc.ReplaceText("[typeWork]", employee.Type_work);
                doc.ReplaceText("[male]", employee.Male_Female);
                if (employee.Languages.Count == 0)
                {
                    doc.ReplaceText("[language]", "");
                    doc.ReplaceText("[lanExp]", "");
                    doc.ReplaceText("[language2]", "");
                    doc.ReplaceText("[lanExp2]", "");
                }
                else
                {
                    doc.ReplaceText("[language]", employee.Languages[0].Language_name);
                    doc.ReplaceText("[lanExp]", employee.Languages[0].Degree_of_knowledge);
                    doc.ReplaceText("[language2]", employee.Languages.Count == 1 ? "" : employee.Languages[1].Language_name);
                    doc.ReplaceText("[lanExp2]", employee.Languages.Count == 1 ? "" : employee.Languages[1].Language_name);
                }
                if (employee.Educations.Count == 0)
                {
                    doc.ReplaceText("[EducationType]", "");
                    doc.ReplaceText("[nameEducationOrg]", "");
                    doc.ReplaceText("[cvalAtEd]", "");
                    doc.ReplaceText("[nameDocEd]", "");
                    doc.ReplaceText("[seriaEd]", "");
                    doc.ReplaceText("[numEd]", "");
                    doc.ReplaceText("[yearEndEd]", "");
                    doc.ReplaceText("[specialityEd]", "");
                    doc.ReplaceText("[nameEducationOrg2]", "");
                    doc.ReplaceText("[cvalAtEd2]", "");
                    doc.ReplaceText("[nameDocEd2]", "");
                    doc.ReplaceText("[seriaEd2]", "");
                    doc.ReplaceText("[numEd2]", "");
                    doc.ReplaceText("[yearEndEd2]", "");
                    doc.ReplaceText("[specialityEd2]", "");
                }
                else
                {
                    doc.ReplaceText("[EducationType]", employee.Educations[0].Type_education);
                    doc.ReplaceText("[nameEducationOrg]", employee.Educations[0].Name_orgnisation);
                    doc.ReplaceText("[cvalAtEd]", employee.Educations[0].Qualification_doc_education);
                    doc.ReplaceText("[nameDocEd]", employee.Educations[0].Name_doc_education);
                    doc.ReplaceText("[seriaEd]", employee.Educations[0].Serial_doc_education);
                    doc.ReplaceText("[numEd]", employee.Educations[0].Num_doc_education);
                    doc.ReplaceText("[yearEndEd]", employee.Educations[0].Year_end.ToString());
                    doc.ReplaceText("[specialityEd]", employee.Educations[0].Direction_or_specialty);

                    doc.ReplaceText("[nameEducationOrg2]", employee.Educations.Count > 1 ? employee.Educations[1].Name_orgnisation : "");
                    doc.ReplaceText("[cvalAtEd2]", employee.Educations.Count > 1 ? employee.Educations[1].Qualification_doc_education : "");
                    doc.ReplaceText("[nameDocEd2]", employee.Educations.Count > 1 ? employee.Educations[1].Name_doc_education : "");
                    doc.ReplaceText("[seriaEd2]", employee.Educations.Count > 1 ? employee.Educations[1].Serial_doc_education : "");
                    doc.ReplaceText("[numEd2]", employee.Educations.Count > 1 ? employee.Educations[1].Num_doc_education : "");
                    doc.ReplaceText("[yearEndEd2]", employee.Educations.Count > 1 ? employee.Educations[1].Year_end.ToString() : "");
                    doc.ReplaceText("[specialityEd2]", employee.Educations.Count > 1 ? employee.Educations[1].Direction_or_specialty : "");

                }
                doc.ReplaceText("[AfterEducationType]",String.IsNullOrEmpty(employee.AfterEducation.Type_education)?"": employee.AfterEducation.Type_education);
                doc.ReplaceText("[nameAfterEducationOrg]", String.IsNullOrEmpty(employee.AfterEducation.Name_organisation) ? "" :employee.AfterEducation.Name_organisation);
                doc.ReplaceText("[nameDocAftEd]", String.IsNullOrEmpty(employee.AfterEducation.Name_education_docAfter) ? "" :employee.AfterEducation.Name_education_docAfter);
                doc.ReplaceText("[numAfterEduc]", String.IsNullOrEmpty(employee.AfterEducation.Num_doc_education) ? "" :employee.AfterEducation.Num_doc_education);
                doc.ReplaceText("[yearEndAfterEd]", employee.AfterEducation.Year_end==0 ? "" :employee.AfterEducation.Year_end.ToString());
                doc.ReplaceText("[specialityAfterEd]", String.IsNullOrEmpty(employee.AfterEducation.Direction_or_speciality) ? "" :employee.AfterEducation.Direction_or_speciality);


                doc.ReplaceText("[MainProfession]", String.IsNullOrEmpty(employee.Profession.Basic)?"":employee.Profession.Basic);
                doc.ReplaceText("[NoMainProfession]", String.IsNullOrEmpty(employee.Profession.Another)?"":employee.Profession.Another);

                if (employee.WorkExperience != null) { 
                doc.ReplaceText("[Common_day]", employee.WorkExperience.Common_day.ToString());
                doc.ReplaceText("[Common_month]", employee.WorkExperience.Common_month.ToString());
                doc.ReplaceText("[Common_year]", employee.WorkExperience.Common_year.ToString());
                doc.ReplaceText("[Continuous_day]", employee.WorkExperience.Continuous_day.ToString());
                doc.ReplaceText("[Continuous_month]", employee.WorkExperience.Continuous_month.ToString());
                doc.ReplaceText("[Continuous_year]", employee.WorkExperience.Continuous_year.ToString());
                doc.ReplaceText("[Giver_day]", employee.WorkExperience.Giver_day.ToString());
                doc.ReplaceText("[Giver_month]", employee.WorkExperience.Giver_month.ToString());
                doc.ReplaceText("[Giver_year]", employee.WorkExperience.Giver_year.ToString());
                }
                else
                {
                doc.ReplaceText("[Common_day]", "");
                doc.ReplaceText("[Common_month]", "");
                doc.ReplaceText("[Common_year]", "");
                doc.ReplaceText("[Continuous_day]", "");
                doc.ReplaceText("[Continuous_month]", "");
                doc.ReplaceText("[Continuous_year]", "");
                doc.ReplaceText("[Giver_day]", "");
                doc.ReplaceText("[Giver_month]", "");
                doc.ReplaceText("[Giver_year]", "");
                }
                doc.ReplaceText("[Marital_status]", employee.Marital_status);


                Table table = doc.Tables.FirstOrDefault(t =>
                 t.Rows.Any(r =>
                    r.Cells.Any(c =>
                      c.Paragraphs.Any(p => p.Text.Contains("[family_Composition]")))));
                if (employee.FamilyCompositions.Count == 0)
                {
                    table.RemoveRow(2);
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();
                }
                else
                {
                    if (table != null)
                    {
                        int a = 5;
                        table.RemoveRow(2);
                        foreach (var person in employee.FamilyCompositions)
                        {
                            var row = table.InsertRow();
                            row.Cells[0].Paragraphs[0].Append(person.Degree_of_kinship).FontSize(8);
                            row.Cells[1].Paragraphs[0].Append(person.FIO).FontSize(8);
                            row.Cells[2].Paragraphs[0].Append(person.Date_birth.ToString("dd.MM.yyyy")).FontSize(8);
                            a--;
                        }
                        while (a > 0)
                        {
                            table.InsertRow();
                            a--;
                        }
                    }
                }
                doc.ReplaceText("[Serial_passport]", employee.Serial_passport);
                doc.ReplaceText("[Num_passport]", employee.Nam_passport);
                doc.ReplaceText("[pass_day]", employee.Date_give_passport.Day.ToString());
                doc.ReplaceText("[pass_month]", employee.Date_give_passport.ToString("MMMM",russianCulture));
                doc.ReplaceText("[pass_year]", employee.Date_give_passport.ToString("yyyy"));
                doc.ReplaceText("[Who_give]", employee.Who_give);

                if (HasData(employee.Address)) { 
                doc.ReplaceText("[IndexReg]", employee.Address.Index_by_register);
                doc.ReplaceText("[Reg]", employee.Address.By_registration);
                doc.ReplaceText("[IndexAct]", employee.Address.Index_actual);
                doc.ReplaceText("[Act]", employee.Address.Actual);
                doc.ReplaceText("[reg_day]", employee.Address.Date_registration.Day.ToString());
                doc.ReplaceText("[reg_month]", employee.Address.Date_registration.ToString("MMMM", russianCulture));
                doc.ReplaceText("[reg_year]", employee.Address.Date_registration.ToString("yyyy"));
                }
                else
                {
                    doc.ReplaceText("[IndexReg]", "");
                    doc.ReplaceText("[Reg]", ".");
                    doc.ReplaceText("[IndexAct]", "");
                    doc.ReplaceText("[Act]", ".");
                    doc.ReplaceText("[reg_day]", "");
                    doc.ReplaceText("[reg_month]", "");
                    doc.ReplaceText("[reg_year]", "");
                }
                doc.ReplaceText("[NumberPhone]", employee.Number_phone);
                if (HasData(employee.MilitaryRegistration))
                {
                    doc.ReplaceText("[cat]", employee.MilitaryRegistration.Category);
                    doc.ReplaceText("[rang]", employee.MilitaryRegistration.Military_rank);
                    doc.ReplaceText("[struct]", employee.MilitaryRegistration.Structure);
                    doc.ReplaceText("[codems]", employee.MilitaryRegistration.Code_mas);
                    doc.ReplaceText("[catlife]", employee.MilitaryRegistration.Category_life);
                    doc.ReplaceText("[namecom]", employee.MilitaryRegistration.Military_commissariat_name);
                    doc.ReplaceText("[nametype]", employee.MilitaryRegistration.Name_type);
                    doc.ReplaceText("[metka]", employee.MilitaryRegistration.De_registration);
                }
                else
                {
                    doc.ReplaceText("[cat]", "");
                    doc.ReplaceText("[rang]", "");
                    doc.ReplaceText("[struct]", "");
                    doc.ReplaceText("[codems]", "");
                    doc.ReplaceText("[catlife]", "");
                    doc.ReplaceText("[namecom]", "");
                    doc.ReplaceText("[nametype]", "");
                    doc.ReplaceText("[metka]", "");
                }

                table = doc.Tables.FirstOrDefault(t =>
                t.Rows.Any(r =>
                   r.Cells.Any(c =>
                     c.Paragraphs.Any(p => p.Text.Contains("[hirringTr]")))));
                if (employee.HiringTransfers.Count == 0)
                {
                    table.RemoveRow(2);
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();
                }
                else
                {
                    if (table != null)
                    {
                        int a = 10;
                        table.RemoveRow(2);
                        foreach (var transfer in employee.HiringTransfers)
                        {
                            var row = table.InsertRow();
                            row.Cells[0].Paragraphs[0].Append(transfer.Date.ToString("dd.mm.yy")).FontSize(9);
                            row.Cells[1].Paragraphs[0].Append(transfer.Struct).FontSize(9);
                            row.Cells[2].Paragraphs[0].Append(transfer.Position_category).FontSize(9);
                            row.Cells[3].Paragraphs[0].Append(transfer.Tariff_rate.ToString()).FontSize(9);
                            row.Cells[4].Paragraphs[0].Append(transfer.Reason).FontSize(9);
                            row.Cells[5].Paragraphs[0].Append("").FontSize(9);
                            a--;
                        }
                        while (a > 0)
                        {
                            table.InsertRow();
                            a--;
                        }
                    }
                }


                table = doc.Tables.FirstOrDefault(t =>
                t.Rows.Any(r =>
                   r.Cells.Any(c =>
                     c.Paragraphs.Any(p => p.Text.Contains("[certif]")))));
                if (employee.Certifications.Count == 0)
                {
                    table.RemoveRow(3);
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();
                    
                }
                else
                {
                    if (table != null)
                    {
                        int a = 5;
                        table.RemoveRow(3);
                        foreach (var cr in employee.Certifications)
                        {
                            var row = table.InsertRow();
                            row.Cells[0].Paragraphs[0].Append(cr.Date_att.ToString("dd.MM.yy")).FontSize(8);
                            row.Cells[1].Paragraphs[0].Append(cr.Decision).FontSize(9);
                            row.Cells[2].Paragraphs[0].Append(cr.Num_doc).FontSize(9);
                            row.Cells[3].Paragraphs[0].Append(cr.Date_doc.ToString("dd.MM.yy")).FontSize(8);
                            row.Cells[4].Paragraphs[0].Append(cr.Reason).FontSize(9);
                            
                            a--;
                        }
                        while (a > 0)
                        {
                            table.InsertRow();
                            a--;
                        }
                    }
                }

                table = doc.Tables.FirstOrDefault(t =>
                t.Rows.Any(r =>
                   r.Cells.Any(c =>
                     c.Paragraphs.Any(p => p.Text.Contains("[profcval]")))));
                if (employee.ProfessionalDevelopments.Count == 0)
                {
                    table.RemoveRow(4);
                    table.InsertRow().MergeCells(5, 6); 
                    table.InsertRow().MergeCells(5, 6);
                    table.InsertRow().MergeCells(5, 6);
                    table.InsertRow().MergeCells(5, 6);
                    table.InsertRow().MergeCells(5, 6);

                }
                else
                {
                    if (table != null)
                    {
                        int a = 5;
                        table.RemoveRow(4);
                        foreach (var cr in employee.ProfessionalDevelopments)
                        {
                            var row = table.InsertRow();
                            row.Cells[0].Paragraphs[0].Append(cr.Date_start.ToString("dd.MM.yy")).FontSize(8);
                            row.Cells[1].Paragraphs[0].Append(cr.Date_end.ToString("dd.MM.yy")).FontSize(8);
                            row.Cells[2].Paragraphs[0].Append(cr.Type_cvalification).FontSize(8);
                            row.Cells[3].Paragraphs[0].Append(cr.Name_education_company).FontSize(8);
                            row.Cells[4].Paragraphs[0].Append(cr.Name_doc).FontSize(8);
                            row.Cells[5].Paragraphs[0].Append(cr.Num_doc+" "+cr.Ser_doc).FontSize(8);
                            row.Cells[7].Paragraphs[0].Append(cr.Date_give_doc.ToString("dd.MM.yy")).FontSize(8);
                            row.Cells[8].Paragraphs[0].Append(cr.Reason).FontSize(8);
                            row.MergeCells(5, 6);
                            a--;
                        }
                        while (a > 0)
                        {
                            table.InsertRow().MergeCells(5, 6);
                            a--;
                        }
                    }
                }

                table = doc.Tables.FirstOrDefault(t =>
                t.Rows.Any(r =>
                   r.Cells.Any(c =>
                     c.Paragraphs.Any(p => p.Text.Contains("[profper]")))));
                if (employee.ProfessionalRetrainings.Count == 0)
                {
                    table.RemoveRow(3);
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();

                }
                else
                {
                    if (table != null)
                    {
                        int a = 5;
                        table.RemoveRow(3);
                        foreach (var cr in employee.ProfessionalRetrainings)
                        {
                            var row = table.InsertRow();
                            row.Cells[0].Paragraphs[0].Append(cr.Date_start.ToString("dd.MM.yy")).FontSize(8);
                            row.Cells[1].Paragraphs[0].Append(cr.Date_end.ToString("dd.MM.yy")).FontSize(8);
                            row.Cells[2].Paragraphs[0].Append(cr.Speciality).FontSize(8);
                            row.Cells[3].Paragraphs[0].Append(cr.Name_doc).FontSize(8);
                            row.Cells[4].Paragraphs[0].Append(cr.Num_doc ).FontSize(8);
                            row.Cells[5].Paragraphs[0].Append(cr.Date_give_doc.ToString("dd.MM.yy")).FontSize(8);
                            row.Cells[6].Paragraphs[0].Append(cr.Reason).FontSize(8);
                            a--;
                        }
                        while (a > 0)
                        {
                            table.InsertRow();
                            a--;
                        }
                    }
                }

                table = doc.Tables.FirstOrDefault(t =>
                t.Rows.Any(r =>
                   r.Cells.Any(c =>
                     c.Paragraphs.Any(p => p.Text.Contains("[award]")))));
                if (employee.Awards.Count == 0)
                {
                    table.RemoveRow(3);
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();

                }
                else
                {
                    if (table != null)
                    {
                        int a = 5;
                        table.RemoveRow(3);
                        foreach (var cr in employee.Awards)
                        {
                            var row = table.InsertRow();
                            row.Cells[0].Paragraphs[0].Append(cr.Name_reward).FontSize(8);
                            row.Cells[1].Paragraphs[0].Append(cr.Name_doc).FontSize(8);
                            row.Cells[2].Paragraphs[0].Append(cr.Num_doc).FontSize(8);
                            row.Cells[3].Paragraphs[0].Append(cr.Date_give_doc.ToString("dd.MM.yy")).FontSize(8);
                            
                            a--;
                        }
                        while (a > 0)
                        {
                            table.InsertRow();
                            a--;
                        }
                    }
                }

                table = doc.Tables.FirstOrDefault(t =>
                t.Rows.Any(r =>
                   r.Cells.Any(c =>
                     c.Paragraphs.Any(p => p.Text.Contains("[vacation]")))));
                if (employee.Vacations.Count == 0)
                {
                    table.RemoveRow(3);
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();

                }
                else
                {
                    if (table != null)
                    {
                        int a = 10;
                        table.RemoveRow(3);
                        foreach (var cr in employee.Vacations)
                        {
                            var row = table.InsertRow();
                            row.Cells[0].Paragraphs[0].Append(cr.Type_vacation).FontSize(8);
                            row.Cells[1].Paragraphs[0].Append(cr.Period_work_start.ToString("dd.MM.yy")).FontSize(8);
                            row.Cells[2].Paragraphs[0].Append(cr.Period_work_end.ToString().Split(' ')[0] ??"").FontSize(8);
                            row.Cells[3].Paragraphs[0].Append(cr.Quantity_day.ToString()).FontSize(8);
                            row.Cells[4].Paragraphs[0].Append(cr.Date_start.ToString("dd.MM.yy")).FontSize(8);
                            row.Cells[5].Paragraphs[0].Append(cr.Date_end.ToString().Split(' ')[0] ?? "").FontSize(8);
                            row.Cells[6].Paragraphs[0].Append(cr.Reason).FontSize(8);
                            a--;
                        }
                        while (a > 0)
                        {
                            table.InsertRow();
                            a--;
                        }
                    }
                }

                table = doc.Tables.FirstOrDefault(t =>
               t.Rows.Any(r =>
                  r.Cells.Any(c =>
                    c.Paragraphs.Any(p => p.Text.Contains("[benefit]")))));
                if (employee.SocialBenefits.Count == 0)
                {
                    table.RemoveRow(3);
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();
                    table.InsertRow();

                }
                else
                {
                    if (table != null)
                    {
                        int a = 5;
                        table.RemoveRow(3);
                        foreach (var cr in employee.SocialBenefits)
                        {
                            var row = table.InsertRow();
                            row.Cells[0].Paragraphs[0].Append(cr.Name_benefit).FontSize(8);
                            row.Cells[1].Paragraphs[0].Append(cr.Num_doc).FontSize(8);
                            row.Cells[2].Paragraphs[0].Append(cr.Date_give_doc.ToString("dd.MM.yy")).FontSize(8);
                            row.Cells[3].Paragraphs[0].Append(cr.Reason).FontSize(8);

                            a--;
                        }
                        while (a > 0)
                        {
                            table.InsertRow();
                            a--;
                        }
                    }
                }
                table = doc.Tables.FirstOrDefault(t =>
              t.Rows.Any(r =>
                 r.Cells.Any(c =>
                   c.Paragraphs.Any(p => p.Text.Contains("[addit]")))));
                if (employee.AdditionalInformations.Count == 0)
                {
                    table.InsertRow();
                    table.RemoveRow(0);
                    table.InsertRow();
                    table.InsertRow();
                }
                else
                {
                    if (table != null)
                    {
                        int a = 5;
                        int i = 1;
                        var rowo = table.InsertRow();
                        rowo.Cells[0].Paragraphs[0].Append(employee.AdditionalInformations[0].Information).FontSize(8);
                        table.RemoveRow(0);
                        foreach (var cr in employee.AdditionalInformations)
                        {
                            if (i-- == 1) continue;
                            var row = table.InsertRow();
                            row.Cells[0].Paragraphs[0].Append(cr.Information).FontSize(8);
                            a--;
                        }
                        while (a > 0)
                        {
                            table.InsertRow();
                            a--;
                        }
                    }
                }

                if (HasData(employee.Dismissal))
                {
                    doc.ReplaceText("[resDis]", employee.Dismissal.Reason);
                    doc.ReplaceText("[dis_d]", employee.Dismissal.Date_dismiss.Day.ToString());
                    doc.ReplaceText("[dis_m]", employee.Dismissal.Date_dismiss.ToString("MMMM", russianCulture));
                    doc.ReplaceText("[dis_y]", employee.Dismissal.Date_dismiss.ToString("yy"));
                    doc.ReplaceText("[numOrder]", employee.Dismissal.Num_order);
                    doc.ReplaceText("[ord_d]", employee.Dismissal.Date_order.Day.ToString());
                    doc.ReplaceText("[ord_m]", employee.Dismissal.Date_order.ToString("MMMM", russianCulture));
                    doc.ReplaceText("[ord_y]", employee.Dismissal.Date_order.ToString("yy"));
                }
                else
                {
                    doc.ReplaceText("[resDis]", "");
                    doc.ReplaceText("[dis_d]", "");
                    doc.ReplaceText("[dis_m]", "");
                    doc.ReplaceText("[dis_y]", "");
                    doc.ReplaceText("[numOrder]", "");
                    doc.ReplaceText("[ord_d]", "");
                    doc.ReplaceText("[ord_m]", "");
                    doc.ReplaceText("[ord_y]", "");
                }




                doc.SaveAs(outputPath);
            }
        }
    }
}

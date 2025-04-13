using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.IsisMtt.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCard
{
    public class GeneralInformation
    {
        public int ID_empl { get; set; }
        public string Last_name { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Place_birth { get; set; }
        public string Citizenship { get; set; }
        public string Marital_status { get; set; }
        public string Nam_passport { get; set; }
        public string Serial_passport { get; set; }
        public DateTime Date_give_passport { get; set; }
        public string Who_give { get; set; }
        public string Number_phone { get; set; }
        public DateTime Date_create_card { get; set; }
        public string T_num_card { get; set; }
        public string INN { get; set; }
        public string Num_pensia { get; set; }
        public string First_char_lastname { get; set; }
        public string Nature_work { get; set; }
        public string Type_work { get; set; }
        public string Male_Female { get; set; }
        public AddressOfResidenceInf Address { get; set; }
        public AfterEducationInf AfterEducation { get; set; }
        public List<AwardInf> Awards { get; set; }
        public List<CertificationInf> Certifications { get; set; }
        public DismissalInf Dismissal { get; set; }
        public List<EducationInf> Educations { get; set; }
        public List<FamilyCompositionInf> FamilyCompositions { get; set; }
        public List<HiringTransferInf> HiringTransfers { get; set; }
        public List<LanguageInf> Languages { get; set; }
        public MilitaryRegistrationInf MilitaryRegistration { get; set; }
        public ProfessionInf Profession { get; set; }
        public List<ProfessionalDevelopmentInf> ProfessionalDevelopments { get; set; }
        public List<ProfessionalRetrainingInf> ProfessionalRetrainings { get; set; }
        public List<SocialBenefitInf> SocialBenefits { get; set; }
        public List<VacationInf> Vacations { get; set; }
        public WorkExperienceInf WorkExperience { get; set; }
        public List<AdditionalInformationInf> AdditionalInformations { get; set; }

        public static GeneralInformation LoadAllEmployeeData(string connectionString, int employeeId)
        {
            var employee = new GeneralInformation();

            
            employee = GeneralInformation.GetById(connectionString, employeeId);
            if (employee == null) return null;

           
            employee.Address = AddressOfResidenceInf.GetByEmployeeId(connectionString, employeeId);
            employee.Awards = AwardInf.GetByEmployeeId(connectionString, employeeId);
            employee.Educations = EducationInf.GetByEmployeeId(connectionString, employeeId);
            employee.FamilyCompositions = FamilyCompositionInf.GetByEmployeeId(connectionString, employeeId);
            employee.Certifications = CertificationInf.GetByEmployeeId(connectionString, employeeId);
            employee.Vacations = VacationInf.GetByEmployeeId(connectionString, employeeId);
            employee.HiringTransfers = HiringTransferInf.GetByEmployeeId(connectionString, employeeId);
            employee.MilitaryRegistration = MilitaryRegistrationInf.GetByEmployeeId(connectionString, employeeId);
            employee.Profession = ProfessionInf.GetByEmployeeId(connectionString, employeeId);
            employee.WorkExperience = WorkExperienceInf.GetByEmployeeId(connectionString, employeeId);
            employee.AdditionalInformations = AdditionalInformationInf.GetByEmployeeId(connectionString, employeeId);
            employee.AfterEducation = AfterEducationInf.GetByEmployeeId(connectionString, employeeId);
            employee.Languages = LanguageInf.GetByEmployeeId(connectionString, employeeId);
            employee.ProfessionalDevelopments = ProfessionalDevelopmentInf.GetByEmployeeId(connectionString, employeeId);
            employee.ProfessionalRetrainings = ProfessionalRetrainingInf.GetByEmployeeId(connectionString, employeeId);
            employee.SocialBenefits = SocialBenefitInf.GetAllByEmployee(connectionString, employeeId);
            employee.Dismissal = DismissalInf.GetByEmployeeId(connectionString, employeeId);

            return employee;
        }
        public static GeneralInformation GetById(string connectionString, int id)
        {
            var employee = new GeneralInformation();
            string query = "SELECT * FROM General_information WHERE ID_empl = @ID";

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        employee.ID_empl = id;
                        employee.Last_name = reader["Last_name"].ToString();
                        employee.Name = reader["Name"].ToString();
                        employee.Surname = reader["Surname"]?.ToString();
                        employee.Birthday = reader.GetDateTime("Birthday");
                        employee.Place_birth = reader["Place_birth"].ToString();
                        employee.Citizenship = reader["citizenship"].ToString();
                        employee.Marital_status = reader["marital_status"].ToString();
                        employee.Nam_passport = reader["nam_passport"].ToString();
                        employee.Serial_passport = reader["serial_passport"].ToString();
                        employee.Date_give_passport = reader.GetDateTime("date_give_passport");
                        employee.Who_give = reader["who_give"]?.ToString();
                        employee.Number_phone = reader["number_phone"].ToString();
                        employee.Date_create_card = reader.GetDateTime("Date_create_card");
                        employee.T_num_card = reader["T_num_card"].ToString();
                        employee.INN = reader["INN"].ToString();
                        employee.Num_pensia = reader["Num_pensia"]?.ToString();
                        employee.First_char_lastname = reader["First_char_lastname"].ToString();
                        employee.Nature_work = reader["Nature_work"].ToString();
                        employee.Type_work = reader["Type_work"].ToString();
                        employee.Male_Female = reader["Male_Female"].ToString();
                    }
                }
            }
            return employee;
        }
    }

    public class AddressOfResidenceInf
    {
        public int ID_empl { get; set; }
        public string By_registration { get; set; }
        public string Actual { get; set; }
        public string Index_by_register { get; set; }
        public string Index_actual { get; set; }
        public DateTime Date_registration { get; set; }

        public static AddressOfResidenceInf GetByEmployeeId(string connectionString, int employeeId)
        {
            var address = new AddressOfResidenceInf();
            string query = "SELECT * FROM address_of_residence WHERE ID_empl = @ID";

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ID", employeeId);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        address.By_registration = reader["by_registration"].ToString();
                        address.Actual = reader["actual"].ToString();
                        address.Index_by_register = reader["Index_by_register"].ToString();
                        address.Index_actual = reader["index_actual"].ToString();
                        address.Date_registration = reader.GetDateTime("date_registration");
                        address.ID_empl = employeeId;
                    }
                }
            }
            return address;
        }


    }

    public class AfterEducationInf
    {
        public int ID_empl { get; set; }
        public string Name_organisation { get; set; }
        public string Name_education_docAfter { get; set; }
        public string Serial_doc_education { get; set; }
        public string Num_doc_education { get; set; }
        public DateTime Year_end { get; set; }
        public DateTime Date_give_doc { get; set; }
        public string Direction_or_speciality { get; set; }
        public string Type_education { get; set; }

        public static AfterEducationInf GetByEmployeeId(string connectionString, int employeeId)
        {
            var afterEducation = new AfterEducationInf();
            string query = "SELECT * FROM After_Education WHERE ID_empl = @ID";

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ID", employeeId);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        afterEducation.Name_organisation = reader["Name_organisation"].ToString();
                        afterEducation.Name_education_docAfter = reader["Name_education_docAfter"].ToString();
                        afterEducation.Serial_doc_education = reader["Serial_doc_education"].ToString();
                        afterEducation.Num_doc_education = reader["Num_doc_education"].ToString();
                        afterEducation.Year_end = reader.GetDateTime("Year_end");
                        afterEducation.Date_give_doc = reader.GetDateTime("Date_give_doc");
                        afterEducation.Direction_or_speciality = reader["Direction_or_speciality"].ToString();
                        afterEducation.Type_education = reader["Type_education"].ToString();
                        afterEducation.ID_empl = employeeId;
                    }
                }
            }
            return afterEducation;
        }


    }

    public class AwardInf
    {
        public int ID_reward { get; set; }
        public int ID_empl { get; set; }
        public string Name_reward { get; set; }
        public string Name_doc { get; set; }
        public string Num_doc { get; set; }
        public DateTime Date_give_doc { get; set; }

        public static List<AwardInf> GetByEmployeeId(string connectionString, int employeeId)
        {
            var awards = new List<AwardInf>();
            string query = "SELECT * FROM awards WHERE ID_empl = @ID";

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ID", employeeId);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        awards.Add(new AwardInf
                        {
                            Name_reward = reader["Name_reward"].ToString(),
                            Name_doc = reader["Name_doc"].ToString(),
                            Num_doc = reader["Num_doc"].ToString(),
                            Date_give_doc = reader.GetDateTime("Date_give_doc"),
                            ID_reward = Convert.ToInt32(reader["ID_reward"]),
                            ID_empl = employeeId
                        });
                    }
                }
            }
            return awards;
        }
    }

    public class CertificationInf
    {
        public int ID_att { get; set; }
        public int ID_empl { get; set; }
        public string Decision { get; set; }
        public string Num_doc { get; set; }
        public DateTime Date_doc { get; set; }
        public string Reason { get; set; }
        public DateTime Date_att { get; set; }

        public static List<CertificationInf> GetByEmployeeId(string connectionString, int employeeId)
        {
            var certifications = new List<CertificationInf>();
            string query = "SELECT * FROM certification WHERE ID_empl = @ID";

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ID", employeeId);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        certifications.Add(new CertificationInf
                        {
                            ID_att = Convert.ToInt32(reader["ID_att"]),
                            Decision = reader["Decision"].ToString(),
                            Num_doc = reader["Num_doc"].ToString(),
                            Date_doc = reader.GetDateTime("Date_doc"),
                            Reason = reader["Reason"].ToString(),
                            Date_att = reader.GetDateTime("Date_att"),
                            ID_empl = employeeId
                        });
                    }
                }
            }
            return certifications;
        }


    }

    public class DismissalInf
    {
        public int ID_empl { get; set; }
        public DateTime Date_dismiss { get; set; }
        public string Num_order { get; set; }
        public DateTime Date_order { get; set; }
        public string Reason { get; set; }

        public static DismissalInf GetByEmployeeId(string connectionString, int employeeId)
        {
            var dismissal = new DismissalInf();
            string query = "SELECT * FROM dismissal WHERE ID_empl = @ID";

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ID", employeeId);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dismissal.Date_dismiss = reader.GetDateTime("Date_dismiss");
                        dismissal.Num_order = reader["Num_order"].ToString();
                        dismissal.Date_order = reader.GetDateTime("Date_order");
                        dismissal.Reason = reader["Reason"].ToString();
                        dismissal.ID_empl = employeeId;
                    }
                }
            }
            return dismissal;
        }

    }

    public class EducationInf
    {
        public int ID_education { get; set; }
        public int ID_empl { get; set; }
        public string Name_orgnisation { get; set; }
        public string Name_doc_education { get; set; }
        public string Serial_doc_education { get; set; }
        public string Num_doc_education { get; set; }
        public int Year_end { get; set; }
        public string Qualification_doc_education { get; set; }
        public string Direction_or_specialty { get; set; }
        public string Code_OKSO { get; set; }
        public string Type_education { get; set; }

        public static List<EducationInf> GetByEmployeeId(string connectionString, int employeeId)
        {
            var educations = new List<EducationInf>();
            string query = "SELECT * FROM Education WHERE ID_empl = @ID";

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ID", employeeId);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        educations.Add(new EducationInf
                        {
                            ID_education = Convert.ToInt32(reader["ID_education"]),
                            Name_orgnisation = reader["Name_orgnisation"].ToString(),
                            Name_doc_education = reader["Name_doc_education"].ToString(),
                            Serial_doc_education = reader["Serial_doc_education"].ToString(),
                            Num_doc_education = reader["Num_doc_education"].ToString(),
                            Year_end = Convert.ToInt32(reader["Year_end"]),
                            Qualification_doc_education = reader["Qualification_doc_education"].ToString(),
                            Direction_or_specialty = reader["direction_or_specialty"].ToString(),
                            Code_OKSO = reader["Code_OKSO"].ToString(),
                            Type_education = reader["Type_education"].ToString(),
                            ID_empl = employeeId
                        });
                    }
                }
            }
            return educations;
        }


    }

    public class FamilyCompositionInf
    {
        public int ID_person { get; set; }
        public int ID_empl { get; set; }
        public string FIO { get; set; }
        public string Degree_of_kinship { get; set; }
        public DateTime Date_birth { get; set; }

        public static List<FamilyCompositionInf> GetByEmployeeId(string connectionString, int employeeId)
        {
            var family = new List<FamilyCompositionInf>();
            string query = "SELECT * FROM family_composition WHERE ID_empl = @ID";

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ID", employeeId);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        family.Add(new FamilyCompositionInf
                        {
                            FIO = reader["FIO"].ToString(),
                            Degree_of_kinship = reader["Degree_of_kinship"].ToString(),
                            Date_birth = reader.GetDateTime("date_birth"),
                            ID_person = Convert.ToInt32(reader["ID_person"]),
                            ID_empl = employeeId
                        });
                    }
                }
            }
            return family;
        }


    }

    public class HiringTransferInf
    {
        public int ID_ht { get; set; }
        public int ID_empl { get; set; }
        public DateTime Date { get; set; }
        public string Struct { get; set; }
        public string Position_category { get; set; }
        public decimal Tariff_rate { get; set; }
        public string Reason { get; set; }

        public static List<HiringTransferInf> GetByEmployeeId(string connectionString, int employeeId)
        {
            var transfers = new List<HiringTransferInf>();
            string query = "SELECT * FROM hiring_transfer WHERE ID_empl = @ID";

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ID", employeeId);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transfers.Add(new HiringTransferInf
                        {
                            ID_empl = employeeId,
                            ID_ht = Convert.ToInt32(reader["ID_ht"]),
                            Date = reader.GetDateTime("Date"),
                            Struct = reader["Struct"].ToString(),
                            Position_category = reader["position_category"].ToString(),
                            Tariff_rate = reader.GetDecimal("Tariff_rate"),
                            Reason = reader["Reason"].ToString()
                        });
                    }
                }
            }
            return transfers;
        }


    }

    public class LanguageInf
    {
        public int ID_language { get; set; }
        public int ID_empl { get; set; }
        public string Language_name { get; set; }
        public string Degree_of_knowledge { get; set; }

        public static List<LanguageInf> GetByEmployeeId(string connectionString, int employeeId)
        {
            var languages = new List<LanguageInf>();
            string query = "SELECT * FROM Language WHERE ID_empl = @EmployeeId";

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        languages.Add(new LanguageInf
                        {
                            ID_language = Convert.ToInt32(reader["ID_language"]),
                            Language_name = reader["Language_name"].ToString(),
                            Degree_of_knowledge = reader["Degree_of_knowledge"].ToString(),
                            ID_empl = employeeId
                        });
                    }
                }
            }
            return languages;
        }

    }

    public class MilitaryRegistrationInf
    {
        public int ID_empl { get; set; }
        public string Category { get; set; }
        public string Military_rank { get; set; }
        public string Structure { get; set; }
        public string Code_mas { get; set; }
        public string Category_life { get; set; }
        public string Military_commissariat_name { get; set; }
        public string De_registration { get; set; }
        public string Name_type { get; set; }
        public string Additional_information { get; set; }

        public static MilitaryRegistrationInf GetByEmployeeId(string connectionString, int employeeId)
        {
            var registration = new MilitaryRegistrationInf();
            string query = "SELECT * FROM military_registration WHERE ID_empl = @ID";

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ID", employeeId);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        registration.Category = reader["Category"].ToString();
                        registration.Military_rank = reader["Military_rank"].ToString();
                        registration.Structure = reader["Structure"].ToString();
                        registration.Code_mas = reader["Code_mas"].ToString();
                        registration.Category_life = reader["Category_life"].ToString();
                        registration.Military_commissariat_name = reader["Military_commissariat_name"].ToString();
                        registration.De_registration = reader["de_registration"].ToString();
                        registration.Name_type = reader["Name_type"].ToString();
                        registration.Additional_information = reader["Additional_information"]?.ToString();
                        registration.ID_empl = employeeId;
                    }
                }
            }
            return registration;
        }


    }

    public class ProfessionInf
    {
        public int ID_empl { get; set; }
        public string Basic { get; set; }
        public string Another { get; set; }

        public static ProfessionInf GetByEmployeeId(string connectionString, int employeeId)
        {
            var profession = new ProfessionInf();
            string query = "SELECT * FROM Profession WHERE ID_empl = @EmployeeId";

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        profession.ID_empl = employeeId;
                        profession.Basic = reader["basic"].ToString();
                        profession.Another = reader["another"]?.ToString();
                    }
                }
            }
            return profession;
        }


    }

    public class ProfessionalDevelopmentInf
    {
        public int ID_cval { get; set; }
        public int ID_empl { get; set; }
        public DateTime Date_start { get; set; }
        public DateTime Date_end { get; set; }
        public string Type_cvalification { get; set; }
        public string Name_education_company { get; set; }
        public string Name_doc { get; set; }
        public string Ser_doc { get; set; }
        public string Num_doc { get; set; }
        public DateTime Date_give_doc { get; set; }
        public string Reason { get; set; }

        public static List<ProfessionalDevelopmentInf> GetByEmployeeId(string connectionString, int employeeId)
        {
            var developments = new List<ProfessionalDevelopmentInf>();
            string query = "SELECT * FROM professional_development WHERE ID_empl = @EmployeeId";

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        developments.Add(new ProfessionalDevelopmentInf
                        {
                            ID_cval = Convert.ToInt32(reader["ID_cval"]),
                            Date_start = reader.GetDateTime("Date_start"),
                            Date_end = reader.GetDateTime("Date_end"),
                            Type_cvalification = reader["Type_cvalification"].ToString(),
                            Name_education_company = reader["Name_education_company"].ToString(),
                            Name_doc = reader["Name_doc"].ToString(),
                            Ser_doc = reader["Ser_doc"].ToString(),
                            Num_doc = reader["Num_doc"].ToString(),
                            Date_give_doc = reader.GetDateTime("Date_give_doc"),
                            Reason = reader["Reason"].ToString(),
                            ID_empl = employeeId
                        });
                    }
                }
            }
            return developments;
        }


    }

    public class ProfessionalRetrainingInf
    {
        public int ID_retr { get; set; }
        public int ID_empl { get; set; }
        public DateTime Date_start { get; set; }
        public DateTime Date_end { get; set; }
        public string Name_doc { get; set; }
        public string Ser_doc { get; set; }
        public string Num_doc { get; set; }
        public DateTime Date_give_doc { get; set; }
        public string Reason { get; set; }
        public string Speciality { get; set; }

        public static List<ProfessionalRetrainingInf> GetByEmployeeId(string connectionString, int employeeId)
        {
            var retrainings = new List<ProfessionalRetrainingInf>();
            string query = "SELECT * FROM professional_retraining WHERE ID_empl = @EmployeeId";

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retrainings.Add(new ProfessionalRetrainingInf
                        {
                            ID_retr = Convert.ToInt32(reader["ID_retr"]),
                            Date_start = reader.GetDateTime("Date_start"),
                            Date_end = reader.GetDateTime("Date_end"),
                            Name_doc = reader["Name_doc"].ToString(),
                            Ser_doc = reader["Ser_doc"].ToString(),
                            Num_doc = reader["Num_doc"].ToString(),
                            Date_give_doc = reader.GetDateTime("Date_give_doc"),
                            Reason = reader["Reason"].ToString(),
                            Speciality = reader["Speciality"].ToString(),
                            ID_empl = employeeId
                        });
                    }
                }
            }
            return retrainings;
        }
    }

    public class SocialBenefitInf
    {
        public int ID_ben { get; set; }
        public int ID_empl { get; set; }
        public string Name_benefit { get; set; }
        public string Num_doc { get; set; }
        public DateTime Date_give_doc { get; set; }
        public string Reason { get; set; }

        public static List<SocialBenefitInf> GetAllByEmployee(string connectionString, int employeeId)
        {
            List<SocialBenefitInf> benefits = new List<SocialBenefitInf>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"SELECT * FROM social_benefits 
                           WHERE ID_empl = @EmployeeId 
                           ORDER BY Date_give_doc DESC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);

                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        benefits.Add(new SocialBenefitInf()
                        {
                            ID_ben = reader.GetInt32("ID_ben"),
                            Name_benefit = reader.GetString("Name_benefit"),
                            Num_doc = reader.GetString("Num_doc"),
                            Date_give_doc = reader.GetDateTime("Date_give_doc"),
                            Reason = reader.IsDBNull(reader.GetOrdinal("Reason")) ?  null : reader.GetString("Reason"),
                            ID_empl = employeeId
                        });
                    }
                }
            }
            return benefits;
        }
    }

    public class VacationInf
    {
        public int ID_vac { get; set; }
        public int ID_empl { get; set; }
        public string Type_vacation { get; set; }
        public DateTime Period_work_start { get; set; }
        public DateTime? Period_work_end { get; set; }
        public int Quantity_day { get; set; }
        public DateTime Date_start { get; set; }
        public DateTime Date_end { get; set; }
        public string Reason { get; set; }

        public static List<VacationInf> GetByEmployeeId(string connectionString, int employeeId)
        {
            var vacations = new List<VacationInf>();
            string query = "SELECT * FROM vacation WHERE ID_empl = @ID";

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ID", employeeId);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vacations.Add(new VacationInf
                        {
                            ID_vac = Convert.ToInt32(reader["ID_vac"]),
                            Type_vacation = reader["Type_vacation"].ToString(),
                            Period_work_start = reader.GetDateTime("Period_work_start"),
                            Period_work_end = reader.IsDBNull(reader.GetOrdinal("Period_work_end")) ?(DateTime?)null : reader.GetDateTime("Period_work_end"),
                            Quantity_day = Convert.ToInt32(reader["Quantity_day"]),
                            Date_start = reader.GetDateTime("Date_start"),
                            Date_end = reader.GetDateTime("Date_end"),
                            Reason = reader["Reason"].ToString(),
                            ID_empl = employeeId
                        });
                    }
                }
            }
            return vacations;
        }


    }

    public class WorkExperienceInf
    {
        public int ID_empl { get; set; }
        public int? Common_day { get; set; }
        public int? Common_year { get; set; }
        public int? Common_month { get; set; }
        public int? Continuous_day { get; set; }
        public int? Continuous_month { get; set; }
        public int? Continuous_year { get; set; }
        public int? Giver_day { get; set; }
        public int? Giver_month { get; set; }
        public int? Giver_year { get; set; }

        public static WorkExperienceInf GetByEmployeeId(string connectionString, int employeeId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM work_experience WHERE ID_empl = @EmployeeId";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);

                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new WorkExperienceInf()
                        {
                            ID_empl = employeeId,
                            Common_day = reader.IsDBNull(reader.GetOrdinal("common_day")) ? null : (int?)reader.GetInt32("common_day"),
                            Common_year = reader.IsDBNull(reader.GetOrdinal("common_year")) ? null : (int?)reader.GetInt32("common_year"),
                            Common_month = reader.IsDBNull(reader.GetOrdinal("common_month")) ? null : (int?)reader.GetInt32("common_month"),
                            Continuous_day = reader.IsDBNull(reader.GetOrdinal("continuous_day")) ? null : (int?)reader.GetInt32("continuous_day"),
                            Continuous_month = reader.IsDBNull(reader.GetOrdinal("continuous_month")) ? null : (int?)reader.GetInt32("continuous_month"),
                            Continuous_year = reader.IsDBNull(reader.GetOrdinal("continuous_year")) ? null : (int?)reader.GetInt32("continuous_year"),
                            Giver_day = reader.IsDBNull(reader.GetOrdinal("giver_day")) ? null : (int?)reader.GetInt32("giver_day"),
                            Giver_month = reader.IsDBNull(reader.GetOrdinal("giver_month")) ? null : (int?)reader.GetInt32("giver_month"),
                            Giver_year = reader.IsDBNull(reader.GetOrdinal("giver_year")) ? null : (int?)reader.GetInt32("giver_year")
                        };
                    }
                }
            }
            return null;
        }


    }

    public class AdditionalInformationInf
    {
        public int ID_mixing { get; set; }
        public int ID_empl { get; set; }
        public string Information { get; set; }

        public static List<AdditionalInformationInf> GetByEmployeeId(string connectionString, int employeeId)
        {
            var infoList = new List<AdditionalInformationInf>();
            string query = "SELECT * FROM Additional_information WHERE ID_empl = @ID";

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ID", employeeId);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        infoList.Add(new AdditionalInformationInf
                        {
                            ID_mixing = Convert.ToInt32(reader["ID_mixing"]),
                            Information = reader["Information"].ToString(),
                            ID_empl = employeeId
                        });
                    }
                }
            }
            return infoList;
        }
    }

    public class UserInf
    {
        public int Id_User { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public short Lock { get; set; }

        public static UserInf GetById(string connectionString, int userId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users WHERE id_User = @UserId";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);

                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new UserInf()
                        {
                            Id_User = reader.GetInt32("id_User"),
                            Name = reader.GetString("Name"),
                            LastName = reader.GetString("LastName"),
                            Surname = reader.IsDBNull(reader.GetOrdinal("Surname")) ? null : reader.GetString("Surname"),
                            Login = reader.GetString("login"),
                            Password = reader.GetString("password"),
                            Role = reader.GetString("role"),
                            Lock = reader.GetInt16("lock")
                        };
                    }
                }
            }
            return null;
        }
    }

}

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
    }

    public class AddressOfResidenceInf
    {
        public int ID_empl { get; set; }
        public string By_registration { get; set; }
        public string Actual { get; set; }
        public string Index_by_register { get; set; }
        public string Index_actual { get; set; }
        public DateTime Date_registration { get; set; }

       
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

        
    }

    public class AwardInf
    {
        public int ID_reward { get; set; }
        public int ID_empl { get; set; }
        public string Name_reward { get; set; }
        public string Name_doc { get; set; }
        public string Num_doc { get; set; }
        public DateTime Date_give_doc { get; set; }
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

        
    }

    public class DismissalInf
    {
        public int ID_empl { get; set; }
        public DateTime Date_dismiss { get; set; }
        public string Num_order { get; set; }
        public DateTime Date_order { get; set; }
        public string Reason { get; set; }

       
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

        
    }

    public class FamilyCompositionInf
    {
        public int ID_person { get; set; }
        public int ID_empl { get; set; }
        public string FIO { get; set; }
        public string Degree_of_kinship { get; set; }
        public DateTime Date_birth { get; set; }

       
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

        
    }

    public class LanguageInf
    {
        public int ID_language { get; set; }
        public int ID_empl { get; set; }
        public string Language_name { get; set; }
        public string Degree_of_knowledge { get; set; }

        
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

        
    }

    public class ProfessionInf
    {
        public int ID_empl { get; set; }
        public string Basic { get; set; }
        public string Another { get; set; }

       
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

        public GeneralInformation Employee { get; set; }
    }

    public class SocialBenefitInf
    {
        public int ID_ben { get; set; }
        public int ID_empl { get; set; }
        public string Name_benefit { get; set; }
        public string Num_doc { get; set; }
        public DateTime Date_give_doc { get; set; }
        public string Reason { get; set; }

        
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

        
    }

    public class AdditionalInformationInf
    {
        public int ID_mixing { get; set; }
        public int ID_empl { get; set; }
        public string Information { get; set; }

        
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
    }

}

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;


namespace SagEmpDataModel
{
    [Table("SGT_EMPLOYEE")]
    public class busSagEmployee
    {
        [Column("SAG_ID")]
        [Key]
        public int sagId { get; set; }

        [DisplayName("First Name")]
        [Column("FIRST_NAME")]
        [Required]
        public string firstName { get; set; }

        [DisplayName("Middle Name")]
        [Column("MIDDLE_NAME")]
        public string middleName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [Column("LAST_NAME")]
        public string lastName { get; set; }

        [Required]
        [DisplayName("Email")]
        [Column("EMAIL")]
        public string email { get; set; }


        [Required]
        [DisplayName("Date_Of_Birth")]
        [Column("DATE_OF_BIRTH")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dateOfBirth { get; set; }

        [Required]
        [DisplayName("Date Of Joining")]
        [Column("DATE_OF_JOINING")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dateOfJoining { get; set; }

        [Required]
        [DisplayName("Project")]
        [Column("PROJECT")]
        public string project { get; set; }



        [Required]
        [DisplayName("Designation")]
        [Column("DESIGNATION")]
        public string designation { get; set; }

        [Required]
        [Column("LOCATIONID")]
        [DisplayName("Location")]
        public byte locationId { get; set; }

        [Column("EDUCATION")]
        [Required]
        [DisplayName("Education")]
        public string education { get; set; }

        [Column("PREVIOUS_COMPANY")]
        [DisplayName("Previous Company")]
        public string previousCompany { get; set; }

        [Column("PREVIOUS_COMPANY_DESIGNATION")]
        [DisplayName("Previous Company Designation")]
        public string previousCompanyDesignation { get; set; }

        [Required]
        [DisplayName("Hobbies")]
        [Column("HOBBIES")]
        public string hobbies { get; set; }

        [DisplayName("Photo")]
        [Column("PHOTO")]
        public string photo { get; set; }

        [Column("JOINING_MAIL_SENT")]
        public bool joiningMailSent { get; set; }

        [Column("BIRTHDAYS")]
        public byte birthdays { get; set; }

        [Column("ANNIVERSARIES")]
        public byte anniversaries { get; set; }

        [Column("IS_TERMINATED")]
        [DisplayName("Is Terminated")]
        public bool IsTerminated { get; set; }

        [Column("EMAIL_TYPE")]
        public byte emailType { get; set; }

        public virtual busSagLocation location { get; set; }

        [Required]
        [NotMapped]
        public HttpPostedFileBase user_image_data { get; set; }
    }
}

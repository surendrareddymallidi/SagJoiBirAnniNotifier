using SagEmpDataModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SagBirJoiAnniEmailService
{
    public partial class SagitecEmailService : Form
    {
        SagEmployeeDbContext _dbContext = new SagEmployeeDbContext();
        public SagitecEmailService()
        {
            InitializeComponent();
            Shown += SagitecEmailService_Shown;
        }

        private void SagitecEmailService_Shown(object sender, System.EventArgs e)
        {
            SendJoiningBirthDayAnniversaryEmails();
        }

        private void SendJoiningBirthDayAnniversaryEmails()
        {
            List<busSagEmployee> llstEmployees = _dbContext.Database.SqlQuery<busSagEmployee>("sp_GetEmployeesForJoiningBirthdayAnniversaryMails").ToList();
            var llstEmployeesGroupedByEmailType = llstEmployees.GroupBy(emp => emp.emailType);
            foreach (var lbussagemployee in llstEmployeesGroupedByEmailType)
            {
                switch (lbussagemployee.Key)
                {
                    case (byte)EmailType.JoiningEmail:
                        SendEmail(lbussagemployee, EmailType.JoiningEmail);
                        break;
                    case (byte)EmailType.BirthDayEmail:
                        SendEmail(lbussagemployee, EmailType.BirthDayEmail);
                        break;
                        case (byte)EmailType.BelatedBirthDayEmail:
                        SendEmail(lbussagemployee, EmailType.BelatedBirthDayEmail);
                        break;
                    case (byte)EmailType.JoiningAnniversary:
                        SendEmail(lbussagemployee, EmailType.JoiningAnniversary);
                        break;
                }
            }
        }
        private void SendEmail(IGrouping<byte, busSagEmployee> lbussagemployee, EmailType eemtMailType)
        {
            string lstrAddresse = "Dear ";
            string[] lstrEmailToAddresses = null;
            lstrAddresse += string.Join(",", lbussagemployee.Select(emp => emp.firstName));
            lstrEmailToAddresses = lbussagemployee.Select(emp => emp.email)?.ToArray();
            string lstrFromAddresses = ConfigurationManager.AppSettings["EmailFromAddress"]?.ToString();
            string lstrOccasion = string.Empty;
            string lstrSubject = string.Empty;
            switch (eemtMailType)
            {
                case EmailType.JoiningEmail:
                    lstrSubject = ConfigurationManager.AppSettings["JoiningEmailSubject"]?.ToString();
                    if (string.IsNullOrEmpty(lstrSubject)) lstrSubject = "Welcome To Sagitec Family";
                    lstrOccasion = lstrSubject;
                    break;
                case EmailType.BirthDayEmail:
                    lstrSubject = ConfigurationManager.AppSettings["BirthDayEmailSubject"]?.ToString();
                    if (string.IsNullOrEmpty(lstrSubject)) lstrSubject = "Happy Birth Day";
                    lstrOccasion = lstrSubject;
                    break;
                case EmailType.BelatedBirthDayEmail:
                    lstrSubject = ConfigurationManager.AppSettings["BelatedBirthDayEmailSubject"]?.ToString();
                    if (string.IsNullOrEmpty(lstrSubject)) lstrSubject = "Belated Happy Birth Day";
                    lstrOccasion = lstrSubject;
                    break;
                case EmailType.JoiningAnniversary:
                    lstrSubject = ConfigurationManager.AppSettings["JoiningAnniversaryEmailSubject"]?.ToString();
                    if (string.IsNullOrEmpty(lstrSubject)) lstrSubject = "Happy Anniversary";
                    lstrOccasion = lstrSubject;
                    break;
                default:
                    break;
            }
            if (SendMail(lstrFromAddresses, lstrEmailToAddresses, lstrSubject, lstrOccasion, lstrAddresse))
                UpdateJoiBirAnniValues(lbussagemployee, eemtMailType);

        }

        private void UpdateJoiBirAnniValues(IGrouping<byte, busSagEmployee> lbussagemployee, EmailType eemtMailType)
        {
            
        }

        private bool SendMail(string astrFromAddresses, string[] astrEmailToAddresses, string astrSubject, string astrOccasion, string astrAddresse)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("surirmallidi@gmail.com", "Sagitec@123");
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(astrFromAddresses);
            foreach (string lmailAddress in astrEmailToAddresses) msg.To.Add(new MailAddress(lmailAddress));
            msg.IsBodyHtml = true;
            msg.AlternateViews.Add(Mail_Body(astrAddresse, astrOccasion));
            try
            {
                client.Send(msg);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        private static AlternateView Mail_Body(string astrStrings, string astrOccasion)
        {
            string path = @"C:\Users\Suri\Pictures\Image.png";
            LinkedResource Img = new LinkedResource(path, MediaTypeNames.Image.Gif);
            Img.ContentId = "MyImage";
            string str = $"<table><tr><td style='font-family: Arial, Helvetica, sans-serif;font-size:14px;color:blue;'>{astrOccasion} {astrStrings}</td></tr><tr><td><img src=cid:MyImage  id='img' alt='' width='100px' height='100px'/></td></tr></table>";
            AlternateView AV =
                AlternateView.CreateAlternateViewFromString(str, null, MediaTypeNames.Text.Html);
            AV.LinkedResources.Add(Img);
            return AV;
        }
    }
}

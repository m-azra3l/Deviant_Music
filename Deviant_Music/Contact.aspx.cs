using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Configuration;
using System.Net;
using System.Net.Mail;

namespace Deviant_Music
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        private void clearmail()
        {
            inputEmail.Text = string.Empty;
            inputName.Text = string.Empty;
            inputMessage.Text = string.Empty;
            inputSubject.Text = string.Empty;
            upload1.AppRelativeTemplateSourceDirectory = string.Empty;
        }
        protected void request_Click(object sender, EventArgs e)
        {
            using (var mailClient = new SmtpClient())
            {
                MailMessage email = new MailMessage(new MailAddress("supportmessage@deviantmusic.com", "(Customer Support)"), new MailAddress("deviantmusicng@gmail.com"));
                email.Subject = inputSubject.Text;
                email.Body = "Name/Username:" +inputName.Text+ "<br/><br/>Email:"+inputEmail.Text+"<br/>"+ inputMessage.Text;
                email.IsBodyHtml = true;
                if(upload1.HasFile)
                {
                    HttpFileCollection fc = Request.Files;
                    for (int i = 0; i <= fc.Count - 1; i++)
                    {
                        HttpPostedFile pf = fc[i];
                        Attachment attach = new Attachment(pf.InputStream, pf.FileName);
                        email.Attachments.Add(attach);
                    }
                }
                mailClient.Host = "smtp.gmail.com";
                mailClient.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = "deviantmusicng@gmail.com";
                NetworkCred.Password = "suryan007";
                mailClient.UseDefaultCredentials = true;
                mailClient.Credentials = NetworkCred;
                mailClient.Port = 587;
                mailClient.Send(email);
            }
            respsuccess.Text = "Email sent successfully";
        }
    }
}
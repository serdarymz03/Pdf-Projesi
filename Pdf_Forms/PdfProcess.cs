using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace Pdf_Forms
{
    class PdfProcess
    {
        static PdfProcess pdfProcess;
        private PdfProcess()
        {

        }
        public string[] ReadPdf(string filePath)
        {
            string[] infos = new string[4];
            PdfDocument pdfDocument = PdfDocument.Open(filePath);

            foreach (Page page in pdfDocument.GetPages())
            {
                //string allText = page.Text;

                var list = page.GetWords().ToList();

                for (int i = 0; i < list.Count; i++)
                {
                    string itemText = list[i].ToString();
                    string itemText2 = list[i + 1].ToString();

                    if (itemText == "Müşteri" && itemText2 == "No")
                    {
                        infos[0] = list[i + 3].ToString();
                        continue;
                    }

                    if (itemText == "Ad" && itemText2 == "Soyad")
                    {
                        infos[1] = list[i + 3].ToString() + " " + list[i + 4].ToString();
                        continue;
                    }

                    if (itemText == "E-mail" && itemText2 == ":")
                    {
                        infos[2] = list[i + 2].ToString();
                        continue;
                    }

                    if (itemText == "TOPLAM" && itemText2 == ":")
                    {
                        infos[3] = list[i + 2].ToString();
                        break;
                    }
                }
            }
            return infos;
        }


        public void MailSend(string subject, string body, List<string> receivers, List<string> attachments = null)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 11000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("mailAddress", "mailPassword");
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("mailAddress", "Yetkili Kişi");
                mailMessage.SubjectEncoding = Encoding.UTF8;
                mailMessage.Subject = subject; //E-posta Konu Kısmı
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.Body = body; // E-posta'nın Gövde Metni
                foreach (string item in receivers)
                {
                    mailMessage.To.Add(item);
                }
                mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                if (attachments != null)
                {
                    if (attachments.Count > 0)
                    {
                        foreach (string filePath in attachments)
                        {
                            if (File.Exists(filePath))
                            {
                                Attachment attachment = new Attachment(filePath);
                                mailMessage.Attachments.Add(attachment);
                            }
                        }
                    }
                }
                client.Send(mailMessage);
            }
            catch { }
        }

        public static PdfProcess GetInstance()
        {
            if (pdfProcess == null)
            {
                pdfProcess = new PdfProcess();
            }
            return pdfProcess;
        }
    }
}

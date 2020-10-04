using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pdf_Forms
{
    public partial class FrmPdfRead : Form
    {
        string filePath, subject, body, email;
        string[] infos;
        PdfProcess pdfProcess;

        public FrmPdfRead()
        {
            InitializeComponent();
            pdfProcess = PdfProcess.GetInstance();          
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Pdf Dosyası |*.pdf";
            DialogResult dialogResult = openFileDialog1.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                TxtPath.Text = filePath;
                infos = pdfProcess.ReadPdf(filePath);
                if (infos.Length == 0)
                {
                    MessageBox.Show("Hata");
                    return;
                }

                subject = "Sayın " + infos[1] + " Bildigesi";
                body = "Sayın " + infos[0] + " Numaralı " + infos[1] + " \nBu Dönemki Toplam Masrafınız : " + infos[3]+" TL";
                RchInfo.Text = "Konu : " + subject + " \n İçerik : " + body;
                email = infos[2];
            }
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (infos == null)
            {
                return;
            }
            if (infos.Length == 0)
            {
                return;
            }

            pdfProcess.MailSend(subject, body, new List<string>() { email }, new List<string>() { filePath });
            MessageBox.Show("İşlem Tamamlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

    }
}

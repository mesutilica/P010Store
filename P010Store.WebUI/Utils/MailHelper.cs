using P010Store.Entities;
using System.Net;
using System.Net.Mail;

namespace P010Store.WebUI.Utils
{
    public class MailHelper
    {
        public static async Task SendMailAsync(Contact contact)
        {
            SmtpClient smtpClient = new SmtpClient("mail.siteadresi.com", 587); // 1. parametre mailin gönderileceği sunucu adresi. 2. parametre mail sunucu port numarası
            smtpClient.Credentials = new NetworkCredential("email kullanıcı adı(info@siteadi.com)", "email şifre");
            smtpClient.EnableSsl = true; // eğer mail sunusu ssl sertifikası kullanıyorsa, aktif et
            MailMessage message = new MailMessage();
            message.From = new MailAddress("info@siteadi.com"); // maili gönderen adres
            message.To.Add("mailingonderilecegiadres@gmail.com"); // mailin gönderileceği adres
            message.To.Add("mailingonderilecegiadres2@gmail.com"); // mailin gönderileceği adres 2
            message.Subject = "Siteden Mesaj Geldi"; // Mail konu başlığı
            message.Body = $"<h1>Mail Bilgileri</h1> İsim : {contact.Name} {contact.Surname} <hr /> Email : {contact.Email} <hr /> Telefon : {contact.Phone} <hr /> Mesaj : {contact.Message} <hr /> Mesaj Tarihi : {DateTime.Now}";
            message.IsBodyHtml = true;
            smtpClient.Send(message); // normal mesaj gönderimi
            await smtpClient.SendMailAsync(message); // asenkron mail gönderimi
            smtpClient.Dispose(); // mesajdan sonra nesneyi yok et
        }
    }
}

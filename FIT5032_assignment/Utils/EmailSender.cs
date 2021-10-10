using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace FIT5032_Week08A.Utils
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "YOUR_API_KEY";

        public void Send(String toEmail, String subject, String contents, HttpPostedFileBase postedFileBase)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("YOUR_SENGDER_EMAIL");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            // send y
            //var emails = new List<EmailAddress>
            //{
            //    new EmailAddress("test1@example.com"),
            //    new EmailAddress("test2@example.com"),
            //    new EmailAddress("test3@example.com")
            //};
            //var msg = MailHelper.CreateSingleEmailToMultipleRecipients(new EmailAddress("test@example.com", "Example User"),
            //                                                           emails,
            //                                                           "Test Subject",
            //                                                           "Plain Text Content",
            //                                                           "HTML Content"
            //                                                           );

            //1. toEmail .split(";")
            //2. controller deal with data

            if (postedFileBase != null && postedFileBase.ContentLength > 0)// view post the file
            {
                string theFileName = Path.GetFileName(postedFileBase.FileName);// naming file
                byte[] fileBytes = new byte[postedFileBase.ContentLength];// convert byte
                using (BinaryReader theReader = new BinaryReader(postedFileBase.InputStream))// break in steam
                {
                    fileBytes = theReader.ReadBytes(postedFileBase.ContentLength);
                }
                string dataAsString = Convert.ToBase64String(fileBytes);// convert to base64
                msg.AddAttachment(theFileName, dataAsString);
            }

            var response = client.SendEmailAsync(msg);
        }


        //public void SendMultiple(List<String> toEmail, String subject, String contents, HttpPostedFileBase postedFileBase)
        //{
        //    var client = new SendGridClient(API_KEY);
        //    var from = new EmailAddress("YOUR_SENGDER_EMAIL");
        //    var tos = new EmailAddress(toEmail, "");
        //    var plainTextContent = contents;
        //    var htmlContent = "<p>" + contents + "</p>";
        //    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

        //    // send y
        //    //var emails = new List<EmailAddress>
        //    //{
        //    //    new EmailAddress("test1@example.com"),
        //    //    new EmailAddress("test2@example.com"),
        //    //    new EmailAddress("test3@example.com")
        //    //};
        //    //var msg = MailHelper.CreateSingleEmailToMultipleRecipients(new EmailAddress("test@example.com", "Example User"),
        //    //                                                           emails,
        //    //                                                           "Test Subject",
        //    //                                                           "Plain Text Content",
        //    //                                                           "HTML Content"
        //    //                                                           );

        //    //1. toEmail .split(";")
        //    //2. controller deal with data

        //    if (postedFileBase != null && postedFileBase.ContentLength > 0)// view post the file
        //    {
        //        string theFileName = Path.GetFileName(postedFileBase.FileName);// naming file
        //        byte[] fileBytes = new byte[postedFileBase.ContentLength];// convert byte
        //        using (BinaryReader theReader = new BinaryReader(postedFileBase.InputStream))// break in steam
        //        {
        //            fileBytes = theReader.ReadBytes(postedFileBase.ContentLength);
        //        }
        //        string dataAsString = Convert.ToBase64String(fileBytes);// convert to base64
        //        msg.AddAttachment(theFileName, dataAsString);
        //    }

        //    var response = client.SendEmailAsync(msg);
        //}
    }
}
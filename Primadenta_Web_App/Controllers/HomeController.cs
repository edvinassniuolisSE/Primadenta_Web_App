using Primadenta_Web_App.Models.BusinessData;
using System;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace Primadenta_Web_App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            //if (User.IsInRole("Admin"))
            //    return View("About", "_LayoutAdmin");

            return View();
        }


        public ActionResult Contact()
        {
            var contact = new ContactForm();



            if (User.IsInRole("Admin"))
                return View("Contact", "_LayoutAdmin", contact);

            return View("Contact");
        }

        public ActionResult TestLayout()
        {
            if (User.IsInRole("Admin"))
                return View("Index", "_LayoutAdmin");

            return View();
        }




        [HttpPost]
        public ActionResult Save(ContactForm contactForm)
        {
            if (!ModelState.IsValid)
            {
                return View("Contact", contactForm);
            }
            else
            {
                try
                {
                    var message = new MailMessage();

                    message.From = new MailAddress(contactForm.Email);
                    message.To.Add("edvinas.sniuolis@gmail.com");
                    message.Subject = contactForm.Subject;
                    message.Body = $"Vardas: {contactForm.Name}\n" +
                                   $"Pavardė: {contactForm.Surname}\n" +
                                   $"---------------\n" + contactForm.Message;


                    var smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.Credentials = new NetworkCredential
                        ("edvinas.sniuolis@gmail.com", "7557asas");
                    smtp.EnableSsl = true;
                    smtp.Send(message);

                    ViewBag.Message = "Thank you for Contacting us ";
                }
                catch (Exception e)
                {
                    ViewBag.Message = $"Atleiskite, šiuo metu nėra galimybės išsiųsti el. pašto";
                    throw;
                }
            }

            return RedirectToAction("Contact", "Home");

        }
    }
}
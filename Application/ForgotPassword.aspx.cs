using Literals;
using System;
using System.Net;
using System.Net.Mail;

namespace Application
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim().ToLower();
            Session["email"] = email;

                // Generate and send an OTP to the user's email address
                if (SendOtpByEmail(email))
                {
                    // Redirect the user to the OTP verification page
                    Response.Redirect($"OTPVerification.aspx?email={email}");
                }
                else
                {
                // Failed to send the OTP
                lblMessage.Text = StringLiterals.OTPSendingError;
                lblMessage.Visible = true;
                }
        }
        private bool SendOtpByEmail(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    return false;
                }

                // Generate a random 6-digit OTP
                string otp = GenerateOtp();

                // Save the OTP and its expiry date to a session variable (insecure for production, use a more secure method)
                Session["ResetOtp"] = otp;
                Session["OtpExpiry"] = DateTime.Now.AddMinutes(5);

                // Send the OTP to the user's email address
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("spam.143zzz@outlook.com", "Web Application");
                mailMessage.To.Add(email);
                mailMessage.Subject = "One-Time Password (OTP) for Password Reset";
                mailMessage.Body = $"Dear {email},\n\nYour OTP for password reset is: {otp}\n\nThis OTP is valid for 5 minutes.\n\nSincerely,\nSupraja Konchada";

                SmtpClient smtpClient = new SmtpClient("smtp.office365.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("spam.143zzz@outlook.com", "SPAMtemp@420");
                smtpClient.Send(mailMessage);

                return true;
            }
            catch (Exception ex)
            {
                // Handle email sending exceptions here
                lblMessage.Text = StringLiterals.OTPSendingError + ex.Message;
                lblMessage.Visible = true;
                return false;
            }
        }
        private string GenerateOtp()
        {
            // Generate a random 6-digit OTP
            Random random = new Random();
            int otpValue = random.Next(100000, 999999);
            return otpValue.ToString();
        }
    }
}

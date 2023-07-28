using Literals;
using System;

namespace Application
{
    public partial class OTPVerification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string email = Request.QueryString["email"];
                if (string.IsNullOrEmpty(email))
                {
                    // Redirect to the "ForgotPassword" page if the email is missing
                    Response.Redirect("ForgotPassword.aspx");
                }
            }
        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {
            string enteredOtp = txtOTP.Text.Trim();

            // Check if the entered OTP matches the generated OTP
            if (IsValidOtp(enteredOtp))
            {
                // Redirect the user to the "ResetPassword" page
                Response.Redirect($"ResetPassword.aspx?email={Request.QueryString["email"]}");
            }
            else
            {
                // Invalid OTP
                lblMessage.Text = StringLiterals.InvailOTP;
                lblMessage.Visible = true;
            }
        }

        private bool IsValidOtp(string enteredOtp)
        {
            // Retrieve the saved OTP and its expiry date from the session (insecure for production, use a more secure method)
            string savedOtp = Session["ResetOtp"] as string;
            DateTime otpExpiry = Convert.ToDateTime(Session["OtpExpiry"]);

            // Compare the entered OTP with the saved OTP and check if it is not expired
            return (enteredOtp == savedOtp && DateTime.Now <= otpExpiry);
        }
    }
}

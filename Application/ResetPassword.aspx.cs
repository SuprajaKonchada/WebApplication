using System;
using BusinessLayer;
using Literals;

namespace Application
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void btnReset_Click(object sender, EventArgs e)
        {
            string email = Session["email"].ToString();
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            BALAuthentication BALAuth = new BALAuthentication();
            BALValidations BALValid = new BALValidations();
            
            if(BALAuth.IsPasswordMatch(newPassword, confirmPassword))
            {
                if(BALValid.IsValidPassword(newPassword))
                {
                    BALAuth.ResetUserPassword(email, newPassword);
                    Response.Redirect(StringLiterals.ToLogin);
                }
                else
                {
                    lblMessage.Text = StringLiterals.InvalidPassword;
                    lblMessage.Visible = true;
                    return;
                }
                
            }
            else
            {
                lblMessage.Text = StringLiterals.NotMatch;
                lblMessage.Visible = true;
            }
        }
    }
}

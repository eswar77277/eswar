using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    if (Request.Cookies["userid"] != null)
        //        txtemail.Text = Request.Cookies["userid"].Value;
        //    if (Request.Cookies["pwd"] != null)
        //        txtpwd.Attributes.Add("value", Request.Cookies["pwd"].Value);
        //    if (Request.Cookies["userid"] != null && Request.Cookies["pwd"] != null)
        //        RememberMe.Checked = true;
        //}
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            SmtpSection secObj = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            string mail = secObj.Network.UserName;
            string pwd = secObj.Network.Password;
            if (txtemail.Text == mail && txtpwd.Text == pwd)
            {
                Session["SessionLogged"] = "YES";
                Response.Redirect("/editor/index.aspx");
            }
            else
                Response.Write("<script>alert('Invalid Credentials');</script>");
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    public static string Encrypt(string input, string key)
    {
        byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
        TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
        tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
        tripleDES.Mode = CipherMode.ECB;
        tripleDES.Padding = PaddingMode.PKCS7;
        ICryptoTransform cTransform = tripleDES.CreateEncryptor();
        byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
        tripleDES.Clear();
        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    }

    public static string Decrypt(string input, string key)
    {
        byte[] inputArray = Convert.FromBase64String(input);
        TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
        tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
        tripleDES.Mode = CipherMode.ECB;
        tripleDES.Padding = PaddingMode.PKCS7;
        ICryptoTransform cTransform = tripleDES.CreateDecryptor();
        byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
        tripleDES.Clear();
        return UTF8Encoding.UTF8.GetString(resultArray);
    }
}
using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


namespace CaptchaDotNet2.Security.Cryptography
{
    /// <summary>
    /// Summary description for RandomText
    /// </summary>
    public static class RandomText
    {
        //public RandomText()
        //{
        //    //
        //    // TODO: Add constructor logic here
        //    //
        //}
        public static string Generate()
        {
            // Generate random text
            string s = "";
            char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
            int index;
            int lenght = RNG.Next(4, 6);
            for (int i = 0; i < lenght; i++)
            {
                index = RNG.Next(chars.Length - 1);
                s += chars[index].ToString();
            }
            return s;
        }
    }
}

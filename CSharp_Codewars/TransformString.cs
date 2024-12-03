using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Codewars
{
    public class TransformString
    {
        public static string TransformWordsWithAtLeastFiveLetters(string s)
        {
            string s1 = String.Copy(s);
            string s2 = "";

            while (s1.Length > 0)
            {
                string pom;
                if (s1.IndexOf(' ') > -1) pom = s1.Substring(0, s1.IndexOf(' '));
                else pom = String.Copy(s1);

                char[] tab = pom.ToCharArray();
                if (pom.Length >= 5) Array.Reverse(tab);
                string pom2 = new string(tab);
                s2 = String.Concat(s2, pom2);

                if (s1.IndexOf(' ') > -1)
                {
                    s2 = String.Concat(s2, " ");
                    s1 = s1.Substring(s1.IndexOf(' ') + 1);
                }
                else s1 = "";
            };

            return s2;
        }
    }
}

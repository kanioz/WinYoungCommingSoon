using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WinYoungUI.Extensions
{
    public static class StringExtensions
    {
        public static string ToSeoFriendly(this string input)
        {
            Func<string, string> func = delegate (string t)
            {
                string str = input.Replace('ı', 'i').Normalize(NormalizationForm.FormKD);
                char[] chArray = new char[input.Length];
                int index = 0;
                foreach (char ch in str)
                {
                    if (char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                    {
                        chArray[index] = ch;
                        index++;
                    }
                }
                return new string(chArray, 0, index);
            };
            Func<string, string> func2 = delegate (string t)
            {
                char[] chArray = new char[input.Length];
                int index = 0;
                bool flag = false;
                for (int j = 0; j < input.Length; j++)
                {
                    char ch = input[j];
                    switch (ch)
                    {
                        case '<':
                            flag = true;
                            break;

                        case '>':
                            flag = false;
                            break;

                        default:
                            if (!flag)
                            {
                                chArray[index] = ch;
                                index++;
                            }
                            break;
                    }
                }
                return new string(chArray, 0, index);
            };
            input = input.ToLower(new CultureInfo("tr-TR"));
            input = func2(input);
            input = func(input);
            input = Regex.Replace(input, "&.+?;", "");
            input = Regex.Replace(input, "[^.a-z0-9 _-]", "");
            input = Regex.Replace(input, @"\.|\s+", "-");
            input = Regex.Replace(input, "-+", "-");
            input = input.Trim(new char[] { '-' });
            return input;
        }
    }
}

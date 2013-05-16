/* 
* The MIT License (MIT)
*
* Copyright (c) 2013 Sean Hathaway
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
* THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TweetClean
{
    public static class TweetText
    {
        public static string CleanTweet(this string s)
        {
            //order is important and changed here
            s = s.RemoveSurroundingQuotes();
            s = s.RemoveLinks();
            s = s.RemovePipeToEnd();
            s = s.RemoveHypenToEnd();
            s = s.RemoveEllipsisToEnd();
            s = s.RemoveVia();
            s = s.RemoveRTs();
            s = s.RemoveMultipleUsers();
            s = s.RemoveLeadingUser();
            s = s.RemoveMultiHash();
            s = s.ParseUserToMultiWord();
            s = s.ParseHashToMultiWord();
            s = s.RemoveInserts();
            s = s.ReplaceAmp();
            s = s.RemoveLoose();
            s = s.CleanOutGarbage();
            s = s.RemoveExtraSpaces();
            s = s.Trim();

            return s;
        }

        #region helper extentions
        //remove naked URL links
        private static string RemoveLinks(this string s)
        {
            var regex = new Regex(@"\b(?:(?:(?:https?|ftp|file)://|www\.|ftp\.)[-A-Z0-9+&@#/%?=~_|$!:,.;]*[-A-Z0-9+&@#/%=~_|$]|((?:mailto:)?[A-Z0-9._%+-]+@[A-Z0-9._%-]+\.[A-Z]{2,4})\b)|”(?:(?:https?|ftp|file)://|www\.|ftp\.)[^""\r\n]+”?|’(?:(?:https?|ftp|file)://|www\.|ftp\.)[^'\r\n]+’?", RegexOptions.IgnoreCase);
            try { return regex.Replace(s, string.Empty); }
            catch { return string.Empty; }
        }

        //remove | to end
        private static string RemovePipeToEnd(this string s)
        {
            var regex = new Regex(@"\|.*", RegexOptions.IgnoreCase);
            try { return regex.Replace(s, string.Empty); }
            catch { return string.Empty; }
        }

        //remove " - " to end
        private static string RemoveHypenToEnd(this string s)
        {
            var regex = new Regex(" - .*", RegexOptions.IgnoreCase);
            try { return regex.Replace(s, string.Empty); }
            catch { return string.Empty; }
        }

        //remove sandwiched "via"
        private static string RemoveVia(this string s)
        {
            var regex = new Regex(@"via @[\w]*\b", RegexOptions.IgnoreCase);
            try { return regex.Replace(s, string.Empty); }
            catch { return string.Empty; }
        }

        //remove groups of multiple hash tags
        private static string RemoveMultiHash(this string s)
        {
            var regex = new Regex(@"((^|[^0-9A-Z&/]+)(#|\uFF03)([0-9A-Z_]*[A-Z_]+[a-z0-9_\\u00c0-\\u00d6\\u00d8-\\u00f6\\u00f8-\\u00ff]*)){2,}", RegexOptions.IgnoreCase);
            try { return regex.Replace(s, string.Empty); }
            catch { return string.Empty; }
        }

        //remove "..." to end
        private static string RemoveEllipsisToEnd(this string s)
        {
            var regex = new Regex(@"\.\.\..*", RegexOptions.IgnoreCase);
            try { return regex.Replace(s, string.Empty); }
            catch { return string.Empty; }
        }

        //remove inserts
        private static string RemoveInserts(this string s)
        {
            var regex = new Regex(@"(\(audio\)|(\(video\)))", RegexOptions.IgnoreCase);
            try { return regex.Replace(s, string.Empty); }
            catch { return string.Empty; }
        }

        //replace "&" with "and"
        private static string ReplaceAmp(this string s)
        {
            var regex = new Regex("( & )|( &amp)", RegexOptions.IgnoreCase);
            try { return regex.Replace(s, "and"); }
            catch { return string.Empty; }
        }

        //remove RTs
        private static string RemoveRTs(this string s)
        {
            try
            {
                var regex = new Regex(@"RT @[\w\s]+:", RegexOptions.IgnoreCase);
                s = regex.Replace(s, string.Empty);

                regex = new Regex(" RT ", RegexOptions.IgnoreCase);
                return regex.Replace(s, string.Empty);

            }
            catch { return string.Empty; }
        }

        //remove leading user
        private static string RemoveLeadingUser(this string s)
        {
            var regex = new Regex(@"^@([A-Za-z0-9_]+)(:?)[\s]", RegexOptions.IgnoreCase);
            try { return regex.Replace(s, string.Empty); }
            catch { return string.Empty; }
        }

        //remove multiple users anywhere
        private static string RemoveMultipleUsers(this string s)
        {
            var regex = new Regex(@"(@([A-Za-z0-9_]+)(:?)[\s]){2,}", RegexOptions.IgnoreCase);
            try { return regex.Replace(s, string.Empty); }
            catch { return string.Empty; }
        }

        //clean out garbage
        private static string CleanOutGarbage(this string s)
        {
            var regex = new Regex(@"[^-\]\\`~!@#$%^&*()_+={}[|:;""',./<>?’“”\w\s#-+]", RegexOptions.IgnoreCase);
            try { return regex.Replace(s, string.Empty); }
            catch { return string.Empty; }
        }

        //remove surrounding quotes
        private static string RemoveSurroundingQuotes(this string s)
        {
            var regex = new Regex(@"(^[`’“”\""'])|([`’“”\""']$)", RegexOptions.IgnoreCase);
            try { return regex.Replace(s, string.Empty); }
            catch { return string.Empty; }
        }

        //split on hyphen and underscore
        private static string ParseMultiWord(this string s)
        {
            s = s.Replace("-", " ");
            s = s.Replace("_", " ");
            s = string.Format(@" {0} ", s);

            return s;
        }

        //split camel case
        public static string SplitCamelCase(this string s)
        {
            s = Regex.Replace(Regex.Replace(s, @"(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2"), @"(\p{Ll})(\P{Ll})", "$1 $2");
            s = s.ParseMultiWord();
            return s;
        }

        //parse users
        private static string ParseUserToMultiWord(this string s)
        {
            var regex = new Regex("@([A-Za-z0-9_]+)", RegexOptions.IgnoreCase);
            try
            {
                foreach (Match match in regex.Matches(s))
                {
                    s = s.Replace(match.Value, match.Value.SplitCamelCase());
                }

                s = s.Replace("@", string.Empty);
                return s;
            }
            catch { return string.Empty; }
        }

        //parse users
        private static string ParseHashToMultiWord(this string s)
        {
            var regex = new Regex(@"(^|[^0-9A-Z&/]+)(#|\uFF03)([0-9A-Z_]*[A-Z_]+[a-z0-9_\\u00c0-\\u00d6\\u00d8-\\u00f6\\u00f8-\\u00ff]*)", RegexOptions.IgnoreCase);
            try
            {
                foreach (Match match in regex.Matches(s))
                {
                    s = s.Replace(match.Value, match.Value.SplitCamelCase());
                }

                s = s.Replace("#", string.Empty);
                return s;
            }
            catch { return string.Empty; }
        }

        //remove extra spaces
        private static string RemoveExtraSpaces(this string s)
        {
            var regex = new Regex("[ ]{2,}", RegexOptions.IgnoreCase);
            try { return regex.Replace(s, " "); }
            catch { return string.Empty; }
        }

        //remove loose
        private static string RemoveLoose(this string s)
        {
            var forboden = new List<string>
                {
                    "https",
                    "http",
                    " htt "
                };

            try { return forboden.Aggregate(s, (current, token) => current.Replace(token, string.Empty)); }
            catch { return string.Empty; }
        }

        //randomly shuffle generic lists
        public static void Shuffle<T>(this IList<T> list)
        {
            var rng = new Random();
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        #endregion
    }
}

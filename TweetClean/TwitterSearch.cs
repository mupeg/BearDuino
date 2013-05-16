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
using System.Web;
using System.Xml.Linq;

namespace TweetClean
{
    public class TwitterSearch
    {
        public static List<Tweet> GetSearchResults(string searchString, int page)
        {
            //More parameters then this. Most important is the page parameter. You can &page=1 to xxx.
            var url = string.Format("http://search.twitter.com/search.atom?lang=en&q={0}&rpp=100&page={1}", HttpUtility.UrlEncode(searchString), page);
            var doc = XDocument.Load(url);
            XNamespace ns = "http://www.w3.org/2005/Atom";

            var tweets = (from item in doc.Descendants(ns + "entry")
                          select new Tweet
                          {
                              Id = item.Element(ns + "id").Value,
                              Published = DateTime.Parse(item.Element(ns + "published").Value),
                              Title = item.Element(ns + "title").Value,
                              Content = item.Element(ns + "content").Value,
                              Link = (from XElement x in item.Descendants(ns + "link")
                                      where x.Attribute("type").Value == "text/html"
                                      select x.Attribute("href").Value).First(),
                              Image = (from XElement x in item.Descendants(ns + "link")
                                       where x.Attribute("type").Value == "image/png"
                                       select x.Attribute("href").Value).First(),
                              Author = new Author()
                              {
                                  Name = item.Element(ns + "author").Element(ns + "name").Value,
                                  Uri = item.Element(ns + "author").Element(ns + "uri").Value
                              }

                          }).ToList();
            return tweets;
        }
    }
}

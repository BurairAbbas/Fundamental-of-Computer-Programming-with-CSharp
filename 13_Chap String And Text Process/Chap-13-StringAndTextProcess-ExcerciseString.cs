using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Chap13StringAndTextProcessEx
{
    class ExcerciseString
    {
        // part 2: take string and reserve it
        protected string ReverseString(string text)
        {
            // stringBuilder to optimize the GC memory 
            StringBuilder reverseSB = new StringBuilder();
            for (int index = text.Length - 1; index >= 0; index--)
            {
                reverseSB.Append(text[index]);
            }
            return reverseSB.ToString();
        }

        //part 3: check weather parentheses are placed correctly or not
        protected void ParenthesesCheck()
        {
            string parentheses = "((a+b)/5+b)";
            int count = 0;
            for (int index = 0; index < parentheses.Length; index++)
            {
                if (parentheses[index] == '(')
                {
                    count++;
                }
                else if (parentheses[index] == ')')
                {
                    count--;
                }
            }
            Console.WriteLine(count == 0 ? "Correct" : "Incorrect");

        }
        //part 4: backlash in the text
        protected void Backlash()
        {
            string splitblack = "one\\two\\three";
            char[] seperator = { '\\' };
            string[] result = splitblack.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
        //part 5: detect how many time 'in' in the text
        protected void TextDetector()
        {
            string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight." +
            "So we are drinking all the day. We will move out of it in 5 days.";
            text = text.ToLower();
            string keyword = "in";
            int startIndex = text.IndexOf(keyword);
            int count = 0;
            while (startIndex != -1)
            {
                count++;
                startIndex = text.IndexOf(keyword, startIndex + 1);
            }
            Console.WriteLine(count);
        }
        // part 6: modifier the casing
        protected void UpperCaseTag()
        {
            string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
            //get the last char of the open html tag
            int stIndexOpenTag = text.IndexOf(">");
            // get the starting char of html text.
            int stIndexCloseTag = text.IndexOf("<", stIndexOpenTag);
            // So, change word into upper case between these two index
            while (stIndexOpenTag != -1)
            {
                /// seperate the word by Substring from text
                /// start from opentag + 1 (so it don't consider last char of tag '>' )
                /// length of word between open and closed tag ('<' - '>') and - 1 so don't consider close tag
                string upercasestring = text.Substring(stIndexOpenTag + 1, (stIndexCloseTag - stIndexOpenTag - 1));
               
                // replace word by converting it into uppercase
                text = text.Replace(upercasestring, upercasestring.ToUpper());
                
                // start find next open tag after the close tag in text
                stIndexOpenTag = text.IndexOf(">", stIndexCloseTag + 9);
                
                // start find the close attribute of upercase after open tag index
                stIndexCloseTag = text.IndexOf("<", stIndexOpenTag + 1);
            }
            //remove those tag from text
            // find index of first open tag
            stIndexOpenTag = text.IndexOf("<");
            stIndexCloseTag = text.IndexOf(">");
            while (true)
            {
                //Remove between index of open tag till the words between those tag we add +1 this time becoz we want to remove last char of tag.
                text = text.Remove(stIndexOpenTag, (stIndexCloseTag - stIndexOpenTag + 1));
                
                // if length is less then close tag then break 
                if (stIndexCloseTag < text.Length)
                {
                    // start find next tag by help of close index that why we depend on index of close text and put closetag condition.
                    stIndexOpenTag = text.IndexOf("<", stIndexCloseTag);
                    // find close index after open tag 
                    stIndexCloseTag = text.IndexOf(">", stIndexOpenTag + 1);
                }
                // to break the loop
                else { break; }
            }
            // display text
            long memory = GC.GetTotalMemory(true);
            Console.WriteLine(memory);
            Console.WriteLine(text);
        }

        //part 7: take userinput max 20 letter if string is short complements it with '*'
        protected void PadRight()
        {
            Console.WriteLine("Enter any string: ");
            string userInput = Console.ReadLine();
            string newstring = userInput.PadRight(20, '*');
            Console.WriteLine(newstring);
        }

        // part 8: convert string into form of array unicode
        protected void ConvertingStringIntoUnicode(string str)
        {
            char[] a = str.ToCharArray();
            int[] charArray = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                charArray[i] = Convert.ToChar(a[i]);
            }
            foreach (var item in charArray)
            {
                Console.Write("\\u{0:x4}", item);
            }
            Console.WriteLine();
        }

        //part 9:Encrypt text by XOR
        protected string EncryptTextByXORAndCipherCode(string data, string key)
        {
            int dataLen = data.Length;
            int keyLen = key.Length;
            char[] output = new char[dataLen];

            for (int i = 0; i < dataLen; ++i)
            {
                output[i] = (char)(data[i] ^ key[i % keyLen]);// data[0] = (T)84 ^ 115(s) = key[0]; (84)1010100 ^ 1110011(115) = 32+4+2+1=39=output[0] 
            }

            return new string(output);
        }

        // part 10: extract all sentence 
        protected void ExtractAndPrintParticularSent()
        {
            string str = "We are living in a yellow submarine.We don't have anything else." +
            "Inside the submarine is very tight.So we are drinking all the day.We will move out of it in 5 days.";
            string[] strArray = str.Split('.');
            foreach (var item in strArray)
            {
                Console.WriteLine(item);
            }
            string word = " in ";
            for (int i = 0; i < strArray.Length; i++)
            {
                // if 'in' is not find in sentence than it return -1 value and don't print that sentence
                if (strArray[i].IndexOf(word) > 0)
                {
                    Console.WriteLine(strArray[i]);
                }
            }
        }

        //part 11: Replaces the forbidden word 
        protected void ReplaceWords()
        {
            string text = "Microsoft announced its next generation C# compiler today." +
                "It uses advanced parser and special optimizer for the Microsoft CLR.";
            string newtext = text.Replace("Microsoft", "*********").Replace("C#", "**").Replace("CLR", "***");
            Console.WriteLine(newtext);
        }

        // part 12: number into decimal, hexadecimal, percentage, currency, exponential
        protected void StringFormatting()
        {
            Console.WriteLine("Enter any number: ");
            int num = int.Parse(Console.ReadLine());

            // decimal
            Console.WriteLine("{0:n2}", num);
            // hexadecimal
            Console.WriteLine("{0:x}", num);
            // percentage
            Console.WriteLine("{0:0%}", num);
            // currency
            Console.WriteLine("{0:c}", num);
        }

        //part 13: extract URL 
        protected void ExtractURL()
        {
            string url = "http://www.cnn.com/video";
            string pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            Regex checkUrl = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            string[] extractUrl = null;
            string[] seperator = { "/", "://" };
            if (checkUrl.IsMatch(url))
            {
                extractUrl = url.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                Console.WriteLine("Wrong Format of URL!");
            }
            //if (System.Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            //{
            //    {
            //        extractUrl = url.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            //    }
            //}
            foreach (var item in extractUrl)
            {
                Console.WriteLine(item);
            }
        }

        //part 14: reserver the word without remove punctuation and space
        protected void ReverseWords()
        {
            StringBuilder sbText = new StringBuilder();
            string text = "C# is not C++ and PHP is not Delphi";
            string[] textArray = Regex.Split(text, @"(?<=[.,;])");
            for (int i = textArray.Length - 1; i >= 0; i--)
            {
                sbText.Append(textArray[i]);
            }
            Console.WriteLine(sbText.ToString());
            // Console.WriteLine(textArray[1] + textArray[2]);
        }

        //part 15: dictionary 
        protected void DictionaryWords()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add(".Net", "platform for applications from Microsoft");
            dictionary.Add("CLR", "managed execution environment for .NET");
            dictionary.Add("namespace", "hierarchical organization of classes");
            bool a = true;
            while (a)
            {
                Console.WriteLine("Enter string to find in dictionary: ");
                string wordFind = Console.ReadLine();
                if (dictionary.ContainsKey(wordFind))
                {
                    string value = dictionary[wordFind];
                    Console.WriteLine(value);
                }
                else
                {
                    Console.WriteLine("Word Not Find");
                    a = false;
                }
            }
            //Console.WriteLine();
            //foreach (KeyValuePair<string,string> item in dictionary)
            //{
            //    Console.WriteLine(item.Key + " " + item.Value);
            //}
        }

        // part 16: change <a href> </a> into [URL] [/URL]
        protected void HyperLinkIntoURL()
        {
            string text = "<p>Please visit <a href=\"http://softuni.org\">our site</a> to choose a training course." +
            " Also visit <a href= \"http://forum.softuni.org\">our forum</a> to discuss the courses.</p>";
            StringBuilder sbtext = new StringBuilder();
            sbtext.Append(text.Replace("<a href", "[URL").Replace("</a>", "[/URL]").Replace(">our", "]our"));
            Console.WriteLine(sbtext);
        }

        //part 17: read two dates and calculate number of days between between.
        protected void DifferenceDate()
        {
            try
            {
                Console.WriteLine("Enter first any date in DD/mm/YYYY format: ");
                string date = Console.ReadLine();

                string format = "d/M/yyyy";
                DateTime firstDate;
                firstDate = DateTime.ParseExact(date, format, System.Globalization.CultureInfo.InvariantCulture);
                Console.WriteLine("Enter second date on above format: ");
                date = Console.ReadLine();
                DateTime seconddate;
                seconddate = DateTime.ParseExact(date, format, System.Globalization.CultureInfo.InvariantCulture);
                int count = 0;
                while (firstDate < seconddate)
                {
                    firstDate = firstDate.AddDays(1);
                    count++;
                }
                Console.WriteLine(count);
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong Format");
            }
        }

        //prt 18: entered in the format day.month.year hour:minutes:second
        protected void Added6AndHalfHour()
        {
            Console.WriteLine("Enter date in day/month/year hour:minutes:second format: ");
            string userdate = Console.ReadLine();
            string format = "d/M/yyyy h:mm:ss";
            DateTime date = DateTime.ParseExact(userdate, format, System.Globalization.CultureInfo.InvariantCulture);
            Console.WriteLine("Current Date is " + date);
            Console.WriteLine("After Six and half an hour");
            date = date.AddHours(6);
            date = date.AddMinutes(30);
            Console.WriteLine("Now Date is " + date);
        }

        //part 19: extract email from text 
        protected void ExtractMail()
        {
            string text = "Please contact us by phone (+001 222 222 222) or by email at" +
                " example@gmail.com or at test.user@yahoo.co.uk."
                + " This is not email: test@test. This also: @gmail.com. Neither this: a@a.b.";
            Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@[gmail|yahoo|hotmail]*\.(com|co.uk)");
            MatchCollection match = emailRegex.Matches(text);
            foreach (Match emailMatch in match)
            {
                Console.WriteLine(emailMatch);
            }
        }

        //part 20: Extract Date from text in DD.MM.YYYY stantard format of canada
        protected void ExtractDate()
        {
            //All this comment are tells me how many time i try different thing to make it work;
            // i am doing it from 9:20 and now time is 11:47
            string text = "I was born at 14.06.1980. My sister was born at 3.7.1984 . In 5/1999 I graduated my high school."
                + " The law says (see section 7.3.12) that we are allowed to do this (section 7.4.2.9).";

            // string[] format = { "DD.MM.YYYY", "D.M.YYYY", "dd/MM/yyyy", "d/m/yyyy" };

            // \d for number, {1,2} range from 1 to 2 digits and 4 digits, '.' between them, @ to remove bachlash'\' error 
            Regex r = new Regex(@"\d{1,2}\.\d{1,2}.\d{4}");

            //i don't know why the hell this didn't worked

            //System.Globalization.CultureInfo.InvariantCulture
            // MatchCollection dates = r.Matches(DateTime.ParseExact(text, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None).ToString());
            // DateTime dates = DateTime.ParseExact(newtext,format.ToString() ,System.Globalization.CultureInfo.InvariantCulture);
            // DateTime date = DateTime.ParseExact(text, format, System.Globalization.CultureInfo.InvariantCulture);/

            //It don't work becoz 'Match' return only first match pattern in the string that why its showing only first result
            //Match match = Regex.Match(text, @"(\d{1,2})\.(\d{1,2})\.(\d{4})");
            //foreach (var item in match.Value)
            //{
            //    Console.WriteLine(item);
            //}
            //Matches return of the match pattern in the string 
            foreach (var item in r.Matches(text))
            {
                Console.WriteLine(item);
            }

            // from stackoverflow and i do above problem by this solution 

            //string stringWithDate = "Employee Filter: All Employees; Time Entry Dates: 01/07/2016-01/07/2016; Exceptions: All Exceptions";
            //Match match = Regex.Match(stringWithDate, @"\d{2}\/\d{2}\/\d{4}");
            //string date = match.Value;
            //if (!string.IsNullOrEmpty(date))
            //{
            //    var dateTime = DateTime.ParseExact(date, "MM/dd/yyyy", CultureInfo.CurrentCulture);
            //    Console.WriteLine(dateTime.ToString());
            //}

            //Console.WriteLine(dates);
        }

        //part 21: extract palindromes

        protected void ExtractPalindromes()
        {
            // text
            string text = "i am gonna extract abba, lamal mean palindrome words";
           
            // to seperater the words from text
            char[] seperator = { ' ', ',' };
           
            // splitting words from text and removing empty space between them
            string[] textarry = text.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
           
            // stringBuilder to add reverse order of words with optimize memory space
            StringBuilder checkword = new StringBuilder();
            
            // array that get padanlium words
            string[] extractedWord = new string[textarry.Length];
           
            // index of above array
            int indexOfEx = -1;
          
            //take single word from text Array and store it
            string eachWord;
            
            for (int i = 1; i < textarry.Length; i++)
            {
                // take one word at a time and reverse it for checkword String
                eachWord = textarry[i];
                //take length of each word and run in a loop in reverse order
                for (int j = textarry[i].Length - 1; j >= 0; j--)
                {
                    //Append each word in checkword
                    checkword.Append(eachWord[j]);
                }
                // if word are match then process
                if (textarry[i] == checkword.ToString())
                {
                    // if word match then store word in extractedword
                    extractedWord[++indexOfEx] = textarry[i];
                    // replace padanlium word with space
                    text = text.Replace(textarry[i], "");
                }
                // clear checkword string so it don't mixup previous word with upcoming word
                checkword.Clear();
            }
            // display text so show changes in it.
            Console.WriteLine(text);
            //display palandium words
            Console.WriteLine("palandium words are: ");
            foreach (string item in extractedWord)
            {
                // remove empty/null spaces form array
                if (item != null)
                {
                    Console.WriteLine(item);
                }
            }
            // it resize the array length at run time; ref is use; indexOfEx is 1(at 0 abbba, at 1 lamal) so array length become
            // 1 and array run n-1 so it show only one value in array which is at index 0(abba) that why i add '+1' in NewSize
            // so length become 2 and array run till 1 and show all value in array
            //Array.Resize(ref extractedWord, indexOfEx + 1);
            //foreach (var item in extractedWord)
            //{
            //    Console.WriteLine(item);
            //}
        }

        //part 22: Get userinput and print LETTERS in alphabetical order and how many times each one accurs.
        protected void OrderListOfLetters()
        {
            Console.WriteLine("Enter any string here: ");
            string userInput = Console.ReadLine();           
            // to remove the blank space from text;
            userInput = userInput.Replace(" ", "");
            
            char?[] eachLetter = new char?[userInput.Length];
            int?[] timesEachLetter = new int?[200];
            char swapchar;
            int num1, num2;

            for (int index = 0; index < userInput.Length; index++)
            {
                // Console.WriteLine("userinput[{0}] = {1}", index, userInput[index]);
                eachLetter[index] = userInput[index];
                // Console.WriteLine("eachletter[{1}] = {0}", eachLetter[index], index);
            }

            for (int i = 0; i < userInput.Length; i++)
            {
                for (int index = 0; index < userInput.Length - 1; index++)
                {
                    num1 = Convert.ToInt32(eachLetter[index]);
                    num2 = Convert.ToInt32(eachLetter[index + 1]);
                    //       Console.WriteLine("num1 = {0}, num2 = {1}", num1, num2);
                    if (num1 > num2)
                    {
                        swapchar = (char)eachLetter[index];
                        eachLetter[index] = eachLetter[index + 1];
                        eachLetter[index + 1] = swapchar;
                    }
                }
            }
            int times = 1;
            for (int i = 0; i < userInput.Length - 1; i++)
            {
                if (eachLetter[i] == eachLetter[i + 1])
                {
                    timesEachLetter[(int)eachLetter[i]] = ++times;
                }
                else
                {
                    times = 1;
                    if (timesEachLetter[(int)eachLetter[i]] > 1)
                    {
                        timesEachLetter[(int)eachLetter[i + 1]] = 1;
                    }
                    else
                    {
                        timesEachLetter[(int)eachLetter[i]] = 1;
                    }
                }
            }
            for (int i = 0; i < userInput.Length - 1; i++)
            {
                if (eachLetter[i] != eachLetter[i + 1])
                {
                    Console.WriteLine("{0} = {1}", eachLetter[i], timesEachLetter[(int)eachLetter[i]]);
                }
            }
        }

        // part 23:Get userinput and print WORDS in alphabetical order and how many times each one accurs. 
        protected void OrderListOfWords()
        {
            Console.WriteLine("Enter the string here: ");
            string userinput = Console.ReadLine();

            // dictionary class to make work easy becoz it manage each key with its value
            Dictionary<string, int> eachWords = new Dictionary<string, int>();
            // to seperate the userinput with every possible user seperator
            char[] seperator = { ' ', '.', ',' };
            // to splitwords and remove spaces between them
            string[] spiltWords = userinput.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            // count how many time each word occurs
            int counts = 1;

            // display splitword string
            //foreach (var item in spiltWords)
            //{
            //    Console.WriteLine(item);
            //}

            // for sort i used nested loops
            for (int i = 0; i < spiltWords.Length; i++)
            {
                for (int j = i; j < spiltWords.Length - 1; j++)
                {
                    // [j + 1] so it don't take words at the same index; ex splitwords[0] = i and splitwords[j] also i, so it counts its as 2 'i' in same text
                    if (spiltWords[i] == spiltWords[j + 1])
                    {
                        // if words are equall then add one
                        counts++;
                    }
                }
                // ContainKey check for same word if there is no same word then it enter that word in distionary class
                if (!eachWords.ContainsKey(spiltWords[i]))
                    eachWords.Add(spiltWords[i], counts);
                // count 1 so we don't add 1 in previous value of count
                counts = 1;
            }
            //foreach (KeyValuePair<string,int> item in eachWords)
            //{

            //    Console.WriteLine("{0} " + "= {1}", item.Key, item.Value);
            //}

            // to arrange in ascending order
            List<string> list = eachWords.Keys.ToList();
            list.Sort();

            foreach (var item in list)
            {
                Console.WriteLine("{0} " + "= {1}", item, eachWords[item]);
            }
        }

        // part 24: replace every identical letter with single letter
        protected void IdenticalLetters()
        {
            Console.WriteLine("Enter any string here: ");
            string userinput = Console.ReadLine();

            StringBuilder sbresult = new StringBuilder();
            for (int i = 0; i < userinput.Length - 1; i++)
            {
                if (userinput[i] != userinput[i + 1])
                {
                    sbresult.Append(userinput[i]);
                }
            }
            if (userinput[userinput.Length - 1] == userinput[userinput.Length - 2])
            {
                sbresult.Append(userinput[userinput.Length - 1]);
            }
            Console.WriteLine(sbresult);
        }

        // part 25: seperate by commas and print in alphabetic order
        protected void CommasAndOrder()
        {
            Console.WriteLine("Enter string here: ");
            string userInput = Console.ReadLine();

            string[] splitUserInput = userInput.Split(',');

            // my book to sort array
            Array.Sort(splitUserInput);

            // my internet to sort array
            //var list = splitUserInput.ToList();
            //list.Sort();

            foreach (var item in splitUserInput)
            {
                Console.WriteLine(item);
            }
        }

        //part 26: remove tag from html
        protected void HtmlEditor()
        {
            string htmlTag = "<html>" +
"<head><title>News</title></head>" + Environment.NewLine +
"<body><p><a href=\"http://softuni.org\">Software" +
"University</a>aims to provide free real-world practical" +
"training for young people who want to turn into " +
"skillful software engineers.</p></body>" +
"</html>";
            // to get the index value of tags 
            int starttag, endtag;

            starttag = htmlTag.IndexOf('<');
            while (starttag >= 0)
            {  
                endtag = htmlTag.IndexOf('>', starttag);
                htmlTag = (htmlTag.Remove(starttag, (endtag - starttag + 1)));
                starttag = htmlTag.IndexOf('<');
            }
            Console.WriteLine(htmlTag);
        }

        public void MainEx()
        {
            //string reserveString = ReverseString("introduction");
            //Console.WriteLine(reserveString);
            //ParenthesesCheck();
            //Backlash();
            //TextDetector();

            //UpperCaseTag();
            //PadRight();
            //Console.WriteLine("Enter any string: ");
            //string str = Console.ReadLine();
            //ConvertingStringIntoUnicode(str);

            //string text = "Test";
            //string key = "sb";
            //string cipherText = EncryptTextByXORAndCipherCode(text, key);
            //string plainText = EncryptTextByXORAndCipherCode(cipherText, key);            
            //Console.WriteLine("\\u{0:x4}",cipherText);
            //Console.WriteLine(plainText);           
            //ExtractAndPrintParticularSent();

            //ReplaceWords();
            //StringFormatting();
            //ExtractURL();
            //ReverseWords();
            //DictionaryWords();

            //HyperLinkIntoURL();            
            //DifferenceDate();
            //Added6AndHalfHour();
            //ExtractMail();
            //ExtractDate();

            //ExtractPalindromes();
            //OrderListOfLetters();
            //OrderListOfWords();
            //IdenticalLetters();
            //CommasAndOrder();
            HtmlEditor();

        }
    }
}

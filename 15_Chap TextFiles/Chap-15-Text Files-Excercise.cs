using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Chap15TextFiles
{
    class Excercise
    {
        //part1: read a text file and print odd lines
        public void PrintOddLine()
        {
            StreamReader reader = new StreamReader(@"TextFilesEx\number.txt");
            try
            {
                using (reader)
                {
                    int oddcounter = 0;
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        if (oddcounter % 2 != 0)
                        {
                            Console.WriteLine("Line {0}: {1}", oddcounter, line);
                        }
                        oddcounter++;
                        line = reader.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File Not Found");
            }
        }

        //part 2: joint two text file and record its result in third file
        public void JointFiles()
        {
            try
            {
                StreamReader reader1 = new StreamReader(@"TextFilesExpt2File1.txt");
                StreamReader reader2 = new StreamReader(@"TextFilesEx\pt2File2.txt");

                //to store reault in third file and apprend is true to add new file in new line
                StreamWriter resultwriter = new StreamWriter(@"TextFilesEx\pt2Result.txt", true);

                using (reader1)
                {
                    using (reader2)
                    {
                        using (resultwriter)
                        {
                            string line1 = reader1.ReadLine();
                            string line2 = reader1.ReadLine();
                            string result;
                            while (line1 != null || line2 != null)
                            {
                                result = line1 + line2;
                                resultwriter.WriteLine(result);
                                line1 = reader1.ReadLine();
                                line2 = reader2.ReadLine();
                            }
                        }
                    }
                }
            }
            catch (FileLoadException)
            {
                Console.WriteLine("File not found");
            }
            catch (IOException)
            {
                Console.WriteLine("Error");
            }
        }

        //part 3:add line number and rewite the file
        public void WriteLineNumber()
        {
            try
            {
                StreamReader reader = new StreamReader(@"TextFilesEx\number.txt");
                StreamWriter write = new StreamWriter(@"TextFilesEx\numberWithLine.txt", true);
                using (reader)
                {
                    using (write)
                    {
                        string line = reader.ReadLine();
                        int linenumber = 0;
                        while (line != null)
                        {
                            linenumber++;
                            write.WriteLine("Line Number {0}: {1}", linenumber, line);
                            line = reader.ReadLine();
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not Found");
            }
        }

        //part 4: compare two textfiles print number of equal and number of different lines
        public void ComparingTextFile()
        {
            try
            {
                StreamReader reader1 = new StreamReader(@"TextFilesEx\pt2File1.txt");
                StreamReader reader2 = new StreamReader(@"TextFilesEx\pt2File2.txt");
                using (reader1)
                {
                    using (reader2)
                    {
                        int rowcounter = 0;
                        int line1counter = 0;
                        int line2counter = 0;
                        string line1 = reader1.ReadLine();
                        string line2 = reader2.ReadLine();
                        while (line1 != null || line2 != null)
                        {
                            while (line1 != null && line2 != null)
                            {
                                rowcounter++;
                                line1 = reader1.ReadLine();
                                line2 = reader2.ReadLine();
                            }
                            if (line1 != null)
                            {
                                line1counter++;
                                line1 = reader1.ReadLine();
                            }
                            else
                            {
                                line2counter++;
                                line2 = reader2.ReadLine();
                            }

                        }

                        Console.WriteLine("Number of equal line r {0} and different lines are {1}", rowcounter, line1counter > 0 ? line1counter : line2counter);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("FileNot Found");
            }
            catch (IOException)
            {
                Console.WriteLine("Error");
            }
        }

        //part 5: maximal sum of 2x2 matrix
        public void MaximalSumOfMatrix()
        {
            StreamReader reader = new StreamReader(@"TextFilesEx\pt5MaximalSum.txt");
            int maxsum = 0;
            string line = reader.ReadLine();
            int matrixlength = int.Parse(line);

            using (reader)
            {
                // to read the 1st 2 line from textfile
                string firstlinerow = reader.ReadLine();
                string secondlinerow = reader.ReadLine();

                int sum = 0;
                //to calculate the no# of colume
                int colume = -1;
                do
                {
                    for (int j = 0; j < matrixlength; j++)
                    {
                        //after every 2 loop sum will be 0 again so sum calculate the value of next 2x2 matrix
                        if (j == 2) { sum = 0; }
                        try
                        {
                            if (colume < 7)
                            {
                                colume++;
                                // for each blank space it add 1 in colume 
                                if (firstlinerow[colume] == ' ')
                                {
                                    colume++;
                                }
                            }
                            else { colume = 0; }
                            // to convert every number to int
                            int firstrow = int.Parse(firstlinerow[colume].ToString());
                            int seconfrow = int.Parse(secondlinerow[colume].ToString());
                            // adding sum
                            sum = firstrow + seconfrow + sum;
                            // comparing to maxsum if maxsum  is less than maxsum store sum value
                            if (maxsum < sum)
                            {
                                maxsum = sum;
                            }
                        }
                        // catch to handle any exception
                        catch (Exception)
                        {
                            Console.WriteLine("Error of for");
                        }
                    }
                    //new row of matrix to repeat the process
                    firstlinerow = reader.ReadLine();
                    secondlinerow = reader.ReadLine();

                    // again initialize with default value so it don't create logical error
                    sum = 0;
                    colume = -1;

                    // repeat the process until row become null
                } while (firstlinerow != null);
                // print the max sum of 2x2 matrix
                Console.WriteLine(maxsum);
            }
        }

        //part 6: read name form list arrange it and write them on another list.

        public void NameArrangementList()
        {
            try
            {
                StreamReader reader = new StreamReader(@"TextFilesEx\pt6Names.txt");
                StreamWriter writer = new StreamWriter(@"TextFilesEx\pt6ArrangeNames.txt");
                //string[] ArrangeNameList = new string[50];
                //int index = 0;

                List<string> ArrangeNameList = new List<string>();

                using (reader)
                {
                    using (writer)
                    {
                        string line = reader.ReadLine();

                        //Me: try to store value in Array then convert 1st letter in char than compare it... but book make the work easy.
                        //while (line != null)
                        //{
                        //    ArrangeNameList[index] = line;
                        //    // adding for next index in array
                        //    index++;
                        //    // next line store from textfile
                        //    line = reader.ReadLine();

                        //    ////resizing the Array by adding one more in array
                        //    ////at 0 index length is 1 to store value at index 1 length of array should 2 that why adding one more in resizing
                        //    //Array.Resize(ref ArrangeNameList, ++index);
                        //    //// get back to previous blank index of array 
                        //    //index--;
                        //}
                        //// Readjust the length of array
                        //Array.Resize(ref ArrangeNameList, index);

                        while (line != null)
                        {
                            ArrangeNameList.Add(line);
                            line = reader.ReadLine();
                        }
                        ArrangeNameList.Sort();
                        foreach (var item in ArrangeNameList)
                        {
                            writer.WriteLine(item);
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File Not Found");
            }
            catch (IOException)
            {
                Console.WriteLine("Error");
            }
        }

        //part 7: replace every occurence substring start with finish in a text file.
        //part 8: change whole words (not part of word)
        public void WholeFileSubstring()
        {
            using (StreamReader reader = new StreamReader(@"TextFilesEx\pt7and8Wholefile.txt"))
            {
                // part 8 finish
                string line = reader.ReadToEnd();
                //start change into finish
                string replaceline = line.Replace("start", "finish");
                using (StreamWriter writer = new StreamWriter(@"TextFilesEx\pt7and8WholefileDone.txt"))
                {
                    foreach (var item in replaceline)
                    {
                        writer.Write(item);
                    }
                }
            }
        }

        //part 9: delete all odd files
        public void DeleteOddFiles()
        {
            using (StreamReader reader = new StreamReader(@"TextFilesEx\numberWithLine.txt"))
            {
                string line = reader.ReadLine();
                int linenumber = 1;
                while (line != null)
                {
                    if (linenumber % 2 == 0)
                    {
                        using (StreamWriter writer = new StreamWriter(@"TextFilesEx\pt9DeleteOddLinefile.txt", true))
                        {
                            writer.WriteLine(line);
                        }
                    }
                    line = reader.ReadLine();
                    linenumber++;
                }
            }
        }

        //part 10: extract from XML file the txext only not tags
        public void ExtractTextFromXML()
        {
            using (StreamReader reader = new StreamReader(@"TextFilesEx\pt10ExtractText.txt"))
            {
                using (StreamWriter writer = new StreamWriter(@"TextFilesEx\pt10ExtractDone.txt", true))
                {
                    string line = reader.ReadLine();
                    // start index of '>' from closing of tag
                    int startindex;
                    // take index from '<' from start of index 
                    int endindex;
                    int difference;
                    // for exceptional index
                    int exceptionendindex;
                    // run untill line is not null
                    while (line != null)
                    {
                        startindex = line.IndexOf(">");
                        endindex = line.IndexOf("<", startindex);
                        difference = endindex - startindex;
                        // take starting index for the text which are on next lines 
                        exceptionendindex = line.IndexOf("<");
                        // if exceptional index is greater then diffence between exception index value
                        if (exceptionendindex > 1)
                        {
                            difference = exceptionendindex;
                        }
                        // run till all tag are not check
                        while (startindex != -1 && endindex != -1)
                        {
                            if (difference > 1)
                            {
                                string word;
                                if (exceptionendindex > 1)
                                {
                                    word = line.Substring(0, difference);
                                    writer.WriteLine(word);
                                }
                                else
                                {
                                    word = line.Substring(startindex + 1, difference - 1);
                                    writer.WriteLine(word);
                                }
                            }
                            startindex = line.IndexOf(">", endindex);
                            endindex = line.IndexOf("<", startindex);
                            difference = endindex - startindex;
                            exceptionendindex = 0;
                        }
                        line = reader.ReadLine();
                    }
                }
            }
        }

        //part 11: delete words 'test' form textfile
        public void DeleteWordTest()
        {

            string line;
            using (StreamReader reader = new StreamReader(@"TextFilesEx\pt11DeleteWordTest.txt"))
            {
                line = reader.ReadToEnd();
                line = line.Replace("test", "");
            }
            using (StreamWriter writer = new StreamWriter(@"TextFilesEx\pt11DeleteWordTest.txt"))
            {
                writer.WriteLine(line);
            }
        }

        //part 12: word.txt which contain different words. text.txt delete all the words those occure in another file(word.txt)
        public void DeleteTextWordFromTextFile()
        {
            // to to remove delete text gab between textfile. stringbuilder rewrite in same reference which is good to adjust words to remove gab
            StringBuilder textline = new StringBuilder();
            try
            {
                // read text and word files from folder
                using (StreamReader textreader = new StreamReader(@"TextFilesEx\pt12Text.txt"))
                {
                    using (StreamReader wordreader = new StreamReader(@"TextFilesEx\pt12Word.txt"))
                    {
                        // append the text of file in stringbuilder
                        textline.Append(textreader.ReadToEnd());
                        // initialize the each word from textfile word in string variable
                        string wordline = wordreader.ReadLine();
                        while (wordline != null)
                        {
                            // to delete the words from another file used buildin Replace Method
                            textline = textline.Replace(wordline, "");
                            // for next words From File
                            wordline = wordreader.ReadLine();
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File Not Found");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found Please recheck your folder name");
            }
            catch (IOException)
            {
                Console.WriteLine("IO Error");
            }

            // run loop to adjust each blank space
            for (int i = 0; i < textline.Length - 1; i++)
            {
                if (textline[i] == ' ' && textline[i + 1] == ' ')
                {
                    // run loop to to replace one character back in files when ever textfile char is blank 
                    for (int j = i; j < textline.Length - 1; j++)
                    {
                        textline[j] = textline[j + 1];
                    }
                }
            }
            try
            {
                // append is true so it write on next line not overwrite the text i file
                using (StreamWriter writer = new StreamWriter(@"TextFilesEx\pt12Text.txt", true))
                {
                    // write the stringbuilder in the existed file
                    writer.WriteLine(textline);
                }
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory Not Found Please Recheck your StreamWriter Folder path");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File Not Found in StreamWriter");
            }
            catch (IOException)
            {
                Console.WriteLine("Io Exception in StreamWriter");
            }
        }

        //part 13: read list of word, count how many in textfile and recordin result text file in sorted descending order
        //left 27/2/2020
        public void CountWordsInTextFile()
        {
           
            string resultword;
            int count = 0;
            Dictionary<string, int> wordsoccures = new Dictionary<string, int>();
            try
            {
                using (StreamReader textreader = new StreamReader(@"TextFilesEx\pt13Text.txt"))
                {
                    using (StreamReader wordreader = new StreamReader(@"TextFilesEx\pt12Word.txt"))
                    {
                        string textline = textreader.ReadToEnd();
                        string[] arraytextline = textline.Split(' ');
                        string wordline = wordreader.ReadLine();
                        for (int i = 0; i < arraytextline.Length; i++)
                        {
                            wordsoccures.Add(arraytextline[i], 0);
                        }
                        if (wordsoccures.ContainsKey(wordline))
                        {
                            //wordsoccures.Values;
                        }


                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException("Directory Not Found Please Recheck your Folder Name");
            }

        }

        public static void MainEx()
        {
            Excercise ex = new Excercise();
            //ex.PrintOddLine();
            //ex.JointFiles();
            //ex.WriteLineNumber();
            //ex.ComparingTextFile();
            //ex.MaximalSumOfMatrix();
            //ex.NameArrangementList();
            //ex.WholeFileSubstring();
            //ex.DeleteOddFiles();
            //ex.ExtractTextFromXML();
            //ex.DeleteWordTest();
            //ex.DeleteTextWordFromTextFile();
        }

    }

}

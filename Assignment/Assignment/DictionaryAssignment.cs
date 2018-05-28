using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Assignment
{
    public class DictionaryAssignment
    {
        ArrayList list = null;

        /// <summary>
        /// Method to read the file line by line 
        /// Store the file content into arraylist 
        /// </summary>
        /// <param name="filePath"> path of file to read</param>
        public void ReadFile(string filePath)
        {
            list = new ArrayList();
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(filePath);
                string line = sr.ReadLine();
                while (line != null)
                {
                    list.Add(line);
                    line = sr.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ëxception Occurred: " + ex.Message);
            }
            finally
            {
                // close the StreamReader object
                sr.Close();
            }
        }

        /// <summary>
        /// Methos to write dictionary words in a sequence followed by their meanings.
        /// Here Assumed that Deliemeter for word and meaning is '-' and for multiple meanings ia ',' 
        /// </summary>
        /// <param name="filePath">File path</param>
        public void WriteDictionayIntoFile(string readFilePath, string writeFilePath, bool isWriteOnConsole)
        {

            if (isWriteOnConsole)
                Console.WriteLine("Writing Words and its meaning into a file");
            StreamWriter sw = null;
            try
            {
                if (!File.Exists(readFilePath))
                    Console.WriteLine("File Does not exists . Enter valid file path to read file");
                if (!File.Exists(writeFilePath))
                    Console.WriteLine("File Does not exists . Enter valid file path to write into file");
                
                ReadFile(readFilePath);
                sw = new StreamWriter(writeFilePath);
                if (list != null)
                {
                    foreach (string line in list)
                    {
                        string[] split1 = line.Split('-');

                        // Write word in file
                        sw.WriteLine(split1[0].Trim());
                        if (isWriteOnConsole)
                            Console.WriteLine(split1[0].Trim());
                        string[] split2 = split1[1].Split(',');
                        for (int i = 0; i < split2.Length; i++)
                        {
                            sw.WriteLine("Meaning: " + split2[i].Trim());
                            if (isWriteOnConsole)
                                Console.WriteLine("Meaning: " + split2[i].Trim());
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Ëxception Occurred: " + ex.Message);
            }
            finally
            {
                // close the StreamReader object
                sw.Close();
            }
        }
    }
}
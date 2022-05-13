using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CsvHelper;
//using WritingCSV;

namespace SimplePassV19
{
    public class MyPassWriter
    {
        public List<Profile> Profiles { get; set; }
        public string Filename { get; set; }

        public string Filepath { get; set; }

        public MyPassWriter(string filename)
        {
            Profiles = new List<Profile>();
            Filename = filename;
            //Filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Filepath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), filename);
        }

        

        public Profile WritePass(string account, string username, string password) 
        {
            Profile prof = new Profile(account, username, password);

            try
            {
                using (StreamWriter sw = File.CreateText(Filepath))
                //using (StreamWriter sw = new StreamWriter(@Filename, append: true))
                {
                    sw.WriteLine(prof.ToString());
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error with 'using' statement\n", ex);
            }
            
            return prof;
        }

        public int ReadPass()
        {
            int numItems = 0;
            string line;
            if (File.Exists(Filename))
            {
                using (StreamReader sr = new StreamReader(Filename))
                {
                    while((line = sr.ReadLine()) != null)
                    {
                        Profiles.Add(new Profile(line));
                        numItems++;
                    }
                    
                }
            }

            return numItems;
        }
    }
}

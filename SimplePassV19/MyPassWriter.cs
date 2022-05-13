using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SimplePassV19
{
    public class MyPassWriter
    {
        public List<Profile> Profiles { get; set; }
        public string Filename { get; set; }

        public MyPassWriter(string filename)
        {
            Profiles = new List<Profile>();
            Filename = filename;
        }

        public Profile WritePass(string account, string username, string password) // needs debug--------------------------------------
        {
            Profile prof = new Profile(account, username, password);


            using (StreamWriter sr = new StreamWriter(Filename, append: true))
            {
     Console.WriteLine("In WritePass using. TEST1.1");//----------------------------------TEST-----------------------------------------
                sr.WriteLine(prof.ToString());
            }
   Console.WriteLine("In WritePass. TEST2");//----------------------------------TEST-----------------------------------------
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

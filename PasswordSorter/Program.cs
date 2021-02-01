using System;
using System.Text.RegularExpressions;

namespace PasswordSorter
{
    class Program

    {
        static void Main(string[] args)
        {

            // file path strings
            string path1 = "/Users/colt/Projects/PasswordSorter/PasswordSorter/10k-most-common.txt"; //contains 10,000 passwords
            string path2 = "/Users/colt/Projects/PasswordSorter/PasswordSorter/1mil-most-common.txt"; //contains 673,908 passwords
            string path3 = "/Users/colt/Projects/PasswordSorter/PasswordSorter/rockyou.txt"; //contains 14,344,391 passwords

            // regex strings
            string uppercaseCheck = "[A-Z]";
            string lowercaseCheck = "[a-z]";
            string numberCheck = "[0-9]";
            string specialCharCheck = "[^A-Za-z0-9]";

            // accepted passwords counter
            int accepted = 0;

            // call the file processing method, passing it file path string
            string[] passwords = processFile(path3);

            Console.WriteLine("Accepted Passwords List: ");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            // loop through string[] of all passwords
            foreach (string password in passwords)
            {
                // check for min length of 12
                if (password.Length > 11)
                {
                    // check for uppercase char
                    if (checkPassword(password, uppercaseCheck))
                    {
                        // check for lowercase char
                        if (checkPassword(password, lowercaseCheck))
                        {
                            // check for number
                            if (checkPassword(password, numberCheck))
                            {
                                // check for special char
                                if (checkPassword(password, specialCharCheck))
                                {
                                    // print password if sucessful
                                    Console.WriteLine(password);
                                    // bump counter
                                    accepted++;

                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Accepted Passwords Count: {0}", accepted);

            // function for processing file
            // expects a file path string
            static string[] processFile(string filename)
            {
                // create and return string array of passwords from file
                string[] passwords = System.IO.File.ReadAllLines(@filename);
                return passwords;
            }
            // function for checking each password
            // expects a password and regex string 
            static bool checkPassword(string password, string regex)
            {
                // create new regex object
                // give it regex string
                Regex rx = new Regex(regex);

                // store in a result var
                var result = rx.Matches(password);
                // if password contains at least one expected result
                // return true
                return (result.Count > 0);
            }
        }
    }
}
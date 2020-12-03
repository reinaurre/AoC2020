using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2020
{
    public static class PasswordValidator
    {
        public static int CountValidPasswordsNew(string[] inputs)
        {
            int count = 0;

            foreach (string input in inputs)
            {
                int index1 = int.MaxValue;
                int index2 = int.MinValue;
                char key = '-';
                string password = string.Empty;

                ParseInput(input, out index1, out index2, out key, out password);

                if (ValidatePasswordNew(index1, index2, key, password))
                {
                    count++;
                }
            }

            return count;
        }

        public static int CountValidPasswords(string[] inputs)
        {
            int count = 0;

            foreach(string input in inputs)
            {
                int min = int.MaxValue;
                int max = int.MinValue;
                char key = '-';
                string password = string.Empty;

                ParseInput(input, out min, out max, out key, out password);

                if(ValidatePassword(min, max, key, password))
                {
                    count++;
                }
            }

            return count;
        }

        private static bool ValidatePasswordNew(int index1, int index2, char key, string password)
        {
            return (password[index1 - 1] == key) != (password[index2 - 1] == key);
        }

        private static bool ValidatePassword(int min, int max, char key, string password)
        {
            int count = 0;

            for(int i = 0; i < password.Length; i++)
            {
                if(password[i] == key)
                {
                    count++;
                }

                if(count > max || password.Length - i <= min - count)
                {
                    return false;
                }
            }

            return true;
        }

        private static void ParseInput(string input, out int min, out int max, out char key, out string password)
        {
            // pattern = 
            // min-max key: password
            string[] splitStr = input.Split('-', ' ', ':'); // regex would be way better but I'm on an airplane and can't look things up lol

            min = Convert.ToInt32(splitStr[0]);
            max = Convert.ToInt32(splitStr[1]);
            key = splitStr[2][0];
            password = splitStr[4];
        }
    }
}

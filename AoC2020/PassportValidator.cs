using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AoC2020
{
    public class PassportValidator
    {
        private Dictionary<string, string> requiredKeys;
        private Dictionary<string, string> optionalKeys;

        public PassportValidator(string[] requiredKeys, string[] optionalKeys)
        {
            this.requiredKeys = new Dictionary<string, string>();
            this.optionalKeys = new Dictionary<string, string>();

            foreach(string str in requiredKeys)
            {
                this.requiredKeys.Add(str, string.Empty);
            }

            foreach(string str in optionalKeys)
            {
                this.optionalKeys.Add(str, string.Empty);
            }
        }

        public int CountValidPassports(string[] inputs)
        {
            List<Dictionary<string, string>> passports = ParsePassports(inputs);

            int count = 0;

            foreach(Dictionary<string, string> passport in passports)
            {
                if (ValidatePassportFields(passport))
                {
                    count++;
                }
            }

            return count;
        }

        private bool ValidatePassportFields(Dictionary<string,string> passport)
        {
            if(passport.Keys.Count < requiredKeys.Keys.Count)
            {
                return false;
            }

            foreach(KeyValuePair<string,string> kvp in requiredKeys)
            {
                if (!passport.ContainsKey(kvp.Key))
                {
                    return false;
                }
            }

            return true;
        }

        private List<Dictionary<string, string>> ParsePassports(string[] inputs)
        {
            List<Dictionary<string, string>> passports = new List<Dictionary<string, string>>();

            Dictionary<string, string> current = new Dictionary<string, string>();

            foreach(string line in inputs)
            {
                if(line == string.Empty)
                {
                    passports.Add(current);
                    current = new Dictionary<string, string>();
                }
                else
                {
                    MatchCollection matches = Regex.Matches(line, @"([a-z]{3}):(\S+)\s?");

                    foreach (Match kvp in matches)
                    {
                        current.Add(kvp.Groups[1].Value, kvp.Groups[2].Value);
                    }
                }
            }

            // last one doesn't have a newline after it
            passports.Add(current);

            return passports;
        }
    }
}

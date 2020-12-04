using System;
using System.Collections.Generic;
using System.Linq;
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
                if (!passport.ContainsKey(kvp.Key) || !ValidateFieldContents(kvp.Key, passport[kvp.Key]))
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidateFieldContents(string key, string value)
        {
            switch (key)
            {
                case "byr": return ValidateYear(value, 1920, 2002);
                case "iyr": return ValidateYear(value, 2010, 2020);
                case "eyr": return ValidateYear(value, 2020, 2030);
                case "hgt": return ValidateHeight(value, 150, 193, 59, 76);
                case "hcl": return ValidateHexCode(value);
                case "ecl": return ValidateColorName(value);
                case "pid": return ValidNumber(value, 9);
                case "cid": return true;
                default: return false;
            }
        }

        private bool ValidNumber(string value, int length)
        {
            if(value.Length < length || value.Length > length)
            {
                return false;
            }

            return Regex.IsMatch(value, "[0-9]+");
        }

        private bool ValidateColorName(string value)
        {
            string[] valids = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

            return valids.Contains(value);
        }

        private bool ValidateHexCode(string value)
        {
            return Regex.IsMatch(value, "#[a-f0-9]{6}");
        }

        private bool ValidateHeight(string value, int minCM, int maxCM, int minIN, int maxIN)
        {
            if(value.Length <= 2)
            {
                return false;
            }

            if(value.EndsWith("cm"))
            {
                value = value.Substring(0, value.Length - 2);
                int val = Convert.ToInt32(value);

                return val >= minCM && val <= maxCM;
            }
            else if (value.EndsWith("in"))
            {
                value = value.Substring(0, value.Length - 2);
                int val = Convert.ToInt32(value);

                return val >= minIN && val <= maxIN;
            }

            return false;
        }

        private bool ValidateYear(string value, int min, int max)
        {
            if(value.Length < 4 || value.Length > 4)
            {
                return false;
            }

            int val = Convert.ToInt32(value);

            return val >= min && val <= max;
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

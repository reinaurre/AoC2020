using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AoC2020
{
    public static class AnswerChecker
    {
        public static int CountUnanimousGroupAnswers(string[] inputs)
        {
            List<Dictionary<string, int>> answerGroups = StringGroupParser(inputs);

            int count = 0;

            foreach(Dictionary<string, int> group in answerGroups)
            {
                int size = group["size"];

                foreach(KeyValuePair<string, int> answer in group)
                {
                    if(answer.Value == size && answer.Key != "size")
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public static int CountGroupAnswers(string[] inputs)
        {
            List<Dictionary<string, int>> answerGroups = StringGroupParser(inputs);

            int count = 0;

            foreach(Dictionary<string, int> group in answerGroups)
            {
                count += group.Count - 1;
            }

            return count;
        }

        public static List<Dictionary<string, int>> StringGroupParser(string[] inputs)
        {
            List<Dictionary<string, int>> groups = new List<Dictionary<string, int>>();

            Dictionary<string, int> current = new Dictionary<string, int>();

            int groupSize = 0;
            foreach (string line in inputs)
            {
                if (line == string.Empty)
                {
                    current.Add("size", groupSize);
                    groups.Add(current);

                    current = new Dictionary<string, int>();
                    groupSize = 0;
                }
                else
                {
                    groupSize++;
                    foreach(char c in line)
                    {
                        string s = c.ToString();
                        if (current.ContainsKey(s))
                        {
                            current[s] += 1;
                        }
                        else
                        {
                            current.Add(s, 1);
                        }
                    }
                }
            }

            // last one doesn't have a newline after it
            current.Add("size", groupSize);
            groups.Add(current);

            return groups;
        }
    }
}

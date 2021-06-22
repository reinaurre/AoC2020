using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AoC2020
{
    public class SatelitteMessaging
    {
        class Rule
        {
            public static Dictionary<string, Rule> Rules;

            string Literal;
            IEnumerable<IEnumerable<string>> Alts;

            public Rule(string literal) => Literal = literal;
            public Rule(IEnumerable<IEnumerable<string>> alts) => Alts = alts;

            public int Check(string s, int index = 0)
            {
                if (Literal is null)
                {
                    foreach (var alt in Alts)
                    {
                        bool match = true;
                        int localIndex = index;
                        foreach (var rule in alt)
                        {
                            int retI = Rules[rule].Check(s, localIndex);
                            if (retI != -1)
                            {
                                localIndex = retI;
                            }
                            else
                            {
                                match = false;
                                break;
                            }
                        }
                        if (match)
                        {
                            return localIndex;
                        }
                    }
                    return -1;
                }
                else
                {
                    return s.Substring(index).StartsWith(Literal) ? index + Literal.Length : -1;
                }
            }
        }

        Regex literalRegex = new Regex("^\"(\\w+)\"");
        Rule MakeRule(string s)
        {
            Match literalM = literalRegex.Match(s);
            if (literalM.Success)
            {
                return new Rule(literalM.Groups[1].Value);
            }
            else
            {
                return new Rule(s.Split("|").Select(p => p.Split(" ").Where(s => !String.IsNullOrWhiteSpace(s))));
            }
        }

        public int GetRuleZeroMatches(string[] inputs)
        {
            List<string> ruleList = new List<string>();
            List<string> valueList = new List<string>();

            int index = 0;
            while (inputs[index] != string.Empty)
            {
                ruleList.Add(inputs[index]);
                index++;
            }

            Rule.Rules = ruleList.Select(l => l.Split(": ")).ToDictionary(p => p[0], p => MakeRule(p[1]));

            index++;

            while (index < inputs.Length)
            {
                valueList.Add(inputs[index]);
                index++;
            }

            return valueList.Sum(l => Rule.Rules["0"].Check(l) == l.Length ? 1 : 0);
        }
    }

    public class SatelliteMessaging2
    {
        class Rule
        {
            public static Dictionary<string, Rule> Rules;

            string Literal;
            IEnumerable<IEnumerable<string>> Alts;
            Func<string, int, int> Func;

            public Rule(string literal) => Literal = literal;
            public Rule(IEnumerable<IEnumerable<string>> alts) => Alts = alts;
            public Rule(Func<string, int, int> func) => Func = func;

            public int Check(string s, int index = 0)
            {
                if (Literal is null && Func is null)
                {
                    foreach (var alt in Alts)
                    {
                        bool match = true;
                        int localIndex = index;
                        foreach (var rule in alt)
                        {
                            int retI = Rules[rule].Check(s, localIndex);
                            if (retI != -1)
                            {
                                localIndex = retI;
                            }
                            else
                            {
                                match = false;
                                break;
                            }
                        }
                        if (match)
                        {
                            return localIndex;
                        }
                    }
                    return -1;
                }
                else if (Literal is null)
                {
                    return Func(s, index);
                }
                else
                {
                    return s.Substring(index).StartsWith(Literal) ? index + Literal.Length : -1;
                }
            }
        }

        Regex literalRegex = new Regex("^\"(\\w+)\"");
        Rule MakeRule(string s)
        {
            Match literalM = literalRegex.Match(s);
            if (literalM.Success)
            {
                return new Rule(literalM.Groups[1].Value);
            }
            else
            {
                return new Rule(s.Split("|").Select(p => p.Split(" ").Where(s => !String.IsNullOrWhiteSpace(s))));
            }
        }

        public int GetRuleZeroMatches (string[] inputs)
        {
            List<string> ruleList = new List<string>();
            List<string> valueList = new List<string>();

            int index = 0;
            while (inputs[index] != string.Empty)
            {
                ruleList.Add(inputs[index]);
                index++;
            }

            Rule.Rules = ruleList.Select(l => l.Split(": ")).ToDictionary(p => p[0], p => MakeRule(p[1]));

            Rule.Rules["0"] = new Rule((s, i) =>
            {
                i = Rule.Rules["42"].Check(s, i);
                if (i != -1)
                {
                    i = Rule.Rules["42"].Check(s, i);
                    if (i != -1)
                    {
                        int matches = 0;
                        while (true)
                        {
                            var retI = Rule.Rules["42"].Check(s, i);
                            if (retI != -1)
                            {
                                i = retI;
                                matches++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        i = Rule.Rules["31"].Check(s, i);
                        if (i != -1)
                        {
                            while (matches > 0)
                            {
                                var retI = Rule.Rules["31"].Check(s, i);
                                if (retI != -1)
                                {
                                    i = retI;
                                    matches--;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            return i;
                        }
                    }
                }

                return -1;
            });

            index++;

            while (index < inputs.Length)
            {
                valueList.Add(inputs[index]);
                index++;
            }


            return valueList.Sum(l => Rule.Rules["0"].Check(l) == l.Length ? 1 : 0);
        }
    }
}



    // Couldn't figure it out.  My attempt is below.


    //    private Dictionary<int,Rule> rules;

    //    public int GetRuleZeroMatches(string[] inputs)
    //    {
    //        int index = ParseRules(inputs);

    //        List<string> matchedValues = rules[0].CalculateValues();

    //        int count = 0;
    //        while (index < inputs.Length)
    //        {
    //            if (matchedValues.Contains(inputs[index]))
    //            {
    //                count++;
    //            }

    //            index++;
    //        }

    //        return count;
    //    }

    //    private int ParseRules(string[] inputs)
    //    {
    //        rules = new Dictionary<int, Rule>();

    //        int index = 0;
    //        while (inputs[index] != string.Empty)
    //        {
    //            string[] input = inputs[index].Split(':');

    //            int ruleNum = int.Parse(input[0]);
    //            if (!rules.ContainsKey(ruleNum))
    //            {
    //                rules.Add(ruleNum, new Rule(ruleNum));
    //            }

    //            input = input[1].Split(' ');

    //            List<Rule> newRules = new List<Rule>();
    //            foreach (string num in input)
    //            {
    //                if (num == string.Empty)
    //                {
    //                    // do nothing
    //                }
    //                else if (num == "|")
    //                {
    //                    rules[ruleNum].AddSubRules(newRules.ToArray());
    //                    newRules.Clear();
    //                }
    //                else if (num.Contains('"'))
    //                {
    //                    rules[ruleNum].SetValue(num.Replace("\"", ""));
    //                }
    //                else
    //                {
    //                    int refNum = int.Parse(num);
    //                    if (!rules.ContainsKey(refNum))
    //                    {
    //                        rules.Add(refNum, new Rule(refNum));
    //                    }

    //                    newRules.Add(rules[refNum]);
    //                }
    //            }

    //            if (newRules.Count > 0)
    //            {
    //                rules[ruleNum].AddSubRules(newRules.ToArray());
    //                newRules.Clear();
    //            }

    //            index++;
    //        }

    //        // move past the blank line
    //        return index + 1;
    //    }
    //}

    //public class Rule
    //{
    //    public int Index { get; private set; }
    //    public List<Rule[]> subRules { get; private set; }
    //    public List<string> values { get; private set; }

    //    public Rule (int index)
    //    {
    //        Index = index;
    //    }

    //    public void SetValue(string str)
    //    {
    //        if (values == null)
    //        {
    //            values = new List<string>();
    //        }
    //        values.Add(str);
    //    }

    //    public void AddSubRules(Rule[] subs)
    //    {
    //        if (subRules == null)
    //        {
    //            subRules = new List<Rule[]>();
    //        }
    //        subRules.Add(subs);
    //    }

    //    public List<string> CalculateValues()
    //    {
    //        if (values != null && values.Count == 1)
    //        {
    //            return values;
    //        }

    //        foreach(Rule[] ruleSet in subRules)
    //        {
    //            foreach(string value in ruleSet[0].CalculateValues())
    //            {
    //                foreach(string pairedValue in ruleSet[1].CalculateValues())
    //                {
    //                    SetValue(value + pairedValue);
    //                }
    //            }
    //        }

    //        return values;
    //    }

    //    public List<string> Calc(string root)
    //    {
    //        if (values != null && values.Count == 1)
    //        {
    //            return values;
    //        }
    //        else if (values == null || values.Count == 0)
    //        {
    //            foreach(Rule[] ruleSet in subRules)
    //            {
    //                foreach(Rule rule in ruleSet)
    //                {
    //                    rule.Calc(root);
    //                }
    //            }
    //        }
    //    }
    //}
//}

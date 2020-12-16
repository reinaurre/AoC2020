using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AoC2020
{
    public class TicketScanner
    {
        private List<TicketRule> rules;
        private int[] yourTicket;
        private List<int[]> tickets;

        private List<int> invalidValues;
        
        public TicketScanner(string[] inputs)
        {
            rules = new List<TicketRule>();
            tickets = new List<int[]>();
            invalidValues = new List<int>();
            ScanInputs(inputs);
        }

        public long GetDepartureProduct()
        {
            long product = 1;

            foreach(TicketRule rule in rules.Where(x => x.Name.Contains("departure")))
            {
                product *= yourTicket[rule.Index];
            }

            return product;
        }

        public void IdentifyFields()
        {
            foreach(int[] ticket in tickets)
            {
                for(int i = 0; i < ticket.Length; i++)
                {
                    CheckRules(ticket[i], i);
                }
            }

            while (rules.Count(x => x.Index == -1) > 0)
            {
                // find rules with only 1 potential index
                List<TicketRule> solos = rules.Where(x => x.PotentialIndexes.Count(r => r.Value == true) == 1).ToList();

                foreach(TicketRule rule in solos)
                {
                    rule.SetIndex(rule.PotentialIndexes.First(x => x.Value == true).Key);

                    // remove claimed index from all other rules
                    foreach(TicketRule ticketRule in rules)
                    {
                        ticketRule.PotentialIndexes[rule.Index] = false;
                    }
                }
            }
        }

        public int FindScanningErrorRate(bool removeInvalid = false)
        {
            List<int[]> invalidTickets = new List<int[]>();

            foreach(int[] ticket in tickets)
            {
                foreach(int value in ticket)
                {
                    if (rules.Count(x => (x.LowerBounds.Item1 <= value && x.LowerBounds.Item2 >= value) || (x.UpperBounds.Item1 <= value && x.UpperBounds.Item2 >= value)) == 0)
                    {
                        invalidValues.Add(value);

                        if (removeInvalid)
                        {
                            invalidTickets.Add(ticket);
                            break;
                        }
                    }
                }
            }

            if (removeInvalid)
            {
                foreach(int[] ticket in invalidTickets)
                {
                    tickets.Remove(ticket);
                }
            }

            int sum = 0;
            foreach(int value in invalidValues)
            {
                sum += value;
            }

            return sum;
        }

        private void ScanInputs(string[] inputs)
        {
            int index = ScanRules(inputs, 0);
            // ends at blank line before "your ticket:"
            // skip "your ticket:" line
            index += 2;

            string[] ticket = inputs[index].Split(',');
            yourTicket = new int[ticket.Length];

            for(int i = 0; i < yourTicket.Length; i++)
            {
                yourTicket[i] = int.Parse(ticket[i]);
            }

            tickets.Add(yourTicket);

            // skip blank line and "nearby tickets:"
            ScanTickets(inputs, index += 3);
        }

        private int ScanRules(string[] inputs, int index)
        {
            string matchRules = @"(\w*\s*\w+\s*)+:\s([0-9]+)-([0-9]+)\sor\s([0-9]+)-([0-9]+)";

            while(inputs[index] != string.Empty)
            {
                Match match = Regex.Match(inputs[index], matchRules);

                TicketRule newRule = new TicketRule(
                    match.Groups[1].Value, 
                    int.Parse(match.Groups[2].Value), 
                    int.Parse(match.Groups[3].Value), 
                    int.Parse(match.Groups[4].Value), 
                    int.Parse(match.Groups[5].Value));
                rules.Add(newRule);
                index++;
            }

            return index;
        }

        private void ScanTickets(string[] inputs, int index)
        {
            while (index < inputs.Length)
            {
                string[] ticket = inputs[index].Split(',');
                int[] newTicket = new int[ticket.Length];

                for (int i = 0; i < yourTicket.Length; i++)
                {
                    newTicket[i] = int.Parse(ticket[i]);
                }

                tickets.Add(newTicket);
                index++;
            }
        }

        private void CheckRules(int value, int index)
        {
            foreach(TicketRule rule in rules)
            {
                if (rule.PotentialIndexes.ContainsKey(index) && rule.PotentialIndexes[index] == false)
                {
                    continue;
                }

                if ((rule.LowerBounds.Item1 <= value && rule.LowerBounds.Item2 >= value) || (rule.UpperBounds.Item1 <= value && rule.UpperBounds.Item2 >= value))
                {
                    if (!rule.PotentialIndexes.ContainsKey(index))
                    {
                        rule.PotentialIndexes.Add(index, true);
                    }
                }
                else
                {
                    if (rule.PotentialIndexes.ContainsKey(index))
                    {
                        rule.PotentialIndexes[index] = false;
                    }
                    else
                    {
                        rule.PotentialIndexes.Add(index, false);
                    }
                }
            }
        }
    }

    public class TicketRule
    {
        public string Name { get; private set; }
        public Tuple<int, int> LowerBounds { get; private set; }
        public Tuple<int, int> UpperBounds { get; private set; }
        public Dictionary<int, bool> PotentialIndexes { get; private set; }
        public int Index { get; private set; }

        public TicketRule(string name, int lowerLower, int lowerUpper, int upperLower, int upperUpper)
        {
            PotentialIndexes = new Dictionary<int, bool>();
            Index = -1;
            Name = name;
            LowerBounds = new Tuple<int, int>(lowerLower, lowerUpper);
            UpperBounds = new Tuple<int, int>(upperLower, upperUpper);
        }

        public void SetIndex(int index)
        {
            Index = index;
        }
    }
}

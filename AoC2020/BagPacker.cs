using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AoC2020
{
    public class Bag
    {
        public string Name { get; private set; }
        public Dictionary<string, int> Contents { get; private set; }

        public Bag(string name)
        {
            this.Name = name;
            this.Contents = new Dictionary<string, int>();
        }

        public void AddContents(string name, int amount)
        {
            if (this.Contents.ContainsKey(name))
            {
                this.Contents[name] = amount;
            }
            else
            {
                this.Contents.Add(name, amount);
            }
        }
    }

    public class BagPacker
    {
        public Dictionary<string, Bag> bagRules;
        public Dictionary<string, int> children;
        public HashSet<string> ancestors;

        public void ParseRules(string[] inputs)
        {
            bagRules = new Dictionary<string, Bag>();

            foreach(string input in inputs)
            {
                MatchCollection matches = Regex.Matches(input, @"(?:([0-9])\s)?([a-zA-Z]+\s[a-z-A-Z]+)(?<!bags|contain|no|other)\s");

                Bag newBag = new Bag(matches[0].Groups[2].Value);

                for(int i = 1; i < matches.Count; i++)
                {
                    newBag.AddContents(matches[i].Groups[2].Value, Convert.ToInt32(matches[i].Groups[1].Value));
                }

                if (bagRules.ContainsKey(newBag.Name))
                {
                    Console.WriteLine($"Overwriting bag {newBag.Name}");
                    bagRules[newBag.Name] = newBag;
                }
                else
                {
                    bagRules.Add(newBag.Name, newBag);
                }
            }
        }

        public int CountAncestors(string name)
        {
            if(bagRules == null)
            {
                Console.WriteLine("Call ParseRules first dummy");
                return -1;
            }

            ancestors = new HashSet<string>();

            FindAncestors(name);

            return ancestors.Count;
        }

        public int GetTotalContents(string name)
        {
            if (bagRules == null)
            {
                Console.WriteLine("Call ParseRules first dummy");
                return -1;
            }

            children = new Dictionary<string, int>();

            // minus 1 because we don't want to count the root container
            return CountChildren(name)-1;
        }

        private void FindAncestors(string name)
        {
            // Get a list of all rules that haven't been checked before contain the current bag name
            List<string> newAncestors = bagRules.Where(x => !ancestors.Contains(x.Key) && x.Value.Contents.ContainsKey(name)).Select(x => x.Key).ToList();

            if(newAncestors.Count == 0)
            {
                return;
            }

            foreach(string newAncestor in newAncestors)
            {
                ancestors.Add(newAncestor);
            }

            foreach(string newAncestor in newAncestors)
            {
                FindAncestors(newAncestor);
            }
        }

        private int CountChildren(string name)
        {
            // count yourself
            int count = 1;

            Dictionary<string, int> children = bagRules.First(x => x.Key == name).Value.Contents;

            if(children.Count == 0)
            {
                return count;
            }

            foreach(KeyValuePair<string, int> kvp in children)
            {
                count += kvp.Value * CountChildren(kvp.Key);
            }

            return count;
        }
    }
}

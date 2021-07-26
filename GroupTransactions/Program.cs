using System;
using System.Collections.Generic;
using System.Linq;

namespace AmazonQuestion1
{
    class Program
    {
        static void Main(string[] args) {
            groupTransactions(new List<string> { "notebook", "notebook", "mouse", "keyboard", "mouse" });
        }

        // notebook notebook mouse keyboard mouse
        public static List<string> groupTransactions(List<string> transactions) {
            if (transactions == null)
                return new List<string>();

            Dictionary<string, int> transDict = new Dictionary<string, int>();
            foreach (string trans in transactions) {
                if (transDict.TryGetValue(trans, out int count)) {
                    transDict.Remove(trans);
                    transDict.Add(trans, ++count);
                } else {
                    transDict.Add(trans, 1);
                }
            }

            int i = 0;
            KeyValuePair<string, int>[] keyValArr = new KeyValuePair<string, int>[transDict.Count];
            foreach (KeyValuePair<string, int> keyVal in transDict) {
                keyValArr[i] = keyVal;
                i++;
            }

            i = 0;
            var orderedTransacitons = keyValArr.OrderByDescending(x => x.Value).ThenBy(y => y.Key);
            List<string> summedTransactions = new List<string>();
            foreach (var item in orderedTransacitons) {
                summedTransactions.Add(item.Key.ToString() + ' ' + item.Value.ToString());
                i++;
            }

            return summedTransactions;
        }
    }
}

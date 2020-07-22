using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace tochka_test.Core
{
    public class StatService
    {
        public string GetStat(string str)
        {
            var result = new List<string>();

            var freq = Frequence(str);

            for (var i = 0; i < freq.Length; i++)
                result.Add($"{(char) (i + 'А')}:{freq[i]:0.000}");


            return JsonConvert.SerializeObject(result);
        }

        private double[] Frequence(string s)
        {
            var result = new double[32];
            foreach (var c in s.ToUpper())
            {
                if ((c >= 'А') && (c <= 'Я')) result[c - 'А']++;
                for (var i = 0; i < result.Length; i++)
                    result[i] /= s.Length;
            }

            return result;
        }
    }
}
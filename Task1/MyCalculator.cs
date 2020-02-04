using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class MyCalculator
    {

        public int GetBinary(int sizeoflist)
        {
            var value = MyPower(2, sizeoflist + 1) + 1;

            return value;
        }
        public int MyPower(int Base, int topower)
        {
            var res = 1;
            for (int i = 0; i < topower; i++)
            {
                res *= Base;
            }
            return res;
        }

        public double CalculateBlock(int[] array)
        {
            double answer = array.Length;
            var x = Uniqueness(array);
            var n = x.Values;
            Dictionary<int, int>.ValueCollection valueColl = n;
            foreach (var val in valueColl)
            {
                var m = Math.Log((double)array.Length / val, 2);
                answer += val * m;
            }
            return answer;
        }
        public Dictionary<int, int> Uniqueness(int[] array)
        {
            Dictionary<int, int> uniques = new Dictionary<int, int>();
            var totalNumber = array.Length;
            for (int i = 0; i < totalNumber; i++)
            {
                if (!uniques.ContainsKey(array[i]))
                {
                    uniques.Add(array[i], 1);
                }
                else
                {
                    uniques[array[i]]++;
                }
            }
            return uniques;
        }
        
        
        public List<List<int>> GetSubArrys(List<int> list, string BinaryValue)
        {
            var indexes = GetIndexes(BinaryValue);

            var res = new List<List<int>>();

            int start = 0;

            for (int i = 0; i < indexes.Count; i++)
            {
                res.Add(GetFromStartToFinish(list, start, indexes[i]));

                start = indexes[i];
            }

            
            return res;
        }
        public List<List<int>> ContinueWith(List<List<int>> pre, List<int> list)
        {
            var count = new List<int>();

            var res = new List<List<int>>();

            for (int i = 0; i < pre.Count;i++)
            {
                count.Add(pre[i].Count);
            }
            count.Reverse();

            var start = 0;

            for(int i = 0; i < count.Count; i++)
            {
                res.Add(GetFromStartToFinish(list, start, count[i]));
            }
                

            return res;
        }
        public List<int> GetIndexes(string BinaryValue)
        {
            var rez = new List<int>();
            for (int i = 0; i < BinaryValue.Length-1; i++)
            {
                if (BinaryValue[i+1] == '1')
                    rez.Add(i);
            }
            return rez;
        }
        public List<int> GetFromStartToFinish(List<int> list, int start, int finish)
        {

            var res = new List<int>();
            var end = finish;
            for (int i = start; i <end; i++)
            {
                var element = list[i];
                res.Add(element);
            }
            return res;
        }
        
    }
}

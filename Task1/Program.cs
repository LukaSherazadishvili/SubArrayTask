using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var myCalculator = new MyCalculator();
            var list = new List<int>()
            {
                6,7,7,7,12,12,12,12,0
            };

            var allSubArrayList = new List<List<List<int>>>();
            var binaryNumnber = myCalculator.GetBinary(list.Count);

            for (int i = 0; i < myCalculator.MyPower(2, list.Count)/2; i++)
            {
                string binaryValue = Convert.ToString(binaryNumnber, 2);
                var tmpSubArray = myCalculator.GetSubArrys(list, binaryValue);
                var mirrorTmpSubArray = myCalculator.ContinueWith(tmpSubArray, list);

                allSubArrayList.Add(tmpSubArray);
                allSubArrayList.Add(mirrorTmpSubArray);
                binaryNumnber += 2;
            }

            var sums = new List<double>();
            foreach(var arr in allSubArrayList)
            {
                double sum = 0;
                for(int i = 0; i < arr.Count; i++)
                {
                    sum+=myCalculator.CalculateBlock(arr[i].ToArray<int>());
                }
                sums.Add(sum);
            }

            var result = sums.Min();
            var indexOfLowestSum = sums.IndexOf(result);

            var FinalResult = allSubArrayList[indexOfLowestSum];

            var OUTPUT = string.Empty;
            foreach(var item in FinalResult)
            {
                var str = item.Count.ToString();
                OUTPUT += str+",";
            }
            Console.WriteLine(OUTPUT);

            Console.ReadLine();
        }
    }
}


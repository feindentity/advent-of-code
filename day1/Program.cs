using System;

namespace day1
{
    class Program
    {
        static int[] LoadInputArray(string fileName)
        {
            string[] inputList;
            int[] inputListIntegers;
            inputList=System.IO.File.ReadAllLines(fileName);
            inputListIntegers = Array.ConvertAll(inputList, s => int.Parse(s));
            return inputListIntegers;
        }

        static int DetermineIncreaseCount(int[] NumbersToCompare)
        {
             int increaseCount=0;
            int prevValue = NumbersToCompare[0];
            int currentValue;         
            for(int counter=1; counter < NumbersToCompare.Length; counter++)
            {
                currentValue = NumbersToCompare[counter];
                if (currentValue > prevValue)
                {
                    increaseCount++;
                }
                prevValue=currentValue;
            }
            return increaseCount;

        }

        static int[] tripledSummedList(int[] initialInputList)
        {
            int[] summedList=new int[1998];
            return(summedList);
        }
        static void Main(string[] args)
        {
           Part1();
        }
        static void Part1()
        {
             int[] currentInputList;
            currentInputList=LoadInputArray("input.txt");
            int increaseCount=DetermineIncreaseCount(currentInputList);
            Console.WriteLine("Part 1 Individual Increases: {0}",increaseCount);
        }
    }
}

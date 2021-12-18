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
            int firstValue = initialInputList[0];
            int secondValue = initialInputList[1];
            int thirdValue;
            int tripledCounter=0;
            for(int counter=2;counter< initialInputList.Length;counter++)
            {
                thirdValue=initialInputList[counter];
                summedList[tripledCounter]=firstValue+secondValue+thirdValue;
                tripledCounter++;
                firstValue=secondValue;
                secondValue=thirdValue;
            }
            return(summedList);
        }
        static void Main(string[] args)
        {  int[] currentInputList;
            currentInputList=LoadInputArray("input.txt");
           Part1(currentInputList);
           Part2(currentInputList);
        }
        static void Part1(int[] currentInputList)
        {
           
            int increaseCount=DetermineIncreaseCount(currentInputList);
            Console.WriteLine("Part 1 Individual Increases: {0}",increaseCount);
        }
        static void Part2(int[] currentInputList)
        {
            int[] summedArray=tripledSummedList(currentInputList);
            int increaseCount=DetermineIncreaseCount(summedArray);
            Console.WriteLine("Part 2 Tripled Sum Increases: {0}",increaseCount);
        }

    }
}

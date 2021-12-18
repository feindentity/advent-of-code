using System;

namespace day1
{
    class Program
    {
        static string[] LoadInputArray(string fileName)
        {
            string[] inputList;
            inputList=System.IO.File.ReadAllLines(fileName);
            return inputList;
        }
        static void Main(string[] args)
        {
            string[] currentInputList;
            currentInputList=LoadInputArray("input.txt");
            int increaseCount=0;
            int prevValue = int.Parse(currentInputList[0]);
            int currentValue;         
            for(int counter=1; counter < currentInputList.Length; counter++)
            {
                currentValue = int.Parse(currentInputList[counter]);
                if (currentValue > prevValue)
                {
                    increaseCount++;
                }
                prevValue=currentValue;
            }
            Console.WriteLine(increaseCount);
        }
    }
}

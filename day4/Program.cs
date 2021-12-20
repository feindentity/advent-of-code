using System;
using System.Collections.Generic;
using day4.bingoBoard;

namespace day4
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
           string[] bingoData=LoadInputArray("input.txt");
           List<gameBoard> GameBoardList = new List<gameBoard>();
           
           gameBoard gb = new gameBoard();
          

            Console.WriteLine(gb.GetGridValue(0,1));
        }
    }
}

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
       
       public static gameBoard GenerateBoard(int startRow, string[] boardlist)
       {
           gameBoard currentBoard = new gameBoard();
           for(int rowCounter=0;rowCounter < 5;rowCounter++)
           {
               for(int columnCounter=0;columnCounter < 5; columnCounter++)
               {
                    int currentValue =int.Parse(boardlist[rowCounter + startRow].Substring((columnCounter*3),2));
                    currentBoard.SetGridValue(rowCounter,columnCounter,currentValue);    
                }
           }
           return currentBoard;
       }
        static void Main(string[] args)
        {
           string[] bingoData=LoadInputArray("input.txt");
           List<gameBoard> GameBoardList = new List<gameBoard>();
           int[] BingoCallList = Array.ConvertAll(bingoData[0].Split(','), s => int.Parse(s));
           gameBoard currentBoard = GenerateBoard(2, bingoData);
           ///gameBoard currentBoard2 = GenerateBoard(8, bingoData);
           
           for(int boardIndex=2;boardIndex < bingoData.Length;boardIndex=boardIndex+6  )
           {
               GameBoardList.Add(GenerateBoard(boardIndex, bingoData));
           }
           gameBoard currentBoard2=GameBoardList[GameBoardList.Count-1];
           Console.WriteLine(currentBoard2.GetGridValue(0,0));
           Console.WriteLine(currentBoard2.GetGridValue(1,1));
           Console.WriteLine(currentBoard2.GetGridValue(2,2));
           Console.WriteLine(currentBoard2.GetGridValue(3,3));
           Console.WriteLine(currentBoard2.GetGridValue(4,4));

           boardPosition currentValue=currentBoard2.FindValue(100);
           Console.WriteLine(currentValue);
         //Column Test
         /*
           currentValue=currentBoard2.FindValue(48);
           currentValue=currentBoard2.FindValue(60);
           currentValue=currentBoard2.FindValue(57);
           currentValue=currentBoard2.FindValue(14);
           currentValue=currentBoard2.FindValue(62);
           Console.WriteLine(currentBoard2.WinningBoard(currentValue));
        */
         //Row Test
           currentValue=currentBoard2.FindValue(55);
           currentValue=currentBoard2.FindValue(63);
           currentValue=currentBoard2.FindValue(50);
           currentValue=currentBoard2.FindValue(7);
           currentValue=currentBoard2.FindValue(62);
           Console.WriteLine(currentBoard2.WinningBoard(currentValue));
             
           
           
           

       /*
           gameBoard gb = new gameBoard();
          
            Console.WriteLine(bingoData[0]);
            Console.WriteLine(BingoCallList[0]);
            Console.WriteLine(BingoCallList[1]);
            Console.WriteLine(BingoCallList[2]);
            Console.WriteLine(BingoCallList[BingoCallList.Length-1]);
         */   

          
        }
    }
}

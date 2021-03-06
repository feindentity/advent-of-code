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
           gameBoard currentBoard = new gameBoard();
           int currentCallerValue=0;
           bool winnerFound=false; 

           //Generate Board
           for(int boardIndex=2;boardIndex < bingoData.Length;boardIndex=boardIndex+6  )
           {
               GameBoardList.Add(GenerateBoard(boardIndex, bingoData));
           }
           //Part 1
           /* 
           for (int callerCounter=0; callerCounter < bingoData.Length && !winnerFound; callerCounter++)
           {
               for(int boardCounter=0;boardCounter < GameBoardList.Count && !winnerFound;boardCounter++)
               {    
                  currentBoard=GameBoardList[boardCounter];
                  currentCallerValue=BingoCallList[callerCounter];
                  boardPosition foundPosition=  currentBoard.FindValue(currentCallerValue);
                  if (foundPosition !=null)
                  {
                      winnerFound=currentBoard.WinningBoard(foundPosition);
                  } 
               Console.WriteLine("Board Counter: " + boardCounter);     
               }
               Console.WriteLine("call result: " + callerCounter);
               Console.WriteLine("caller value: " + currentCallerValue);
           } 
        
         Console.WriteLine("Winner: "+ winnerFound);
         */
         //PART 2
         // List<gameBoard> WinningList = new List<gameBoard>();
         List<int> WinningList = new List<int>();
          for (int callerCounter=0; callerCounter < bingoData.Length ; callerCounter++)
           {
               for(int boardCounter=0;boardCounter < GameBoardList.Count; boardCounter++)
               {    
                  currentBoard=GameBoardList[boardCounter];
                if (!currentBoard.winner)
                {
                    currentCallerValue=BingoCallList[callerCounter];
                    boardPosition foundPosition=  currentBoard.FindValue(currentCallerValue);
                    if (foundPosition !=null)
                    {
                        winnerFound=currentBoard.WinningBoard(foundPosition);
                    }
                    if (winnerFound)
                     {
                            currentBoard.winner=true;
                            currentBoard.winningValue=currentCallerValue;
                            Console.WriteLine("Board Index:" + boardCounter);
                            Console.WriteLine("Winning Value: "+ currentCallerValue);
                            WinningList.Add(boardCounter);
                            winnerFound=false;
                     } 
           //         Console.WriteLine("Board Counter: " + boardCounter);
                }     
               }

            } 
            currentBoard=GameBoardList[WinningList[WinningList.Count-1]];
          //  currentBoard.PositionGrid[4,3].Selected=true;

       //  Console.WriteLine(currentBoard.GetGridValue(0,0) + currentBoard.GetGridValue(0,0).)
       int basicScore=0;
            for( int rowCounter=0;rowCounter < 5; rowCounter++)
            {
                for(int columnCounter=0;columnCounter<5;columnCounter++)
                {
                    if(!currentBoard.PositionGrid[columnCounter,rowCounter].Selected)
                    {
                        basicScore+=currentBoard.PositionGrid[columnCounter,rowCounter].PositionValue;
                    }
                }
            } 
            basicScore*=currentBoard.winningValue;
            Console.WriteLine("bingo score: " + basicScore);
        }
        public static void Test()
        {
          /*  
           gameBoard currentBoard2=GameBoardList[GameBoardList.Count-1];
           Console.WriteLine(currentBoard2.GetGridValue(0,0));
           Console.WriteLine(currentBoard2.GetGridValue(1,1));
           Console.WriteLine(currentBoard2.GetGridValue(2,2));
           Console.WriteLine(currentBoard2.GetGridValue(3,3));
           Console.WriteLine(currentBoard2.GetGridValue(4,4));

           boardPosition currentValue=currentBoard2.FindValue(100);
           Console.WriteLine(currentValue);
           */
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
          /*
           currentValue=currentBoard2.FindValue(55);
           currentValue=currentBoard2.FindValue(63);
           currentValue=currentBoard2.FindValue(50);
           currentValue=currentBoard2.FindValue(7);
           currentValue=currentBoard2.FindValue(62);
           Console.WriteLine(currentBoard2.WinningBoard(currentValue));
             
           
           */
           

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

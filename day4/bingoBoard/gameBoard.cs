using System;
namespace day4.bingoBoard
{
    public  class gameBoard
    {
        public gameBoard()
        {
            this.PositionGrid = new boardPosition[5,5];
        }
        private int foundCounter;
        public boardPosition[,] PositionGrid{get;set;}
        public void SetGridValue(int row, int column, int value)
        {
            this.PositionGrid[row,column]=new boardPosition(value, row, column);
        }
        public int GetGridValue(int row, int column)
        {
            return this.PositionGrid[row,column].PositionValue;
        }
        public boardPosition FindValue(int currentValue)
        {
            boardPosition foundPosition =null;
            bool found=false;
            for(int rowCounter=0;rowCounter < 5 && !found; rowCounter++)
            {
                for(int columnCounter=0;columnCounter < 5 && !found; columnCounter++)
                {
                    if (this.PositionGrid[rowCounter,columnCounter].PositionValue==currentValue && !this.PositionGrid[rowCounter,columnCounter].Selected )
                    {
                        this.PositionGrid[rowCounter,columnCounter].Selected=true;
                        found=true;
                        foundPosition=this.PositionGrid[rowCounter,columnCounter];
                        foundCounter++;
                    }
                }
            }
            return foundPosition;
        }
        public bool WinningBoard(boardPosition currentPosition)
        {
            bool IsWinning=false;
            if (this.foundCounter < 5)
                 return IsWinning;
            //check column
            IsWinning = this.PositionGrid[0,currentPosition.Column].Selected
                        && this.PositionGrid[1,currentPosition.Column].Selected
                        && this.PositionGrid[2,currentPosition.Column].Selected
                        && this.PositionGrid[3,currentPosition.Column].Selected
                        && this.PositionGrid[4,currentPosition.Column].Selected; 
            if(!IsWinning)
            {
                IsWinning = this.PositionGrid[currentPosition.Row,0].Selected
                        && this.PositionGrid[currentPosition.Row,1].Selected
                        && this.PositionGrid[currentPosition.Row,2].Selected
                        && this.PositionGrid[currentPosition.Row,3].Selected
                        && this.PositionGrid[currentPosition.Row,4].Selected; 
            }
                //IsWinning=true;
            return IsWinning;
        }
    }
}
namespace day4.bingoBoard
{
    public  class gameBoard
    {
        public gameBoard()
        {
            this.PositionGrid = new boardPosition[5,5];
        }
        private boardPosition[,] PositionGrid{get;set;}
        public void SetGridValue(int row, int column, int value)
        {
            this.PositionGrid[row,column]=new boardPosition(value);
        }
        public int GetGridValue(int row, int column)
        {
            return this.PositionGrid[row,column].PositionValue;
        }
    }
}
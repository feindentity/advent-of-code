namespace day4.bingoBoard
{
    public  class boardPosition
    {
        public boardPosition(int value, int row, int column)
        {
            this.PositionValue=value;
            this.Row=row;
            this.Column=column;
        }
        public int PositionValue{get;set;}
        public int Row{get;set;}
        public int Column{get;set;}
        public bool Selected{get;set;}
    }
}
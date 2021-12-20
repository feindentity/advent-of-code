namespace day4.bingoBoard
{
    public  class boardPosition
    {
        public boardPosition(int value)
        {
            this.PositionValue=value;
        }
        public int PositionValue{get;set;}
        public bool Selected{get;set;}
    }
}
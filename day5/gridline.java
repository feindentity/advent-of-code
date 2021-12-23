import java.util.List;
import java.util.ArrayList;
import java.awt.geom.Line2D;
import java.awt.geom.Point2D;

public class gridline{
    
    public gridline(int startX, int startY, int endX, int endY)
    {
        StartX=startX;
        StartY=startY;
        EndX=endX;
        EndY=endY;
    }
    public int StartX;
    public int EndX; 
    public int StartY;
    public int EndY;
}
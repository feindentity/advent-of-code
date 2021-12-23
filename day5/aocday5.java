import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.List;


import java.util.ArrayList;

public class aocday5 {

    public static List<String> ReadCommandsFromInput() throws IOException {
        List<String> CommandList = Files.readAllLines(Paths.get("input.txt"));
        return (CommandList);
    }

    public static List<gridline> HorizontalVerticalLineList(List<String> currentLineList) {
        List<gridline> filteredLineList = new ArrayList<gridline>();

        // Filter out diagnal movement
        currentLineList.forEach((line) -> {
            String[] linepoints = line.split(" -> ");
            String[] startPoint = linepoints[0].split(",");
            String[] endPoint = linepoints[1].split(",");
            if (startPoint[0].equals(endPoint[0]) || startPoint[1].equals(endPoint[1])) {
                filteredLineList.add(new gridline(Integer.parseInt(startPoint[0]),
                Integer.parseInt(startPoint[1]),
                Integer.parseInt(endPoint[0]),
                Integer.parseInt(endPoint[1])));
                //        System.out.println("Full Line: " + line);
                //        System.out.println("X,Y X,Y: "+startPoint[0]+","+startPoint[1]+" "+endPoint[0]+","+endPoint[1]);
            
            }

        });
        return filteredLineList;
    }
    public static List<gridline> AllLineList(List<String> currentLineList) {
        List<gridline> filteredLineList = new ArrayList<gridline>();

        // Filter out diagnal movement
        currentLineList.forEach((line) -> {
            String[] linepoints = line.split(" -> ");
            String[] startPoint = linepoints[0].split(",");
            String[] endPoint = linepoints[1].split(",");
            //if (startPoint[0].equals(endPoint[0]) || startPoint[1].equals(endPoint[1])) {
                filteredLineList.add(new gridline(Integer.parseInt(startPoint[0]),
                Integer.parseInt(startPoint[1]),
                Integer.parseInt(endPoint[0]),
                Integer.parseInt(endPoint[1])));
                //        System.out.println("Full Line: " + line);
                //        System.out.println("X,Y X,Y: "+startPoint[0]+","+startPoint[1]+" "+endPoint[0]+","+endPoint[1]);
            
           // }

        });
        return filteredLineList;
    }

    public static void Part1(List<String> currentList) {
        List<gridline> localLineList = AllLineList(currentList);//HorizontalVerticalLineList(currentList);
        int[][] lineCanvas = new int[1001][1001];
        localLineList.forEach((line) -> {
            int yStarter;
            int yEnder;
            int xStarter;
            int xEnder;
            boolean yDown=false;
            boolean xDown=true;
            if (line.StartY<=line.EndY)
            {
                yStarter=line.StartY;
                yEnder = line.EndY;
                yDown=false;
            }
            else
            {
                yStarter=line.EndY;
                yEnder = line.StartY;
                yDown=true;
            }

            if (line.StartX<=line.EndX)
            {
                xStarter=line.StartX;
                xEnder = line.EndX;
                xDown=false;
            }
            else
            {
                xStarter=line.EndX;
                xEnder = line.StartX;
                xDown=true;
            }

           
          

           if (line.StartX==line.EndX)
            {
           
                for(int counter=yStarter;counter<=yEnder;counter++)
                {
                    lineCanvas[line.StartX][counter]++;
                }
            }
            else if (line.StartY==line.EndY)
            {
             
                for(int counter=xStarter;counter<=xEnder;counter++)
                {
                    lineCanvas[counter][line.StartY]++;
                }
            }
            else if (xEnder-xStarter == yEnder-yStarter)
            {
                  //Added Calculations for Part2
                for(int counter=0;counter<=(yEnder-yStarter);counter++)
                {
                  int yOffset;
                  int xOffset;
                  xOffset=counter;
                  yOffset=counter;
                   if (yDown)
                        yOffset=yOffset*-1;

                  if(xDown)
                        xOffset=xOffset*-1;

                    lineCanvas[line.StartX+xOffset][line.StartY+yOffset]++;
               //    System.out.println("startx: "+ line.StartX + "xOffset: "+ xOffset + "starty:" + line.StartY + "yOffset: " + yOffset );
                    
                }
             //   System.out.println("Start X: " + line.StartX + " End X: "+line.EndX+ " X Down: "+ xDown); 
             //   System.out.println(" Start Y: " + line.StartY + " End Y: "+ line.EndY +" Y Down: " + yDown) ;
              //   System.out.println("Start to End x:" + xStarter + ","+xEnder + "y:" + yStarter + "," + yEnder);
           
            }
          
        });
        int multiplePointHit=0;
        for(int rowCounter=1;rowCounter <=1000;rowCounter++)
        {
            for(int columnCounter=1;columnCounter<=1000;columnCounter++)
            {
                if(lineCanvas[rowCounter][columnCounter]>1)
                {
                    multiplePointHit++;
                }

            }
        }
        System.out.println("How many multiple points: " + multiplePointHit);
      //  System.out.println(localLineList.size());
    }

    public static void Part2(List<String> currentList) {

    }

    public static void main(String[] args) throws IOException {

        List<String> currentList = ReadCommandsFromInput();
        Part1(currentList);
        // Part2(currentList);
    }

}

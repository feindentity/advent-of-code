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

    public static void Part1(List<String> currentList) {
        List<gridline> localLineList = HorizontalVerticalLineList(currentList);
        int[][] lineCanvas = new int[1001][1001];
        localLineList.forEach((line) -> {
            if (line.StartX==line.EndX)
            {
                int yStarter;
                int yEnder;
                if (line.StartY<line.EndY)
                {
                    yStarter=line.StartY;
                    yEnder = line.EndY;
                }
                else
                {
                    yStarter=line.EndY;
                    yEnder = line.StartY;
                }
                for(int counter=yStarter;counter<=yEnder;counter++)
                {
                    lineCanvas[line.StartX][counter]++;
                }
            }
            if (line.StartY==line.EndY)
            {
                int xStarter;
                int xEnder;
                if (line.StartX<line.EndX)
                {
                    xStarter=line.StartX;
                    xEnder = line.EndX;
                }
                else
                {
                    xStarter=line.EndX;
                    xEnder = line.StartX;
                }
                for(int counter=xStarter;counter<=xEnder;counter++)
                {
                    lineCanvas[counter][line.StartY]++;
                }
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
        System.out.println(localLineList.size());
    }

    public static void Part2(List<String> currentList) {

    }

    public static void main(String[] args) throws IOException {

        List<String> currentList = ReadCommandsFromInput();
        Part1(currentList);
        // Part2(currentList);
    }

}

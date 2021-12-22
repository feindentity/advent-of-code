import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.List;
import java.util.ArrayList;
import java.awt.geom.Line2D;

public class aocday5 {

    public static List<String> ReadCommandsFromInput() throws IOException {
        List<String> CommandList = Files.readAllLines(Paths.get("input.txt"));
        return (CommandList);
    }

    public static List<Line2D.Float> HorizontalVerticalLineList(List<String> currentLineList) {
        List<Line2D.Float> filteredLineList = new ArrayList<Line2D.Float>();

        // Filter out diagnal movement
        currentLineList.forEach((line) -> {
            String[] linepoints = line.split(" -> ");
            String[] startPoint = linepoints[0].split(",");
            String[] endPoint = linepoints[1].split(",");
            if (startPoint[0].equals(endPoint[0]) || startPoint[1].equals(endPoint[1])) {
                filteredLineList.add(new Line2D.Float(Float.parseFloat(startPoint[0]),
                        Float.parseFloat(startPoint[1]),
                        Float.parseFloat(endPoint[0]),
                        Float.parseFloat(endPoint[1])));
                        System.out.println("Full Line: " + line);
                        System.out.println("X,Y X,Y: "+startPoint[0]+","+startPoint[1]+" "+endPoint[0]+","+endPoint[1]);
            
            }

        });
        System.out.println(filteredLineList.size());
        return filteredLineList;
    }

    public static void Part1(List<String> currentList) {
        List<Line2D.Float> localLineList = HorizontalVerticalLineList(currentList);
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

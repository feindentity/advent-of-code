import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.List;
import java.util.concurrent.atomic.AtomicInteger;
public class aocday2 {
    
    public static List<String> ReadCommandsFromInput() throws IOException
    {
        List<String> CommandList = Files.readAllLines(Paths.get("input.txt"));
        return(CommandList);
    }
    public static void Part1(List<String> currentList)
    {
        AtomicInteger DepthDistance = new AtomicInteger(0);
        AtomicInteger ForwardDistance = new AtomicInteger(0);

        currentList.forEach((command)->{
            String[] currentCommand=command.split(" ");
            switch(currentCommand[0])
            {
                case "forward":
                    ForwardDistance.getAndAdd(Integer.parseInt(currentCommand[1])); 
                break;
                case "up":
                    DepthDistance.getAndAdd(Integer.parseInt(currentCommand[1])*-1);
                break;
                case "down":
                    DepthDistance.getAndAdd(Integer.parseInt(currentCommand[1]));
                break;
            }
       
       });
       System.out.println(DepthDistance.get());
       System.out.println(ForwardDistance.get());
       System.out.println(ForwardDistance.get()*DepthDistance.get());

    }
    public static void Part2(List<String> currentList)
    {
        AtomicInteger DepthDistance = new AtomicInteger(0);
        AtomicInteger ForwardDistance = new AtomicInteger(0);
        AtomicInteger AimDistance = new AtomicInteger(0);

        currentList.forEach((command)->{
            String[] currentCommand=command.split(" ");
            switch(currentCommand[0])
            {
                case "forward":
                    ForwardDistance.getAndAdd(Integer.parseInt(currentCommand[1]));
                    DepthDistance.getAndAdd(Integer.parseInt(currentCommand[1])*AimDistance.get()); 
                break;
                case "up":
                    AimDistance.getAndAdd(Integer.parseInt(currentCommand[1])*-1);
                break;
                case "down":
                    AimDistance.getAndAdd(Integer.parseInt(currentCommand[1]));
                break;
            }
       
       });
       System.out.println("Part 2  Depth:" + DepthDistance.toString());
       System.out.println("Part 2 horizontal: " + ForwardDistance.toString());
       System.out.println(ForwardDistance.get()*DepthDistance.get());

    }
    public static void main(String[] args) throws IOException {

        List<String> currentList = ReadCommandsFromInput();
        Part1(currentList);
        Part2(currentList);
            }
    
}

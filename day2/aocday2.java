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
    public static void main(String[] args) throws IOException {

        List<String> currentList = ReadCommandsFromInput();
      /*
        int DepthDistance = 0;
        int ForwardDistance= 0;
        for(int counter=0; counter < currentList.size(); counter++)
        {
            String[] currentCommand=currentList.get(counter).split(" ");
            switch(currentCommand[0])
            {
                case "forward":
                    ForwardDistance++; 
                break;
                case "up":
                    DepthDistance--;
                break;
                case "down":
                    DepthDistance++;
                break;
            }
        }
        */
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
    
}

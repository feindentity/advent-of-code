import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.List;

public class aocday8 {
    public static List<String> ReadCommandsFromInput() throws IOException {
        List<String> CommandList = Files.readAllLines(Paths.get("input.txt"));
        return (CommandList);
    }
    public static void main(String[] args) throws IOException {
        int easyDigitCounter=0;
        List<String> currentList = ReadCommandsFromInput();
        for(int rowCounter=0;rowCounter < currentList.size();rowCounter++)
        {//   String[] splitSignal = currentList.get(rowCounter).split(" | ");
            String[] splitNumbers = currentList.get(rowCounter).substring(60).split(" ");
            for(int splitCounter=0;splitCounter < splitNumbers.length;splitCounter++)
            {   int currentDigitLength=splitNumbers[splitCounter].length();
                 System.out.println("Current Digit Length: " + currentDigitLength);
       

                if(currentDigitLength==2|currentDigitLength==3|currentDigitLength==4|currentDigitLength==7)
                {
                    easyDigitCounter++;
                }
            }
        }
        System.out.println("Digit Counter: " + easyDigitCounter);
    
     }
}

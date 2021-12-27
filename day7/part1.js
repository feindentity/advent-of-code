const { groupEnd } = require('console');
var fs = require('fs');

var GetMoves = function(path){
    try {
        // read contents of the file
        const data = fs.readFileSync(path, 'UTF-8');
    
        // split the contents by new line
        const moveList= data.split(",");
        var ArrayOfMoves = moveList.map(Number);
    
    return ArrayOfMoves;

    } catch (err) {
        console.error(err);
    }
}

var currentMoveList
var currentTotalFuel=0;
var LeastFuelTotal=300000000;
var positionForLeastTotal=-1;
currentMoveList=GetMoves("input.txt");

var Part1Calculate = function(calculateMoveList){

    for(positionCounter=0;positionCounter < 2000; positionCounter++)
    {
        for(counter=0;counter<calculateMoveList.length;counter++)
        {
            var positionDifference
            currentTotalFuel+=Math.abs(calculateMoveList[counter] -positionCounter);
        }
    //   console.log("curretTotal: " + currentTotalFuel);
    //   console.log("position: " + counter);

    if(currentTotalFuel < LeastFuelTotal)
        {
            LeastFuelTotal=currentTotalFuel
            positionForLeastTotal=positionCounter;        
        }
        currentTotalFuel=0;
    }
    console.log("least total fuel: " + LeastFuelTotal);
    console.log("least fuel postionion: " + positionForLeastTotal);
}
var Part2Calculate = function(calculateMoveList){

    for(positionCounter=0;positionCounter < 2000; positionCounter++)
    {
        for(counter=0;counter<calculateMoveList.length;counter++)
        {
            var positionDifference
            positionDifference=Math.abs(calculateMoveList[counter] -positionCounter);
            for(positionDifferenceCounter=positionDifference; positionDifferenceCounter >0; positionDifferenceCounter--)
            {
                currentTotalFuel+=positionDifferenceCounter; 
                positionDifferenceCounter
            }
        }
    //   console.log("curretTotal: " + currentTotalFuel);
    //   console.log("position: " + counter);

    if(currentTotalFuel < LeastFuelTotal)
        {
            LeastFuelTotal=currentTotalFuel
            positionForLeastTotal=positionCounter;        
        }
        currentTotalFuel=0;
    }
    console.log("least total fuel: " + LeastFuelTotal);
    console.log("least fuel postionion: " + positionForLeastTotal);
}
//Part1Calculate(currentMoveList);
Part2Calculate(currentMoveList);

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
var LeastFuelTotal=1000000;
var positionForLeastTotal=-1;
currentMoveList=GetMoves("input.txt");
for(positionCounter=0;positionCounter < 2000; positionCounter++)
{
    for(counter=0;counter<currentMoveList.length;counter++)
    {
        currentTotalFuel+=Math.abs(currentMoveList[counter] -positionCounter);
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
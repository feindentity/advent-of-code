var fs = require('fs');

var GetFish = function(path){
    try {
        // read contents of the file
        const data = fs.readFileSync(path, 'UTF-8');
    
        // split the contents by new line
        const school= data.split(",");
        var ArrayOfFish = school.map(Number);
    
    return ArrayOfFish;

    } catch (err) {
        console.error(err);
    }
}
var AddFish=function(currentFishList,numberOfFishToAdd)
{
    for(var counter=0;counter<numberOfFishToAdd;counter++)
    {
        currentFishList.push(8);
    }
}

var fishList = GetFish("input.txt");
console.log(fishList.length);
var maxGeneration = 80;
//var maxGeneration=256;
for(var dayCounter=0;dayCounter<maxGeneration;dayCounter++)
{   var newFishCounter=0;
    for(var fishCounter=0;fishCounter<fishList.length;fishCounter++)
    {
        if (fishList[fishCounter]==0)
        {
            fishList[fishCounter]=6;
            newFishCounter++;
        }
        else
        {
            fishList[fishCounter]--;
        }
    }
    AddFish(fishList,newFishCounter);
}
console.log("Amount of Fish: " + fishList.length);
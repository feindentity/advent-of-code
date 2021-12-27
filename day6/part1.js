const { groupEnd } = require('console');
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

var SchoolGeneration=function(schoolList, maxGeneration)
{
    var schoolDistrict=[schoolList]
    for(var dayCounter=0;dayCounter<maxGeneration;dayCounter++)
    {   var newFishCounter=0;
            for(var districtCounter=0; districtCounter<schoolDistrict.length;districtCounter++)
            {
                for(var fishCounter=0;fishCounter<schoolDistrict[districtCounter].length;fishCounter++)
                {
        
                    if (schoolDistrict[districtCounter][fishCounter]==0)
                    {
                        schoolDistrict[districtCounter][fishCounter]=6;
                        newFishCounter++;
                    }
                    else
                    {
                        schoolDistrict[districtCounter][fishCounter]--;
                    }
                }
            }
       var SplitCounter=newFishCounter;
       
       while(SplitCounter>0)
       {
            if (SplitCounter <  1000000)
            {
            var generationSchool = [];
            AddFish(generationSchool,SplitCounter);
            SplitCounter=0;
            }
            else
            {
            var generationSchool = [];
            AddFish(generationSchool,1000000);
            SplitCounter=SplitCounter-1000000;
            }
            schoolDistrict.push(generationSchool);      
       }
//            var generationSchool = [];
//            AddFish(generationSchool,newFishCounter);
        console.log("day: " + dayCounter);
        console.log("genneration number: " +  schoolDistrict.length);
    }
    return schoolDistrict;
}
var fishList = GetFish("input.txt");
var maxGeneration = 256;
/*
var school1 = fishList.slice(0,1);
var currentSchoolDistrict = SchoolGeneration(school1,maxGeneration);
console.log("Generation Count: " + currentSchoolDistrict.length);
var fishCounter=0;
for (var districtCounter=0; districtCounter < currentSchoolDistrict.length;districtCounter++)
{
    fishCounter+=currentSchoolDistrict[districtCounter].length;
}
//var maxGeneration=256;
console.log("Fish Count: " + fishCounter);
//console.log("Amount of Fish: " + schoolListCounter1);

//calculate a new fish for a number generates
var fish=[8];
*/
var TrackCounters=function(schoolList, maxGeneration)
{
    var generationCounter=[];
    for(var dayCounter=0;dayCounter<maxGeneration;dayCounter++)
    {   var newFishCounter=0;
                for(var fishCounter=0;fishCounter<schoolList.length;fishCounter++)
                {
        
                    if (schoolList[fishCounter]==0)
                    {
                        schoolList[fishCounter]=6;
                        newFishCounter++;
                    }
                    else
                    {
                        schoolList[fishCounter]--;
                    }
                }
            console.log("Track Counter: Generation: " + dayCounter +  ", New Fish Count: " + newFishCounter);
            generationCounter.push({generation: dayCounter, newFish: newFishCounter })

    }
    return generationCounter;
}

var generationList = TrackCounters(fishList, maxGeneration);
console.log("ListFrom Track Counters" + generationList.length);
for(genCounter=0;genCounter < generationList.length;genCounter++)
{
    console.log("Generation: " + generationList[genCounter].generation +  ", New Fish Count: " + generationList[genCounter].newFish);
}
totalCounter=300;
// add count generation 

for(generationCounterMain=0;generationCounterMain<maxGeneration; generationCounterMain++)
{ 
    generationAddition=generationList[generationCounterMain].newFish;
    currentGeneration=generationList[generationCounterMain].generation;
        
    if(generationAddition > 0)
    {


        totalCounter+=generationAddition;
        // do first add 10 generations
        var generationToUpdate = currentGeneration+9;
        if (generationToUpdate < maxGeneration)
        {
            generationList[generationToUpdate].newFish+=generationAddition;
            generationToUpdate+=7;
            while(generationToUpdate < maxGeneration)
            {
                generationList[generationToUpdate].newFish+=generationAddition;
                generationToUpdate+=7;
            }
        }
    }
   
}
for(genCounter=0;genCounter < generationList.length;genCounter++)
{
    console.log("Generation: " + generationList[genCounter].generation +  ", New Fish Count: " + generationList[genCounter].newFish);
}
console.log(totalCounter);
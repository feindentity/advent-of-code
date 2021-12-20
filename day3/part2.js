var fs = require('fs');

var GetLines = function(path){
    try {
        // read contents of the file
        const data = fs.readFileSync(path, 'UTF-8');
    
        // split the contents by new line
        const lines = data.split(/\r?\n/);
    
    return lines;

    } catch (err) {
        console.error(err);
    }
}
var GenerateOxygenArray = function(inputList, bitIndex)
{
    const oneArray=[];
    const zeroArray=[];
    var oxygenArray;
    inputList.forEach((inputLine) =>{
    if (inputLine.charAt(bitIndex)=='1')
    {
        oneArray.push(inputLine);
    }
    else
    {
        zeroArray.push(inputLine);
    }
    });

    if (oneArray.length >= zeroArray.length)
    {
         oxygenArray = oneArray;
    } 
    else
    {
         oxygenArray = zeroArray;
    }
    return oxygenArray;
}
var GenerateCarbonArray = function(inputList, bitIndex)
{
    const oneArray=[];
    const zeroArray=[];
    var carbonArray;
    inputList.forEach((inputLine) =>{
    if (inputLine.charAt(bitIndex)=='1')
    {
        oneArray.push(inputLine);
    }
    else
    {
        zeroArray.push(inputLine);
    }
    });

    if (oneArray.length < zeroArray.length)
    {
         carbonArray = oneArray;
    } 
    else
    {
         carbonArray = zeroArray;
    }
    return carbonArray;
}

var GetLinesTest = function(){
    const testLines=[];
    testLines.push("101010011010");
    testLines.push("101111111001");
    testLines.push("100100100000");
    testLines.push("000001010010");
    testLines.push("100100110011");
    testLines.push("000101100110");
    return testLines;
}
//var inputLines = GetLinesTest();
var inputLines=GetLines("input.txt");
var currentOxygenArray=inputLines;
var currentCarbonArray=inputLines;
console.log(inputLines.length);
for(bitCounter=0;(bitCounter < inputLines[0].length && currentOxygenArray.length > 1 );bitCounter++)
{
    currentOxygenArray=GenerateOxygenArray(currentOxygenArray,bitCounter);
   // console.log(currentOxygenArray.length);
}
console.log("Oxygen #: " + currentCarbonArray[0]);

for(bitCounter=0;(bitCounter < inputLines[0].length && currentCarbonArray.length > 1 );bitCounter++)
{
    currentCarbonArray=GenerateCarbonArray(currentCarbonArray,bitCounter);
  //  console.log(currentCarbonArray.length);
}
console.log("Carbon #: " + currentCarbonArray[0]);
var oxygenValue = parseInt(currentOxygenArray[0],2);
var carbonValue = parseInt(currentCarbonArray[0],2);
console.log("Carbon Base 10: " + carbonValue);
console.log("Oxygen Base 10: " + oxygenValue);
console.log("Coefficient: " + (oxygenValue* carbonValue));
/*
const Beta=[];
Beta.push("000000000");
Beta.push("00000001");
const Gamma=Beta;

Gamma.forEach((item)=>{
    console.log(item);
});*/
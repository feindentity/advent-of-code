var fs = require('fs');
var readline=require('readline')
var binaryString = "1010";
var testNumber = parseInt(binaryString,2);
var testCompare = (binaryString.charAt(0)=='1');
var testGenerateGamma = '1';
testGenerateGamma = testGenerateGamma + '2';
console.log(testNumber);
console.log(binaryString.charAt(0));
console.log(binaryString.charAt(1));
console.log(testCompare);
console.log(testGenerateGamma);

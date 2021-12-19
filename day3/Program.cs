using System;
using System.Text;
namespace day3
{
    class Program
    {
        static string[] LoadInputArray(string fileName)
        {
            string[] inputList;
            inputList=System.IO.File.ReadAllLines(fileName);
            return inputList;
        }
        static void Main(string[] args)
        {
            string[] currentInputList = LoadInputArray("input.txt");
            //track the columns first
            StringBuilder gammaBuilder=new StringBuilder(currentInputList[0].Length);
            StringBuilder epsilonBuilder=new StringBuilder(currentInputList[0].Length);
            int GammaValue;
            int EpsilonValue;
            for(int columnCounter=0;columnCounter < currentInputList[0].Length; columnCounter++)
            {
                    int oneCounter=0;
                    int zeroCounter=0;
                
                    for(int rowCounter=0;rowCounter< currentInputList.Length;rowCounter++)
                    {
                        
                        if(currentInputList[rowCounter].ToCharArray()[columnCounter].Equals('1'))
                        {
                            oneCounter++;
                        }
                        else
                        {
                            zeroCounter++;
                        }

                    }
                    if (oneCounter>zeroCounter) 
                     gammaBuilder.Append("1"); 
                    else 
                      gammaBuilder.Append("0");
                    
                    if(oneCounter<zeroCounter) 
                        epsilonBuilder.Append("1"); 
                    else
                        epsilonBuilder.Append("0");
                    
                    

                }
                Console.WriteLine("gamma:" + gammaBuilder.ToString());
                Console.WriteLine("epsilon:" + epsilonBuilder.ToString());
                GammaValue=Convert.ToInt32(gammaBuilder.ToString(),2);
                EpsilonValue=Convert.ToInt32(epsilonBuilder.ToString(),2);
                Console.WriteLine("gamma number:" + GammaValue.ToString());
                Console.WriteLine("epsilon number:" + EpsilonValue.ToString());
                Console.WriteLine("Power:" + (GammaValue*EpsilonValue).ToString());
              //  Console.WriteLine("epsilon:" + epsilonBuilder.ToString());    
            }
        }
    }


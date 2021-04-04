using System;
using System.Linq;

namespace arrayV._1
{
    class Program
    {
        static int Binarysearch(int searchValue, int arrayFound, int[] array){
            int arrayMiddle = 0;
            int arrayLow = 0;
            int arrayHigh = (array.Length) - 1;
            int arrayMid = (arrayLow + arrayHigh) / 2;
            int arrayTrackMiddle = 0;

            while(arrayLow <= arrayHigh){
                arrayMid = (arrayLow + arrayHigh) / 2;
                arrayMiddle = array[arrayMid];
                    
                if(arrayMiddle == searchValue){
                    //Console.WriteLine("Step 1");
                    arrayFound = arrayFound + 1;
                    return arrayFound;
                }
                if((arrayMiddle > searchValue) && (arrayMiddle != arrayTrackMiddle)){
                    arrayHigh = arrayMid + 1;
                    arrayTrackMiddle = arrayMiddle;
                    //Console.WriteLine("Step 2");
                }
                else{
                    arrayLow = arrayMid + 1;
                    //Console.WriteLine("Step 3");
                }
            }

            if(arrayLow > arrayHigh){
                //Console.WriteLine("Step 4");
                arrayFound = arrayFound - 1;
                return arrayFound;
            } 
            else{
                //Console.WriteLine("Step 5");
                return arrayFound;
            }      
        }

        static void Main(string[] args){
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Please, enter a number, but keep is contained: ");
            try{
                string input = Console.ReadLine();   
                int arraySize = Convert.ToInt32(input);
                int arrayFound = 0;
                int min = 0;
                int max = arraySize * 2;

                
                int[] array = new int[arraySize];
                Random randNum = new Random();
                int randomNumber = 0;

                for(int i = 0; i < arraySize; i++){
                    randomNumber = randNum.Next(min, max);

                    while(array.Contains(randomNumber)){
                        randomNumber = randNum.Next(min, max);
                    }
                    array[i] = randomNumber;
                    Console.Write(array[i] + "  ");
                }       

                Console.WriteLine("");
                Console.Write("Enter a number from this array. Maybe I'll find it ... : ");

                string searchInput = Console.ReadLine();
                int searchValue = Convert.ToInt32(searchInput);

                Array.Sort(array);
                Console.WriteLine("I ordered the array, because thats a requirement for the algorithm: ");
                
                for(int i = 0; i < arraySize; i++){
                    Console.Write("  " + array[i]);
                }

                Console.WriteLine("");
                Console.WriteLine("I am looking for your number");

                int result = Binarysearch(searchValue, arrayFound, array);

                Console.WriteLine(result);
                
            }  
            catch{
                Console.WriteLine("Make sure it's a number, and the number is beneath 2 billion");
                Console.ReadKey(true);
            } 
        }
    }
}
using System;
using System.Collections.Generic;

class AdjacentDistinct {
  static void Main() {
      string inputString = "abcabbaacbca";
      AdjacentDistinct.TryReduceAdjacentLetter(inputString);
  }
  
    // Method to print the process of reducing the adjacent and distinct letter
    private static void TryReduceAdjacentLetter(string inputString)
    {
        int minLength = inputString.Length;
        Queue<string> myQueue = new Queue<string>();
        myQueue.Enqueue(inputString);
    
    	Console.WriteLine("Original: " + inputString);
    
        int iter = 0;
        while (myQueue.Count > 0)
        {         
            string tempString = myQueue.Dequeue();
            char[] tempChar = tempString.ToCharArray();
    
            // Update the minimum length of string required and Print the reduced string
            if (tempString.Length < minLength)
            {
                minLength = tempString.Length;
                Console.WriteLine("Reduced: " + tempString);
            }
            
            // Check the adjacent distinct letter
            for (int j = 0; j < tempString.Length; j++)
            {
                if (j < tempString.Length - 1)
                {
                    string substring = tempChar[j].ToString() + tempChar[j + 1].ToString();
    
                    if (substring == "ab" || substring == "ba")
                    {
                        string substring2 = "";
    
                        for (int k = 0; k < j; k++)
                        {
                            substring2 = string.Concat(substring2, tempChar[k].ToString());
                        }
    
                        // Change the adjacent and distinct letter
                        substring2 = string.Concat(substring2, "c");
    
                        for (int k = j + 2; k < tempChar.Length; k++)
                        {
                            substring2 = string.Concat(substring2, tempChar[k].ToString());
                        }
    
                        myQueue.Enqueue(substring2);
                    }
                    else if (substring == "bc" || substring == "cb")
                    {
                        string substring2 = "";
    
                        for (int k = 0; k < j; k++)
                        {
                            substring2 = string.Concat(substring2, tempChar[k].ToString());
                        }
    
                        // Change the adjacent and distinct letter
                        substring2 = string.Concat(substring2, "a");
    
                        for (int k = j + 2; k < tempChar.Length; k++)
                        {
                            substring2 = string.Concat(substring2, tempChar[k].ToString());
                        }
    
                        myQueue.Enqueue(substring2);
                    }
                    else if (substring == "ac" || substring == "ca")
                    {
                        string substring2 = "";
    
                        for (int k = 0; k < j; k++)
                        {
                            substring2 = string.Concat(substring2, tempChar[k].ToString());
                        }
    
                        // Change the adjacent and distinct letter
                        substring2 = string.Concat(substring2, "b");
    
                        for (int k = j + 2; k < tempString.Length; k++)
                        {
                            substring2 = string.Concat(substring2, tempChar[k].ToString());
                        }
    
                        myQueue.Enqueue(substring2);
                    }
    
                }
    
            }
               
            iter += 1;
            
        }
        
        Console.WriteLine("Number of iteration: " + iter);
        
    }
}
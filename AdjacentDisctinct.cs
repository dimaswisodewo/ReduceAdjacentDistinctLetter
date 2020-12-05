using System;
using System.Collections.Generic;

class AdjacentDistinct {
    static void Main() {
        List<string> step = new List<string>();
        string inputString = "cabb";
        step = AdjacentDistinct.TryReduceAdjacentLetter(inputString);
        
        foreach(string s in step) Console.WriteLine(s);
    }
  
    private static List<string> TryReduceAdjacentLetter(string inputString)
    {
        List<string> stepFront = new List<string>();
        List<string> stepBack = new List<string>();
        
        stepFront = ReduceAdjacentLetter(inputString, FROM.FRONT);
        stepBack = ReduceAdjacentLetter(inputString, FROM.BACK);
        
    	Console.WriteLine("Original: " + inputString);
    	
        if (stepFront[stepFront.Count-1].Length <= stepBack[stepBack.Count-1].Length)
        {
            return stepFront;
        }
        else
        {
            return stepBack;
        }
    }
    
    // Method to print the process of reducing the adjacent and distinct letter
    private static List<string> ReduceAdjacentLetter(string inputString, FROM fromEnum)
    {
        int minLength = inputString.Length;
        List<string> step = new List<string>();
        Queue<string> myQueue = new Queue<string>();
        myQueue.Enqueue(inputString);
        bool allLetterAreSame = false;
    
        while (myQueue.Count > 0)
        {         
            if (allLetterAreSame == true)
            {
                return step;
                break;
            }
            
            string tempString = myQueue.Dequeue();
            char[] tempChar = tempString.ToCharArray();
    
            // Update the minimum length of string required and Print the reduced string
            if (tempString.Length < minLength)
            {
                minLength = tempString.Length;
                step.Add(tempString);
                
                allLetterAreSame = true;
                for (int i = 0; i < tempString.Length-1; i++)
                {
                    if (tempChar[i] != tempChar[i+1])
                    {
                        allLetterAreSame = false;
                    }
                }
                
            }
            
            switch (fromEnum)
            {
                case FROM.FRONT:
                    // Check the adjacent distinct letter from front
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
                    break;
                    
                case FROM.BACK:
                    // Check the adjacent distinct letter from back
                    for (int j = tempString.Length-1; j >= 0; j--)
                    {
                        if (j > 0)
                        {
                            string substring = tempChar[j].ToString() + tempChar[j - 1].ToString();
            
                            if (substring == "ab" || substring == "ba")
                            {
                                string substring2 = "";
            
                                for (int k = 0; k < j-1; k++)
                                {
                                    substring2 = string.Concat(substring2, tempChar[k].ToString());
                                }
            
                                // Change the adjacent and distinct letter
                                substring2 = string.Concat(substring2, "c");
            
                                for (int k = j+1; k < tempChar.Length; k++)
                                {
                                    substring2 = string.Concat(substring2, tempChar[k].ToString());
                                }
            
                                myQueue.Enqueue(substring2);
                            }
                            else if (substring == "bc" || substring == "cb")
                            {
                                string substring2 = "";
            
                                for (int k = 0; k < j-1; k++)
                                {
                                    substring2 = string.Concat(substring2, tempChar[k].ToString());
                                }
            
                                // Change the adjacent and distinct letter
                                substring2 = string.Concat(substring2, "a");
            
                                for (int k = j+1; k < tempChar.Length; k++)
                                {
                                    substring2 = string.Concat(substring2, tempChar[k].ToString());
                                }
            
                                myQueue.Enqueue(substring2);
                            }
                            else if (substring == "ac" || substring == "ca")
                            {
                                string substring2 = "";
            
                                for (int k = 0; k < j-1; k++)
                                {
                                    substring2 = string.Concat(substring2, tempChar[k].ToString());
                                }
            
                                // Change the adjacent and distinct letter
                                substring2 = string.Concat(substring2, "b");
            
                                for (int k = j+1; k < tempChar.Length; k++)
                                {
                                    substring2 = string.Concat(substring2, tempChar[k].ToString());
                                }
            
                                myQueue.Enqueue(substring2);
                            }
            
                        }
            
                    }
                    break;
            }
            
        }
        
        return step;
    }
    
}


public enum FROM {
    FRONT,
    BACK
}

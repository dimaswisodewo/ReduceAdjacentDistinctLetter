import java.util.ArrayList;
import java.util.List;
import java.util.LinkedList; 
import java.util.Queue; 

public class Main
{
    enum FROM
    {
        FRONT,
        BACK
    }
    
	public static void main(String[] args) {
		List<String> step = new ArrayList<String>();
        String inputString = "cabcabbaacbca";
        step = Main.TryReduceAdjacentLetter(inputString);
        
        for (String s : step) System.out.println(s);
	}
	
	private static List<String> TryReduceAdjacentLetter(String inputString)
    {
        List<String> step = new ArrayList<String>();
        step = ReduceAdjacentLetter(inputString, FROM.FRONT);
        
        if (step.get(step.size()-1).length() > 1)
        {
            List<String> stepBack = new ArrayList<String>();
            stepBack = ReduceAdjacentLetter(inputString, FROM.BACK);
    	
            if (stepBack.get(stepBack.size()-1).length() < step.get(step.size()-1).length())
            {
                step = stepBack;
            }
        }
        
    	System.out.println("Original: " + inputString);
    	return step;
    }
    
    // Method to print the process of reducing the adjacent and distinct letter
    private static List<String> ReduceAdjacentLetter(String inputString, FROM fromEnum)
    {
        int minLength = inputString.length();
        List<String> step = new ArrayList<String>();
        Queue<String> myQueue = new LinkedList<>();
        myQueue.add(inputString);
        boolean allLetterAreSame = false;
    
        while (myQueue.size() > 0)
        {         
            if (allLetterAreSame == true)
            {
                return step;
            }
            
            String tempString = myQueue.remove();
            char[] tempChar = tempString.toCharArray();
    
            // Update the minimum length of string required and Print the reduced string
            if (tempString.length() < minLength)
            {
                minLength = tempString.length();
                step.add(tempString);
                
                allLetterAreSame = true;
                for (int i = 0; i < tempString.length()-1; i++)
                {
                    if (tempChar[i] != tempChar[i+1])
                    {
                        allLetterAreSame = false;
                    }
                }
                
            }
            
            switch (fromEnum)
            {
                case FRONT:
                    // Check the adjacent distinct letter from front
                    for (int j = 0; j < tempString.length(); j++)
                    {
                        if (j < tempString.length() - 1)
                        {
                            String substring = String.valueOf(tempChar[j]) + String.valueOf(tempChar[j + 1]);
            
                            if (substring.equals("ab") || substring.equals("ba"))
                            {
                                String substring2 = "";
            
                                for (int k = 0; k < j; k++)
                                {
                                    substring2 = substring2.concat(String.valueOf(tempChar[k]));
                                }
            
                                // Change the adjacent and distinct letter
                                substring2 = substring2.concat("c");
            
                                for (int k = j + 2; k < tempChar.length; k++)
                                {
                                    substring2 = substring2.concat(String.valueOf(tempChar[k]));
                                }
            
                                myQueue.add(substring2);
                            }
                            else if (substring.equals("bc") || substring.equals("cb"))
                            {
                                String substring2 = "";
            
                                for (int k = 0; k < j; k++)
                                {
                                    substring2 = substring2.concat(String.valueOf(tempChar[k]));
                                }
            
                                // Change the adjacent and distinct letter
                                substring2 = substring2.concat("a");
            
                                for (int k = j + 2; k < tempChar.length; k++)
                                {
                                    substring2 = substring2.concat(String.valueOf(tempChar[k]));
                                }
            
                                myQueue.add(substring2);
                            }
                            else if (substring.equals("ac") || substring.equals("ca"))
                            {
                                String substring2 = "";
            
                                for (int k = 0; k < j; k++)
                                {
                                    substring2 = substring2.concat(String.valueOf(tempChar[k]));
                                }
            
                                // Change the adjacent and distinct letter
                                substring2 = substring2.concat("b");
            
                                for (int k = j + 2; k < tempChar.length; k++)
                                {
                                    substring2 = substring2.concat(String.valueOf(tempChar[k]));
                                }
                                
                                myQueue.add(substring2);
                            }
            
                        }
            
                    }
                    break;
                    
                case BACK:
                    // Check the adjacent distinct letter from back
                    for (int j = tempString.length()-1; j >= 0; j--)
                    {
                        if (j > 0)
                        {
                            String substring = String.valueOf(tempChar[j]) + String.valueOf(tempChar[j - 1]);
            
                            if (substring.equals("ab") || substring.equals("ba"))
                            {
                                String substring2 = "";
            
                                for (int k = 0; k < j-1; k++)
                                {
                                    substring2 = substring2.concat(String.valueOf(tempChar[k]));
                                }
            
                                // Change the adjacent and distinct letter
                                substring2 = substring2.concat("c");
            
                                for (int k = j+1; k < tempChar.length; k++)
                                {
                                    substring2 = substring2.concat(String.valueOf(tempChar[k]));
                                }
            
                                myQueue.add(substring2);
                            }
                            else if (substring.equals("bc") || substring.equals("cb"))
                            {
                                String substring2 = "";
            
                                for (int k = 0; k < j-1; k++)
                                {
                                    substring2 = substring2.concat(String.valueOf(tempChar[k]));
                                }
            
                                // Change the adjacent and distinct letter
                                substring2 = substring2.concat("a");
            
                                for (int k = j+1; k < tempChar.length; k++)
                                {
                                    substring2 = substring2.concat(String.valueOf(tempChar[k]));
                                }
            
                                myQueue.add(substring2);
                            }
                            else if (substring.equals("ac") || substring.equals("ca"))
                            {
                                String substring2 = "";
            
                                for (int k = 0; k < j-1; k++)
                                {
                                    substring2 = substring2.concat(String.valueOf(tempChar[k]));
                                }
            
                                // Change the adjacent and distinct letter
                                substring2 = substring2.concat("b");
            
                                for (int k = j+1; k < tempChar.length; k++)
                                {
                                    substring2 = substring2.concat(String.valueOf(tempChar[k]));
                                }
            
                                myQueue.add(substring2);
                            }
            
                        }
            
                    }
                    break;
            }
            
        }
        
        return step;
    }

}

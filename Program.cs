


internal class Program
{

    private static int getUserInput(string message){
        int number=0;
        bool success=false;
        while(!success)
        {   Console.WriteLine("Please enter "+message+" number: ");
            success=int.TryParse(Console.ReadLine(), out number);
        }
        return number;
    }

    // private static int[] getUserRules(){
    //     Console.WriteLine("Please enter rules. You can choose anyone or any combination of [3,5,7,11,13,17]");
    //     string ruleString=""+Console.ReadLine();
    //     string[] ruleArray=ruleString.Split(',');
    //     int[] ruleNumberArray= new int[1];
    //     foreach(var item in ruleArray){
    //         ruleNumberArray.Append(int.Parse(item));
    //     }
    //     return ruleNumberArray;
    //     }

    
    private static void Main(string[] args)
    {   //Dictionary initialisation
        Dictionary<int, string> fizzBuzz = new Dictionary<int, string>(){
            [3]="Fizz",
            [5]="Buzz",
            [7]="Bang",
            [11]="Bong",
            [13]="Fezz",
            [17]=""     
        };
        // fizzBuzz.Add(3, "Fizz");
        // fizzBuzz.Add(5, "Buzz");
        // fizzBuzz.Add(7, "Bang");
        // fizzBuzz.Add(11, "Bong");
        // fizzBuzz.Add(13, "Fezz");
        // fizzBuzz.Add(17, "");

        int userInputMin=getUserInput("Minimum");
        int userInputMax=getUserInput("Maximum");
        // int[] rules=getUserRules();
        // foreach(var rule in rules){
        //     Console.Write(rule);
        // }

        for (int i = userInputMin; i <= userInputMax; i++)
        {
            string answer = "";
            foreach (var key in fizzBuzz.Keys)
            {
                if (i % key == 0)
                {
                    if (key == 13)
                    {
                        if (answer.Contains('B'))
                            //if answer has 'B',current key will be inserted at where the 'B' is
                            answer = answer.Insert(answer.IndexOf('B'), fizzBuzz[key]);
                        else answer = answer + fizzBuzz[key];
                    }
                    else if (key == 17)
                    {
                        if (answer.Length > 0)
                        { foreach (var c in answer){
                            if(char.IsUpper(c) && answer.IndexOf(c)!=0)
                                answer=answer.Insert(answer.IndexOf(c), " "); // go through string, insert space if character is uppercase and not first 
                        }
                        string[] newAnswer=answer.Split(" "); //put string into a string array, seperate by space
                        answer=string.Join("",newAnswer.Reverse()); //reverse array, then convert to string by string.join with no space
                        }
                    }
                    else answer = answer + fizzBuzz[key];
                }
            }

            if (answer.Length != 0)
            {
                Console.WriteLine(answer);
            }
            else
            {
                Console.WriteLine(i);
            }
        }
    }
}
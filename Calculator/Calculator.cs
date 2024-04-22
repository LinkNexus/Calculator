using System.Numerics;

namespace Calculator;

public class Calculator
{
    public static double Result { set; get; }
    public static double Total { set; get; }
    
    public static bool ThereIsAResult { set; get; }
    public static string? Response { set; get; }

    private static List<double> _numbers = new List<double>(); 
    
    public static string? NextInput { set; get; }
    
    public static bool IsNumberEntered { set; get; }

    private static string _initialMessage = "Welcome to our Calculator App! Choose which operation you want to do " +
                                            "(Do your choice by writing the number of the operation).\n" +
                                            "1. Addition\n" +
                                            "2. Subtraction\n" +
                                            "3. Multiplication\n" +
                                            "4. Division\n" +
                                            "5. Square\n" +
                                            "6. Square Root\n" +
                                            "7. Logarithm\n" +
                                            "8. Exit\n";

    public static List<double> Numbers
    {
        get => _numbers;
        set => _numbers = value;
    }
    public static string InitialMessage
    {
        get => _initialMessage;
        set => _initialMessage = value;
    }

    public static void InitialProcess()
    {
        if (ThereIsAResult)
        {
            Console.Write("Do you want to use the result of this operation for the next one? (Respond by yes or no): ");
            Response = Console.ReadLine()?.ToLower();
            Console.WriteLine(InitialMessage);
        }
        else
        {
            Console.WriteLine(InitialMessage);
        }
        
        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Addition();
                break;
            
            case "2":
                Subtraction();
                break;
            
            case "3":
                Multiplication();
                break;
            
            case "4":
                Division();
                break;
            
            case "5":
                Square();
                break;
            
            case "6":
                SquareRoot();
                break;
            
            case "7":
                Logarithm();
                break;
            
            case "8":
                return;
        }
    }

    public static void Addition()
    {
        double number = 0;

        if (Response == "yes")
        {
            Console.WriteLine("Choose which numbers to add to " + Result + ", press only enter if you are finished.");
            Numbers.Add(Result);
        } else {
            Console.WriteLine("Give the numbers you want to add, press only enter if you are finished.");
        }

        do
        {
            if (NextInput == "")
            {
                double.TryParse(Console.ReadLine(), out number);
            }
            else
            {
                double.TryParse(NextInput, out number);
            }

            Numbers.Add(number);
            NextInput = Console.ReadLine();
            
            if (NextInput != "")
            {
                IsNumberEntered = true;
            }
            else
            {
                IsNumberEntered = false;
            }
        } while (IsNumberEntered);

        foreach (double value in Numbers)
        {
            Total += value;
        }

        Result = Total;
        ThereIsAResult = true;
        Console.WriteLine("The result of your operation is {0}", Result);

        Numbers.Clear();

        Total = 0;
        
        InitialProcess();
    }

    public static void Subtraction()
    {
        double numberToBeSubtractedFrom = 0;
        double numberSubtracting = 0;
        
        if (Response == "yes")
        {
            numberToBeSubtractedFrom = Result;
        } else {
            Console.WriteLine("Give the number you want to subtract from, press only enter if you are finished.");
            double.TryParse(Console.ReadLine(), out numberToBeSubtractedFrom);
        }
        
        Console.WriteLine("Give the number to subtract from {0}, press only enter if you are finished.", numberToBeSubtractedFrom);
        double.TryParse(Console.ReadLine(), out numberSubtracting);
        
        Total = numberToBeSubtractedFrom - numberSubtracting;
        Result = Total;
        ThereIsAResult = true;
        Console.WriteLine("The result of your operation is {0}", Result);

        Total = 0;
        
        InitialProcess();
    }

    public static void Multiplication()
    {
        double number = 0;
        Total = 1;
        
        if (Response == "yes")
        {
            Console.WriteLine("Choose which numbers to multiply to " + Result + ", press only enter if you are finished.");
            Numbers.Add(Result);
        } else {
            Console.WriteLine("Give the numbers you want to multiply together, press only enter if you are finished.");
        }

        do
        {
            if (string.IsNullOrEmpty(NextInput))
            {
                double.TryParse(Console.ReadLine(), out number);
            }
            else
            {
                double.TryParse(NextInput, out number);
            }

            Numbers.Add(number);
            NextInput = Console.ReadLine();
            
            if (NextInput != "")
            {
                IsNumberEntered = true;
            }
            else
            {
                IsNumberEntered = false;
            }
        } while (IsNumberEntered);

        foreach (double value in Numbers)
        {
            Total *= value;
        }

        Result = Total;
        ThereIsAResult = true;
        Console.WriteLine("The result of your operation is {0}", Result);

        Numbers.Clear();

        Total = 0;
        
        InitialProcess();
    }

    public static void Division()
    {
        double numberToBeDivided = 0;
        double numberDividing = 0;
        
        if (Response == "yes")
        {
            numberToBeDivided = Result;
        } else {
            Console.WriteLine("Give the number you want to divide, press only enter if you are finished.");
            double.TryParse(Console.ReadLine(), out numberToBeDivided);
        }
        
        Console.WriteLine("Give the number which should divide {0}, press only enter if you are finished.", numberToBeDivided);
        double.TryParse(Console.ReadLine(), out numberDividing);
        
        Total = numberToBeDivided / numberDividing;
        Result = Total;
        ThereIsAResult = true;
        Console.WriteLine("The result of your operation is {0}", Result);

        Total = 0;
        
        InitialProcess();
    }

    public static void Square()
    {
        double number = 0;
        
        if (Response == "yes")
        {
            number = Result;
        } else {
            Console.WriteLine("Give the number you want to square, press only enter if you are finished.");
            double.TryParse(Console.ReadLine(), out number);
        }

        Total = number * number;
        Result = Total;
        ThereIsAResult = true;
        Console.WriteLine("The result of your operation is {0}", Result);

        Total = 0;
        
        InitialProcess();
    }

    public static void SquareRoot()
    {
        double number = 0;
        
        if (Response == "yes")
        {
            number = Result;
        } else {
            Console.WriteLine("Give the number you want to find the square root, press only enter if you are finished.");
            double.TryParse(Console.ReadLine(), out number);
        }

        Total = Math.Sqrt(number);
        Result = Total;
        ThereIsAResult = true;
        Console.WriteLine("The result of your operation is {0}", Result);

        Total = 0;
        
        InitialProcess();
    }

    public static void Logarithm()
    {
        double number = 0;
        double numberBase = 0;
        
        if (Response == "yes")
        {
            number = Result;
        } else {
            Console.WriteLine("Give the number you want to find the logarithm, press only enter if you are finished.");
            double.TryParse(Console.ReadLine(), out number);
        }
        
        Console.WriteLine("Choose the base of the logarithm (pick by the writing down the number of the option)\n" +
                          "1. Base 10\n" +
                          "2. Base e (Natural Logarithm)\n" +
                          "3. Base 2\n" +
                          "4. Custom Base\n");
        string? choice = Console.ReadLine();

        if (choice == "1")
        {
            Total = Math.Log10(number);
        }

        if (choice == "2")
        {
            Total = Math.Log(number);
        }

        if (choice == "3")
        {
            Total = Math.Log2(number);
        }

        if (choice == "4")
        {
            Console.Write("Give the base of the logarithm:");
            double.TryParse(Console.ReadLine(), out numberBase);
            
            Total = Math.Log(number, numberBase);
        }
        
        Result = Total;
        ThereIsAResult = true;
        Console.WriteLine("The result of your operation is {0}", Result);

        Total = 0;
        
        InitialProcess();
    }
}
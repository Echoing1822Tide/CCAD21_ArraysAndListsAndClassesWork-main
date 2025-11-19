using System.Runtime.InteropServices;
using ConsoleHelpers;

namespace ConsoleAppProject.Menus;

public class MainMenu
{
    //private variables for various menus
    //string[] stockSymbols = new string[5];
    //stocksymbols[0] = "AAPL";
    //stocksymbols[1] = "MSFT";
    //stocksymbols[2] = "PPY";
    //stocksymbols[3] = "GOOG";
    //stocksymbols[4] = "NVDA";
    
    string[] stockSymbols = new string[] { "AAPL", "MSFT", "PPY", "GOOG", "NVDA"};

    List<string> stockSymbolList = new List<string>()
    {
        "AAPL", "MSFT", "PPY", "GOOG", "NVDA"
    };

    int count = 0;

    public MainMenu()
    {
        count = stockSymbols.Length;
        Console.WriteLine($"Current Counts: {count} | {stockSymbolList.Count}");
    }

    
    private void AddStockSymbol()
    {
        if (count == stockSymbols.Length)
        {
            ResizeArray();
        }
        string newSymbol = InputHelpers.GetInputAsString("Enter a new Stock Symbol:", true);

        //are we full?
        
        //add the new stock into the new array
        stockSymbols[count++] = newSymbol;
        /******************************************************************************/
        ShowStockSymbols();
    }

    private void ShowStockSymbols()
    {
        Console.WriteLine(OutputHelpers.BoxedArrayWithTitle("My Stocks", stockSymbols, count:count));
    }

    private void ShowFormattedMessages()
    {
        var prompt = "What is your name?";
        var response = InputHelpers.GetInputAsString(prompt);
        Console.WriteLine(OutputHelpers.BoxedMessage(response, '*'));
        Console.WriteLine(OutputHelpers.BoxedMessage(response, '-'));
        string tooLong = "asdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdf";
        Console.WriteLine(OutputHelpers.BoxedMessage(tooLong, '-'));
        Console.WriteLine(new string('~', 40));

        Console.WriteLine(OutputHelpers.BoxedMessageWithTitle("Welcome", response));
    }

    private void ShowInputHelpers()
    {
        string prompt = "Please enter your favorite constant";
        double min = 0;
        double max = 100;
        // double sample1 = InputHelpers.GetInputAsDouble(prompt);
        // double sample2 = InputHelpers.GetInputAsDouble(prompt, confirm: true);
        // double sample3 = InputHelpers.GetInputAsDouble(prompt, min, confirm:true);
        
        double result = InputHelpers.GetInputAsDouble(prompt, min, max, true);
        Console.WriteLine($"You entered {result}");

        prompt = "Guess a number between 1 and 7";
        int intMin = 1;
        int intMax = 7;
        int intResult = InputHelpers.GetInputAsInt(prompt, intMin, intMax, true);
        Console.WriteLine($"You guessed {intResult}");

        prompt = "Would you like to continue?";
        bool boolResult = InputHelpers.GetInputAsBool(prompt, true);
        Console.WriteLine($"continue: {(boolResult? "yes" : "no")}");

        var prompt2 = "IS C# the best language?";
        bool boolResult2 = InputHelpers.GetInputAsBool(prompt2);
        Console.WriteLine($"give up: {(boolResult2? "yes" : "no")}");

        // String method
        var prompt3 = "What is your name?";
        string stringResult = InputHelpers.GetInputAsString(prompt3);
        Console.WriteLine($"Hello {stringResult}!");

        var prompt4 = "Enter your name again";
        string stringResult2 = InputHelpers.GetInputAsString(prompt4, true);
        Console.WriteLine($"Hello again {stringResult2}!");
    }

    public async Task ShowAsync()
    {
        bool shouldContinue = true;
        string[] menuOptions = GetMenuOptions();

        while (shouldContinue)
        {
            Console.Clear();

            var menuText = MenuGenerator.GenerateMenu("Main Menu", "Please select an operation", menuOptions, 40);

            // Show menu and get user choice
            int choice = InputHelpers.GetInputAsInt(menuText, 1, menuOptions.Length, true);

            try
            {
                shouldContinue = await HandleMenuChoiceAsync(choice);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

    }

    private void ShowStockSymbolsList()
    {
        Console.WriteLine(OutputHelpers.BoxedListWithTitle("Stock List", stockSymbolList, 80));
    }

    private void AddStockSymbolList()
    {
        string newSymbol = InputHelpers.GetInputAsString("Enter a new Stock Symbol:", true);

        //add the new stock into the new array
        stockSymbolList.Add(newSymbol);

        ShowStockSymbolsList();
    }

    //handle user choice
    private async Task<bool> HandleMenuChoiceAsync(int choice)
    {
        switch (choice)
        {
            case 1:
                ShowFormattedMessages();
                break;
            case 2:
                ShowInputHelpers();
                break;
            case 3:
                ShowStockSymbols();
                break;
            case 4:
                AddStockSymbol();
                break;
            case 5:
                ShowStockSymbolsList();
                break;
            case 6:
                AddStockSymbolList();
                break;
            default:
                return false;
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        return true;
    }

    private string[] GetMenuOptions()
    {
        return new string[] {
            "Show formatted Messages",
            "Show Input Helpers",
            "Show Stocks",
            "Add Stock Symbol",
            "Show Stocks [List]",
            "Add Stock [List]",
            "Exit"
        };
    }

    private void ResizeArray()
    {
        string[] newStockSymbols = new string[stockSymbols.Length *2];
        for (int i = 0; i < stockSymbols.Length; i++)
        {
            //copy the original array into the new one
            newStockSymbols[i] = stockSymbols[i];
        }
        stockSymbols = newStockSymbols;
    }
}

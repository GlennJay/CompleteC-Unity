
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    string[] level1Passwords = {
        "grade book",
        "schedule",
        "desk",
        "detention",
        "tardy"

    };
     string[] level2Passwords = {
        "currency",
        "lock",
        "teller",
        "income",
        "loans"

    };
     string[] level3Passwords = {
        "high security",
        "general",
        "CIA",
        "top secret",
        "military"

    };

    //Game state
    int level;
    string password;
    
    enum Screen {MainMenu, Password, Win };
    Screen currentScreen;
    void Start()
    {
        
        showMainMenu();
    }
    void showMainMenu(){
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();

        Terminal.WriteLine("   BEWARE: Your about to dive deep!  ");
        Terminal.WriteLine("\nwhich area you want to hack into?");
        Terminal.WriteLine("Press 1 for the Principal's office");
        Terminal.WriteLine("Press 2 for the Bank vault");
        Terminal.WriteLine("Press 3 for the Pentagon");
        Terminal.WriteLine("Enter your selection: ");
    }
    //only decide how to handle input
    void OnUserInput(string input)
	{
        
		if(input == "menu"){
           
            showMainMenu();
        }else if(currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }else if(currentScreen == Screen.Password){
           CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        
        if(isValidLevelNumber){
            level = int.Parse(input);
            AskForPassword();
        }else if (input == "omg")
        {
            Terminal.WriteLine("NOT THAT....");
        }
        else
        {
            Terminal.WriteLine("Not a valid entry");
        }
    }

    void AskForPassword()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Password;
        SetRandPassword();
        MenuPrompt();
        Terminal.WriteLine("Enter the password. hint: " + password.Anagram());

    }

    void SetRandPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[UnityEngine.Random.Range(0, level1Passwords.Length)];
                break;

            case 2:
                password = level2Passwords[UnityEngine.Random.Range(0, level2Passwords.Length)];
                break;

            case 3:
                password = level3Passwords[UnityEngine.Random.Range(0, level3Passwords.Length)];
                break;

            default:
                Debug.LogError("You hit an error");
                break;
        }
    }

    void CheckPassword(string input){
        if(input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        MenuPrompt();
    }

    void ShowLevelReward()
    {
        switch (level)
        { 
            case 1:
            Terminal.WriteLine(@"
***    *    ***    ***  
*  *  * *  *      *
***  * * *  *      *    
*    *   *    *      *  
*    *   *  **     **   
            ");
            break;
            case 2:
            Terminal.WriteLine(@"
***    *    ***    ***
*  *  * *  *      *
***  * * *  *      *    
*    *   *    *      *  
*    *   *  **     **   
            ");
            break;
            case 3:
            Terminal.WriteLine(@"
***    *    ***    ***
*  *  * *  *      *
***  * * *  *      *    
*    *   *    *      *  
*    *   *  **     **   
            ");
            break;
        }

        
    }

    void MenuPrompt(){
        Terminal.WriteLine("Type menu to get back to main menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Start is called before the first frame update

    //Game state
    int level;
    enum Screen {MainMenu, Password, Win };
    Screen currentScreen;
    void Start()
    {
        
        showMainMenu();
    }
    void showMainMenu(){
        Terminal.ClearScreen();

        Terminal.WriteLine("   BEWARE: Your about to dive deep!  ");
        Terminal.WriteLine("\nwhich area you want to hack into?");
        Terminal.WriteLine("Press 1 for the Principal's office");
        Terminal.WriteLine("Press 2 for the Bank vault");
        Terminal.WriteLine("Press 1 for the Pentagon");
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
        }
    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            StartGame();
        }
        else if (input == "3")
        {
            level = 3;
            StartGame();
        }
        else if (input == "omg")
        {
            Terminal.WriteLine("NOT THAT....");
        }
        else
        {
            Terminal.WriteLine("Not a valid entry");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You chose level " + level);
        Terminal.WriteLine("Enter the password");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}

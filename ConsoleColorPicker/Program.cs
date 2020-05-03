using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleColorPicker
{
    // **************************************************
    //
    // Title: Console Color Picker
    // Description: A program to help you pick your console color combination
    // Application Type: Console
    // Author: Bolser, Lindsey
    // Date Created:        5/2/2020
    // Date Revised:        5/2/2020
    //
    // **************************************************
    class Program
    {
        static void Main(string[] args)
        {
            SetTheme();
            DisplayWelcomeMessage();
            DisplayMenu();
            DisplayClosingScreen();
        }

        private static void DisplayMenu()
        {
            Console.Clear();
            bool quitApplication = false;
            string myMenuChoice;

            do
            {
                DisplayScreenHeader("Console Color Picker Menu");
                Console.WriteLine();
                Console.WriteLine("\t[A] Change Foreground Color");
                Console.WriteLine("\t[B] Change Background Color");
                Console.WriteLine("\t[C] Test Out Color Scheme");
                Console.WriteLine("\t[Q] Quit Application");
                Console.WriteLine();
                Console.Write("\tWhat would you like to do? ");
                myMenuChoice = Console.ReadLine().ToLower();

                switch (myMenuChoice)
                {
                    case "a":
                        DisplayForegroundColor();
                        break;

                    case "b":
                        DisplayBackgroundColor();
                        break;

                    case "c":
                        DisplayTestScheme();
                        break;

                    case "q":
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.Write("\tPlease enter [A], [B], [C] or [Q]: ");
                        Console.WriteLine();
                        DisplayContinuePrompt();
                        break;
                }
            } while (!quitApplication);
        }

        private static void DisplayForegroundColor()
        {
            Console.Clear();
            Console.ForegroundColor = DisplayForegroundColorChoices();
        }

        private static ConsoleColor DisplayForegroundColorChoices()
        {
            ConsoleColor consoleColor;
            bool validConsoleColor;

            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

            do
            {
                ConsoleColor currentBackground = Console.BackgroundColor;
                ConsoleColor currentForeground = Console.ForegroundColor;
                DisplayScreenHeader("Console Foreground Color Changer");
                Console.WriteLine();
                Console.WriteLine("\tAvailable Foreground Colors:");
                Console.WriteLine();
                foreach (var color in colors)
                {
                    if (color == currentBackground)
                    {
                        Console.ForegroundColor = color;
                        Console.Write("\t ");
                        Console.Write('\u2588');
                        Console.Write('\u2588');
                        Console.Write('\u2588');
                        Console.ForegroundColor = currentForeground;
                        Console.WriteLine(" {0} - See Background Color", color);
                        continue;
                    }
                    Console.ForegroundColor = color;
                    Console.Write("\t ");
                    Console.Write('\u2588');
                    Console.Write('\u2588');
                    Console.Write('\u2588');
                    Console.ForegroundColor = currentForeground;
                    Console.Write(" {0} - ", color);
                    Console.ForegroundColor = color;
                    Console.WriteLine("SAMPLE ");
                }
                Console.ForegroundColor = currentForeground;
                Console.WriteLine();

                Console.Write($"\tEnter a color: ");
                
                validConsoleColor = Enum.TryParse<ConsoleColor>(Console.ReadLine(), true, out consoleColor);
                if (consoleColor == Console.BackgroundColor)
                {
                    Console.Clear();
                    DisplayScreenHeader("Console Foreground Color Picker");
                    Console.WriteLine("\n\tERROR: \tPlease provide a color different than the current background color. \n");
                    Console.WriteLine($"\t\tCurrent background color: {Console.BackgroundColor}");
                    Console.WriteLine();
                    consoleColor = Console.ForegroundColor;
                    DisplayContinuePrompt();
                    Console.Clear();
                    validConsoleColor = false;
                }
                else
                {

                    if (!validConsoleColor)
                    {
                        Console.Clear();
                        DisplayScreenHeader("Console Foreground Color Picker");
                        Console.WriteLine("\n\tERROR: Please provide a valid console color. \n");
                        DisplayContinuePrompt();
                        Console.Clear();
                    }
                    else
                    {
                        validConsoleColor = true;
                    }
                }
            } while (!validConsoleColor);
            
            return consoleColor;
        }

        private static void DisplayBackgroundColor()
        {
            Console.Clear();
            Console.BackgroundColor = DisplayBackgroundColorChoices();
        }

        private static ConsoleColor DisplayBackgroundColorChoices()
        {
            ConsoleColor consoleColor;
            bool validConsoleColor;

            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

            do
            {
                ConsoleColor currentBackground = Console.BackgroundColor;
                ConsoleColor currentForeground = Console.ForegroundColor;
                DisplayScreenHeader("Console Background Color Changer");
                Console.WriteLine();
                Console.WriteLine("\tAvailable Background Colors:");
                Console.WriteLine();
                foreach (var color in colors)
                {
                    if (color == currentForeground)
                    {
                        Console.BackgroundColor = color;
                        Console.Write("\t ");
                        Console.BackgroundColor = currentBackground;
                        Console.WriteLine(" {0} - See Foreground Color", color);
                        continue;
                    }
                    var width = Console.WindowWidth - 35;
                    Console.BackgroundColor = color;
                    Console.WriteLine("\t This is an example of {0, -" + width + "} ", color);
                }
                Console.BackgroundColor = currentBackground;
                Console.WriteLine();

                Console.Write($"\tEnter a color: ");

                validConsoleColor = Enum.TryParse<ConsoleColor>(Console.ReadLine(), true, out consoleColor);

                
                if (consoleColor == Console.ForegroundColor)
                {
                    Console.Clear();
                    DisplayScreenHeader("Console Background Color Changer");
                    Console.WriteLine("\n\tERROR: \tPlease provide a color different than the current foreground color. \n");
                    Console.WriteLine($"\t\tCurrent foreground color: {Console.ForegroundColor}");
                    Console.WriteLine();
                    consoleColor = Console.BackgroundColor;
                    DisplayContinuePrompt();
                    Console.Clear();
                    validConsoleColor = false;
                }
                else
                {
                    
                    if (!validConsoleColor)
                    {
                        Console.Clear();
                        DisplayScreenHeader("Console Background Color Changer");
                        Console.WriteLine("\n\tERROR: Please provide a valid console color. \n");
                        DisplayContinuePrompt();
                        Console.Clear();
                    }
                    else
                    {
                        validConsoleColor = true;
                    }
                }
            } while (!validConsoleColor);

            return consoleColor;
        }

        private static void DisplayTestScheme()
        {
            Console.Clear();
            DisplayScreenHeader("Console Color Scheme Tester");
            Console.WriteLine();
            Console.WriteLine($"\tCurrent foreground color: {Console.ForegroundColor}");
            Console.WriteLine($"\tCurrent background color: {Console.BackgroundColor}");
            Console.WriteLine();
            Console.WriteLine("\tExample Text:");
            Console.WriteLine();
            Console.WriteLine("\t\tIf You Think You Are Beaten by Walter D. Wintle");
            Console.WriteLine();
            Console.WriteLine("\t\tIf you think you are beaten, you are.");
            Console.WriteLine("\t\tIf you think you dare not, you don\'t.");
            Console.WriteLine("\t\tIf you\'d like to win but think you can\'t,");
            Console.WriteLine("\t\tIt\'s almost certain you won\'t.");
            Console.WriteLine("\t\tLife\'s battles don\'t always go");
            Console.WriteLine("\t\tTo the stronger or faster man,");
            Console.WriteLine("\t\tBut sooner or later, the man who wins");
            Console.WriteLine("\t\tIs the man who thinks he can."); 
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            DisplayScreenHeader("Console Color Picker");
            Console.WriteLine();
            Console.WriteLine("\tThank you for using Console Color Picker");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        private static void DisplayWelcomeMessage()
        {
            DisplayScreenHeader("Welcome To Console Color Picker");
            Console.WriteLine();
            Console.WriteLine("\tThis program is designed to help you pick which console colors you want to use.");
            DisplayContinuePrompt();
        }

        private static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.Write("\tPlease press any key to continue. ");
            Console.ReadKey();
        }

        private static void DisplayScreenHeader(string headerForeground)
        {
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            ConsoleColor currentForeground = Console.ForegroundColor;

            Console.Clear();
            Console.Write("\t\t");

            foreach (var color in colors)
            {
                Console.ForegroundColor = color;
                Console.Write('\u002B');
                Console.Write(" ");
                Console.ForegroundColor = currentForeground;
            }
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerForeground);
            Console.Write("\t\t");
            foreach (var color in colors)
            {
                Console.ForegroundColor = color;
                Console.Write('\u002B');
                Console.Write(" ");
                Console.ForegroundColor = currentForeground;
            }
            Console.WriteLine();
        }
        private static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
        }

    }
}

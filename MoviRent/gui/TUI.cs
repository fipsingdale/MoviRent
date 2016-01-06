using MoviRent.data;
using MoviRent.interfaces;
using MoviRent.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviRent.gui
{
    class TUI
    {
        private readonly RequirementsDefinition requirementsDefinition;
        private User tempUser;
        private Movie tempMovie;
        private Validator validator;
        private String input;
        public TUI(RequirementsDefinition requirementsDefinition)
        {
            this.requirementsDefinition = requirementsDefinition;
            DisplayStartMenue();
        }


        private void DisplayStartMenue()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("MoviRent-Management TUI");
                Console.WriteLine("#######################");
                Console.WriteLine("Choose section:");
                Console.WriteLine("Movie               (m)");
                Console.WriteLine("User                (u)");
                Console.WriteLine("-----------------------");
                Console.WriteLine("Back	            (b)");
                Console.WriteLine("Chose and enter character");
                Console.WriteLine("inside brackets and");
                Console.WriteLine("confirm by using return");
                PrintCursor();
                input = Console.ReadLine();
                input = input.ToLower();
                if (input.Equals("m"))
                {
                    DisplayMenue(MenueType.Movie);
                }
                else if (input.Equals("u"))
                {
                    DisplayMenue(MenueType.User);
                }
                else if (input.Equals("b")) {
                    DisplayStartMenue();
                }
            } while (!input.Equals("q"));
        }
        private void DisplayMenue(MenueType menueType)
        {
            do
            {
                Console.Clear();
                Console.WriteLine(menueType.ToString() + "-Management TUI ");
                Console.WriteLine("###################");
                Console.WriteLine("Create  " + menueType.ToString() + " 	(c)");
                Console.WriteLine("Edit   " + menueType.ToString() + "	(e)");
                Console.WriteLine("Delete " + menueType.ToString() + " 	(d)");
                Console.WriteLine("-------------------");
                Console.WriteLine("Show   " + menueType.ToString() + "	(v)");
                Console.WriteLine("Search " + menueType.ToString() + "	(s)");
                Console.WriteLine("-------------------");
                Console.WriteLine("Exit	(q)");
                Console.WriteLine("Chose and enter character inside brackets");
                Console.WriteLine("and confirm by using return");
                PrintCursor();
                input = Console.ReadLine();

                if (validator.valitadeInputFromDisplayMenue(input))
                {
                    RedirectMenue(input, menueType);
                }
                else
                {
                    Console.WriteLine("no Valid input!");
                }
            } while (!input.Equals("q"));
        }
        private bool isValidInput(String input, String[] validInput)
        {
            if (validInput.Length == 0)
            {
                return false;
            }
            return !validInput.Contains<String>(input);
        }

        private void RedirectMenue(String input, MenueType menueType)
        {
            switch (input)
            {
                case "c": DisplayCreate(menueType);
                    break;
                case "d": DisplayDelete(menueType);
                    break;
                case "e": DisplayEdit(menueType);
                    break;
                case "s": DisplaySearch(menueType);
                    break;
                case "v": DisplayShow(menueType);
                    break;
                case "q":
                    break;
                default: DisplayMenue(menueType);
                    break;
            }
        }

        private void DisplayShow(MenueType menueType)
        {
            Console.Clear();
            Console.WriteLine(menueType.ToString() + "-Management TUI ");
            Console.WriteLine("#######################");
            if (menueType.Equals(MenueType.Movie))
            {
                Console.WriteLine("Display all Movies               (m)");
                Console.WriteLine("Display Movies which are borrowed              (g)");
                Console.WriteLine("Display Movies which are unborrowed                (a)");
            }
            else
            {
                Console.WriteLine("Display all User      (u)");
                Console.WriteLine("Display User Who lend  (l)");
            }
            Console.WriteLine("-----------------------");
            Console.WriteLine("Back             (b)");
            Console.WriteLine("Chose and enter character");
            Console.WriteLine("inside brackets and");
            Console.WriteLine("confirm by using return");
            PrintCursor();
            input = Console.ReadLine();
            input = input.ToLower();
            if (validator.valitadeInputFromShowMenue(input))
            {
                switch (input)
                {
                    case "m": requirementsDefinition.GetAllMovies();
                        break;
                    case "g": requirementsDefinition.GetAllBorrowedMovies();
                        break;
                    case "a": requirementsDefinition.GetAllUnborrowedMovies();
                        break;
                    case "u": requirementsDefinition.GetAllUser();
                        break;
                    case "l": requirementsDefinition.GetUserWhoBorrowed();
                        break;
                    case "b": RedirectMenue("x", menueType);
                        break;
                }
            }
        }

        private void DisplaySearch(MenueType menueType)
        {
            Console.Clear();
            Console.WriteLine(menueType.ToString() + "-Management TUI ");
            Console.WriteLine("#######################");
            Console.WriteLine("Enter " + menueType.ToString() + "ID");
            PrintCursor();
            if (validator.valitadeInputFromSearchMenue(input))
            {
                if (menueType.Equals(MenueType.Movie))
                {
                    requirementsDefinition.GetMovieById(input);
                }
                else
                {
                    requirementsDefinition.GetUserById(input);
                }
            }
            RedirectMenue("x", menueType);
        }

        private void DisplayEdit(MenueType menueType)
        {
            Console.Clear();
            Console.WriteLine(menueType.ToString() + "-Management TUI ");
            Console.WriteLine("#######################");
            if (menueType.Equals(MenueType.Movie))
            {
                Console.WriteLine("Edit Movie               (m)");
            }
            else
            {
                Console.WriteLine("Edit Use      (u)");
                Console.WriteLine("Return borrowed Movie (r)");
            }
            Console.WriteLine("-----------------------");
            Console.WriteLine("Back             (b)");
            Console.WriteLine("Chose and enter character");
            Console.WriteLine("inside brackets and");
            Console.WriteLine("confirm by using return");
            PrintCursor();
            input = Console.ReadLine();
            input = input.ToLower();            
        }

        private void DisplayDelete(MenueType menueType)
        {
            Console.Clear();
            Console.WriteLine(menueType.ToString() + "-Management TUI ");
            Console.WriteLine("Enter "+menueType+" ID");
            Console.WriteLine("and confirm by using return");
            PrintCursor();
            input = Console.ReadLine();
            if (menueType.Equals(MenueType.Movie))
            {
                requirementsDefinition.DeleteMovie(input);
            }
            else
            {
                requirementsDefinition.DeleteUser(input);
            }
            RedirectMenue("x", menueType);
        }

        private void DisplayCreate(MenueType menueType)
        {
            Console.Clear();
            Console.WriteLine(menueType.ToString() + "-Management TUI ");
            if (menueType.Equals(MenueType.Movie))
            {
                requirementsDefinition.CreateMovie(tempMovie);
            }
            else
            {
                requirementsDefinition.CreateUser(tempUser);
            }
            RedirectMenue("x", menueType);
        }
        private void PrintCursor()
        {
            Console.Write("$>");
        }
    }
}

using System;


namespace RouletteFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            //Invoking Game_Details1 method
            Game.Game_Details1("", 200, 0, 0);
        }
        //creating new class called Game.
        class Game
        {
            //constructor, not sure how to implement 
            public int money, bet, attempts;
            public string guess;

            private void Game_Details()
            {

                Game Roulette = new Game();
                Roulette.money = 200;
                Roulette.bet = 0;
                Roulette.attempts = 0;
                Roulette.guess = " ";
            }

            public static void Game_Details1(string guess, int money, int bet, int attempts)
            {
                //assigning different values
                string[] color = { "Black", "Red" };
                var ran = new Random();
                Random rand = new Random();
                while (money != 0)
                {
                    //Beginning point, that lists different input options
                    Console.WriteLine($"Money = ${money}");
                    Console.WriteLine("Pick an option:");
                    Console.WriteLine("a. Even number    b. Odd Number");
                    Console.WriteLine("c. Red            d. Black");
                    Console.WriteLine("e. 1 to 18        f. 19 to 36");

                    //creating a guess input
                    guess = (Console.ReadLine());
                    bool[] conditions = {guess == "a", guess == "b", guess ==  "c",
                    guess == "d", guess == "e", guess == "f"};
                    //testing array for true conditions using check_guess.
                    int check_guess = Array.IndexOf(conditions, true);
                    
                    if (check_guess == -1)
                    {
                        //if not vlaid input 
                        Console.WriteLine("Try a valid option!");
                        Console.ReadLine();
                        Console.Clear();
                        return;
                    }
                    else
                    {

                    //assigning bet and converting bet to int.
                    bet: Console.WriteLine("How much to bet?");
                        bet = Convert.ToInt32(Console.ReadLine());
                        //making sure that the bet is lower than money amount.
                        if (bet > money)
                        {
                            Console.WriteLine("bet exceeds cash amount, pick a lower number!");
                            Console.ReadKey();
                            /*goto statement will bring back to the begining of bet statement
                             if the bet exceeds money amount*/
                            goto bet;
                        }
                        else
                        {
                            //money subtracted from bet amount.
                            money = money - bet;
                            //creating random nmuber 1 to 37.
                            int roll = rand.Next(1, 37);
                            bool even = roll % 2 == 0;
                            //creating random color.
                            string randColor = color[ran.Next(color.Length)];
                            //identifyiing conditions.
                            if ((guess == "a" && even == true) || (guess == "b" && even == false) || (guess == "c" && randColor == "Red") || (guess == "d" && randColor == "Black") || (guess == "e" && roll < 19) || (guess == "f" && roll >= 19))
                            {
                                
                                Console.WriteLine($"You rolled {randColor} {roll}, You won ${bet * 2}!");
                                //money will reflect from the bet if you won or lost.
                                money = money + bet * 2;
                                Console.WriteLine("press enter to keep playing");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                //when loss the bet, create way to leave the program.
                                Console.WriteLine($"Rolled {randColor} {roll}, and lost ${bet}");
                                Console.ReadLine();
                                Console.WriteLine("To leave table press x, to keep playing press enter");
                                if (Console.ReadLine() == "x") 
                                {
                                    Console.WriteLine("Thanks For Playing");
                                    break;
                                }
                            }
                            if (money == 0)
                            //when running out of money, program will end.
                            {
                                Console.ReadKey();
                                Console.WriteLine("You are out of money, thanks for playing");
                            }
                        }
                    }
                }
            }
        }
    }
}


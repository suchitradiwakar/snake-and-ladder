using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{

    class Game
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Game starts...");
            List<Player> order = new List<Player>();
            int dice;
            Boolean status = false;

            Player player1 = new Player("Player1");
            Player player2 = new Player("Player2");


            Console.WriteLine("Player1 starts..");
            int Player1Dice = player1.Roll();
            Console.WriteLine(Player1Dice);

            Console.WriteLine("Player2 rolls..");
            int Player2Dice = player2.Roll();
            Console.WriteLine(Player2Dice);

            if (Player1Dice > Player2Dice)
            {
                Console.WriteLine("Player 1 starts");
                order.Add(player1);
                order.Add(player2);
            }
            else
            {
                Console.WriteLine("Player 2 starts");
                order.Add(player2);
                order.Add(player1);
            }

            Dictionary<int, int> SnakeAndLadder = new Dictionary<int, int>();
            Elements board = new Elements(SnakeAndLadder);

            do
            {
                foreach (Player player in order)
                {
                    dice = player.Roll();
                    Console.WriteLine(player.Name + " rolls dice.." + dice);

                    status = player.Update(dice, SnakeAndLadder);

                    //Console.Write(player.Position);

                }

            } while (status == false);


        }
    }

   

}

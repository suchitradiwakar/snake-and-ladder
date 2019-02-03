using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class Player
    {
        public String Name;
        public int Position;
        public Boolean status = false;

        public Player(String name)
        {
            Name = name;
            Position = 1;
        }

        public int Roll()
        {
            return RandomNumber(1, 6);
        }

        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public Boolean Update(int dice, Dictionary<int, int> snakeladder)
        {
            int position = Position + dice;
            int NewPosition;

            //Console.Write(position);

            if (position > 100)
            {
                Position = position - dice;
                Console.WriteLine("Player can not move!");
            }
            else if (position == 100)
            {
                Console.WriteLine(Name + " WINS!!!");
                status = true;
            }
            else
            {
                if (snakeladder.ContainsKey(position))
                {
                    NewPosition = snakeladder[position];
                    if (NewPosition > position)
                        Console.WriteLine("You climb up the ladder." + NewPosition);
                    else if (NewPosition < position)
                        Console.WriteLine("The snake bit you." + NewPosition);
                    Position = NewPosition;
                }
                else
                {
                    Position = position;
                }
            }
            return status;
        }

    }
}

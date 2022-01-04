using System;

namespace GuessDate
{
    class SecondPlayerModeGame
    {
        private int hiddenDate;
        private int HiddenDate
        {
            set
            {
                if ((value > 0) && (value <= 100))
                {
                    hiddenDate = value;
                }
            }
        }
        private int AmountAttempts { get; set; } = 5;
        private int playerAttempt;
        public void StartPlay(int userDate)
        {
            int newUserDate;
            playerAttempt++;
            if (playerAttempt == this.AmountAttempts - 1)
                Console.WriteLine("You have last try");
            if (playerAttempt == this.AmountAttempts)
                Console.WriteLine("You used up all the ettempts. You lose... Do you want to try again?");
            while (playerAttempt < this.AmountAttempts)
            {
                if (userDate == this.hiddenDate)
                {
                    Console.WriteLine("You win!");
                    break;
                }
                else if (userDate > this.hiddenDate)
                {
                    Console.WriteLine("Your date is bigger");
                    newUserDate = int.Parse(Console.ReadLine());
                    StartPlay(newUserDate);
                }
                else
                {
                    Console.WriteLine("Your date is lesser");
                    newUserDate = int.Parse(Console.ReadLine());
                    StartPlay(newUserDate);
                }
            }
        }
        public void MakeDate()
        {
            Console.WriteLine("Let's play the game! I've made the date. You won't to guess it :)");
            Random random = new ();
            this.HiddenDate = random.Next(100);
        }
    }
    class AutomaticallyModeGame
    {
        private int hiddenDate;
        private int HiddenDate
        {
            set
            {
                if ((value > 0) && (value <= 100))
                {
                    hiddenDate = value;
                }
            }
        }
        private int AmountAttempts { get; set; } = 5;
        private int userAttempt;
        public void StartPlay(int leftValue=0, int rightValue=100)
        {
            var autoDate = (leftValue + rightValue) / 2;
            Console.WriteLine($"I think... It's {autoDate}. Is it?");
            Console.ReadLine();
            userAttempt++;
            if (userAttempt == this.AmountAttempts - 1)
                Console.WriteLine("You have last try");
            if (userAttempt == this.AmountAttempts)
                Console.WriteLine("You used up all the ettempts. You lose...");
            if (userAttempt < this.AmountAttempts)
            {
                if (autoDate == this.hiddenDate)
                    Console.WriteLine("Yeah! I win!"); 
                else if (autoDate > this.hiddenDate)
                {
                    rightValue = autoDate - 1;
                    StartPlay(leftValue, rightValue);
                }
                else
                {
                    leftValue = autoDate + 1;
                    StartPlay(leftValue, rightValue);
                }
            }
        }
        public void MakeDate()
        {
            Console.WriteLine("Ok, your opponent is the Mr. Computer. Let's play! Make the date...");
            int date = int.Parse(Console.ReadLine());
            this.HiddenDate = date;
            Console.WriteLine("Press ENTER to clear console from your date");
            Console.Read();
            Console.Clear();
        }
    }
  
    class Program
    {
        static void Main(string[] args)
        {
            AutomaticallyModeGame game1 = new();
            game1.MakeDate();
            game1.StartPlay();
            Console.WriteLine("Ok, now you will guess the date. Press ENTER to clear console");
            Console.Read();
            Console.Clear();
            SecondPlayerModeGame game2 = new();
            game2.MakeDate();
        }
    }
}

using System;

namespace BlueSeaBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Challenge challenge = new Challenge();
                challenge.GetChallenge();
                Console.ReadLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace BlueSeaBattle
{
    public class Challenge
    {
        private List<string> operators;
        private Tuple<int, string> challenge;

        public Challenge()
        {
            this.operators = new List<string> { };
            this.operators.Add("+");
            this.operators.Add("-");
            this.operators.Add("*");
            this.operators.Add("/");
            this.operators.Add("%");
        }

        public Tuple<int, string> GetChallenge()
        {
            int numberOne = 0;
            int numberTwo = 0;
            int solution = 0;
            int usedOperator = getRandomNumber(this.operators.Count - 1);  //Random operator zoeken in de List
            if (this.getOperator(usedOperator) == "+" ||        // +, -, *
                this.getOperator(usedOperator) == "-" ||
                this.getOperator(usedOperator) == "*")      
            {
                numberOne = this.getRandomNumber(100);
                numberTwo = this.getRandomNumber(100);
                if (this.getOperator(usedOperator) == "+")      // + addition
                {
                    solution = numberOne + numberTwo;
                }
                if (this.getOperator(usedOperator) == "-")      // - substraction
                {
                    if (numberOne < numberTwo)
                    {
                        int tempInt = numberOne;
                        numberOne = numberTwo;
                        numberTwo = tempInt;
                    }
                    solution = numberOne - numberTwo;
                }
                if (this.getOperator(usedOperator) == "*")      // * multiplation
                {
                    numberTwo /= 5;
                    solution = numberOne * numberTwo;
                }
            }
            else if (this.getOperator(usedOperator) == "/")     // / Divide
            {
                numberOne = this.getRandomNumber(50) * 2;
                numberTwo = this.getRandomNumber(24)+1;
                while (!this.checkDividable(numberOne, numberTwo))
                {
                    numberTwo = this.getRandomNumber(24)+1;
                }
                solution = numberOne / numberTwo;
            }
            else if (this.getOperator(usedOperator) == "%")      // % modulo
            {
                numberOne = this.getRandomNumber(100);
                numberTwo = this.getRandomNumber(9)+1;
                solution = numberOne % numberTwo;
            }
            if (getRandomNumber(1) == 0)
            {
                this.challenge = new Tuple<int, string>(solution, $"{numberOne} {this.getOperator(usedOperator)} {numberTwo}");
                Console.WriteLine($"Sol:{solution} = {numberOne} {this.getOperator(usedOperator)} {numberTwo}");
            }
            else
            {
                this.challenge = new Tuple<int, string>(solution, $"{this.getOperator(usedOperator)} {numberOne} {numberTwo}");
                Console.WriteLine($"Sol:{solution} = {this.getOperator(usedOperator)} {numberOne} {numberTwo}");
            }
            return this.challenge;
        }

        private string getOperator(int operatorInt)
        {
            return this.operators[operatorInt];
        }

        private int getRandomNumber(int maxValue)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(0, maxValue + 1);
            return randomNumber;
        }

        private bool checkDividable(int valA, int valB)
        {
            if (valA % valB == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

using RPGTextBased.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGTextBased
{
    class Game
    {
        private bool end;

        public bool End
        {
            get { return this.end; }
            set { this.end = value; }
        }
        
        private Stack<State> states;

        private void InitVariables()
        {
            this.End = false;
        }

        private void InitStates()
        {
            this.states = new Stack<State>();

            this.states.Push(new State(this.states));
        }
        public Game()
        {
            this.InitVariables();
            this.InitStates();

            Console.WriteLine("Hello from the Game...!");
        }

        public void Run()
        {
            while(this.end == false)
            {
                Console.WriteLine("Write a number: ");
                int number = Convert.ToInt32(Console.ReadLine());

                if (number < 0)
                    this.end = true;
                else
                    Console.WriteLine("You entered: " + number);
            }

            Console.WriteLine("Ending game...");
        }
    }
}



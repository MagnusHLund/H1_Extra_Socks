using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Extra_Socks.Controller
{
    internal class MainController
    {
        // Char array to keep track of the user input
        private char[] input;

        View.View view = new View.View();
        Model.Characters characters = new Model.Characters();

        /// <summary>
        /// The Start() method handles the main parts of the program.
        /// It gets called from the Main method in the Program class.
        /// It catches input inside an infinite loop, which then counts the pair of socks, based of the return in the Calculation method.
        /// </summary>
        internal void Start()
        {
            view.Message("Write any combination of alphabetic characters");

            while (true)
            {
                // Reads user input and converts to char array
                input = Console.ReadLine().ToLower().ToCharArray();

                // Creates counter which keeps track of the pairs
                ushort counter = 0;

                // Goes through each character in the array in Model.Characters.characters[]
                foreach (char c in characters.characters)
                {
                    // Adds the total value of each returned ushort, from the Calculation method.
                    counter += Calculation(input, c);
                }

                // Outputs the total amount of socks
                view.Message(counter.ToString());
            }
        }

        /// <summary>
        /// The calculation method checks how many times a character occurs in the input string.
        /// The total counter gets divided with 2, because we are returning the pairs. 1 pair is 2 identical characters.
        /// Even if the counter is an odd value, its gonna return the correct number of pairs. Example: 3/2=1.5 which returns 1. '3' represents the counter value, in that example.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="lookFor"></param>
        /// <returns></returns>
        private ushort Calculation(char[] input, char lookFor)
        {
            // Counter to keep track of repeated characters
            ushort counter = 0;

            // Goes through each character that the user input
            foreach (char c in input)
            {
                // Checks if the character from the user input is the same as the character that we are looking for.
                // The "lookFor" character is from the Model.Characters.characters[], which is retrieved from line 35.
                if (c == lookFor)
                {
                    // If the character matches, then the counter goes up by 1
                    counter++;
                }
            }

            // Divdes the counter by 2, because its pairs of socks, not individual socks. The method then returns the counter value.
            counter /= 2;
            return counter;
        }
    }
}

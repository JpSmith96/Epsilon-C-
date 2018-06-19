using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epsilon_Csharp
{
    class WordDecimalConverter
    {
        int valueToReturn = 0;

        public WordDecimalConverter()
        {

        }


        public int convert(String input)
        {
            switch (input)
            {
                case "one":
                    valueToReturn = 1;
                    break;

                case "two":
                    valueToReturn = 2;
                    break;

                case "three":
                    valueToReturn = 3;
                    break;

                case "four":
                    valueToReturn = 4;
                    break;

                case "five":
                    valueToReturn = 5;
                    break;

                case "six":
                    valueToReturn = 6;
                    break;

                case "seven":
                    valueToReturn = 7;
                    break;

                case "eight":
                    valueToReturn = 8;
                    break;

                case "nine":
                    valueToReturn = 9;
                    break;

            }

            return valueToReturn;

        }


    }
}

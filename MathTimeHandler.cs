using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epsilon_Csharp
{
    class MathTimeHandler
    {

        WordDecimalConverter wdc = new WordDecimalConverter();

        public MathTimeHandler()
        {

        }

        public String CurrentTime()
        {
            String date = DateTime.Now.ToString("h:mm tt");
            return date;
        }

        public String CurrentDate()
        {
            String date = DateTime.Today.ToString("D");
            return date;
        }

        public int TimerParser(String input)
        {

            if(input.Contains("timer for"))
                input = input.Substring(input.IndexOf("for") + 4);



            input = input.IndexOf(" ") > -1
                ? input.Substring(0, input.IndexOf(" "))
                : input;


            int temp;

            bool isInt = int.TryParse(input, out temp);

            if (!(isInt))
            {
                input = input.Replace(input, wdc.convert(input).ToString());
            }



            int value = Int32.Parse(input);


            return value;

        }

        public String Calc(String input)
        {
            try
            {
                input = input.Replace("what", "");
                input = input.Replace("what's", "");
                input = input.Replace("is", "");
                input = input.Replace("plus", "+");
                input = input.Replace("add", "+");
                input = input.Replace("minus", "-");
                input = input.Replace("subtract", "-");
                input = input.Replace("ing", "");
                input = input.Replace("times", "*");
                input = input.Replace("multiply", "*");
                input = input.Replace("divide", "/");
                input = input.Replace("by", "");

                Console.WriteLine(input);

                String value = new DataTable().Compute(input, null).ToString();
                return value;
            }
            catch (Exception e)
            {
                return "Error during processing";
            }
        }
    }
}

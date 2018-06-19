using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epsilon_Csharp
{
    public class NameHandler
    {

        public NameHandler()
        {

        }

        public void ChangeName(String input)
        {
            String inputName = input.First().ToString().ToUpper() + input.Substring(1);
            File.WriteAllText("name.txt", inputName);
        }

        public String GetName()
        {
            try
            {
                string name = System.IO.File.ReadAllText("name.txt");
                return name.First().ToString().ToUpper() + name.Substring(1);
            }catch(Exception e)
            {
                return e.ToString();
            }
        }
    }



}

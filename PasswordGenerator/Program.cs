using System;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] List = { '!', '@', '#', '$', '%', '&', '*', '+', '-', '/', '^', '?' };
            int length = List.Length;
            Random rand = new();
            for (int i = 0; i < 8; i++)
            {
                //Upper
                string Password = ((char)rand.Next(65, 90)).ToString() +
                    //Lower
                    ((char)rand.Next(97, 122)).ToString() +
                    //Digit
                    ((char)rand.Next(48, 57)).ToString() +
                    //Special Char form Above List.
                    (List[rand.Next(length)]).ToString();

                //Added Static MDL_ to make it easy to memorize for general public.
                Console.WriteLine(rand.Next(11) > 5 ? $"MDL_{ StringMixer(Password)}" : $"{StringMixer(Password)}_MDL");
                Console.WriteLine();
            }
        }

        // Fisher Yates Algorithm
        static void Fisher_Yates(int[] array)
        {
            Random rnd = new();
            int arraysize = array.Length;
            int random;
            int temp;

            for (int i = 0; i < arraysize; i++)
            {
                random = i + (int)(rnd.NextDouble() * (arraysize - i));

                temp = array[random];
                array[random] = array[i];
                array[i] = temp;
            }
        }

        public static string StringMixer(string s)
        {
            string output = "";
            int arraysize = s.Length;
            int[] randomArray = new int[arraysize];

            for (int i = 0; i < arraysize; i++)
            {
                randomArray[i] = i;
            }

            Fisher_Yates(randomArray);

            for (int i = 0; i < arraysize; i++)
            {
                output += s[randomArray[i]];
            }

            return output;
        }
    }
}


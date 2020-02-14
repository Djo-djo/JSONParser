using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonText = "{" +
                "\"Number\": 7," +
                "\"Md\": 120," +
                "\"Pressure\": 39500000," +
                "\"Density\": {" +
                    "\"Liquid\": 518," +
                    "\"Gas\": 50}," +
                "\"MassFractions\": {" +
                    "\"Liquid\": [" +
                        "{\"Key\": \"6276c48e-83d9-47ec-8d69-5aa623abe950\"," +
                        "\"Value\": 0.3}" +
                        "]," +
                    "\"Gas\": [" +
                        "{\"Key\": \"16abc7fb-5bde-4619-9c36-2329fbc63923\"," +
                        "\"Value\": 0.5}]" +
                    "}" +
                "}";

            Flatter.Parse(jsonText);
            Console.WriteLine(Flatter.JsonKeys);
            Console.WriteLine();
            Console.WriteLine(Flatter.JsonValues);
        }
    }
}
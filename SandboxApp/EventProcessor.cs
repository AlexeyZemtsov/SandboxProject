//using System;
using Foundation;
using System;

namespace SandboxApp
{
    public static class EventProcessor
    {
        public static void PutOpenUrlParameters(State state, string host, IDictionary<string, string> parameters)
        {
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine($"Got url request at path {host}");

            // Iterate over URL query items
            foreach (KeyValuePair<string, string> entry in parameters)
            {
                Console.WriteLine($"Url request parameter {entry.Key} = {entry.Value}");
            }

            state.Field1 = host;
            //SandboxApp.MauiProgram
        }
    }
}


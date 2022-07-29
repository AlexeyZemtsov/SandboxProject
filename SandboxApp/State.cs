namespace SandboxApp
{
    public class State
    {
        public State()
        {
            Console.WriteLine("========= State is initialized");
            this.Field1 = "Ohohohohohoho";
        }

        public string Field1;

        public static State GetState()
        {
            var currentServices = MauiUIApplicationDelegate.Current.Services;
            return (State)currentServices.GetService(typeof(State));
        }
    }
}


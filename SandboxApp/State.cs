namespace SandboxApp
{
    public class State
    {
        public State()
        {
            FieldHost = "HostApp";
            FieldName1 = "Name1Init";
            FieldValue1 = "Value1Init";
            FieldName2 = "Name12Init";
            FieldValue2 = "Value2Init";
            FieldName3 = "Name3Init";
            FieldValue3 = "Value3Init";

            Console.WriteLine("========= State is initialized");
            this.Field1 = FieldHost;
        }

        public string Field1;
        public string FieldHost;
        public string FieldName1;
        public string FieldValue1;
        public string FieldName2;
        public string FieldValue2;
        public string FieldName3;
        public string FieldValue3;


        public static State GetState()
        {
            var currentServices = MauiUIApplicationDelegate.Current.Services;
            return (State)currentServices.GetService(typeof(State));
        }
    }
}


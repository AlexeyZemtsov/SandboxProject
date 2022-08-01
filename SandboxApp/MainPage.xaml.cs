namespace SandboxApp;

public partial class MainPage : ContentPage
{
    // for debug
    string name1 = "Name11";
    string value1 = "Value11";
    string name2 = "Name12";
    string value2 = "Value12";
    string name3 = "Name13";
    string value3 = "Value13";
    string host = "SandApp";

    public MainPage()
    {
        InitializeComponent();

        //        CalcBtn.Text = State.GetState().Field1;
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        //count++;

        //if (count == 1)
        //    CounterBtn.Text = $"Clicked {count} time";
        //else
        //    CounterBtn.Text = $"Clicked {count} times";

        //SemanticScreenReader.Announce(CounterBtn.Text);
    }
    private async void OnMapsClicked(object sender, EventArgs e)
    {
        bool supportsUri = await Launcher.Default.CanOpenAsync("maps://");

        if (supportsUri)
            await Launcher.Default.OpenAsync("maps://");

    }

    private void OnTestClicked(object sender, EventArgs e)
    {
        string Name1 = State.GetState().FieldName1;
        string Value1 = State.GetState().FieldValue1;
        string Name2 = State.GetState().FieldName2;
        string Value2 = State.GetState().FieldValue2;
        string Name3 = State.GetState().FieldName3;
        string Value3 = State.GetState().FieldValue3;

        string SummText = String.Concat(State.GetState().Field1, "  host ", State.GetState().FieldHost, " ",
            Name1, " ", Value1);
        OutputLabel.Text = SummText;

        LabelName1.Text = Name1;
        LabelValue1.Text = Value1;
        LabelName2.Text = Name2;
        LabelValue2.Text = Value2;
        LabelName3.Text = Name3;
        LabelValue3.Text = Value3;


    }

    private async void OnURLClicked(object sender, EventArgs e)
    {
        //"sandbox-app://ridetype?first=1111&second=2222"


        bool supportsUri = await Launcher.Default.CanOpenAsync("sandbox-app://");

        if (supportsUri)
        {
            string urlstring = "sandbox-app://";
            urlstring = String.Concat(urlstring, host, "?", name1, "=", value1, "&", name2, "=", value2, "&", name3, "=", value3);

            await Launcher.Default.OpenAsync(urlstring);
        }
        else
            OutputLabel.Text = $"Нет URL";

    }

    //public void UpdateCalcBtn(string newLabel)
    //{
    //    OutputLabel.Text = newLabel;
    //}

}



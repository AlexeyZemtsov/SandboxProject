namespace SandboxApp;

public partial class MainPage : ContentPage
{
    string name1 = "Name1";
    string value1 = "Value1";
    string name2 = "Name2";
    string value2 = "Value2";
    string name3 = "Name3";
    string value3 = "Value3";

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

    private void OnCalcClicked(object sender, EventArgs e)
    {
        OutputLabel.Text = State.GetState().Field1;

    }

    private async void OnURLClicked(object sender, EventArgs e)
    {
        //"sandbox-app://ridetype?first=1111&second=2222"
        string host = "ridetype";

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

    public void UpdateCalcBtn(string newLabel)
    {
        OutputLabel.Text = newLabel;
    }

    public void CompletedName1(object sender, EventArgs e)
    {
        name1 = ((Entry)sender).Text;
    }
    public void CompletedValue1(object sender, EventArgs e)
    {
        value1 = ((Entry)sender).Text;
    }
    public void CompletedName2(object sender, EventArgs e)
    {
        name2 = ((Entry)sender).Text;
    }
    public void CompletedValue2(object sender, EventArgs e)
    {
        value2 = ((Entry)sender).Text;
    }
    public void CompletedName3(object sender, EventArgs e)
    {
        name3 = ((Entry)sender).Text;
    }
    public void CompletedValue3(object sender, EventArgs e)
    {
        value3 = ((Entry)sender).Text;
    }


}



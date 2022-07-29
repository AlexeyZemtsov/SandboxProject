namespace SandboxApp;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();

        CalcBtn.Text = State.GetState().Field1;
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
    private async void OnMapsClicked(object sender, EventArgs e)
    {
        bool supportsUri = await Launcher.Default.CanOpenAsync("maps://");

        if (supportsUri)
            await Launcher.Default.OpenAsync("maps://");

    }

    private void OnCalcClicked(object sender, EventArgs e)
    {
        CalcBtn.Text = State.GetState().Field1;
    }

    private async void OnURLClicked(object sender, EventArgs e)
    {
        bool supportsUri = await Launcher.Default.CanOpenAsync("sandbox-app://");

        if (supportsUri)
            await Launcher.Default.OpenAsync("sandbox-app://ridetype?first=1111&second=2222");
        else
            CalcBtn.Text = $"Нет URL";

    }

    public void UpdateCalcBtn(string newLabel)
    {
        CalcBtn.Text = newLabel;
    }
}



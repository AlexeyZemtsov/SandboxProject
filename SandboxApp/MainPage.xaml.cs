namespace SandboxApp;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
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
}



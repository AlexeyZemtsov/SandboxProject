using Foundation;
using UIKit;

namespace SandboxApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);

        var state = State.GetState();

        System.Diagnostics.Debug.WriteLine($"========== Opened a window, {state.Field1}");

        return window;
    }
}
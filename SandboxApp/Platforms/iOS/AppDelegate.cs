using Foundation;
using UIKit;

namespace SandboxApp;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    public State State = new State();

    protected override MauiApp CreateMauiApp() =>
        MauiProgram.CreateMauiApp();
}


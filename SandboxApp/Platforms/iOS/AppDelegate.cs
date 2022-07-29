using Foundation;
using UIKit;

namespace SandboxApp;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    public State State = new State();

    protected override MauiApp CreateMauiApp() =>
        MauiProgram.CreateMauiApp();

    public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
    {

        // Parse url into components
        var components = NSUrlComponents.FromUrl(url, false);

        var host = components.Host;
        var parameters = new Dictionary<string, string>();

        // Iterate over URL query items
        foreach (NSUrlQueryItem item in components.QueryItems)
        {
            parameters.Add(item.Name, item.Value);

        }

        EventProcessor.PutOpenUrlParameters(this.State, components.Host, parameters);
        return true;
    }


}


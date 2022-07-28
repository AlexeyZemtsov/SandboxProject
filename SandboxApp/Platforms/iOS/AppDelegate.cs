using Foundation;
using UIKit;

namespace SandboxApp;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
    {
        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        Console.WriteLine(url.ToString());

        // Parse url into components
        var components = NSUrlComponents.FromUrl(url, false);
        Console.WriteLine($"Got url request at path {components.Host}");

        // Iterate over URL query items
        foreach (NSUrlQueryItem item in components.QueryItems)
        {
            Console.WriteLine($"Url request parameter {item.Name} = {item.Value}");
        }

        return true;
    }


}


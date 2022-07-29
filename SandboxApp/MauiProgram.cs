namespace SandboxApp;

using Foundation;
using Microsoft.Maui.LifecycleEvents;
using UIKit;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var state = new State();

        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .ConfigureLifecycleEvents(events =>
            {
#if IOS
                events.AddiOS(ios => ios
                    .OpenUrl(OpenUrlDelegate)
                );
#endif

                bool OpenUrlDelegate(UIApplication app, NSUrl url, NSDictionary options)
                {
                    LogEvent("OpenUrl", url.ToString());
                    return OpenUrl(app, url, options);
                }

                bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
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

                    state.Field1 = url.ToString();

                    return true;
                }

                static void LogEvent(string eventName, string type = null)
                {
                    System.Diagnostics.Debug.WriteLine($"Lifecycle event: {eventName}{(type == null ? string.Empty : $" ({type})")}");
                }
            });

        builder.Services.AddSingleton<State>(state);

        return builder.Build();
    }
}


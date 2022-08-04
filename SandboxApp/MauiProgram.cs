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
                    .OnActivated((app) => LogEvent("==================>OnActivate"))
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
                    state.FieldHost = host;

                    List<KeyValuePair<string, string>> theList = new List<KeyValuePair<string, string>>(parameters);
                    state.FieldName1 = theList[0].Key;
                    state.FieldValue1 = theList[0].Value;

                    state.FieldName2 = theList[1].Key;
                    state.FieldValue2 = theList[1].Value;
                    state.FieldName3 = theList[2].Key;
                    state.FieldValue3 = theList[2].Value;


                    //for (int i = 0; i < theList.Count; i++)
                    //{
                    //    // the key
                    //    Console.WriteLine(theList[i].Key);
                    //}


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


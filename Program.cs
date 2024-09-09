
using System.Text.RegularExpressions;

namespace NotificationChannelParser
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter the notification title: ");
            string titles = Console.ReadLine();
            Console.WriteLine(ParseNotificationChannels(titles));
            //Input1 "[BE][FE][Urgent] there is error"
            //Input2: "[BE][QA][HAHA][Urgent] there is error"

        }

        static string ParseNotificationChannels(string title)
        {

            HashSet<string> notificationChannels = new HashSet<string> { "BE", "FE", "QA", "Urgent" };

            var matches = Regex.Matches(title, @"\[(.*?)\]");

            var channels = matches.Cast<Match>()
                .Select(m => m.Groups[1].Value)
                .Where(tag => notificationChannels.Contains(tag))
                .ToHashSet();

            return channels.Any() 
                ? $"Receive channels: {string.Join(", ", channels)}" 
                : "No valid channels found.";
        }
    }
}
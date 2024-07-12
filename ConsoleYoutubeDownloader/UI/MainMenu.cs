using System;
using System.Text;

public class MainMenu {
    public void Show() {
        string border = new string('=', 40);
        string title = " Console YouTube Downloader ";

        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine(border);
        Console.WriteLine(title.PadLeft((40 + title.Length) / 2).PadRight(40));
        Console.WriteLine(border);

        while (true) {
            Console.Write("Enter YouTube URL or 'exit' to quit: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit") break; 
                DownloadService downloadService = new DownloadService();
                Task.Run(() => downloadService.DownloadVideo(input));
        }
    }
}

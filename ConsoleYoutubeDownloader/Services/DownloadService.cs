using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;
using System;
using System.IO;


public class DownloadService {
        private readonly string videosFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "videos");

        public DownloadService() {
            EnsureVideosFolderExists();
        }

        private void EnsureVideosFolderExists() {
            if (!Directory.Exists(videosFolderPath))    {
                Directory.CreateDirectory(videosFolderPath);
            }
        }

        public async Task DownloadVideo(string url) {
            YoutubeClient youtube = new YoutubeClient();

            Video video = await youtube.Videos.GetAsync(url);
            string videoName = video.Title;

            StreamManifest streamManifest = await youtube.Videos.Streams.GetManifestAsync(url);
            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
            string videoExtension = streamInfo.Container.Name;

            string fileName = Path.Combine(videosFolderPath, $"{videoName}.{videoExtension}");

            await youtube.Videos.Streams.DownloadAsync(streamInfo, fileName);
        }
}
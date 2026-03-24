using System.Collections.Concurrent;

namespace WinFormsApp4
{
    public class ScannerService
    {
        private CancellationTokenSource cts;
        private ManualResetEventSlim pauseEvent = new(true);

        private ConcurrentDictionary<string, int> wordStats = new();

        public async Task Start(List<string> forbiddenWords, string outputDir, Action<int> progress)
        {
            cts = new CancellationTokenSource();

            int processed = 0;

            await Task.Run(() =>
            {
                foreach (var drive in DriveInfo.GetDrives())
                {
                    if (!drive.IsReady)
                        continue;

                    ScanDirectory(drive.RootDirectory.FullName, forbiddenWords, outputDir, progress, ref processed);
                }
            });
        }

        private void ScanDirectory(string path, List<string> forbiddenWords, string outputDir, Action<int> progress, ref int processed)
        {
            if (cts.IsCancellationRequested)
                return;

            pauseEvent.Wait();

            try
            {
                foreach (var file in Directory.GetFiles(path))
                {
                    try
                    {
                        var result = FileProcessor.Process(file, forbiddenWords, wordStats);

                        if (result.Found)
                        {
                            var dest = Path.Combine(outputDir, Path.GetFileName(file));
                            File.Copy(file, dest, true);

                            var cleaned = Path.Combine(outputDir, "cleaned_" + Path.GetFileName(file));
                            File.WriteAllText(cleaned, result.CleanContent);
                        }
                    }
                    catch { }

                    processed++;
                    progress(processed % 100);
                }
            }
            catch { }

            try
            {
                foreach (var dir in Directory.GetDirectories(path))
                {
                    ScanDirectory(dir, forbiddenWords, outputDir, progress, ref processed);
                }
            }
            catch { }
        }

        private IEnumerable<string> GetFiles(string path)
        {
            List<string> files = new();

            try
            {
                files.AddRange(Directory.GetFiles(path));
            }
            catch { }

            try
            {
                foreach (var dir in Directory.GetDirectories(path))
                {
                    files.AddRange(GetFiles(dir));
                }
            }
            catch { }

            return files;
        }

        public void Pause() => pauseEvent.Reset();
        public void Resume() => pauseEvent.Set();
        public void Stop() => cts.Cancel();

        public Dictionary<string, int> GetTopWords()
        {
            return wordStats
                .OrderByDescending(x => x.Value)
                .Take(10)
                .ToDictionary(x => x.Key, x => x.Value);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitExample
{
    public class AsyncProcess
    {
        public string GetHtml(string url)
        {
            var webClient = new WebClient();

            return webClient.DownloadString(url);
        }

        public async Task<string> GetHtmlAsync(string url)
        {
            var webClient = new WebClient();

            return await webClient.DownloadStringTaskAsync(url);
        }

        public void RunProcess(string url)
        {
            #region Total Watch
            var watchTotal = System.Diagnostics.Stopwatch.StartNew();
            #region Sync Process
            var watchAP = System.Diagnostics.Stopwatch.StartNew();
            var res = GetHtml(url);
            Console.WriteLine(res.Substring(0, 100));
            watchAP.Stop();
            #endregion
            #region Loop
            var watchLoop = System.Diagnostics.Stopwatch.StartNew();
            for (var i = 0; i < 1000; i++)
            {
                if (i % 50 == 0)
                {
                    Console.WriteLine(i);
                }
            }
            watchLoop.Stop();
            #endregion
            watchTotal.Stop();
            #endregion
            //Final Watch result
            Console.WriteLine(string.Format("AP={0}, loop={1}, Total={2}",
                watchAP.ElapsedMilliseconds,
                watchLoop.ElapsedMilliseconds,
                watchTotal.ElapsedMilliseconds));
        }

        public async Task RunProcessAsync(string url)
        {
            #region Total Watch
            var watchTotal = System.Diagnostics.Stopwatch.StartNew();
            #region Async Process
            var watchAP = System.Diagnostics.Stopwatch.StartNew();
            var htmlTask = GetHtmlAsync(url);
            #region Loop
            var watchLoop = System.Diagnostics.Stopwatch.StartNew();
            for (var i = 0; i < 1000; i++)
            {
                if (i%50==0)
                {
                    Console.WriteLine(i);
                }
            }
            watchLoop.Stop();
            #endregion
            var res = await htmlTask;
            Console.WriteLine(res.Substring(0, 100));
            watchAP.Stop();
            #endregion
            watchTotal.Stop();
            #endregion
            //Final Watch result
            Console.WriteLine(string.Format("AP={0}, loop={1}, Total={2}",
                watchAP.ElapsedMilliseconds,
                watchLoop.ElapsedMilliseconds,
                watchTotal.ElapsedMilliseconds));
        }
    }
}

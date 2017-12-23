using Primer.Infrasctructure;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System;

namespace Primer.Controllers
{
    public class PageSizeController : ApiController, ICustomController
    {
        private static string TargetUrl = "https://www.amazon.com/";

        public async Task<long> GetPageSize(CancellationToken cToken)
        {
            WebClient wc = new WebClient();
            Stopwatch sw = Stopwatch.StartNew();
            byte[] amazonData = await wc.DownloadDataTaskAsync(TargetUrl);
            Debug.WriteLine("Elapsed ms: {0}", sw.ElapsedMilliseconds);
            return amazonData.LongLength;
        }

        public Task PostUrl(string newUrl, CancellationToken cToken)
        {
            TargetUrl = newUrl;
            return Task.FromResult<object>(null);
        }
    }
}

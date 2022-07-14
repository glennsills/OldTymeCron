using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OldTymeCron.CronJob.Worker
{
    public class TopNewsHttpClient : TopNewsClient
    {
        public TopNewsHttpClient(string baseUrl, HttpClient httpClient) : base(baseUrl, httpClient)
        {
        }
    }
}
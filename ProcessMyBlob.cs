using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public class ProcessMyBlob
    {
        [FunctionName("ProcessMyBlob")]
        public void Run(
            [BlobTrigger("azfunctiondemo/{name}", Connection = "AzureWebJobsStorage")]Stream myBlob,
            [Blob("output/{name}", FileAccess.ReadWrite, Connection = "AzureWebJobsStorage")]Stream outputBlob,
            string name, 
            ILogger log)
        {
            var len = myBlob.Length;
            myBlob.CopyTo(outputBlob);
            
        }
    }
}

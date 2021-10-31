using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TsBizcase.Api.Filters.Helpers
{
    public static class RequestBodyReader
    {
        public static async Task<T> GetBody<T>(HttpRequest request)
        {
            request.EnableBuffering();
            var stream = new StreamReader(request.Body);
            var body = await stream.ReadToEndAsync();
            var payload = JsonConvert.DeserializeObject<T>(body);
            request.Body.Position = 0;

            return payload;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Refit;

namespace Cake.BrowserStack.Services
{
    internal class JsonPart : ByteArrayPart
    {
        public JsonPart(string fileName, object value) : base(Serialize(value), fileName, "application/json")
        {
        }

        private static byte[] Serialize(object value)
        {
            var contents = JsonConvert.SerializeObject(value);
            return Encoding.UTF8.GetBytes(contents);
        }
    }
}

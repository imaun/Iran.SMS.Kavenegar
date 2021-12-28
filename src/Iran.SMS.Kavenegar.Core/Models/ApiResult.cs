using System.Collections.Generic;
using Newtonsoft.Json;
using Iran.SMS.Kavenegar.Core.Internal;

namespace Iran.SMS.Kavenegar.Core.Models {

    /// <summary>
    /// Base class to wrap common properties of API results.
    /// </summary>
    /// <typeparam name="T">Type of entiries</typeparam>
    public class ApiResult<T>  {

        public ApiResult()
            => Entries = new List<T>();

        [JsonProperty("return")]
        public ApiReturnResult Result { get; set; }
        
        [JsonProperty("entries")]
        public List<T> Entries { get; set; }

        public bool Success => Result != null ? Result.Successful : false;

        public string Message => Result != null ? Result.Message : null;

        public string StatusText => Result != null ? Result.StatusText : null;
    }

    public class ApiReturnResult {

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonIgnore]
        public string StatusText => ReturnCodes.Translate(Status);

        [JsonIgnore]
        public bool Successful => Status.EnsureSuccessCode();

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}

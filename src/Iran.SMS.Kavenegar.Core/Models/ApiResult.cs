using Newtonsoft.Json;
using Iran.SMS.Kavenegar.Core.Internal;

namespace Iran.SMS.Kavenegar.Core.Models {

    public class ApiResult<T>  {

        [JsonProperty("return")]
        public ApiReturnResult Result { get; set; }
        
        [JsonProperty("entries")]
        public T Entries { get; set; }
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

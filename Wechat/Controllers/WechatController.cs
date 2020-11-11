using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Text;
using Wechat.Models;

namespace Wechat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WechatController : ControllerBase
    {
        private readonly string Token = "huangxg666";

        private readonly ILogger<WechatController> _logger;

        public WechatController(ILogger<WechatController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get(ApiModel apiModel)
        {
            _logger.LogInformation(JsonConvert.SerializeObject(apiModel));

            string[] contents = { Token, apiModel.Signature, apiModel.Nonce};
            Array.Sort(contents);

            string content = string.Join("", contents);
            var sha1 = HmacSha1Sign(content);

            _logger.LogInformation(sha1);

            if (sha1.Equals(apiModel.Signature))
                return apiModel.EchoStr;

            return "";
        }

        [HttpPost]
        public string Post()
        {
            return "";
        }

        private string HmacSha1Sign(string str)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var hash = sha1.ComputeHash(Encoding.Default.GetBytes(str));
            string byte2String = null;
            for (int i = 0; i < hash.Length; i++)
            {
                byte2String += hash[i].ToString("x2");
            }
            return byte2String;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace speck.Web.Common.Config
{
    public class WebConfigModel
    {
        /// <summary>
        /// 站点url
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string WebDomain { get; set; }

        /// <summary>
        /// 日志存放地址
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string WebLog { get; set; }

        /// <summary>
        /// cookie加密密钥
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string EncryptionKey { get; set; }

        /// <summary>
        /// 密钥字节
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public Byte[] EncryptionKeyBytes { get; set; }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string SqlConnectString { get; set; }

        /// <summary>
        /// 加密向量
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string EncryptionIv { get; set; }

        /// <summary>
        /// 向量
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public Byte[] EncryptionIvBytes { get; set; }

    }
}

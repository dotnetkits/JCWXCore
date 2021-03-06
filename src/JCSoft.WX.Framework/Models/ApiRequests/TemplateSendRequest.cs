﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;
using JCSoft.Core.Net.Http;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    /// <summary>
    /// 发送模板消息
    /// </summary>
    public class TemplateSendRequest : ApiRequest<TemplateSendResponse>
    {
        /// <summary>
        /// 用户的openid
        /// </summary>
        [JsonProperty("touser")]
        public string ToUser { get; set; }

        /// <summary>
        /// 模板ID
        /// </summary>
        [JsonProperty("template_id")]
        public string TemplateID { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("topcolor")]
        public string TopColor { get; set; }

        /// <summary>
        /// 模板内的数据内容
        /// </summary>
        /// 举例：{{first.Data}}, Data.Add("first", new TemplateDataProperty{Value = "显示文本", Color="颜色"});
        [JsonProperty("data")]
        public Dictionary<string, TemplateDataProperty> Data { get; set; }


        internal override HttpRequestActionType Method
        {
            get { return HttpRequestActionType.Content; }
        }

        protected override string UrlFormat
        {
            get { return "/cgi-bin/message/template/send?access_token={0}"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken);
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        internal override string GetPostContent()
        {
            return JsonConvert.SerializeObject(this);
        }

        public override void Validate()
        {
            base.Validate();

            if (String.IsNullOrEmpty(this.ToUser))
            {
                throw new ArgumentNullException("touser is null");
            }

            if (string.IsNullOrEmpty(this.Url))
            {
                throw new ArgumentNullException("url is null");
            }

            if (string.IsNullOrEmpty(this.TemplateID))
            {
                throw new ArgumentNullException("templateid is null");
            }
        }
    }
}

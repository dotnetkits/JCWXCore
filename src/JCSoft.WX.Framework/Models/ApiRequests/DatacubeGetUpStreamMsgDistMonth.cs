﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    /// <summary>
    /// 获取消息发送分布月数据（getupstreammsgdistmonth）	
    /// </summary>
    public class DatacubeGetUpStreamMsgDistMonth : DatacubeGetStreamMsgRequest
    {
        protected override string UrlFormat
        {
            get { return "/datacube/getupstreammsgdistmonth?access_token={0}"; }
        }
    }
}

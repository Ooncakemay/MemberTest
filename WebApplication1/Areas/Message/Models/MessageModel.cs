using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Areas.Message.Models
{
    public class MessageModel
    {
        public string id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string CreateTime { get; set; }
        public string Title { get; set; }
    }
}


/*
 *  [id]
      ,[Name]
      ,[Content]
      ,[CreateTime]
      ,[Title]
 */

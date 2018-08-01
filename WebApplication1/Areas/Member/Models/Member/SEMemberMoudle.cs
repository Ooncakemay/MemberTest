using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication1.Areas.Member.Models.SEMember
{ 
   
    public class SEMemberMoudle
    {

        public String strContactID { get; set; }
        public String strEMail { get; set; }
        public String strName { get; set; }
        public String strMobile { get; set; }
        public String strPhone { get; set; }
        public String ysnActivate { get; set; }
        public String strMemberTypeName { get; set; }
        public String ROWID { get; set; }
        public String strCity { get; set; }
        public String dtmBirth { get; set; }
        public String strMemberID { get; set; }
    }
    public class MemberSearchModle {
        public String strContactID { get; set; }
        public String strEMail { get; set; }
        public String strName { get; set; }
        public String strMobile { get; set; }
        public String strPhone { get; set; }
        public String strCity { get; set; }

    }


}
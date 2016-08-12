﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sakinawedsjuzar.Models.CommentModel
{
    public class CommentItem
    {
        public int CommentID { get; set; }
        public int ParentCommentID { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public string ProfileImageUrl { get; set; }
    }

    public class CommentMaster
    {
        public List<CommentItem> childcomments { get; set; }
    }

    public class CommentList
    {
        public List<CommentMaster> ParentComments { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _14_02_2018_Template.Models
{
    public class Blog_Category_ViewModel
    {
        public IList<Blog> _blogs { get; set; }
        public IList<Category> _categories { get; set; }
    }
}
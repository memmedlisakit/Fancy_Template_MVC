using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _14_02_2018_Template.Models
{
    public class ViewModel
    { 
       public IList<Feature_Boxes> _boxs { get; set; }
       public IList<Blog> _blogs { get; set; }
       public Industry _industry { get; set; }
       public IList<Service_Area> _service_area { get; set; }
       public List<Service_Area_Contents> _contents { get; set; }
       public IList<Testimonials_Slider> _testimintial_slider { get; set; }
    }
}
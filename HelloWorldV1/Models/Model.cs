using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldV1.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
    }

    public class Actor
    {
        public int Id { get; set; }
        public string ActorName { get; set; }
        public string ShortBio { get; set; }
    }

    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public virtual Movie movie { get; set; }
        public virtual Actor actor { get; set; }
    }
}
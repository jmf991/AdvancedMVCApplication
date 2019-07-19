using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelloWorldV1.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title of the movie is required")]
        [MaxLength(100, ErrorMessage = "Title can't be greater than 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Release year is required")]
        [Range(1900, 2020, ErrorMessage = "Year of release should be in between 1900 and 2020")]
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
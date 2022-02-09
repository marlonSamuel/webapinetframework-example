using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBAPI.Models.dtos
{
    public class PeopleDto
    {
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
    }
}
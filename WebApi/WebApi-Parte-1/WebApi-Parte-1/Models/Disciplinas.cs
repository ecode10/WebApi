using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi_Parte_1.Models
{
    public class Disciplinas
    {

        [Key]
        public Int64 IdDisc { get; set; }

        public string NomeDisc { get; set; }
    }
}
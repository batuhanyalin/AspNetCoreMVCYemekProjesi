using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMVCYemekProjesi.Data.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [StringLength(20,ErrorMessage ="The username must be the most 20 characters.")]
        public string UserName { get; set; }
        [StringLength(20, ErrorMessage = "The password must be the most 20 characters.")]
        public string Password { get; set; }
        [StringLength(1)]
        public string AdminRole { get; set; }
    }
}

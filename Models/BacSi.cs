using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLPKDKTN.Models
{
    public class BacSi
    {
        [Key]
        public int id { get; set; }
        public string HoTen { get; set; }
        public string SDT { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        public string role { get; set; }
        [Required]
        public string Password{ get; set; }
        [NotMapped]
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string ConfirmPassword { get; set; }
        public ICollection<BenhNhan> BenhNhans { get; set; }
    }
}
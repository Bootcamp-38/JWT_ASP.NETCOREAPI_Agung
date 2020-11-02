using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_ASPNetCore_Agung.Models
{
    [Table("TB_M_UserApplication")]
    public class UserApplication
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public int ApplicationId { get; set; }
        public Application Applications { get; set; }

    }
}

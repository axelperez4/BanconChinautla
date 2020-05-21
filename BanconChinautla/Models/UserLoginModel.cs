using BanconChinautla.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BanconChinautla.Models
{
    public class UserLoginModel
    {
        [Required]
        public int Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public async Task<UserLoginModel> Validar()
        {
            var repo = new BancoRepository();
            var esValido = repo.login(this.Username, this.Password);
            if (true)
                return this; //Update IF statement when database is testeable
            else
                return null;
        }
    }
}

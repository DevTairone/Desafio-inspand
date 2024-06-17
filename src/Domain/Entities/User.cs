using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : Entity<User>
    {   
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Idade { get; set; }

        public override bool IsValid()
        {
            //throw new NotImplementedException();
            return true;
        }
    }
}

using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UserService : Service<User>, IUserService
    {
        public UserService(IUserRepository repository) : base(repository)
        {
        }
    }
}

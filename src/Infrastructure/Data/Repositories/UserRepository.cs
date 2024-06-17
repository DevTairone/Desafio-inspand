using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(SqlDbContext context) : base(context)
        {
        }
    }
}

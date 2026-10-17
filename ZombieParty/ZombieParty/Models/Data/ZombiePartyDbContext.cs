using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ZombieParty.Models.Data
{
    public class ZombiePartyDbContext: DbContext
    {
        public ZombiePartyDbContext(DbContextOptions<ZombiePartyDbContext> options) : base(options)
        {

        }


    }
}

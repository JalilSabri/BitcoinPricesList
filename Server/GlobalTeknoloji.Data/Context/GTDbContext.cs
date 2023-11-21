using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalTeknoloji.Domain.Models.Bitcoin;
using GlobalTeknoloji.Domain.Models.user;

namespace GlobalTeknoloji.Data.Context
{
    public class GTDbContext : DbContext
    {
        public GTDbContext(DbContextOptions<GTDbContext> options) : base(options)
        {

        }

        public DbSet<MarketInfo> MarketInfos { get; set; }
        public DbSet<UserInfo> userInfos { get; set; }
    }
}

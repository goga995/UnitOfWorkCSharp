using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnitOfWork.Models;

namespace UnitOfWork.Data
{
    public class AplicationDbContext : DbContext
    {
        //the dbset property will tell ef core to create table if it doesnt exist
        public virtual DbSet<User> Users { get; set; }
        
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
            : base(options) //Vraca opcije parent klase 
        {
            
        }
       
    }
}
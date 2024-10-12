using Microsoft.EntityFrameworkCore;
using ProEventos.API.Models;
using System;

namespace ProEventos.API.Data
{

    public class ApplicationContext : DbContext
    {
        public DbSet<Evento> Eventos
        {
            get;
            set;
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
    }

}
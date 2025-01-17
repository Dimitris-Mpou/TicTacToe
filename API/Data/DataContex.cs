﻿using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContex : DbContext
    {

        public DataContex(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}

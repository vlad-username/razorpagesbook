﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesBook.Models
{
    public class RazorPagesBookContext : DbContext
    {
        public RazorPagesBookContext (DbContextOptions<RazorPagesBookContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesBook.Models.Book> Book { get; set; }
    }
}

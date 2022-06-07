using System;
using System.Collections.Generic;
using System.Text;
using ChordProgressionGenerator.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChordProgressionGenerator.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Chord> Chords { get; set; }

        public DbSet<Key> Keys { get; set; }

        public DbSet<Progression> Progressions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}

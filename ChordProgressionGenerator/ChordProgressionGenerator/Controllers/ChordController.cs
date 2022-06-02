using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChordProgressionGenerator.Models;
using ChordProgressionGenerator.Data;

namespace ChordProgressionGenerator.Controllers
{
    public class ChordController : Controller
    {
        private ApplicationDbContext context;

        public ChordController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Chord> chords = context.Chords.ToList();
            return View(chords);
        }

        public IActionResult About(int id)
        {
            Chord chord = context.Chords.Find(23);
            return View();
        }
    }
}

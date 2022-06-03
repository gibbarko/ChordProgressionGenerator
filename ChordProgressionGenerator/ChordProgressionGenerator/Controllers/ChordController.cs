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

        //testing that chords show up from db
        public IActionResult Index()
        {
            List<Chord> chords = context.Chords.ToList();
            return View(chords);
        }

        //return random chord from database
        public Chord GenerateRandomChord()
        {
            Random rnd = new Random();

            int randId = rnd.Next(1, 2632);

            return context.Chords.Find(randId);
        }

        //allows user to generate random chord when they click link
        public IActionResult RandomChord()
        {
            Chord chord = GenerateRandomChord();

            return View(chord);
        }
    }
}

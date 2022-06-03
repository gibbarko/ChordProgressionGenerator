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
    public class ProgressionController : Controller
    {
        private ApplicationDbContext context;

        public ProgressionController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Chord> chords = context.Chords.ToList();
            return View(chords);
        }
    }
}

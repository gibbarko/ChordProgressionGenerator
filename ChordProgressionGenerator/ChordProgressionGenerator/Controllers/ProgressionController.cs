using System;
using System.Collections.Generic;
using System.Linq;
using ChordProgressionGenerator.Data;
using ChordProgressionGenerator.Models;
using ChordProgressionGenerator.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ChordProgressionGenerator.Controllers;
using System.Security.Claims;

namespace ChordProgressionGenerator.Controllers
{
    [Authorize]
    public class ProgressionController : Controller
    {
        private ApplicationDbContext context;

        public ProgressionController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        private List<Chord> ConvertStringToChords(string chordIds)
        {
            List<Chord> chords = new List<Chord>();
            string[] strArr = chordIds.Split(", ");

            int[] ints = Array.ConvertAll(strArr, s => int.Parse(s));

            foreach (int id in ints)
            {
                Chord chord = context.Chords.Find(id);

                chords.Add(chord);
            };

            return chords;
        }


        public IActionResult Index()
        {
            List<Progression> progressions = context.Progressions
                .Where(x => x.ApplicationUserId == this.User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();

            return View(progressions);
        }

        //create instance of TempProgressionController in order to convert chord string to list of chord objects
        public IActionResult Display(int Id)
        {
            Progression progression = context.Progressions.Find(Id);
            List<Chord> chords = ConvertStringToChords(progression.ChordString);
            return View(chords);
        }

        public IActionResult Delete(int Id)
        {
            Progression progression = context.Progressions.Find(Id);

            context.Progressions.Remove(progression);
            context.SaveChanges();

            return Redirect("Index");
        }

        public IActionResult SaveProgression(string name, TempProgression tempProgression)
        {
            Progression progression = new Progression(name)
            {
                Name = name,
                ApplicationUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier),
                RootNote = tempProgression.RootNote,
                ScaleType = tempProgression.ScaleType,
                ChordString = tempProgression.ChordString

            };

            context.Progressions.Add(progression);
            context.SaveChanges();

            return Redirect("Index");
        }
    }
}

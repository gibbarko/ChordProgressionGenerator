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
        private List<Progression> progressions;
        private List<Progression> userProgressions;

        public ProgressionController(ApplicationDbContext dbContext)
        {
            context = dbContext;
            //List<Progression> progressions = context.Progressions.ToList();
            //List<Progression> userProgressions = context.Progressions
            //    .Where(x => x.ApplicationUserId == this.User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
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
            return View(context.Progressions
                .Where(x => x.ApplicationUserId == this.User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList());
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

        [HttpGet]
        [Route("Progression/Delete")]
        public IActionResult Delete()
        {
            return View(userProgressions);
        }

        [HttpPost]
        [Route("Recipe/Delete")]
        public IActionResult Delete(int[] recipeIds)
        {
            foreach (int recipeId in recipeIds)
            {
                Progression theProgression = context.Progressions.Find(recipeId);
                context.Progressions.Remove(theProgression);
            }
            context.SaveChanges();

            return Redirect("/Progression");
        }
    }

}

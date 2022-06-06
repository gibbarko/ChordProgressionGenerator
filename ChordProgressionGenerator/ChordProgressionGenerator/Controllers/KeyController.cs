using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ChordProgressionGenerator.Data;
using ChordProgressionGenerator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ChordProgressionGenerator.Controllers
{
    public class KeyController : Controller
    {
        private ApplicationDbContext context;

        public KeyController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public string[] FindKey(string rootNote, string scaleType)
        {
            List<Key> keys = context.Keys.ToList();

            Key key = keys.Find(k => k.ROOT_NOTE == rootNote && k.SCALE_TYPE == scaleType);

            string[] notes = key.NOTES.Split(", ");

            return notes;
        }

    }
}

using EverythingWeb.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EverythingWeb.Controllers
{
    public class MusicApiController : ApiController
    {
        private MyContext context = new MyContext();

        [HttpGet]
        public IEnumerable<Musics> GetMusics()
        {
            var query = context.Musics.ToList();
            return context.Musics;
        }

        public IHttpActionResult GetMusic(Guid id)
        {
            var music = context.Musics.Find(id);
            if (music == null)
            {
                return NotFound();
            }
            return Ok(music);
        }

        public IHttpActionResult PutMusic(Guid id, Musics music)
        {
            if (ModelState.IsValid && id == music.ID)
            {
                context.Entry(music).State = System.Data.Entity.EntityState.Modified;
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return Ok(music);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        public IHttpActionResult PostMusic(Musics music)
        {
            if (ModelState.IsValid)
            {
                context.Musics.Add(music);
                context.SaveChanges();
                var uri = new Uri(
                     Url.Link("DefaultApi", new { id = music.ID })
                    );
                return Created(uri, music);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        public IHttpActionResult DeleteMusic(Guid id)
        {
            var music = context.Musics.Find(id);
            if (music == null)
            {
                return NotFound();
            }
            context.Musics.Remove(music);
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            return Ok(music);
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}

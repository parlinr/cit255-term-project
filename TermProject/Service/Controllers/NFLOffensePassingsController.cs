using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Service.Models;

namespace Service.Controllers
{
    public class NFLOffensePassingsController : ApiController
    {
        private testEntities1 db = new testEntities1();

        // GET: api/NFLOffensePassings
        public IQueryable<NFLOffensePassing> GetNFLOffensePassings()
        {
            return db.NFLOffensePassings;
        }

        // GET: api/NFLOffensePassings/5
        [ResponseType(typeof(NFLOffensePassing))]
        public IHttpActionResult GetNFLOffensePassing(int id)
        {
            NFLOffensePassing nFLOffensePassing = db.NFLOffensePassings.Find(id);
            if (nFLOffensePassing == null)
            {
                return NotFound();
            }

            return Ok(nFLOffensePassing);
        }

        // PUT: api/NFLOffensePassings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNFLOffensePassing(int id, NFLOffensePassing nFLOffensePassing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nFLOffensePassing.recordNumber)
            {
                return BadRequest();
            }

            db.Entry(nFLOffensePassing).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NFLOffensePassingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/NFLOffensePassings
        [ResponseType(typeof(NFLOffensePassing))]
        public IHttpActionResult PostNFLOffensePassing(NFLOffensePassing nFLOffensePassing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NFLOffensePassings.Add(nFLOffensePassing);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nFLOffensePassing.recordNumber }, nFLOffensePassing);
        }

        // DELETE: api/NFLOffensePassings/5
        [ResponseType(typeof(NFLOffensePassing))]
        public IHttpActionResult DeleteNFLOffensePassing(int id)
        {
            NFLOffensePassing nFLOffensePassing = db.NFLOffensePassings.Find(id);
            if (nFLOffensePassing == null)
            {
                return NotFound();
            }

            db.NFLOffensePassings.Remove(nFLOffensePassing);
            db.SaveChanges();

            return Ok(nFLOffensePassing);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NFLOffensePassingExists(int id)
        {
            return db.NFLOffensePassings.Count(e => e.recordNumber == id) > 0;
        }
    }
}
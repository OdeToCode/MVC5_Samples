using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi2.Models;
using MongoDB.Bson;

namespace WebApi2.Controllers
{

    //[EnableCors(origins:"*", headers:"*", methods:"GET")] enabled globally
    [Authorize]
    public class PatientController : ApiController
    {
        MongoCollection<Patient> _db;
        
        public PatientController()
        {
            _db  = PatientDb.Open();
        }

        // GET api/patient
        [Queryable]
        public IQueryable<Patient> Get()
        {
            return _db.AsQueryable();
        }

        public IHttpActionResult Get(string id)
        {
            var patient = _db.FindOneById(ObjectId.Parse(id));
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);                
        }
        
        [Route("api/patient/{id}/medications")]        
        public IHttpActionResult GetMedications(string id)
        {
            var patient = _db.FindOneById(ObjectId.Parse(id));
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient.Medications.ToList());
        }   
    }
}

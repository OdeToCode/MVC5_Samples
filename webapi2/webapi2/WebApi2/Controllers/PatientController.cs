using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2.Models;

namespace WebApi2.Controllers
{
    public class PatientController : ApiController
    {
        MongoRepository<Patient> _repository;
        
        public PatientController()
        {
            _repository = new MongoRepository<Patient>();
        }

        // GET api/patient
        [Queryable]
        public IQueryable<Patient> Get()
        {   
            return _repository;
        }

        public IHttpActionResult Get(string id)
        {
            var patient = _repository.FirstOrDefault(p => p.Id == id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);                
        }
        
        [Route("api/patient/{id}/medications")]
        public IHttpActionResult GetMedications(string id)
        {
            var patient = _repository.FirstOrDefault(p => p.Id == id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient.Medications.ToList());
        }   
    }
}

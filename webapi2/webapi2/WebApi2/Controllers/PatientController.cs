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
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _repository);
        }

        // GET api/patient/5
        public HttpResponseMessage Get(string id)
        {
            var patient = _repository.FirstOrDefault(p => p.Id == id);
            if (patient == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient not found!");
            }
            return Request.CreateResponse(HttpStatusCode.OK, patient);
        }       
    }
}

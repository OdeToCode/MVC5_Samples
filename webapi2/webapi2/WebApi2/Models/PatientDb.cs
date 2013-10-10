using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi2.Models
{
    public static class PatientDb
    {
        public static MongoCollection<Patient> Open()
        {
            var client = new MongoClient("mongodb://localhost/");
            var server = client.GetServer();
            var db = server.GetDatabase("PatientDb");
            return db.GetCollection<Patient>("Patients");            
        }      
    }
}
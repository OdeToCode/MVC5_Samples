using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi2.Models
{
    public class Patient : Entity
    {
        public string Name { get; set; }
        public ICollection<Ailment> Ailments { get; set; }
        public ICollection<Medication> Medications { get; set; }    
    }

    public class Medication
    {
        public string Name { get; set; }
        public int Dosage { get; set; }
    }

    public class Ailment
    {
        public string Name { get; set; }
    }
}
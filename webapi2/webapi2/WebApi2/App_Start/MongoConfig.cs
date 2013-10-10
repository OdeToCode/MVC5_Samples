using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi2.Models;

namespace WebApi2
{
    public class MongoConfig
    {
        internal static void SeedDatabase()
        {
            var repository = new MongoRepository<Patient>();
            if (!repository.Any(p => p.Name == "Scott"))
            {
                var patients = new List<Patient>()
                {
                    new Patient { Name = "Scott", 
                                  Ailments = new List<Ailment>() { new Ailment { Name="Crazy" }, new Ailment { Name="Old" }},
                                  Medications = new List<Medication> { new Medication { Name="Aspirin", Dosage = 2}}
                    },
                    new Patient { Name = "Alex", 
                                  Ailments = new List<Ailment>() { new Ailment { Name="Crazy" }, new Ailment { Name="Old" }},
                                  Medications = new List<Medication> { new Medication { Name="Aspirin", Dosage = 2}}
                    },
                    new Patient { Name = "Chris", 
                                  Ailments = new List<Ailment>() { new Ailment { Name="Crazy" }, new Ailment { Name="Old" }},
                                  Medications = new List<Medication> { new Medication { Name="Aspirin", Dosage = 2}}
                    }
                };

                repository.Add(patients);
            }
        }
    }
}
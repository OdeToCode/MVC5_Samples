using System.Data.Entity;
using CustomizedUserStore.Identity.Mongo;
using CustomizedUserStore.Models;
using Microsoft.AspNet.Identity;
using StructureMap;
namespace CustomizedUserStore.DependencyResolution {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                            x.For<DbContext>().HttpContextScoped().Use<BooksDbEf>();
                                                        
                            // x.For<IUserStore<User>>().Use<EntityFrameworkUserStore>();
                            x.For<IUserStore<User>>().Use<MongoUserStore>();

                        });
            return ObjectFactory.Container;
        }
    }
}
using PruebaCRUD.Data;
using PruebaCRUD.Models;

namespace PruebaCRUD
{
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext _dataContext)
        {
            this.dataContext = _dataContext;
        }

        public void SeedDataContext()
        {
            if (!dataContext.Users.Any())
            {
                var users = new List<User>()
                {
                    new User (){ Nombre = "Paul", Apellido = "Pérez", Dni="87654321" },
                    new User (){ Nombre = "Juan", Apellido = "Rodriguez", Dni = "83049441" },
                    new User (){ Nombre = "Elena", Apellido = "Rodriguez", Dni = "44271840" },
                    new User (){ Nombre = "Pedro", Apellido = "Perez", Dni = "97163397" },
                    new User (){ Nombre = "Carlos", Apellido = "Rodriguez", Dni = "73000429" },
                    new User (){ Nombre = "Camila", Apellido = "Perez", Dni = "49348627" },
                    new User (){ Nombre = "Luis", Apellido = "Gonzalez", Dni = "51907957" },
                    new User (){ Nombre = "Carlos", Apellido = "Perez", Dni = "83237240" }

                };
                dataContext.Users.AddRange(users);
                dataContext.SaveChanges();
            }
        }
    }
}

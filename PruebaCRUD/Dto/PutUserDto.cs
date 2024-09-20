using System.ComponentModel.DataAnnotations;

namespace PruebaCRUD.Dto
{
    public class PutUserDto
    {
        [Required]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
    }
}

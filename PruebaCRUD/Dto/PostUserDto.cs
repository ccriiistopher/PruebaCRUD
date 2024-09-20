using System.ComponentModel.DataAnnotations;

namespace PruebaCRUD.Dto
{
    public class PostUserDto
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Dni { get; set; }
    }
}

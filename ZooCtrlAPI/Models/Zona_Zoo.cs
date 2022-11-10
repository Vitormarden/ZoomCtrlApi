using System.ComponentModel.DataAnnotations;

namespace ZooCtrlAPI.Models
{
    public class Zona_Zoo
    {
        [Key]
        public int Id_Zona { get; set; }
        public string Nome { get; set; }
        public int Id_Filo { get; set; }
    }
}

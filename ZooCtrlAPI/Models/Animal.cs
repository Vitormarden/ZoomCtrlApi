using System.ComponentModel.DataAnnotations;

namespace ZooCtrlAPI.Models
{
    public class Animal
    {
        [Key]
         public int Id_Animal { get; set; } 
         public string Nome { get; set; }
         public string Especie { get; set; }
         public int Id_Filo { get; set; }

    }
}

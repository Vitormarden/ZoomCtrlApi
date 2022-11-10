using System.ComponentModel.DataAnnotations;

namespace ZooCtrlAPI.Models
{
    public class Filo
    {
        [Key]
         public int Id_Filo { get; set; }   
         public string Nome { get; set; }
         public string Descricao { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Visitante
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int VisitanteId { get; set; }
    public int VisitaId { get; set; }
    public string Nome{ get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Celular { get; set; }
}

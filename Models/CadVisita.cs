public class Visita
{
    public int VisitaId { get; set; }
    public string NomeEmpresa { get; set; }
    public string Estado { get; set; }
    public string Cidade { get; set; }
    public DateTime DataVisita { get; set; }
    public DateTime DataLimiteCadastro { get; set; }
    public int QuantidadePessoas { get; set; }
    public string Status { get; set; }
    public string? Link { get; set; }
}

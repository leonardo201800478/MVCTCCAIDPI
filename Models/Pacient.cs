namespace MVCTCCAIDPI.Models
{
    public class Pacient
    {
        public int PacientId { get; set; }
        public string Name { get; set; }
        public string cpf { get; set; }
        public string? Identidade { get; set; }
        public string? Endereco { get; set; }
        public string? DataNasc { get; set;}
        public List<Medic> Medics { get; } = new();
    }
}

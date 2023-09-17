namespace MVCTCCAIDPI.Models
{
    public class Medic
    {

        public int MedicId { get; set; }
        public string Name { get; set; }
        public string Especialidade { get; set; }
        public string Crm { get; set; }
        public string? Contato { get; set; }
        public List<Pacient> Pacients { get; } = new();
    }
}

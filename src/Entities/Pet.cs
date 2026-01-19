namespace PetShop.Entities
{

    public class Pet
    {
        public int PetId { get; set; }

        public string Paciente { get; set; } = string.Empty;

        // Ex.: "Gato" / "Cachorro"
        public string Tipo { get; set; } = string.Empty;

        public string? Raca { get; set; }

        public int? Idade { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    }
}

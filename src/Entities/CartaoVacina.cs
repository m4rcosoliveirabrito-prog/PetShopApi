namespace PetShop.Entities
{
    public class CartaoVacina
    {
        public int Id { get; set; }
        public int PetId { get; set; }

        public int VacinaId { get; set; }

        public DateTime DataAplicacao { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    }
}

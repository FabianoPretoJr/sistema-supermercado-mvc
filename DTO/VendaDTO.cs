namespace sistema_supermercado_mvc.DTO
{
    public class VendaDTO
    {
        public float total { get; set; }
        public float troco { get; set; }
        public SaidaDTO[] produtos { get; set; }
    }
}
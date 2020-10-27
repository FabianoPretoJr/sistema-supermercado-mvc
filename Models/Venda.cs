using System;

namespace sistema_supermercado_mvc.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public float Total { get; set; }
        public float ValorPago { get; set; }
        public float Troco { get; set; }
    }
}
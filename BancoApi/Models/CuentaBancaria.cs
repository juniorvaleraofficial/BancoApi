namespace BancoApi.Models
{
    public class CuentaBancaria
    {
        public int Id { get; set; }
        public string Titular { get; set; } = string.Empty;
        public string NumeroCuenta { get; set; } = string.Empty;
        public decimal Saldo { get; set; } = 0;
        public DateTime FechaCreacion { get; set; } 
    }
}

namespace Laboratory.Service
{
    public class ExamenRangoQuery
    {
        public string? IdExamen { get; set; }
        public string? StrValorMinimo { get; set; }
        public string? StrValorMaximo { get; set; }
        public decimal? ValorMinimo => (StrValorMinimo == null) ? 0 : Convert.ToDecimal(StrValorMinimo);
        public decimal? ValorMaximo => (StrValorMaximo == null) ? 0 : Convert.ToDecimal(StrValorMaximo);
    }
}

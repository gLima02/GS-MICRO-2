namespace MicroservicesDomain
{
    public class Consumo
    {
        public int Id { get; set; }
        public string? Data { get; set; }
        public double ConsumoKwh { get; set; }
        public double Custo { get; set; }
        public string? FonteEnergia { get; set; }
        public double EmissaoCO2 { get; set; }
        public string? Localizacao { get; set; }
        public string? Dispositivo { get; set; }
        public double PercentualEnergiaRenovavel { get; set; }
        public bool PicoConsumo { get; set; }
        public string? UsuarioResponsavel { get; set; }
    }
}

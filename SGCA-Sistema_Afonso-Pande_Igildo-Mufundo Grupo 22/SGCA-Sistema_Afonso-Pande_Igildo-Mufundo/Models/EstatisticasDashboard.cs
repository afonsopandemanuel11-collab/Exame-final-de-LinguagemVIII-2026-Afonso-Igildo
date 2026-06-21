namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models
{
    public class ActividadeRecente
    {
        public string Tipo { get; set; } = "";
        public DateTime Data { get; set; }
        public string Descricao { get; set; } = "";
    }

    public class EstatisticasDashboard
    {
        public int TotalCooperativistasActivos { get; set; }
        public int TotalProdutosActivos { get; set; }
        public int TotalEntregas { get; set; }
        public int EpocasAbertas { get; set; }
        public int TotalEpocas { get; set; }
        public int TotalComercializacoes { get; set; }
        public decimal TotalLucrosDistribuidos { get; set; }
        public decimal SomaQuotasActivas { get; set; }
        public int EntregasMesActual { get; set; }
        public string? EpocaActual { get; set; }
        public List<ActividadeRecente> ActividadesRecentes { get; set; } = new();
    }
}

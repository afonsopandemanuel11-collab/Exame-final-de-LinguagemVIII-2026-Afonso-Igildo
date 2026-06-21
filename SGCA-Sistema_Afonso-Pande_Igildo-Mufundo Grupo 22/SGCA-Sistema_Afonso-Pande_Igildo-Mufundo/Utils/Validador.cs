using System;
using System.Collections.Generic;
using System.Text;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Utils
{
    public static class Validador
    {
        public static bool CampoObrigatorio(string? valor) =>
            !string.IsNullOrWhiteSpace(valor);

        public static bool QuantidadeValida(string texto, out decimal valor)
        {
            if (decimal.TryParse(texto.Replace(',', '.'),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out valor))
                return valor > 0;
            return false;
        }

        public static bool PrecoValido(string texto, out decimal valor)
            => QuantidadeValida(texto, out valor);

        public static bool QuotaValida(string texto, out decimal valor)
        {
            if (decimal.TryParse(texto.Replace(',', '.'),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out valor))
                return valor > 0 && valor <= 100;
            return false;
        }

        /// <summary>Destaca o controlo a vermelho se inválido, repõe cor branca se válido.</summary>
        public static void DestacarCampo(Control ctrl, bool invalido)
        {
            ctrl.BackColor = invalido ? Color.LightCoral : Color.White;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Interfaces
{
public interface ICalculavelLucro
    {
        ///<param name = "valorApurado" > Valor total apurado pelo cooperativista(AOA).</param>
 ///<param name = "quotaPercent" > Quota de participação em percentagem(ex: 25 = 25%).</param>
   /// <returns>Valor do lucro proporcional arredondado a 2 casas decimais.</returns>
    decimal CalcularLucro(decimal valorApurado, decimal quotaPercent);
    }
}

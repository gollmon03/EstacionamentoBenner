using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.Models;

namespace Repository.DAO
{
    public class MensalistaRepository : RepositoryBase<Mensalista>
    {
        public Mensalista BuscaPorPlaca(string placa)
        {
            return Contexto.Mensalistas.Where(m => m.PlacaVeiculo == placa).FirstOrDefault();
        }
    }
}

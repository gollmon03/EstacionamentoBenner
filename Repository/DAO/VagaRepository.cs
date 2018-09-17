using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.Models;
using Estacionamento.Models.Enuns;

namespace Repository.DAO
{
    public class VagaRepository : RepositoryBase<Vaga>
    {
        public Vaga BuscarVagaLivre()
        {           
            return Contexto.Vagas.Where(v => v.Situacao == TipoSituacao.Disponivel).FirstOrDefault();            
        }
    }
}

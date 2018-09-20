using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.Models;

namespace Repository.DAO
{
    public class PessoaRepository : RepositoryBase<Pessoa>
    {
        public Pessoa BuscaPorNome(string nome)
        {
            return Contexto.Pessoas.Where(p => p.Nome == nome).FirstOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.Models;

namespace Repository.DAO
{
    public class DocumentoFinanceiroRepository : RepositoryBase<DocumentoFinanceiro>
    {
        public IList<DocumentoFinanceiro> BuscaProcessadosPorPessoa(int pessoaId)
        {
            return Contexto.DocumentosFinanceiro.Where(d =>  d.Status == "Processado" && d.PessoaId == pessoaId).ToList();
        }
    }
}

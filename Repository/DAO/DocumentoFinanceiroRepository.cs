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

        public IList<DocumentoFinanceiro> BuscaPorData(DateTime data)
        {
            return Contexto.DocumentosFinanceiro.Where(d => d.Data.Month == data.Month && d.Data.Year == data.Year).ToList();
        }

        public bool UsuarioJaTemRegistroPorMes(DateTime data, int pessoaId)
        {
            var docs = Contexto.DocumentosFinanceiro.Where(d => d.PessoaId == pessoaId && 
                                                                d.Data.Month == data.Month &&
                                                                d.Data.Year == data.Year).ToList();
            return docs.Count > 0;
        }

        public bool UsuarioNaoTemRegistroMes(DateTime data, int pessoaId)
        {
            return Contexto.DocumentosFinanceiro.Where(d => d.PessoaId == pessoaId &&
                                                            d.Data.Month == data.Month &&
                                                            d.Data.Year == data.Year).Count() > 0;
        }
    }
}

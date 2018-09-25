using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.Models;
using Repository.DAO;

namespace RegrasNegocio.Regras
{
    public class DocumentoFinanceiroRegras : RegrasBase<DocumentoFinanceiro>
    {
        DocumentoFinanceiroRepository documentofinanceirorepository;

        public DocumentoFinanceiroRegras()
        {
            documentofinanceirorepository = new DocumentoFinanceiroRepository();
        }

        public void Gerar(DateTime data, string tipo, int mensalistaId)
        {
            var documentoFinanceiro = new DocumentoFinanceiro()
            {
                Data = DateTime.Now,
                Tipo = "Contas a receber",
                DataVencimento = DateTime.Now,
                Status = "Processado",
                DataProcessamento = DateTime.Now
            };

            switch (tipo)
            {
                case "2":
                    GerarTipoVeiculo(documentoFinanceiro, data);
                    break;
                case "1":
                    GerarTipoMensalista(documentoFinanceiro, mensalistaId, data);
                    break;
            }
        }

        public IList<DocumentoFinanceiro> BuscaPorData(DateTime data)
        {
            return documentofinanceirorepository.BuscaPorData(data);
        }

        private void GerarTipoMensalista(DocumentoFinanceiro documentoFinanceiro, int mensalistaId, DateTime data)
        {
            var mensalista = new MensalistaRegras().buscarporID(mensalistaId);

            documentoFinanceiro.PessoaId = mensalista.Pessoa.Id;
            documentoFinanceiro.NumeroDocumento = data.Month.ToString() + data.Year + mensalista.Id;
            documentoFinanceiro.Valor = mensalista.ValorMensal;

            Adicionar(documentoFinanceiro);
        }

        internal IList<DocumentoFinanceiro> BuscaProcessadosPorPessoa(int pessoaId)
        {
            return documentofinanceirorepository.BuscaProcessadosPorPessoa(pessoaId);
        }

        private void GerarTipoVeiculo(DocumentoFinanceiro documentoFinanceiro, DateTime data)
        {
            documentoFinanceiro.NumeroDocumento = data.Month.ToString() + data.Year.ToString();
            documentoFinanceiro.Valor = new MovimentacaoVeiculoRegras().CalculaValorTotalVeiculos(data);
            documentoFinanceiro.PessoaId = new PessoaRegras().BuscaPorNome("Pessoa Anonima").Id;

            Adicionar(documentoFinanceiro);
        }
    }
}

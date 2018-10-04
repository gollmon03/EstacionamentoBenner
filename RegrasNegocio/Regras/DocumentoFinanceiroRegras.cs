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
            var docFinanceiro = documentofinanceirorepository.BuscaPorData(data);
            foreach (var item in docFinanceiro)
            {
                item.Pessoa = new PessoaRegras().buscarporIDSemMensalista(item.PessoaId);
            }
            return docFinanceiro;
        }

        public bool UsuarioJaTemRegistroPorMes(DateTime data, int pessoaId)
        {
            return documentofinanceirorepository.UsuarioJaTemRegistroPorMes(data, pessoaId);
        }

        private void GerarTipoMensalista(DocumentoFinanceiro documentoFinanceiro, int mensalistaId, DateTime data)
        {
            var mensalista = new MensalistaRegras().buscarporID(mensalistaId);

            var temRegistro = new MovimentacaoVeiculoRegras().UsuarioTemRegistroPorMes(data, mensalista.Id);
            if (!temRegistro)
                throw new Exception("Nenhuma movimentação deste cleinte no mês informado");

            if (UsuarioJaTemRegistroPorMes(data, mensalista.PessoaId))
                throw new Exception("Já foi gerado um documento financeiro para este mesnsalista neste mês");

            documentoFinanceiro.PessoaId = mensalista.Pessoa.Id;
            documentoFinanceiro.NumeroDocumento = data.Month.ToString() + data.Year + mensalista.Id;
            documentoFinanceiro.Valor = mensalista.ValorMensal;            

            Adicionar(documentoFinanceiro);
        }

        private bool UsuarioNaoTemRegistroMes(DateTime data, int PessoaId)
        {
            return documentofinanceirorepository.UsuarioNaoTemRegistroMes(data, PessoaId);
        }

        internal IList<DocumentoFinanceiro> BuscaProcessadosPorPessoa(int pessoaId)
        {
            return documentofinanceirorepository.BuscaProcessadosPorPessoa(pessoaId);
        }

        private void GerarTipoVeiculo(DocumentoFinanceiro documentoFinanceiro, DateTime data)
        {
            documentoFinanceiro.NumeroDocumento = data.Month.ToString() + data.Year.ToString();
            documentoFinanceiro.Valor = new MovimentacaoVeiculoRegras().CalculaValorTotalVeiculos(data);
            if (documentoFinanceiro.Valor == 0m)
                throw new Exception("Nenhuma movimentação registrada neste período");
            documentoFinanceiro.PessoaId = new PessoaRegras().BuscaPorNome("Pessoa Anonima").Id;

            Adicionar(documentoFinanceiro);
        }
    }
}

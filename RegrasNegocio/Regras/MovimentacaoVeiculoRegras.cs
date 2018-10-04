using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.Models;
using Repository.DAO;

namespace RegrasNegocio.Regras
{
    public class MovimentacaoVeiculoRegras : RegrasBase<MovimentacaoVeiculo>
    {
        MovimentacaoVeiculoRepository movimentacaoveiculorepository;
        TabelaPrecoRepository tabelaPrecoRepository;

        public MovimentacaoVeiculoRegras()
        {
            movimentacaoveiculorepository = new MovimentacaoVeiculoRepository();
            tabelaPrecoRepository = new TabelaPrecoRepository();
        }

        public override void Adicionar(MovimentacaoVeiculo entidade)
        {
            var mensalista = new MensalistaRegras().BuscaPorPlaca(entidade.PlacaVeiculo);

            if (mensalista != null)
            {
                if (new MensalistaRegras().EstaInadinplente(mensalista))
                    throw new Exception($"Mensalista {mensalista.Pessoa.Nome} está inadimplente");

                var modeloVeiculo = new ModeloVeiculoRegras().buscarporID(mensalista.ModeloVeiculoId);
                entidade.TipoVeiculoId = modeloVeiculo.TipoVeiculoId;
                entidade.PlacaVeiculo = mensalista.PlacaVeiculo;
                entidade.MensalistaId = mensalista.Id;
                entidade.ValorTotal = 0m;
                entidade.Gerado = false;
            }

            if (entidade.DataHoraEntrada == null)
                entidade.DataHoraEntrada = DateTime.Now;

            var vaga = new VagaRegras().BuscarVagaLivre();
            if (vaga == null)
                throw new Exception("Não ha vaga disponivel no momento");
            entidade.VagaId = vaga.Id;

            if (movimentacaoveiculorepository.ExisteVeiculoCadastrdo(entidade.PlacaVeiculo))
                throw new Exception("Já existe uma movimentação com este veiculo");
            entidade.UsuarioId = 3;

            base.Adicionar(entidade);
        }        

        internal decimal CalculaValorTotalVeiculos(DateTime data)
        {
            var valorTotal = 0m;
            IList<MovimentacaoVeiculo> movimentacoesSemMensalista = BuscaTodosNaoGeradosPorMes(data);
            foreach (var item in movimentacoesSemMensalista)
            {                                
                if (item.ValorTotal == 0)
                    valorTotal += item.Mensalista.ValorMensal;
                else              
                    valorTotal += item.ValorTotal;

                item.Gerado = true;
                item.Mensalista = null;
                Atualizar(item);
            }
            return valorTotal;
        }

        internal bool UsuarioTemRegistroPorMes(DateTime data, int mensalistaId)
        {
            return movimentacaoveiculorepository.UsuarioTemRegistroPorMes(data, mensalistaId);
        }

        private IList<MovimentacaoVeiculo> BuscaTodosNaoGeradosPorMes(DateTime data)
        {
            var movimentacoes = movimentacaoveiculorepository.BuscaTodosNaoGeradosPorMes(data);
            foreach (var item in movimentacoes)
            {                
                if (item.MensalistaId != null)
                    item.Mensalista = new MensalistaRegras().buscarporID(Convert.ToInt32(item.MensalistaId));
            }
            return movimentacoes;
        }

        public MovimentacaoVeiculo FinalizarMovimentacao(int id)
        {                       
            var movimentacao = movimentacaoveiculorepository.buscarporID(id);

            if (movimentacao.DataHoraSaida == null)
            {
                movimentacao.DataHoraSaida = DateTime.Now;

                if (movimentacao.MensalistaId == null)
                    movimentacao.ValorTotal = CalculaValorTotal(movimentacao);                

                movimentacaoveiculorepository.Atualizar(movimentacao);                
            }
            return movimentacao;
        }

        private decimal CalculaValorTotal(MovimentacaoVeiculo movimentacao)
        {
            var tempoEstacionado = movimentacao.DataHoraEntrada - movimentacao.DataHoraSaida;
            var tabelaPreco = tabelaPrecoRepository.BuscaPorIdTipoVeiculo(movimentacao.TipoVeiculoId);
            if (tabelaPreco == null)
                throw new Exception("Registre um preço para este tipo de veiculo");
            var totalEmHoras = tempoEstacionado.Value.TotalHours;

            return (Convert.ToDecimal(tempoEstacionado.Value.TotalHours) * tabelaPreco.ValorHora) *-1;
            
        }

        public override IList<MovimentacaoVeiculo> buscarTodos()
        {
            var movimentacoes = base.buscarTodos();
            return MontaDadosFaltando(movimentacoes);
        }

        public IList<MovimentacaoVeiculo> BuscaTodosAtivos()
        {
            var movimentacoes = movimentacaoveiculorepository.BuscaTodosAtivos();
            return MontaDadosFaltando(movimentacoes);             
        }

        private IList<MovimentacaoVeiculo> MontaDadosFaltando(IList<MovimentacaoVeiculo> movimentacoes)
        {
            foreach (var item in movimentacoes)
            {
                item.Vaga = new VagaRegras().buscarporID(item.VagaId);
                item.Vaga.Setor = new SetorRegras().buscarporID(item.Vaga.SetorId);
                if (item.MensalistaId != null)
                {
                    item.Mensalista = new MensalistaRegras().buscarporID((int)item.MensalistaId);
                    item.Mensalista.ModeloVeiculo = new ModeloVeiculoRegras().buscarporID(item.Mensalista.ModeloVeiculoId);
                }
            }
            return movimentacoes;
        }

    }
}

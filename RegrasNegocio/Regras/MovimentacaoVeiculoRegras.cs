﻿using System;
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
            }

            entidade.DataHoraEntrada = DateTime.Now;
            var vaga = new VagaRegras().BuscarVagaLivre().Id;
            if (vaga == 0)
                throw new Exception("Não ha vaga disponivel no momento");
            entidade.VagaId = vaga;
            if (movimentacaoveiculorepository.ExisteVeiculoCadastrdo(entidade.PlacaVeiculo))
                throw new Exception("Já existe uma movimentação com este veiculo");
            entidade.UsuarioId = 1;

            base.Adicionar(entidade);
        }        

        internal decimal CalculaValorTotalVeiculos(DateTime data)
        {
            var valorTotal = 0m;
            IList<MovimentacaoVeiculo> movimentacoesSemMensalista = movimentacaoveiculorepository.BuscaTodosSemMensalitaPorMes(data);
            foreach (var item in movimentacoesSemMensalista)
            {
                valorTotal += item.ValorTotal;
            }
            return valorTotal;
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

        public IList<MovimentacaoVeiculo> BuscaTodosAtivos()
        {
            var movimentacoes = movimentacaoveiculorepository.BuscaTodosAtivos();
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

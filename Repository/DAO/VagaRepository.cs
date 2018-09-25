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
            return Contexto.Vagas.SqlQuery("SELECT v.* " +
                                             "FROM Vaga v " +
                                            "WHERE v.Situacao = 0 " +
                                              "AND v.Id not in " +
                                                       "(SELECT mv.VagaId " +
                                                          "FROM MovimentacaoVeiculo mv " +
                                                         "WHERE mv.DataHoraSaida is null)").FirstOrDefault();
        }
    }
}

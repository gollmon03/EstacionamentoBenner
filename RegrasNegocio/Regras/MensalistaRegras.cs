using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.Models;
using Repository.DAO;

namespace RegrasNegocio.Regras
{
    public class MensalistaRegras : RegrasBase<Mensalista>
    {
        MensalistaRepository mensalistarepository;

        public MensalistaRegras()
        {
            mensalistarepository = new MensalistaRepository();
        }

        public Mensalista BuscaPorPlaca(string placa)
        {
            var mensalista = mensalistarepository.BuscaPorPlaca(placa);
            if (mensalista != null)
                mensalista.Pessoa = new PessoaRegras().buscarporID(mensalista.PessoaId);
            return mensalista;
        }
    }
}

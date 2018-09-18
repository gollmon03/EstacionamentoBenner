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

        public override Mensalista buscarporID(int Id)
        {
            var mensalista = base.buscarporID(Id);
            mensalista.Pessoa = new PessoaRegras().buscarporID(mensalista.PessoaId);
            return mensalista;
        }

        public Mensalista BuscaPorPlaca(string placa)
        {
            var mensalista = mensalistarepository.BuscaPorPlaca(placa);
            if (mensalista != null)
                mensalista.Pessoa = new PessoaRegras().buscarporID(mensalista.PessoaId);
            return mensalista;
        }

        public override IList<Mensalista> buscarTodos()
        {
            var mensalistas = base.buscarTodos();

            foreach (var item in mensalistas)
            {
                item.Pessoa = new PessoaRegras().buscarporID(item.PessoaId);
            }
            return mensalistas;
        }
    }
}

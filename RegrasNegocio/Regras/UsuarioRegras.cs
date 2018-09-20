using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.Models;
using Repository.DAO;

namespace RegrasNegocio.Regras
{
    public class UsuarioRegras : RegrasBase<Usuario>
    {
        UsuarioRepository usuariorepository;

        public UsuarioRegras()
        {
            usuariorepository = new UsuarioRepository();
        }

        public Usuario BuscaPorLoginESenha(string login, string senha)
        {
            return usuariorepository.BuscaPorLoginESenha(login, senha);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.Models;

namespace Repository.DAO
{
    public class UsuarioRepository : RepositoryBase<Usuario>
    {
        public Usuario BuscaPorLoginESenha(string login, string senha)
        {
            return Contexto.Usuarios.Where(u => u.Login == login && u.Senha == senha).FirstOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.Models;
using Repository.DAO;

namespace RegrasNegocio.Regras
{
    public class PessoaRegras : RegrasBase<Pessoa>
    {
        PessoaRepository pessoarepository; 

        public PessoaRegras()
        {
            pessoarepository = new PessoaRepository();
        }

        public override void Adicionar(Pessoa entidade)
        {
            if (entidade.Cpf == null)
            {
                throw new Exception("CPF invalido!");
            }
            if (entidade.Nome.Length < 5)
            {
                throw new Exception("Nome deve contar no maximo 4 caracteres");
            }
            base.Adicionar(entidade);
        }
    }
}

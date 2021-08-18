using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CategoriaDAO
    {
        public void SalvarCategoria(tb_categoria objCategoria)
        {
            banco objbanco = new banco();
            objbanco.AddTotb_categoria(objCategoria);
            objbanco.SaveChanges();
        }

        public List<tb_categoria> ConsultarCategoria(int codLogado)
        {
            banco objbanco = new banco();

            List<tb_categoria> listaCategoria = objbanco.tb_categoria.Where(cat => cat.id_usuario == codLogado).ToList();

            return listaCategoria;
        }

        public void AlterarCategoria(tb_categoria objCategoria)
        {
            banco objbanco = new banco();

            tb_categoria objResgate = objbanco.tb_categoria.Where(cat => cat.id_categoria == objCategoria.id_categoria).FirstOrDefault();

            objResgate.nome_categoria = objCategoria.nome_categoria;

            objbanco.SaveChanges();
        }

        public void ExcluirCategoria(int codCategoria)
        {
            banco objbanco = new banco();

            tb_categoria objResgate = objbanco.tb_categoria.Where(cat => cat.id_categoria == codCategoria).FirstOrDefault();

            objbanco.DeleteObject(objResgate);

            objbanco.SaveChanges();
        }
    }
}

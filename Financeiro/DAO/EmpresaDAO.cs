using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class EmpresaDAO
    {
        public void SalvarEmpresa(tb_empresa objEmpresa)
        {
            banco objbanco = new banco();
            objbanco.AddTotb_empresa(objEmpresa);
            objbanco.SaveChanges();
        }

        public List<tb_empresa> ConsultarEmpresa(int codLogado)
        {
            banco objbanco = new banco();

            List<tb_empresa> listaEmpresa = objbanco.tb_empresa.Where(emp => emp.id_usuario == codLogado).ToList();

            return listaEmpresa;
        }

        public void AlterarEmpresa(tb_empresa objEmpresa)
        {
            banco objbanco = new banco();

            tb_empresa objResgate = objbanco.tb_empresa.Where(emp => emp.id_empresa == objEmpresa.id_empresa).FirstOrDefault();

            objResgate.nome_empresa = objEmpresa.nome_empresa;
            objResgate.endereco_empresa = objEmpresa.endereco_empresa;
            objResgate.telefone_empresa = objEmpresa.telefone_empresa;

            objbanco.SaveChanges();
        }

        public void ExcluirEmpresa(int codEmpresa)
        {
            banco objbanco = new banco();

            tb_empresa objResgate = objbanco.tb_empresa.Where(emp => emp.id_empresa == codEmpresa).FirstOrDefault();

            objbanco.DeleteObject(objResgate);

            objbanco.SaveChanges();
        }
    }
}

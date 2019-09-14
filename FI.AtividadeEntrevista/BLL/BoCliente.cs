using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.BLL
{
    public class BoCliente
    {
        /// <summary>
        /// Inclui um novo cliente
        /// </summary>
        /// <param name="cliente">Objeto de cliente</param>
        public long Incluir(DML.Cliente cliente)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            return cli.Incluir(cliente);
        }

        /// <summary>
        /// Altera um cliente
        /// </summary>
        /// <param name="cliente">Objeto de cliente</param>
        public void Alterar(DML.Cliente cliente)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            cli.Alterar(cliente);
        }

        /// <summary>
        /// Consulta o cliente pelo id
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <returns></returns>
        public DML.Cliente Consultar(long id)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            return cli.Consultar(id);
        }

        /// <summary>
        /// Excluir o cliente pelo id
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <returns></returns>
        public void Excluir(long id)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            cli.Excluir(id);
        }

        /// <summary>
        /// Lista os clientes
        /// </summary>
        public List<DML.Cliente> Listar()
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            return cli.Listar();
        }

        /// <summary>
        /// Lista os clientes
        /// </summary>
        public List<DML.Cliente> Pesquisa(int iniciarEm, int quantidade, string campoOrdenacao, bool crescente, out int qtd)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            return cli.Pesquisa(iniciarEm,  quantidade, campoOrdenacao, crescente, out qtd);
        }

        /// <summary>
        /// VerificaExistencia
        /// </summary>
        /// <param name="CPF"></param>
        /// <returns></returns>
        public bool VerificarExistencia(string CPF)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            return cli.VerificarExistencia(CPF);
        }

        public bool ValidaCPF(string CPF)
        {
            string newCPF = NormalizaCPF(CPF);
            if (ValidaPrimeiroDigito(newCPF) && ValidaSegundoDigito(newCPF) && ValidaTodasPosicoes(newCPF))
                return true;
            else
                return false;
        }

        private bool ValidaPrimeiroDigito(string CPF)
        {
            int multiplicador = 10;
            int soma = 0;

            for (int x = 0; x < 9; x++)
            {
                soma += Convert.ToInt32(CPF.Substring(x, 1)) * multiplicador;
                multiplicador--;
            }

            int restoDivisao = (soma * 10) % 11;

            return restoDivisao == Convert.ToInt32(CPF.Substring(9, 1));
        }

        private bool ValidaSegundoDigito(string CPF)
        {

            int multiplicador = 11;
            int soma = 0;

            for (int x = 0; x < 10; x++)
            {
                soma += Convert.ToInt32(CPF.Substring(x, 1)) * multiplicador;
                multiplicador--;
            }

            int restoDivisao = (soma * 10) % 11;

            return restoDivisao == Convert.ToInt32(CPF.Substring(10, 1));
        }


        //Valida se todas as posições do CPF não possuem o mesmo valor
        private bool ValidaTodasPosicoes(string CPF)
        {
            int primeiraPosicao = CPF.ElementAt(0);

            for (int x = 1; x < 11; x++)
            {
                int posicaoAtual = CPF.ElementAt(x);
                if (primeiraPosicao != posicaoAtual)
                    return true;
            }
            return false;
        }

        private string NormalizaCPF(string CPF)
        {

            string newCPF = CPF.Substring(0, 3) + CPF.Substring(4, 3) + CPF.Substring(8, 3) + CPF.Substring(12, 2);

            return newCPF;
        }
    }
}

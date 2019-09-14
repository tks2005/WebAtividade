using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.BLL
{
    public class BoBeneficiario
    {
        /// <summary>
        /// Inclui um novo beneficiario
        /// </summary>
        /// <param name="beneficiario">Objeto de beneficiario</param>
        public long Incluir(DML.Beneficiario beneficiario)
        {
            DAL.DaoBeneficiarios ben = new DAL.DaoBeneficiarios();
            return ben.Incluir(beneficiario);
        }

        /// <summary>
        /// Altera um beneficiario
        /// </summary>
        /// <param name="beneficiario">Objeto de beneficiario</param>
        public void Alterar(DML.Beneficiario beneficiario)
        {
            DAL.DaoBeneficiarios ben = new DAL.DaoBeneficiarios();
            ben.Alterar(beneficiario);
        }

        /// <summary>
        /// Consulta o beneficiario pelo id
        /// </summary>
        /// <param name="id">id do beneficiario</param>
        /// <returns></returns>
        public DML.Beneficiario Consultar(long id)
        {
            DAL.DaoBeneficiarios ben = new DAL.DaoBeneficiarios();
            return ben.Consultar(id);
        }

        /// <summary>
        /// Excluir o beneficiario pelo id
        /// </summary>
        /// <param name="id">id do beneficiario</param>
        /// <returns></returns>
        public void Excluir(long id)
        {
            DAL.DaoBeneficiarios ben = new DAL.DaoBeneficiarios();
            ben.Excluir(id);
        }

        /// <summary>
        /// Lista os beneficiarios
        /// </summary>
        public List<DML.Beneficiario> Listar()
        {
            DAL.DaoBeneficiarios ben = new DAL.DaoBeneficiarios();
            return ben.Listar();
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

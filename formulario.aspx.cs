using System;
using System.Web.UI;

namespace Simulador_de_Seguros
{
    public partial class Formulario : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnCalcular_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string dataNascimento = txtDataNascimento.Text;
            string cpf = txtCpf.Text;

            string mensagem = "";
            decimal valorSeguro = 0;

            // Validação dos campos
            if (string.IsNullOrEmpty(nome))
            {
                mensagem += "Nome é obrigatório!<br />";
                errorNome.Text = "Nome é obrigatório!";
            }
            else
            {
                errorNome.Text = "";
            }

            if (string.IsNullOrEmpty(dataNascimento))
            {
                mensagem += "Data de Nascimento é obrigatória!<br />";
                errorDataNascimento.Text = "Data de Nascimento é obrigatória!";
            }
            else
            {
                errorDataNascimento.Text = "";
            }

            if (string.IsNullOrEmpty(cpf) || !ValidarCpf(cpf))
            {
                mensagem += "CPF inválido!<br />";
                errorCpf.Text = "CPF inválido!";
            }
            else
            {
                errorCpf.Text = "";
            }

            if (!string.IsNullOrEmpty(mensagem))
            {
                lblMensagem.Text = mensagem;
                return;
            }

            // Cálculo do valor do seguro
            decimal fatorSeguro = decimal.Parse(comboTipoSeguro.SelectedValue);
            valorSeguro = 1000m * fatorSeguro; // Valor base

            txtResultado.Text = $"R$ {valorSeguro:F2}";
            lblMensagem.Text = "Cálculo realizado com sucesso!";
        }

        private bool ValidarCpf(string cpf)
        {
            // Remover caracteres não numéricos
            cpf = cpf.Replace(".", "").Replace("-", "").Trim();

            // CPF deve ter 11 dígitos
            if (cpf.Length != 11 || !long.TryParse(cpf, out _))
                return false;

            // Validação dos dígitos verificadores
            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string parteDoCpf = cpf.Substring(0, 9);
            string digitoVerificador = cpf.Substring(9, 2);
            string novoCpf = parteDoCpf;

            // Primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < multiplicador1.Length; i++)
            {
                soma += int.Parse(parteDoCpf[i].ToString()) * multiplicador1[i];
            }

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            novoCpf += resto.ToString();

            // Segundo dígito verificador
            soma = 0;
            for (int i = 0; i < multiplicador2.Length; i++)
            {
                soma += int.Parse(novoCpf[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            novoCpf += resto.ToString();

            return novoCpf == cpf;
        }
    }
}


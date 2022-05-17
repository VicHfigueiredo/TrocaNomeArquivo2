using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrocaNomeArquivo.View
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            tbxEndereco.Text = string.Empty;

            try
            {
                if(folderBrowserDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    tbxEndereco.Text = folderBrowserDialog1.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta de Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void btnTrocar_Click(object sender, EventArgs e)
        {
            try
            {
                if(tbxEndereco.Text.Trim() == string.Empty)
                {
                    throw new Exception("Selecione a pasta para evetivar a troca de arquivos");
                }
                if (tbxDe.Text.Trim() == string.Empty)
                {
                    throw new Exception("Informe o valor procurado para a troca.");
                }
                System.IO.FileInfo[] arquivos = new System.IO.DirectoryInfo(tbxEndereco.Text).GetFiles();
                foreach(var arquivo in arquivos)
                {
                    string novoNome = tbxEndereco.Text + "\\" + arquivo.Name.Replace(tbxDe.Text, tbxPara.Text);
                    if (!System.IO.File.Exists(novoNome))
                    {
                        arquivo.CopyTo(novoNome);
                        arquivo.Delete();
                    }
                }
                MessageBox.Show("Troca de nome de arquivo efetuada com sucesso...","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta de erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbxDe_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


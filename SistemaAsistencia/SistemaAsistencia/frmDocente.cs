using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocios;
namespace SistemaAsistencia
{


    public partial class frmDocente : Form
    {
        private CapaNegocios.clsDocente OpcionDocente = new CapaNegocios.clsDocente();
        private CapaEntidad.clsDocente docente = new CapaEntidad.clsDocente();
        private string rutafoto="";
        
        public frmDocente()
        {
            InitializeComponent();
        }
        private void ListarDocente()
        {
            dtgbus.Rows.Clear();
            DataTable dt = new DataTable();
          
            dt = OpcionDocente.Listar(txtbus.Text);
            //recorremos el data table
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtgbus.Rows.Add(dt.Rows[i][0]);
                dtgbus.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                dtgbus.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                dtgbus.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                dtgbus.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                dtgbus.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
                dtgbus.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
                dtgbus.Rows[i].Cells[6].Value = dt.Rows[i][6].ToString();
                dtgbus.Rows[i].Cells[7].Value = dt.Rows[i][7].ToString();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            docente.DNI = txtdni.Text;
            docente.Ap_paterno = txtapep.Text;
            docente.Ap_materno = txtapem.Text;
            docente.Nombres = txtnom.Text;
            if (rbtmas.Checked == true) docente.Sexo = "M"; docente.Sexo = "F";
            docente.Correo = txtema.Text;
           
            String dni = "../../images/" + txtdni.Text + ".jpg";
            ptbfoto.Image.Save(dni, System.Drawing.Imaging.ImageFormat.Jpeg);
            docente.Ruta_foto = dni;
            docente.Estado = cbestado.Text;
            MessageBox.Show(OpcionDocente.InsertarDocente(docente), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "Foto JPG(*.JPG;*.PNG)|*.JPG;*.PNG";
            openFileDialog1.Title = "Buscar Imagen";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ptbfoto.ImageLocation = openFileDialog1.FileName;
                txtema.Text = openFileDialog1.SafeFileName;
                

            }
            openFileDialog1.Dispose();
           
        }

        private void btnelim_Click(object sender, EventArgs e)
        {
           
        }

        private void frmDocente_Load(object sender, EventArgs e)
        {
            //ptbfoto.ImageLocation = "../../images/47586493.jpg";
        }

        private void txtbus_TextChanged(object sender, EventArgs e)
        {
            ListarDocente();
        }

        private void dtgbus_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int row = dtgbus.CurrentCell.RowIndex;
            string sexo = dtgbus.Rows[row].Cells[4].Value.ToString();
            string foto = dtgbus.Rows[row].Cells[6].Value.ToString();
            string estado = dtgbus.Rows[row].Cells[7].Value.ToString();
            txtdni.Text = dtgbus.Rows[row].Cells[0].Value.ToString();
            txtapep.Text = dtgbus.Rows[row].Cells[1].Value.ToString();
            txtapem.Text = dtgbus.Rows[row].Cells[2].Value.ToString();
            txtnom.Text = dtgbus.Rows[row].Cells[3].Value.ToString();
            if (sexo == "M") rbtmas.Checked = true; rbtfem.Checked = true;
            txtema.Text = dtgbus.Rows[row].Cells[5].Value.ToString();
            ptbfoto.ImageLocation = foto;
            if (estado=="A") cbestado.SelectedIndex=0;
            if (estado == "V") cbestado.SelectedIndex = 1;
            if (estado == "") cbestado.SelectedIndex = 2;

            pnlbus.Visible = false;
            
           
            
        }

        private void dtgbus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnlbus.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pnlbus.Visible = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaAsistencia
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            panelcurso.Visible = true;
            paneldocente.Visible = false;
            panelasistencia.Visible = false;
            panelreporte.Visible = false;
        }

        private void btnreg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.panelprincipal.Controls.Count > 0)
                this.panelprincipal.Controls.RemoveAt(0);
            frmDocente docente = new frmDocente();
            docente.TopLevel = false;
            docente.FormBorderStyle = FormBorderStyle.None;
            docente.Dock = DockStyle.None;
            this.panelprincipal.Controls.Add(docente);
            this.panelprincipal.Tag = docente;
            docente.Show();
        }

        private void btndis_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.panelprincipal.Controls.Count > 0)
                this.panelprincipal.Controls.RemoveAt(0);
            frmdisponibilidad disponibilidad = new frmdisponibilidad();
            disponibilidad.TopLevel = false;
            disponibilidad.FormBorderStyle = FormBorderStyle.None;
            disponibilidad.Dock = DockStyle.Left;
            this.panelprincipal.Controls.Add(disponibilidad);
            this.panelprincipal.Tag = disponibilidad;
            disponibilidad.Show();
        }

        private void panelprincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btncar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.panelprincipal.Controls.Count > 0)
                this.panelprincipal.Controls.RemoveAt(0);
            frmCargaHoraria cargahoraria = new frmCargaHoraria();
            cargahoraria.TopLevel = false;
            cargahoraria.FormBorderStyle = FormBorderStyle.None;
            cargahoraria.Dock = DockStyle.None;
            this.panelprincipal.Controls.Add(cargahoraria);
            this.panelprincipal.Tag = cargahoraria;
            cargahoraria.Show();
        }

        private void btndocente_Click(object sender, EventArgs e)
        {
            panelcurso.Visible = false;
            paneldocente.Visible = true;
            panelasistencia.Visible = false;
            panelreporte.Visible = false;
            
        }

        private void btnasistencia_Click(object sender, EventArgs e)
        {
            panelcurso.Visible = false;
            paneldocente.Visible = false;
            panelasistencia.Visible = true;
            panelreporte.Visible = false;
        }

        private void btnreporte_Click(object sender, EventArgs e)
        {
            panelcurso.Visible = false;
            paneldocente.Visible = false;
            panelasistencia.Visible = false;
            panelreporte.Visible = true;
        }

        private void btnagrecur_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.panelprincipal.Controls.Count > 0)
                this.panelprincipal.Controls.RemoveAt(0);
            frmCurso curso = new frmCurso();
            curso.TopLevel = false;
            curso.FormBorderStyle = FormBorderStyle.None;
            curso.Dock = DockStyle.None;
            this.panelprincipal.Controls.Add(curso);
            this.panelprincipal.Tag = curso;
            curso.Show();
        }

        private void btnasigcur_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.panelprincipal.Controls.Count > 0)
                this.panelprincipal.Controls.RemoveAt(0);
            frmAsignacionCurso asignarcurso = new frmAsignacionCurso();
            asignarcurso.TopLevel = false;
            asignarcurso.FormBorderStyle = FormBorderStyle.None;
            asignarcurso.Dock = DockStyle.None ;
            this.panelprincipal.Controls.Add(asignarcurso);
            this.panelprincipal.Tag = asignarcurso;
            asignarcurso.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel19_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}

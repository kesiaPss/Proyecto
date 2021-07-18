using System;
using System.Windows.Forms;
using BL.CitasMedicas;
using System.IO;
using System.Drawing;

namespace Citas_Medicas
{
    public partial class FormCrearCitaMedica : Form
    {
        private CitasBL _citas;
        public FormCrearCitaMedica()
        {
            InitializeComponent();

            _citas = new CitasBL();
            listaPacientesBindingSource.DataSource = _citas.ObtenerCitas();
        }

        private void listaPacientesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaPacientesBindingSource.EndEdit();
            var paciente = (Paciente)listaPacientesBindingSource.Current;

            if (fotoPictureBox.Image != null)
            {
                paciente.Foto = Program.imageToByteArray(fotoPictureBox.Image);
            }
            else
            {
                paciente.Foto = null;
            }

            var resultado = _citas.GuardarPaciente(paciente);

            if (resultado.Exitoso == true)
            {
                listaPacientesBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
                MessageBox.Show("Cita Guardada");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _citas.AgregarPaciente();
            listaPacientesBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);
        }

        private void DeshabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripButtonCancelar.Visible = !valor;

        }


        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("¿Desea Eliminar esta Cita?", "Eliminar Cita", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }
            }

        }

        private void Eliminar(int id)
        {
            var resultado = _citas.EliminarPaciente(id);

            if (resultado == true)
            {
                listaPacientesBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Error al eliminar Paciente");
            }
        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBotones(true);
            Eliminar(0);
        }

        private void FormCrearCitaMedica_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var paciente = (Paciente)listaPacientesBindingSource.Current;

            if (paciente != null)
            { 
            openFileDialog1.ShowDialog();
            var archivo = openFileDialog1.FileName;

                if (archivo != "")
                {
                    var fileInfo = new FileInfo(archivo);
                    var fileStream = fileInfo.OpenRead();

                    fotoPictureBox.Image = Image.FromStream(fileStream);
                }
            }

            else
            {
                MessageBox.Show("Cree un paciente antes de asignarle una foto ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fotoPictureBox.Image = null;
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ALBERGUE_HUELLITAS_FELICES.Usuarios;

namespace ALBERGUE_HUELLITAS_FELICES
{
    public partial class CREARUSUARIOS : Form
    {
        public CREARUSUARIOS()
        {
            InitializeComponent();
        }

        private void CREARUSUARIOS_Load(object sender, EventArgs e)
        {
            if (!Sesion.Autenticado || Sesion.Rol != "Administrador")
            {
                MessageBox.Show("No tiene permiso para acceder a este módulo.", "Acceso denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            cmbRolCrearUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRolCrearUsuario.Items.Clear();
            cmbRolCrearUsuario.Items.AddRange(new object[] { "Administrador", "Empleado" });

            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            dgvCrearUsuario.AutoGenerateColumns = true;
            dgvCrearUsuario.DataSource = UsuarioDatos.ListarUsuarios();
        }

        private void btnEliminarCrearUsuario_Click(object sender, EventArgs e)
        {
            {
                if (dgvCrearUsuario.CurrentRow?.DataBoundItem is not DataRowView fila)
                {
                    MessageBox.Show("Seleccione un usuario para eliminar.");
                    return;
                }

                int id = (int)fila["id_usuario"];
                string nombre = fila["NombreCompleto"].ToString() ?? "";
                string rol = fila["Rol"].ToString() ?? "";

                if (id == Sesion.IdUsuario)
                {
                    MessageBox.Show("No puede eliminar su propia cuenta.");
                    return;
                }

                if (rol == "Administrador" && UsuarioDatos.ContarAdministradores() <= 1)
                {
                    MessageBox.Show("No se puede eliminar al único administrador del sistema.");
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    $"¿Está seguro de eliminar a {nombre}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (respuesta != DialogResult.Yes)
                    return;

                try
                {
                    UsuarioDatos.EliminarUsuario(id);
                    MessageBox.Show("Usuario eliminado correctamente.");
                    CargarUsuarios();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message + "\nPuede dejar la cuenta como Inactiva en lugar de eliminarla.",
                        "No se pudo eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrió un error al eliminar el usuario.");
                }
            }
        }


        private void btnGuardarCrearUsuario_Click(object sender, EventArgs e)
        {
            bool ok = AutenticacionUsuario.Crear(
                txtNombreCompletoCrearUsuario.Text,
                txtUsuarioCrearUsuario.Text,
                txtContrasenaCrearUsuario.Text,
                txtConfirmarCrearUsuario.Text,
                cmbRolCrearUsuario.SelectedItem?.ToString(),
                out string mensaje);

            if (ok)
            {
                MessageBox.Show(mensaje, "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarUsuarios();
            }
            else
            {
                MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LimpiarCampos()
        {
            txtNombreCompletoCrearUsuario.Clear();
            txtUsuarioCrearUsuario.Clear();
            txtContrasenaCrearUsuario.Clear();
            txtConfirmarCrearUsuario.Clear();
            cmbRolCrearUsuario.SelectedIndex = -1;
            txtNombreCompletoCrearUsuario.Focus();
        }

        private void btnDesbloquearCrearUsuario_Click_1(object sender, EventArgs e)

        {
            if (dgvCrearUsuario.CurrentRow?.DataBoundItem is not DataRowView fila)
            {
                MessageBox.Show("Seleccione un usuario de la lista.");
                return;
            }

            UsuarioDatos.Desbloquear((int)fila["id_usuario"]);
            CargarUsuarios();
        }
        private int idSeleccionado = 0;
        private string rolSeleccionado = "";

        private void dgvCrearUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvCrearUsuario.Rows[e.RowIndex].DataBoundItem is not DataRowView fila) return;

            idSeleccionado = (int)fila["id_usuario"];
            rolSeleccionado = fila["Rol"].ToString() ?? "";

            txtNombreCompletoCrearUsuario.Text = fila["NombreCompleto"].ToString();
            txtUsuarioCrearUsuario.Text = fila["Usuario"].ToString();
            cmbRolCrearUsuario.SelectedItem = rolSeleccionado;
            txtContrasenaCrearUsuario.Clear();
            txtConfirmarCrearUsuario.Clear();
        }

        private void btnEditarCrearUsuario_Click(object sender, EventArgs e)
        {
            bool ok = AutenticacionUsuario.Editar(
           idSeleccionado,
           rolSeleccionado,
           txtNombreCompletoCrearUsuario.Text,
           cmbRolCrearUsuario.SelectedItem?.ToString(),
           txtContrasenaCrearUsuario.Text,
           txtConfirmarCrearUsuario.Text,
           out string mensaje);

            if (ok)
            {
                MessageBox.Show(mensaje, "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarUsuarios();
            }
            else
            {
                MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}    

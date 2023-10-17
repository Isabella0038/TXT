using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TXT
{
    public partial class Form1 : Form
    {
        private string txtFilePath; // Ruta del archivo TXT

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            // Mostrar el cuadro de diálogo de apertura de archivo
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de texto|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath = openFileDialog.FileName;
                LoadAndDisplayTxtData();
                MessageBox.Show("Archivo de texto cargado exitosamente.");
            }
        }

        private void LoadAndDisplayTxtData()
        {
            try
            {
                // Leer todos los datos del archivo de texto y mostrarlos en un cuadro de texto
                using (StreamReader reader = new StreamReader(txtFilePath))
                {
                    string content = reader.ReadToEnd();
                    txtContent.Text = content;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar y mostrar desde el archivo de texto: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Guardar el contenido del TextBox txtContent de vuelta al archivo de texto
                using (StreamWriter writer = new StreamWriter(txtFilePath))
                {
                    writer.Write(txtContent.Text);
                }

                MessageBox.Show("Guardado en el archivo de texto.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en el archivo de texto: " + ex.Message);
            }
        }

        // Evento para el botón "Editar"
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Verificar si hay algo seleccionado en el TextBox
            if (!string.IsNullOrWhiteSpace(txtContent.SelectedText))
            {
                // Obtener el texto seleccionado
                string selectedText = txtContent.SelectedText;

                // Mostrar un cuadro de diálogo para editar el texto seleccionado
                string editedText = Microsoft.VisualBasic.Interaction.InputBox("Editar texto:", "Edición", selectedText);

                // Reemplazar el texto seleccionado con el texto editado
                txtContent.Text = txtContent.Text.Replace(selectedText, editedText);
            }
            else
            {
                MessageBox.Show("Seleccione el texto que desea editar.");
            }
        }

        // Evento para el botón "Borrar"
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Verificar si hay algo seleccionado en el TextBox
            if (!string.IsNullOrWhiteSpace(txtContent.SelectedText))
            {
                // Borrar el texto seleccionado
                txtContent.Text = txtContent.Text.Replace(txtContent.SelectedText, "");
            }
            else
            {
                MessageBox.Show("Seleccione el texto que desea borrar.");
            }
        }
    }
}

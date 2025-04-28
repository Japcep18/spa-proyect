using MaterialSkin.Controls;
using Modelos;
using ProyectoIntegrador.Utilidades.Controles;
using System.ComponentModel;
using System.Globalization;

namespace ProyectoIntegrador.Utilidades
{
    static internal class FormUtils
    {
        public static void MostrarAlertaEnMenu(string message, bool iserror = false)
        {
            if (Application.OpenForms.Count == 0)
                return;

            Form? form = Application.OpenForms[0]; // Generalmente el menu
            if (form is null)
                return;

            form.Activate();

            if (iserror)
                AlertaController.AlertaInformacion(form, message);
            else
                AlertaController.AlertaError(form, message);
        }

        public static bool InitForm(Form newForm, bool showDialog = false, bool disableResize = true)
        {
            void Form_Activated(object? sender, EventArgs e)
            {
                if (sender is Form form)
                    SesionModel.CurrentProgram = form.GetType().FullName;
            }

            if (Application.OpenForms.Count > 0)
            {
                Form mainForm = Application.OpenForms[0]!; // Tomamos el primer formulario abierto (generalmente el principal)

                if (mainForm.InvokeRequired)
                {
                    mainForm.Invoke(new Action(() => InitForm(newForm)));
                    return false;
                }
            }

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == newForm.GetType())
                {
                    // Si ya está abierto, traerlo al frente y salir del método
                    form.WindowState = FormWindowState.Normal; // Restaurarlo si estaba minimizado
                    form.TopMost = true;  // Lo pone temporalmente por encima
                    form.TopMost = false; // Lo devuelve a su estado normal
                    form.BringToFront(); // Lo trae al frente
                    form.Activate(); // Lo enfoca
                    form.Focus();

                    // Asegurar que los eventos estén registrados
                    form.Activated += Form_Activated;
                    form.Activated -= Form_Activated;

                    return false;
                }
            }

            newForm.AutoScaleMode = AutoScaleMode.Font;

            if (disableResize)
            {
                newForm.MaximizeBox = false;
                newForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                newForm.MaximumSize = newForm.Size;
                newForm.MinimumSize = newForm.Size;
            }

            newForm.KeyDown += delegate (object? sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.F10 && e.Control)
                {
                    MessageBox.Show($"{newForm.Name} | {newForm.Text}");
                }
            };

            newForm.StartPosition = FormStartPosition.CenterParent;

            newForm.Activated -= Form_Activated;
            newForm.Activated += Form_Activated;

            if (showDialog)
                newForm.ShowDialog();
            else
                newForm.Show();

            return true;
        }

        public static ItemCard RenderCard(object item, string text, string? iconname, string? subtitle)
        {
            ItemCard card = new(text, GetImageFromName($"{iconname}_64"), subtitle:subtitle??"");
            return card;
        }

        private static Image? GetImageFromName(string? iconname)
        {
            return (iconname == null) ? null : (Image?)Properties.Resources.ResourceManager.GetObject(iconname);
        }

        public static Button RenderButton(object item, string text, string? iconname, int width, Color color)
        {
            MaterialButton btn = new();
            Font fnt = new("Roboto", 10, FontStyle.Bold);
            int heigth;
            btn.BackColor = color;
            btn.Text = text;
            Graphics graphics = Graphics.FromImage(new Bitmap(100, 100));
            heigth = (int)graphics.MeasureString(btn.Text, btn.Font).Height;
            btn.Tag = item;
            if (iconname != null)
            {
                try
                {
                    Image? img = (Image?)Properties.Resources.ResourceManager.GetObject(iconname);
                    if (img != null)
                    {
                        btn.Image = img;
                        heigth = img.Height;
                        if (heigth > 96) heigth = 96;
                    }
                }
                catch (Exception)
                {
                }
            }

            btn.Height = heigth + 20;
            btn.ImageAlign = ContentAlignment.MiddleLeft;
            btn.TextAlign = ContentAlignment.MiddleRight;
            btn.Font = fnt;

            if (btn.Image != null)
            {
                float btnWidth = graphics.MeasureString(text, btn.Font, width).Width;
                if (btnWidth + btn.Image.Width + 40 /* PADDING */ > width)
                    width = (int)(btnWidth + btn.Image.Width + 40);
            }
            btn.Width = width;

            return btn;
        }

        #region Control

        public static void AcceptOnlyUIntOnKeyPress(ref object sender, ref KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        public static void AcceptOnlyDecimalOnKeyPress(object? sender, KeyPressEventArgs e)
        {
            if(sender is not BaseTextBox textBox) {
                e.Handled = true;
                return;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                return;
            }

            // only allow one decimal point
            if ((e.KeyChar.ToString() == CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator) &&
                (textBox.Text.IndexOf(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator) > -1))
            {
                e.Handled = true;
            }
        }

        #endregion

        #region ComboBox
        public static void SelectItemInComboBox<T>(ComboBox comboBox, T itemToSelect, Func<T, bool> comparer) // (var2) => var1.codigo == var2.codigo
        {
            if (comboBox == null || itemToSelect == null || comparer == null)
                throw new ArgumentNullException("Argumento nulo");
            
            if(itemToSelect == null)
            {
                comboBox.SelectedItem = null;
                return;
            }

            foreach (var item in comboBox.Items)
            {
                if (item.GetType() == typeof(T))
                {
                    T currentItem = (T)item;
                    if (comparer(currentItem))
                    {
                        comboBox.SelectedItem = currentItem;
                        comboBox.Invalidate();
                        return;
                    }
                }
            }
        }
        #endregion

        #region Manipulacion de datos
        public static T? DataRowToObject<T>(DataGridViewRow? dataRow)
        {
            if (dataRow == null) return default;
            T? item = (T?)Activator.CreateInstance(typeof(T));
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T?));

            foreach (DataGridViewColumn columns in dataRow.DataGridView.Columns)
            {
                props[columns.Name]!.SetValue(item, dataRow.Cells[columns.Name].Value);
            }

            return item;
        }

        #endregion

        #region Errores
        public static void AddError(ErrorProvider errorProvider, Control control, string error, bool displayToast = true)
        {
            control.Select();
            errorProvider.SetError(control, error);
            if (displayToast)
            {
                Form? parent = control.FindForm();
                if (parent != null)
                {
                    ToastController.MostrarError(parent, error);
                }
            }
        }
        #endregion

        internal static void SetTextBoxChangeFocusOnEnter(Control mainControl)
        {
            foreach (Control item in mainControl.Controls.Cast<Control>().Prepend(mainControl))
            {
                if (item is BaseTextBox ctrlTextBox)
                {
                    addKeyPress(ctrlTextBox);
                }
                else if (item is MaterialTextBox matTextBox)
                {
                    addKeyPress(matTextBox);
                }
            }

            void addKeyPress(Control ctrlTextBox)
            {
                ctrlTextBox.KeyPress += delegate (object? sender, KeyPressEventArgs e)
                {
                    if (Convert.ToChar(Keys.Enter) == e.KeyChar)
                    {
                        e.Handled = true;
                        mainControl.SelectNextControl(ctrlTextBox, true, true, true, true);
                    }
                };
            }
        }
    }
}

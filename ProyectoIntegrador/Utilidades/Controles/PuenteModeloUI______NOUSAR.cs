using Modelos.Servicios;
using Modelos.Tipos;
using Presentacion.Support;
using System.Data;
namespace ProyectoIntegrador.Utilidades.Controles
{
    public class PuenteModeloUI<T> where T : class, new()
    {
        private bool codigoTouched = false;
        private bool bloquearCodigoLuegoDeBuscar = true;
        private IModeloSimple<T> modelo;
        // Textbox para el codigo
        private TextBoxBase? CodigoTextBox;
        // TextBox para la descripcion
        private TextBoxBase? DescripcionTextBox;
        // Boton para buscar
        private ButtonBase? ButtonBuscar;

        public event EventHandler<ValorProgreso>? ProgresoCarga;

        public bool Editar { get; set; }
        public bool BloquearCodigoLuegoDeBuscar { get => bloquearCodigoLuegoDeBuscar; set => bloquearCodigoLuegoDeBuscar = value; }


        //public event EventHandler<string> ValorCambio;

        public IModeloSimple<T> Modelo { get => modelo; set => modelo = value; }

        public PuenteModeloUI(IModeloSimple<T> modelo)
        {
            this.modelo = modelo;
        }

        public void SetBotonBuscar(ButtonBase button)
        {
            if (button.InvokeRequired)
            {
                button.Invoke(delegate
                {
                    this.ButtonBuscar = button;
                    this.ButtonBuscar.Enabled = true;
                });
            }
            else
            {
                this.ButtonBuscar = button;
                this.ButtonBuscar.Enabled = true;
            }

            this.ButtonBuscar!.MouseUp += delegate
            {
                if (!this.ButtonBuscar.Enabled)
                    return;

                this.ButtonBuscar.Enabled = false;
                Task.Run(() =>
                {
                    // -----------------------------------------------------
                    this.ProgresoCarga?.Invoke(this, new()
                    {
                        Labelstatus = "Cargando datos",
                        ValorActual = 20,
                        ValorMax = 100
                    });
                    // -----------------------------------------------------
                    var msg = modelo.CargarDatos();
                    if (!msg.State)
                    {
                        this.ButtonBuscar.Invoke(() =>
                        {
                            AlertaController.AlertaError(this.ButtonBuscar.FindForm()!, msg.Msg);
                            this.ButtonBuscar.Enabled = true;
                        });
                        this.ProgresoCarga?.Invoke(this, new()
                        {
                            Labelstatus = "Error al cargar los datos",
                            ValorActual = 100,
                            ValorMax = 100,
                        });
                        return;
                    }
                    this.ButtonBuscar.FindForm()!.Invoke(() =>
                        {
                            Consulta consulta = new Consulta(DataManager.ToDataTable(msg.Entity ?? []));
                            this.ProgresoCarga?.Invoke(this, new()
                            {
                                Labelstatus = "Eligiendo registro",
                                ValorActual = 50,
                                ValorMax = 100
                            });
                            consulta.ShowDialog();
                            DataRow? selectedRow = consulta.GetSelectedRow();
                            if (selectedRow != null)
                            {
                                T? selectedObject = DataManager.DataRowToObject<T>(selectedRow);
                                this.modelo.CargarDatos(selectedObject);
                                if (selectedObject != null)
                                {
                                    if (this.BloquearCodigoLuegoDeBuscar)
                                    {
                                        this.codigoTouched = true;
                                        if (this.ButtonBuscar.InvokeRequired)
                                        {
                                            this.ButtonBuscar.Invoke(() =>
                                            {
                                                if (this.CodigoTextBox != null)
                                                    this.CodigoTextBox.Enabled = false;
                                            });
                                        }
                                        else
                                        {
                                            if (this.CodigoTextBox != null)
                                                this.CodigoTextBox.Enabled = false;
                                        }
                                    }
                                }
                            }
                        });

                    void tempAction()
                    {
                        this.ButtonBuscar.Enabled = true;
                    }

                    Task.Delay(400).ContinueWith((tsk) =>
                    {
                        if (this.ButtonBuscar.InvokeRequired)
                            this.ButtonBuscar.Invoke(tempAction);
                        else
                            tempAction();
                    });
                });
                //.ContinueWith((s) => {
                //    this.ProgresoCarga?.Invoke(this, new()
                //    {
                //        Labelstatus = null,
                //        ValorActual = 0,
                //        ValorMax = 100,
                //    });
                //});
            };
        }

        public void SetTextBoxDescripcion(TextBoxBase textBox)
        {
            this.DescripcionTextBox = textBox;
        }

        public void SetTextBoxCodigo(TextBoxBase textBox)
        {
            Action settxtbox = () =>
            {
                this.CodigoTextBox = textBox;
                this.CodigoTextBox.Enabled = true;

                this.codigoTouched = false;
            };
            if (textBox.InvokeRequired)
            {
                textBox.Invoke(settxtbox);
            }
            else
            {
                settxtbox();
            }

            /// Conectar el modelo con el puente
            this.Modelo.CambioModelo += delegate
            {
                this.CodigoTextBox.Invoke(() =>
                {
                    this.CodigoTextBox.Text = this.Modelo.Codigo;
                    if (this.DescripcionTextBox != null)
                    {
                        this.DescripcionTextBox.Text = this.Modelo.Descripcion;
                    }
                    else
                    {
                        if (this.Editar)
                        {
                            // Colocar aquí lógica para agregar el siguiente código
                            SecuenciaManager.ObtenerSiguiente(this.Modelo.TableName);
                            // ====================================================
                        }
                    }
                });
            };

            // ================================================
            // Buscar los datos
            // Cuando se deja el Txtbox del codigo
            this.CodigoTextBox.Leave += delegate
            {
                if (this.BloquearCodigoLuegoDeBuscar)
                {
                    if (this.codigoTouched)
                        return;
                }

                var obj = this.Modelo.Obtener(this.CodigoTextBox.Text);
                this.Modelo.CargarDatos(obj);

                if (obj != null)
                {
                    this.codigoTouched = true;
                    if (this.BloquearCodigoLuegoDeBuscar)
                    {
                        this.CodigoTextBox.Enabled = false;
                    }
                }
                this.codigoTouched = true;
            };

            // Cuando se presiona enter
            this.CodigoTextBox.KeyPress += delegate (object? sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    if (this.BloquearCodigoLuegoDeBuscar)
                    {
                        if (this.codigoTouched)
                            return;
                        this.codigoTouched = true;
                        this.CodigoTextBox.Enabled = false;
                    }

                    var obj = this.Modelo.Obtener(this.CodigoTextBox.Text);
                    this.Modelo.CargarDatos(obj);
                }
            };
        }

    }

    public class ValorProgreso
    {
        public string? Labelstatus { get; set; }
        public int ValorMax { get; set; }
        public int ValorActual { get; set; }
    }

    // QUIZA NI SE USE
    public enum EstadoProgreso
    {
        INACTIVO,
        PROCESANDO,
        COMPLETADO,
    }
}

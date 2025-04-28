using Modelos;
using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using Presentacion.Support;
using System.Data;
namespace ProyectoIntegrador.Utilidades.Controles
{
    public class PuenteModeloUI<T> where T : DBObject, new()
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
                    Form parent = this.ButtonBuscar.FindForm()!;
                    if(parent.InvokeRequired)
                    {
                        parent.Invoke(() =>
                        {
                            ActualizarProgreso(Mensajes.Msj_Aviso_EligiendoRegistro, 50);
                        });
                    }
                    else
                        ActualizarProgreso(Mensajes.Msj_Aviso_EligiendoRegistro, 50);
                    // -----------------------------------------------------

                    var msg = modelo.CargarDatos();
                    if (!msg.State)
                    {
                        this.ButtonBuscar.Invoke(() =>
                        {
                            AlertaController.AlertaError(parent!, msg.Msg);
                            this.ButtonBuscar.Enabled = true;
                        });
                        if (parent.InvokeRequired)
                        {
                            parent.Invoke(() =>
                            {
                                ActualizarProgreso(Mensajes.Msj_Error_CargarDatos, 100);
                            });
                        }
                        else
                            ActualizarProgreso(Mensajes.Msj_Error_CargarDatos, 100);
                        return;
                    }

                    void consultarDatos(EntityMessage<IEnumerable<T>> msg)
                    {
                        Consulta consulta;
                        bool fromConsultable = false;
                        // --------------------------------------- Consultable -----------------------------------------
                        if (this.Modelo is IConsultableModel<T> consultable)
                        {
                            DataTable data = consultable.GetDataTable();
                            consulta = new Consulta(data);
                            fromConsultable = true;
                        }
                        // ------------------------------------------------------------------------------------
                        else
                        {
                            consulta = new Consulta(DataManager.ToDataTable(msg.Entity ?? []));
                        }

                        this.ProgresoCarga?.Invoke(this, new()
                        {
                            Labelstatus = Mensajes.Msj_Aviso_EligiendoRegistro,
                            ValorActual = 50,
                            ValorMax = 100
                        });
                        consulta.ShowDialog();
                        DataRow? selectedRow = consulta.GetSelectedRow();
                        if (selectedRow != null)
                        {
                            T? selectedObject;
                            // ------------------------------------------------------------------------------------
                            if (fromConsultable)
                                selectedObject = ((IConsultableModel<T>)this.Modelo).RetrieveData(selectedRow);
                            // ------------------------------------------------------------------------------------
                            else
                                selectedObject = DataManager.DataRowToObject<T>(selectedRow); 

                            this.modelo.CargarDatos(selectedObject);
                            if (selectedObject != null)
                            {
                                if (this.DescripcionTextBox != null)
                                {
                                    Action updateDescTextBox = () => this.DescripcionTextBox.Text = this.Modelo.Descripcion;
                                    if (this.DescripcionTextBox.InvokeRequired)
                                        this.DescripcionTextBox.Invoke(updateDescTextBox);
                                    else
                                        updateDescTextBox();
                                }   
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
                            var parentForm = this.ButtonBuscar.FindForm();
                            if(parentForm != null)
                            {
                                parentForm.Activate();
                            }
                        }
                    }
                    
                    if(parent.InvokeRequired)
                    {
                        parent.Invoke(() =>
                        {
                            consultarDatos(msg);
                        });
                    }
                    else
                        consultarDatos(msg);

                    void tempAction()
                    {
                        this.ButtonBuscar.Enabled = true;
                        this.CodigoTextBox?.Focus();
                    }

                    Task.Delay(150).ContinueWith((tsk) =>
                    {
                        if (this.ButtonBuscar.InvokeRequired)
                            this.ButtonBuscar.Invoke(tempAction);
                        else
                            tempAction();
                    });
                });
            };
        }

        private void ActualizarProgreso(string labelstatus, int actual, int max = 100)
        {
            this.ProgresoCarga?.Invoke(this, new()
            {
                Labelstatus = labelstatus,
                ValorActual = actual,
                ValorMax = max
            });
        }

        public void SetTextBoxDescripcion(TextBoxBase textBox)
        {
            this.DescripcionTextBox = textBox;
        }

        public void SetTextBoxCodigo(TextBoxBase textBox)
        {
            // Asigna el textbox
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
                Action method = () =>
                                {
                                    this.CodigoTextBox.Text = this.Modelo.Codigo;
                                    if (this.DescripcionTextBox != null)
                                    {
                                        this.DescripcionTextBox.Text = this.Modelo.Descripcion;
                                    }
                                    else
                                    {
                                        ColocarSecuencia();
                                    }
                                };
                if(this.CodigoTextBox.InvokeRequired)
                {
                    this.CodigoTextBox.Invoke(method);
                } else
                {
                    method();
                }
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

                Form parent = this.CodigoTextBox.FindForm()!;
                if (parent.InvokeRequired)
                    parent.Invoke(() => this.ActualizarProgreso(Mensajes.Msj_Aviso_EligiendoRegistro, 50));
                else
                    this.ActualizarProgreso(Mensajes.Msj_Aviso_EligiendoRegistro, 50);

                var obj = this.Modelo.Obtener(CodigoTextBox.Text);
                this.Modelo.CargarDatos(obj); 

                string newstatus = "Registro no encontrado";
                if (obj != null)
                {
                    newstatus = "Registro encontrado";
                    this.codigoTouched = true;
                    if (this.BloquearCodigoLuegoDeBuscar)
                    {
                        this.CodigoTextBox.Enabled = false;
                    }
                }
                else
                {
                    this.ColocarSecuencia();
                }
                if (parent.InvokeRequired)
                    parent.Invoke(() => this.ActualizarProgreso(newstatus, 100));
                else
                    this.ActualizarProgreso(newstatus, 100);
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
                    if(obj is null) {
                        this.ColocarSecuencia();
                    } 
                    else
                    {
                        this.Modelo.CargarDatos(obj);
                    }
                }
            };

            this.ColocarSecuencia();
        }

        private void ColocarSecuencia()
        {
            if (this.CodigoTextBox is null)
                return;

            if (!this.Editar)
                return;

            var del = delegate ()
            {
                // Colocar aquí lógica para agregar el siguiente código
                this.CodigoTextBox.Text = (SecuenciaManager.ObtenerSiguiente(this.Modelo.TableName).Entity ?? 0).ToString();
                // ====================================================
            };

            if (this.CodigoTextBox.InvokeRequired)
            {
                this.CodigoTextBox.Invoke(del);
            }
            else
                del();
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

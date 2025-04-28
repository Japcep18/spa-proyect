using MaterialSkin.Controls;
using System.Text;

namespace ProyectoIntegrador
{
    public partial class Prueba : MaterialForm
    {
        public Prueba()
        {
            InitializeComponent();
        }

        private void materialListBox1_SelectedIndexChanged(object sender, MaterialSkin.MaterialListBoxItem selectedItem)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            MaterialDialog materialDialog = new MaterialDialog(this, "Dialog Title", "Dialogs inform users about a task and can contain critical information, require decisions, or involve multiple tasks.", "OK", true, "Cancel");
            DialogResult result = materialDialog.ShowDialog(this);

            MaterialSnackBar SnackBarMessage = new MaterialSnackBar(result.ToString(), 750);
            SnackBarMessage.Show(this);
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            var builder = new StringBuilder("Batch operation report:\n\n");
            var random = new Random();
            var result = 0;

            for (int i = 0; i < 200; i++)
            {
                result = random.Next(1000);

                if (result < 950)
                {
                    builder.AppendFormat(" - Task {0}: Operation completed sucessfully.\n", i);
                }
                else
                {
                    builder.AppendFormat(" - Task {0}: Operation failed! A very very very very very very very very very very very very serious error has occured during this sub-operation. The errorcode is: {1}).\n", i, result);
                }
            }

            var batchOperationResults = builder.ToString();
            //batchOperationResults = "Simple text";
            var mresult = MaterialMessageBox.Show(batchOperationResults, "Batch Operation", MessageBoxButtons.YesNoCancel, FlexibleMaterialForm.ButtonsPosition.Center);
            materialComboBox1.Items.Add("this is a very long string");
        }
    }
}

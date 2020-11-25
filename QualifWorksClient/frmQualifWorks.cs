using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QualifWorksClient
{
    public partial class frmQualifWorks : Form
    {
        public frmQualifWorks()
        {
            InitializeComponent();
        }

        private void dgvSupervisors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdateSupervisors_Click(object sender, EventArgs e)
        {
            UpdateSupervisors("Vai tiešām saglabāt veiktās izmaiņas?");
        }

        private DialogResult UpdateSupervisors(string message)
        {
            DialogResult result = MessageBox.Show(message
                , "Darbu vadītāju datu saglabāšana"
                , MessageBoxButtons.YesNoCancel
                , MessageBoxIcon.Question);
            if (DialogResult.Yes == result)
            {
                // atceras tekošā raksta pozīciju
                int index = bsSupervisors.Position;
                taSupervisors.Update(dsDataModel.Supervisors);
                taSupervisors.Fill(dsDataModel.Supervisors);
                // atjauno tekošā raksta pozīciju
                bsSupervisors.Position = index;
            }

            return result;
        }

        private void btnCancelSupervisors_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show(
                "Vai tiešām atcelt veiktās izmaiņas?"
                , "Darbu vadītāju datu saglabāšana", MessageBoxButtons.YesNo
                , MessageBoxIcon.Question))
            {
                dsDataModel.Supervisors.RejectChanges();
            }
        }

        private void tbcQualifWorks_Leave(object sender, EventArgs e)
        {

        }

        private void dgvSupervisors_Leave(object sender, EventArgs e)
        {

        }

        private void tbpSupervisors_Leave(object sender, EventArgs e)
        {
            if (dsDataModel.HasChanges())
                UpdateSupervisors("Ir nesaglabāti labojumi darbu vadītāju datos."
                                  + " Vai saglabāt izmaiņas datu bāzē?");
        }

        private void frmQualifWorks_Leave(object sender, EventArgs e)
        {
            taSupervisors.Fill(dsDataModel.Supervisors);
            Application.Idle += delegate (object sender1, EventArgs e1)
            {
                // pogas Saglabāt un Atcelt iespējo tikai tad, ja datu kopā
                // ir veiktas izmaiņas
                btnUpdateSupervisors.Enabled = dsDataModel.HasChanges();
                btnCancelSupervisors.Enabled = btnUpdateSupervisors.Enabled;
            };
        }

        private void frmQualifWorks_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dsDataModel.HasChanges())
                if (DialogResult.Cancel == UpdateSupervisors("Ir nesaglabāti"
                                                             + " labojumi darbu vadītāju datos."
                                                             + " Vai saglabāt izmaiņas datu bāzē?"))
                    e.Cancel = true;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

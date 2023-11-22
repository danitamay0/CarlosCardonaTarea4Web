using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GestorActasEscaneadasCarlosCardona;

namespace CarlosCardonaWeb
{
    public partial class _Default : Page
    {

        private ScannedFile scannedFile;
        private ScannedFileQuery query;

        protected void Page_Load(object sender, EventArgs e)
        {
            scannedFile = new ScannedFile();
            query = new ScannedFileQuery();

            if (!IsPostBack)
            {
                query.gridScannedFiles(grid_scanned_files);
            }
        }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime fecha = Convert.ToDateTime(grid_scanned_files.SelectedRow.Cells[2].Text);
            dateInput1.Text = fecha.ToString("yyyy-MM-dd");
            place.Text = grid_scanned_files.SelectedRow.Cells[3].Text;
            chairman_meeting.Text = grid_scanned_files.SelectedRow.Cells[4].Text;
            resume.Text = grid_scanned_files.SelectedRow.Cells[5].Text;

            updateBtn.Visible = true;


        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {

            if (query.addScannedFile(dateInput1.Text, place.Text, chairman_meeting.Text , resume.Text))
            {
                query.gridScannedFiles(grid_scanned_files);
                dateInput1.Text = "";
                place.Text = "";
                chairman_meeting.Text = "";
                resume.Text = "";
            }
        }

        protected void grid_scanned_files_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (query.removeScannedFile(Convert.ToInt32(e.Keys["id"])))
            {
                query.gridScannedFiles(grid_scanned_files);
                dateInput1.Text = "";
                place.Text = "";
                chairman_meeting.Text = "";
                resume.Text = "";
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            if (query.editScannedFile( Convert.ToInt32(grid_scanned_files.SelectedValue), dateInput1.Text, place.Text, chairman_meeting.Text, resume.Text))
            {
                query.gridScannedFiles(grid_scanned_files);
                dateInput1.Text = "";
                place.Text = "";
                chairman_meeting.Text = "";
                resume.Text = "";
            }
        }
    }
}
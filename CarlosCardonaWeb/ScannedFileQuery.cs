using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using CarlosCardonaWeb;
using MySql.Data.MySqlClient;

namespace GestorActasEscaneadasCarlosCardona
{
    internal class ScannedFileQuery
    {
        private UnadDB conexionMysql;
        private List<ScannedFile> scannedFiles;

        public ScannedFileQuery()
        {
            conexionMysql = new UnadDB();
            scannedFiles = new List<ScannedFile>();
        }

        public bool addScannedFile(string date, string place, string chairman_meeting, string resume)
        {

            string query = "INSERT INTO scanned_files (date, place, chairman_meeting, resume)" +
                "values (@date, @place, @chairman_meeting, @resume)";

            MySqlCommand mCommand = new MySqlCommand(query, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@date", date));
            mCommand.Parameters.Add(new MySqlParameter("@place", place));
            mCommand.Parameters.Add(new MySqlParameter("@chairman_meeting", chairman_meeting));
            mCommand.Parameters.Add(new MySqlParameter("@resume", resume));

            return mCommand.ExecuteNonQuery() > 0;

        }

        public DataTable getSannedFiles(string filter)

        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM scanned_files";
               if (filter != "")
                {
                    query += " WHERE " +
                        "id LIKE '%" + filter + "%' OR " +
                        "place LIKE '%" + filter + "%' OR " +
                        "resume LIKE '%" + filter + "%' OR " +
                        "chairman_meeting LIKE '%" + filter + "%' ";

                }
                query = string.Format(query);
                MySqlDataAdapter queryAdapter = new MySqlDataAdapter(query, conexionMysql.GetConnection());
                queryAdapter.Fill(dt);
                conexionMysql.CloseConnection();
                return dt;
        }

        public void gridScannedFiles(GridView grid)
        {
            grid.DataSource = getSannedFiles("");
            grid.DataBind();
        }

        internal bool editScannedFile(int id, string date, string place, string chairman_meeting, string resume)
        {
            string query = "UPDATE scanned_files " +
                "SET date=@date, " +
                "place=@place, " +
                "chairman_meeting=@chairman_meeting, " +
                "resume= @resume " +
                "WHERE id=@id";

            MySqlCommand mCommand = new MySqlCommand(query, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@date", date));
            mCommand.Parameters.Add(new MySqlParameter("@place", place));
            mCommand.Parameters.Add(new MySqlParameter("@chairman_meeting", chairman_meeting));
            mCommand.Parameters.Add(new MySqlParameter("@resume", resume));
            mCommand.Parameters.Add(new MySqlParameter("@id", id));

            return mCommand.ExecuteNonQuery() > 0;

        }

        internal bool removeScannedFile(int id)
        {
            string query = "DELETE FROM scanned_files " +
                "WHERE id=@id";

            MySqlCommand mCommand = new MySqlCommand(query, conexionMysql.GetConnection());
            mCommand.Parameters.Add(new MySqlParameter("@id", id));

            return mCommand.ExecuteNonQuery() > 0;
        }
    }
}

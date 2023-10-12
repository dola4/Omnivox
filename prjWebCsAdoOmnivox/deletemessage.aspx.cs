using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace prjWebCsAdoOmnivox
{
    public partial class deletemessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/omnivoxDB_432.accdb");
            OleDbConnection mycon = new OleDbConnection(conString);
            mycon.Open();

            // Recuperer le refmessage envoye par le lien Effacer de la page accueil.aspx
            int refMsg = Convert.ToInt32(Request.QueryString["refm"]);

            
            // effacer le message 
           string sql = "DELETE FROM Messages WHERE RefMessage=" + refMsg;
           OleDbCommand mycmd = new OleDbCommand(sql, mycon);
            mycmd.ExecuteNonQuery();

            mycon.Close();
            Response.Redirect("accueil.aspx");
        }
    }
}
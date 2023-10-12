using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace prjWebCsAdoOmnivox
{
    public partial class ecriremessage : System.Web.UI.Page
    {
        static OleDbConnection mycon;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack == false)
            {
                string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/omnivoxDB_432.accdb");
                mycon = new OleDbConnection(conString);
            mycon.Open();

            string sql = "SELECT RefMembre, Numero, Nom FROM Membres";

            OleDbCommand mycmd = new OleDbCommand(sql, mycon);
            OleDbDataReader myRder = mycmd.ExecuteReader();
            while (myRder.Read())
            {
                ListItem el = new ListItem();
                el.Text = myRder["Nom"].ToString() + " (" +
                    myRder["Numero"].ToString() + ")";
                el.Value = myRder["RefMembre"].ToString();
                cboDestinataire.Items.Add(el);
            }
            myRder.Close();
            mycon.Close();
            }
        }

        protected void btnEnvoyer_Click(object sender, EventArgs e)
        {
            mycon.Open();
            Int32 refMbDestin = Convert.ToInt32(cboDestinataire.SelectedItem.Value);
            string titre = txtTitre.Text.Trim();
            string msg = txtMessage.Text.Trim();
            //msg = msg.Replace("'", "\''");
            //titre = titre.Replace("'", "\''");
            Int32 refM = Convert.ToInt32(Session["RefMb"]);
            string sql = "INSERT INTO Messages(Titre,Message,Destinataire,Envoyeur)";
            sql += " VALUES(@tit,@msg,@refDest,@refM)" ;
            OleDbCommand mycmd = new OleDbCommand(sql, mycon);
            mycmd.Parameters.AddWithValue("tit", titre);
            mycmd.Parameters.AddWithValue("msg", msg);
            mycmd.Parameters.AddWithValue("refDest", refMbDestin);
            mycmd.Parameters.AddWithValue("refM", refM);
            mycmd.ExecuteNonQuery();
            mycon.Close();
            Response.Redirect("accueil.aspx");


        }
    }
}
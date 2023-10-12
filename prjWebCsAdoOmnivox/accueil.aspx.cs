using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Drawing;

namespace prjWebCsAdoOmnivox
{
    public partial class accueil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            string nom="";
            int refm =Convert.ToInt32(Session["RefMb"].ToString());
            string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/omnivoxDB_432.accdb");
            OleDbConnection mycon = new OleDbConnection(conString);
            mycon.Open();
            string sql = "SELECT Nom FROM Membres WHERE RefMembre = " + refm;
            OleDbCommand mycmd = new OleDbCommand(sql, mycon);
            OleDbDataReader myRder = mycmd.ExecuteReader();
                if (myRder.Read())
                { 
                nom = myRder["Nom"].ToString();
                }






                // Recuperer les messages recus du membre
                sql = "SELECT Messages.Titre, Messages.Nouveau, Membres.Nom, Messages.RefMessage FROM " +
                    "Membres, Messages WHERE Membres.RefMembre = Messages.Envoyeur " +
                    "AND Messages.Destinataire = " + refm;
                
                myRder.Close();
                mycmd = new OleDbCommand(sql, mycon);
                myRder = mycmd.ExecuteReader();
                Int32 nbmsg = 0;
                while (myRder.Read())
                {
                    nbmsg ++; // pour compter le nombre de messages

                    TableRow myrow = new TableRow();// creation ligne
                    myrow.BackColor = Color.WhiteSmoke;
                    TableCell mycel = new TableCell(); // creation cellule 1
                    mycel.Text = myRder["Titre"].ToString();
                    myrow.Cells.Add(mycel);
                    
                    mycel = new TableCell(); // creation cellule 1
                    mycel.Text = myRder["Nom"].ToString();
                    myrow.Cells.Add(mycel);

                    int refMsg = Convert.ToInt32(myRder["RefMessage"].ToString());

                    mycel = new TableCell(); // creation cellule 1
                    mycel.Text = "<a href='liremessage.aspx?refm=" + refMsg + "'> Lire </a>   <a href = 'deletemessage.aspx?refm=" + refMsg + "' > Effacer </ a > ";
                    myrow.Cells.Add(mycel);

                    // changer la couleur de la ligne si le message est nouveau
                    if (myRder["Nouveau"].ToString() == "True")
                    {
                        myrow.BackColor = Color.Gold;
                    }

                    tabMessages.Rows.Add(myrow);
                }

                lblInfo.Text = "Bienvenue " + nom + ", Vous avez " + nbmsg; 
                   


                mycon.Close();

            }
            

        }

        protected void btnMessage_Click(object sender, EventArgs e)
        {
            Server.Transfer("ecriremessage.aspx");
        }
    }
}
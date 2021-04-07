using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OraiMunka20210407
{
    public partial class Form1 : Form
    {
        private List<Auto> autokLista = new List<Auto>();
        private DataTable raktarTable;
        

        public Form1()
        {
            InitializeComponent();


            raktarTable = new DataTable();
            TablaSema();
            Adatok();
            adatFeltoltes();

            //megjelenités
            dataGridView1.DataSource = raktarTable;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void adatFeltoltes() {
           
            foreach (Auto auto in autokLista)
            {
                DataRow dr = raktarTable.NewRow();
 
                dr["Név"] = auto.Nev;
                dr["Gyárto"] = auto.Gyarto;
                dr["Szín"] = auto.Szin;
                raktarTable.Rows.Add(dr);


            }
        }
        private void TablaSema() {
            DataColumn autoIdColumn = new DataColumn("autoId", typeof(int));
            autoIdColumn.Caption = "Autó ID";
            autoIdColumn.ReadOnly = true;
            autoIdColumn.AllowDBNull = false;
            autoIdColumn.Unique = true;
            autoIdColumn.AutoIncrement = true;
            autoIdColumn.AutoIncrementSeed = 0;
            autoIdColumn.AutoIncrementStep = 1;

            DataColumn autoGyartoColumn = new DataColumn("Gyárto", typeof(string));
            DataColumn autoSzinColumn = new DataColumn("Szín", typeof(string));
            DataColumn autoNevColumn = new DataColumn("Név", typeof(string));
            autoNevColumn.Caption = "Autó neve";
            //DataColumn nevColumn = new DataColumn("Név", typeof(string));

            //DataColumn gyartoColumn = new DataColumn("Gyárto", typeof(string));

            //DataColumn szinColumn = new DataColumn("Szín", typeof(string));

            raktarTable.Columns.AddRange(new DataColumn[]{

            autoIdColumn, autoGyartoColumn, autoSzinColumn, autoNevColumn
            });
        }

        private void Adatok() {
            autokLista.Add(new Auto("Krisztián", "BMW", "lila"));
            autokLista.Add(new Auto("Barnabás", "VW", "kék"));
            autokLista.Add(new Auto("Dániel", "Porsche", "zöld"));
            autokLista.Add(new Auto("Attila", "Subaru", "Piros"));
        }
        private void btnTorol_Click(object sender, EventArgs e)
          
        {
            try
            {
                raktarTable.Rows[int.Parse(txtTorol.Text)].Delete();
                raktarTable.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Adatok();
        }
    }
}

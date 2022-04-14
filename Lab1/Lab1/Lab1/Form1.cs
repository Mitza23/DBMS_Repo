using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlDataAdapter daAthletes, daParticipations;
        DataSet ds;
        SqlCommandBuilder cb;
        BindingSource bsAthletes, bsParticipations;

        private void button1_Click(object sender, EventArgs e)
        {
            daParticipations.Update(ds, "Participations");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection("Server=MITZAS-DELL;Database=Laborator_1;User ID=mitza;Password=test;");
            ds = new DataSet();
            daAthletes = new SqlDataAdapter("select * from Athletes", connection);
            daParticipations = new SqlDataAdapter("select * from Participations", connection);

            cb = new SqlCommandBuilder(daParticipations);

            daParticipations.Fill(ds, "Participations");
            daAthletes.Fill(ds, "Athletes");

            DataRelation dr = new DataRelation("FK_Participation_Athlete",
                ds.Tables["Athletes"].Columns["athlete_id"],
                ds.Tables["Participations"].Columns["athlete_id"]);
            ds.Relations.Add(dr);

            bsAthletes = new BindingSource();
            bsAthletes.DataSource = ds;
            bsAthletes.DataMember = "Athletes";

            bsParticipations = new BindingSource();
            bsParticipations.DataSource = bsAthletes;
            bsParticipations.DataMember = "FK_Participation_Athlete";

            GridAthlete.DataSource = bsAthletes;
            GridParticipations.DataSource = bsParticipations;
        }

        private void GridAthlete_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            daParticipations.Update(ds, "Participations");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection("Server=MITZAS-DELL;Database=Laborator_1;User ID=mitza;Password=test;");
            ds = new DataSet();
            daAthletes = new SqlDataAdapter("select * from Athletes", connection);
            daParticipations = new SqlDataAdapter("select * from Participations", connection);

            cb = new SqlCommandBuilder(daParticipations);

            daParticipations.Fill(ds, "Participations");
            daAthletes.Fill(ds, "Athletes");

            DataRelation dr = new DataRelation("FK_Participation_Athlete",
                ds.Tables["Athletes"].Columns["athlete_id"],
                ds.Tables["Participations"].Columns["athlete_id"]);
            ds.Relations.Add(dr);

            bsAthletes = new BindingSource();
            bsAthletes.DataSource = ds;
            bsAthletes.DataMember = "Athletes";

            bsParticipations = new BindingSource();
            bsParticipations.DataSource = bsAthletes;
            bsParticipations.DataMember = "FK_Participation_Athlete";

            GridAthlete.DataSource = bsAthletes;
            GridParticipations.DataSource = bsParticipations;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

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
using System.Configuration;
using System.Collections.Specialized;

namespace Lab2
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;
        SqlDataAdapter sqlDataAdapter;
        SqlDataAdapter sqlDataAdapter1;
        DataSet dataSet;
        DataSet dataSet1;
        BindingSource bindingSource;
        BindingSource bindingSource1;

        public Form1()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(ConfigurationManager.AppSettings.Get("data_connection"));
            sqlDataAdapter = new SqlDataAdapter(ConfigurationManager.AppSettings.Get("selectAllParent"), sqlConnection);
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, ConfigurationManager.AppSettings.Get("parentTable"));
            bindingSource = new BindingSource();

            dataGridView1.DataSource = dataSet.Tables[ConfigurationManager.AppSettings.Get("parentTable")];
            bindingSource.DataSource = dataSet.Tables[ConfigurationManager.AppSettings.Get("parentTable")];

            //textBox1.DataBindings.Add("Text", bindingSource, "FirstName");

            bindingSource.MoveNext();
            dataGridView1.ClearSelection();
            dataGridView1.Rows[bindingSource.Position].Selected = true;
        }


        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string trainerID = this.dataGridView1.SelectedRows[0].Cells[ConfigurationManager.AppSettings.Get("parentAttribute1")].Value.ToString();
            Console.WriteLine(trainerID);
            dataSet1 = new DataSet();
            sqlDataAdapter1 = new SqlDataAdapter(ConfigurationManager.AppSettings.Get("selectChildSpecific") + trainerID, sqlConnection);
            bindingSource1 = new BindingSource();
            sqlDataAdapter1.Fill(dataSet1, ConfigurationManager.AppSettings.Get("childTable"));

            dataGridView2.DataSource = dataSet1.Tables[ConfigurationManager.AppSettings.Get("childTable")];
            bindingSource1.DataSource = dataSet1.Tables[ConfigurationManager.AppSettings.Get("childTable")];

            bindingSource1.MoveNext();
            dataGridView2.ClearSelection();
            dataGridView2.Rows[bindingSource1.Position].Selected = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TO DO: try catch error!!!
            //int mealID = Int32.Parse(this.Meal_ID_text.Text.ToString());
            string attr1 = this.textBox1.Text.ToString();
            int attrFk = Int32.Parse(this.textBox2.Text.ToString());
            dataSet1 = new DataSet();
            sqlDataAdapter1 = new SqlDataAdapter(ConfigurationManager.AppSettings.Get("addChild") 
                //+ mealID.ToString()
                + " '"
                + attr1 + "', "
                + attrFk.ToString() + ")", sqlConnection);
            sqlDataAdapter1.Fill(dataSet1, ConfigurationManager.AppSettings.Get("childTable"));

            dataGridView2.DataSource = dataSet1.Tables[ConfigurationManager.AppSettings.Get("childTable")];
            bindingSource1.DataSource = dataSet1.Tables[ConfigurationManager.AppSettings.Get("childTable")];

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int attrId = Int32.Parse(this.dataGridView2.SelectedRows[0].Cells[ConfigurationManager.AppSettings.Get("childAttribute1")].Value.ToString());

            dataSet1 = new DataSet();
            sqlDataAdapter1 = new SqlDataAdapter(ConfigurationManager.AppSettings.Get("deleteChild") + attrId, sqlConnection);
            sqlDataAdapter1.Fill(dataSet1, ConfigurationManager.AppSettings.Get("childTable"));

            dataGridView2.DataSource = dataSet1.Tables[ConfigurationManager.AppSettings.Get("childTable")];
            bindingSource1.DataSource = dataSet1.Tables[ConfigurationManager.AppSettings.Get("childTable")];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //TO DO: try catch error!!!
            string attrId = this.attrId_text.Text.ToString();
            string attr1 = this.textBox1.Text.ToString();
            string attrFk = this.textBox2.Text.ToString();

            dataSet1 = new DataSet();
            sqlDataAdapter1 = new SqlDataAdapter(ConfigurationManager.AppSettings.Get("updateChild_1") + attr1 +
                ConfigurationManager.AppSettings.Get("updateChild_2") + attrFk + ConfigurationManager.AppSettings.Get("updateChild_3") + attrId, sqlConnection);

            sqlDataAdapter1.Fill(dataSet1, ConfigurationManager.AppSettings.Get("childTable"));

            dataGridView2.DataSource = dataSet1.Tables[ConfigurationManager.AppSettings.Get("childTable")];
            bindingSource1.DataSource = dataSet1.Tables[ConfigurationManager.AppSettings.Get("childTable")];

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

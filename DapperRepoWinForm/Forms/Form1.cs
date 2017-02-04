using System.Windows.Forms;
using DapperRepoWinForm.Bll;
using DapperRepoWinForm.ClassObjects;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace DapperRepoWinForm.Forms
{
    public partial class Form1 : Form
    {
        ClassObjects.users _user = new ClassObjects.users();
        Bll.users _metod = new Bll.users();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {

        }

        #region buttoms
        
        private void btnNew_Click(object sender, System.EventArgs e)
        {
            cleanform();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            _user.id = textBox1.Text;
            _user.name = textBox2.Text;
            _user.address = textBox3.Text;
            _user.status = textBox4.Text;
            string msg = _metod.insertUpdate(_user);
            if (msg == "0")
            {
                MessageBox.Show("Record added");
                cleanform();
            }
            else
            {
                MessageBox.Show(msg);
            }

        }

        private void btnClear_Click(object sender, System.EventArgs e)
        {
            cleanform();
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            _user.id = textBox1.Text;
            string msg = _metod.delete(_user);
            if (msg == "0")
            {
                MessageBox.Show("record deleted");
                cleanform();
            }
            else
            {
                MessageBox.Show(msg);
            }
        }

        private void btnFind_Click(object sender, System.EventArgs e)
        {
            if (textBox1.Text != "")
            {

                var items = _metod.findById (textBox1.Text);
                if (items != null)
                {
                    textBox2.Text = items.name;
                    textBox3.Text = items.address;
                    textBox4.Text = items.status;
                }
                else
                {
                    MessageBox.Show("Record not found");
                }

            }
        }

        private void btnPopulate_Click(object sender, System.EventArgs e)
        {
            List<ClassObjects.users> lista = _metod.allRecords(_user);
            dataGridView1.DataSource = lista;
            int i = 0;
            string xx = "";
            dataGridView2.AutoGenerateColumns = false;
            foreach (var prop in _user.GetType().GetProperties())
            {
                dataGridView2.Columns[i].DataPropertyName =  prop.Name;
                i = i + 1;
            }
            dataGridView2.DataSource = lista;
        }


   
        private void btnPopulateDyn_Click(object sender, System.EventArgs e)
        {
             Utilities.Funciones FG = new Utilities.Funciones();
            var items = _metod.dynamicsList();
            DataTable dt = new DataTable();
            dt = FG.ConvertToDataTable(items);
            dataGridView1.DataSource = dt;
            
         
            dataGridView2.AutoGenerateColumns = false;
            for (int i = 0; i < dt.Columns.Count - 1; i++)
            {
                dataGridView2.Columns[i].DataPropertyName = dt.Columns[i].ColumnName;
            }
            dataGridView2.DataSource = dt;


        }

        #endregion


        private void cleanform()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

      
    }
}

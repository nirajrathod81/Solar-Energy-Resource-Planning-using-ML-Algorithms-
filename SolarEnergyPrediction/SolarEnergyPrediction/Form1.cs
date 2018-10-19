using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using SQL = System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace SolarEnergyPrediction
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbRegion.Text = "Pune";
            cbModel.Text = "Select Model";
            cbReportModel.Text = "Select Model";

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cbModel.SelectedIndex == 0)
            {
                MessageBox.Show("Select Model ...");
                return;
            }
            int dayofyr = dateTimePicker1.Value.DayOfYear;
            int model = cbModel.SelectedIndex;
            //System.Data.OleDb.OleDbDataAdapter MyCommand,MyCommand1;
            System.Data.DataSet DtSet;
            DtSet = new System.Data.DataSet();
            DataSet dtt = new DataSet();
            string resultpath = "";
            switch (model)
            {
                case 1://LMS
                    dtt.Clear();
                    resultpath = Properties.Settings.Default.lsrresult;
                    //MyCommand = GetData(dayofyr, resultpath);
                    Excel.Application xlApp = new Excel.Application();
                    Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(resultpath, ReadOnly: false);
                    xlApp.Visible = false;
                    Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                    Excel.Range xlRange = xlWorksheet.UsedRange;
                    System.Data.OleDb.OleDbConnection MyConnection;
                    System.Data.OleDb.OleDbDataAdapter MyCommand;
                    MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + resultpath + "';Extended Properties=Excel 8.0;");
                    MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Results$] where Day_Number=" + dayofyr, MyConnection);
                    MyCommand.Fill(dtt).ToString();
                    MyCommand.Dispose();
                    MyConnection.Close();
                    xlWorkbook.Close();
                    xlApp.Quit();
                    break;
                case 2://SVM
                    dtt.Clear();
                    resultpath = Properties.Settings.Default.svmresult;
                    Excel.Application xlApp1 = new Excel.Application();
                    Excel.Workbook xlWorkbook1 = xlApp1.Workbooks.Open(resultpath, ReadOnly: false);
                    xlApp1.Visible = false;
                    Excel._Worksheet xlWorksheet1 = xlWorkbook1.Sheets[1];
                    Excel.Range xlRange1 = xlWorksheet1.UsedRange;
                    System.Data.OleDb.OleDbConnection MyConnection1;
                    System.Data.OleDb.OleDbDataAdapter MyCommand1;
                    MyConnection1 = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + resultpath + "';Extended Properties=Excel 8.0;");
                    MyCommand1 = new System.Data.OleDb.OleDbDataAdapter("select * from [Results$] where Day_Number=" + dayofyr, MyConnection1);
                    MyCommand1.Fill(dtt).ToString();
                    MyCommand1.Dispose();
                    MyConnection1.Close();
                    xlWorkbook1.Close();
                    xlApp1.Quit();
                    //MyCommand = GetData(dayofyr, resultpath);
                    //MyCommand.Fill(dtt);
                    break;
                case 3://Both
                    dtt.Clear();
                    resultpath = Properties.Settings.Default.lsrresult;
                    Excel.Application xlApp2 = new Excel.Application();
                    Excel.Workbook xlWorkbook2 = xlApp2.Workbooks.Open(resultpath, ReadOnly: false);
                    xlApp2.Visible = false;
                    Excel._Worksheet xlWorksheet2 = xlWorkbook2.Sheets[1];
                    Excel.Range xlRange2 = xlWorksheet2.UsedRange;
                    System.Data.OleDb.OleDbConnection MyConnection2;
                    System.Data.OleDb.OleDbDataAdapter MyCommand2;
                    MyConnection2 = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + resultpath + "';Extended Properties=Excel 8.0;");
                    MyCommand2 = new System.Data.OleDb.OleDbDataAdapter("select * from [Results$] where Day_Number=" + dayofyr, MyConnection2);
                    MyCommand2.Fill(dtt).ToString();
                    MyCommand2.Dispose();
                    MyConnection2.Close();
                    xlWorkbook2.Close();
                    xlApp2.Quit();
                    //MyCommand = GetData(dayofyr, resultpath);
                    // MyCommand.Fill(dtt);
                    resultpath = Properties.Settings.Default.svmresult;
                    Excel.Application xlApp3 = new Excel.Application();
                    Excel.Workbook xlWorkbook3 = xlApp3.Workbooks.Open(resultpath, ReadOnly: false);
                    xlApp3.Visible = false;
                    Excel._Worksheet xlWorksheet3 = xlWorkbook3.Sheets[1];
                    Excel.Range xlRange3 = xlWorksheet3.UsedRange;
                    System.Data.OleDb.OleDbConnection MyConnection3;
                    System.Data.OleDb.OleDbDataAdapter MyCommand3;
                    MyConnection3 = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + resultpath + "';Extended Properties=Excel 8.0;");
                    MyCommand3 = new System.Data.OleDb.OleDbDataAdapter("select * from [Results$] where Day_Number=" + dayofyr, MyConnection3);
                    MyCommand3.Fill(dtt).ToString();
                    MyCommand3.Dispose();
                    MyConnection3.Close();
                    xlWorkbook3.Close();
                    xlApp3.Quit();
                    //MyCommand = GetData(dayofyr, resultpath);
                    //MyCommand.Fill(dtt);
                    break;
                default://0 or else
                    dtt.Clear();
                    //MessageBox.Show("Select Model ...");
                    break;
            }

            //MyCommand.Fill(dtt).ToString();
            dataGridView1.DataSource = dtt.Tables[0];
            dataGridView1.DataBindings.ToString();
            /*string pathname = Path.GetDirectoryName(path);
            filePath1.ReadOnly = true;
            filePath1.Text = path;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@path, ReadOnly: false);
            xlApp.Visible = false;
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            opLstCst2.Items.Clear();
            System.Data.OleDb.OleDbConnection MyConnection;
            System.Data.DataSet DtSet;
            System.Data.OleDb.OleDbDataAdapter MyCommand, MyCommand1;
            MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + path + "';Extended Properties=Excel 8.0;");
            MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
            DtSet = new System.Data.DataSet();
            MyCommand.Fill(dtt).ToString();
            dataGridViewDisplayPanel.DataSource = dtt.Tables[0];
            dataGridViewDisplayPanel.DataBindings.ToString();
            for (int m = 0; m < dataGridViewDisplayPanel.Columns.Count; m++)
            {
                opLstCst2.Items.Add(dataGridViewDisplayPanel.Columns[m].Name);
            }
            xlWorkbook.Close();
            xlApp.Quit();
            lblTotal.Text = "Total: " + dataGridViewDisplayPanel.Rows.Count;*/
        }

        public System.Data.OleDb.OleDbDataAdapter GetData(int index, string path)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(Properties.Settings.Default.svmresult, ReadOnly: false);
            xlApp.Visible = false;
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            System.Data.OleDb.OleDbConnection MyConnection;
            System.Data.OleDb.OleDbDataAdapter MyCommand;
            MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + path + "';Extended Properties=Excel 8.0;");
            MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Results$] where Day_Number=" + index, MyConnection);
            return MyCommand;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            switch (cbReportModel.SelectedIndex)
            {
                case 1:
                    axAcroPDF1.LoadFile(Properties.Settings.Default.lsrmodel.ToString());
                    break;
                case 2:
                    axAcroPDF1.LoadFile(Properties.Settings.Default.svmmodel.ToString());
                    break;
                case 3:
                    axAcroPDF1.LoadFile(Properties.Settings.Default.annmodel.ToString());
                    break;
                case 4:
                    axAcroPDF1.LoadFile(Properties.Settings.Default.arimamodel.ToString());
                    break;
                default:
                    MessageBox.Show("Please Select Model to Show ...");
                    break;
            }
        }

        private void cbModel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

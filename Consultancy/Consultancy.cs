using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Consultancy
{
    public partial class Consultancy : Form
    {
        public Consultancy()
        {
            InitializeComponent();
        }

        private void Consultancy_Load(object sender, EventArgs e)
        {

        }

        public void disp_data()
        {
            conn connect = new conn();
            if (connect.OpenConnection() == true)
            {
                string query = "SELECT * FROM consultancy";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                DataGridView1.DataSource = dt;

                connect.CloseConnection();
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                conn connect = new conn();
                string query = "insert into consultancy values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "')";

                if (connect.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                    cmd.ExecuteNonQuery();
                    connect.CloseConnection();
                    MessageBox.Show("Record Successfully saved!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                conn connect = new conn();
                string query = "update consultancy set 	consultancy_id='" + TextBox1.Text + "', consultancy_name='" + TextBox2.Text + "', consultancy_number='" + TextBox3.Text + "', consultancy_location='" + TextBox4.Text + "', consultancy_email='" + TextBox5.Text + "' where consultancy_id='" + TextBox1.Text + "' ";

                if (connect.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                    cmd.ExecuteNonQuery();
                    connect.CloseConnection();
                    MessageBox.Show("Record updated Successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                conn connect = new conn();
                string query = "delete from consultancy where consultancy_id='" + TextBox1.Text + "' ";

                if (connect.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                    cmd.ExecuteNonQuery();
                    connect.CloseConnection();

                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    TextBox5.Text = "";
                    MessageBox.Show("Record deleted Successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void viewDataButton_Click(object sender, EventArgs e)
        {
            disp_data();
        }
    }
}

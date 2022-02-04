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
    public partial class Scores : Form
    {
        public Scores()
        {
            InitializeComponent();
        }

        private void Scores_Load(object sender, EventArgs e)
        {

        }

        public void disp_data()
        {
            conn connect = new conn();
            if (connect.OpenConnection() == true)
            {
                string query = "SELECT * FROM scores";
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
                string query = "insert into scores values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "')";

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
                string query = "update scores set scores_id='" + TextBox1.Text + "', exam_name='" + TextBox2.Text + "', scores='" + TextBox3.Text + "', year_of_exam='" + TextBox4.Text + "', scores_number='" + TextBox5.Text + "' where scores_id='" + TextBox1.Text + "' ";

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
                string query = "delete from scores where scores_id='" + TextBox1.Text + "' ";

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

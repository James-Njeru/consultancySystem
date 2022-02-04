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
    public partial class Student : Form
    {
        String query;
        DataTable dt;
        int index = 0;

        public Student()
        {
            InitializeComponent();
        }

        private void Student_Load(object sender, EventArgs e)
        {

        }

        public void disp_data() 
        {
            conn connect = new conn();
            if (connect.OpenConnection() == true)
            {
                query = "SELECT * FROM student";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                DataGridView1.DataSource = dt;

                connect.CloseConnection();
            }
        }

        public void showData(int position)
        {
            conn connect = new conn();
            if (connect.OpenConnection() == true)
            {
                query = "SELECT * FROM student";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                MySqlDataAdapter da;
                dt = new DataTable();
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                DataGridView1.DataSource = dt;

                //Read the data and store them in the list
                TextBox1.Text = dt.Rows[position]["member_id"].ToString();
                TextBox2.Text = dt.Rows[position]["member_name"].ToString();
                TextBox3.Text = dt.Rows[position]["contact_number"].ToString();
                TextBox4.Text = dt.Rows[position]["member_address"].ToString();
                TextBox5.Text = dt.Rows[position]["checkin"].ToString();
                TextBox6.Text = dt.Rows[position]["checkout"].ToString();
                TextBox7.Text = dt.Rows[position]["password"].ToString();

                dataReader.Close();
                connect.CloseConnection();
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                conn connect = new conn();
                string query = "insert into student values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "')";

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
                string query = "update student set student_id='" + TextBox1.Text + "', student_name='" + TextBox2.Text + "', student_email='" + TextBox3.Text + "', student_work_experience='" + TextBox4.Text + "', student_number='" + TextBox5.Text + "', student_scores='" + TextBox6.Text + "', university='" + TextBox7.Text + "', password='" + TextBox8.Text + "' where student_id='" + TextBox1.Text + "' ";

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
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                conn connect = new conn();
                string query = "delete from student where student_id='" + TextBox1.Text + "' ";

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
                    TextBox6.Text = "";
                    TextBox7.Text = "";
                    TextBox8.Text = "";
                    MessageBox.Show("Record deleted Successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void FirstButton_Click(object sender, EventArgs e)
        {
            disp_data();

            conn connect = new conn();
            if (connect.OpenConnection() == true)
            {
                query = "SELECT * FROM student";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                if (dataReader.Read())
                {
                    this.TextBox1.Text = dataReader["student_id"].ToString();
                    this.TextBox2.Text = dataReader["student_name"].ToString();
                    this.TextBox3.Text = dataReader["student_email"].ToString();
                    this.TextBox4.Text = dataReader["student_work_experience"].ToString();
                    this.TextBox5.Text = dataReader["student_number"].ToString();
                    this.TextBox6.Text = dataReader["student_scores"].ToString();
                    this.TextBox7.Text = dataReader["university"].ToString();
                    this.TextBox8.Text = dataReader["password"].ToString();
                }
                dataReader.Close();
                connect.CloseConnection();
            }
        }

        private void LastButton_Click(object sender, EventArgs e)
        {
            index = dt.Rows.Count - 1;
            showData(index);
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            showData(index);
            index = dt.Rows.Count + 1;
        }

        private void PrevButton_Click(object sender, EventArgs e)
        {
            index -= 1;
            showData(index);
        }
    }
}

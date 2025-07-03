using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace LR4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadProducts();
        }

        private static string connectionString = "Server=localhost;Database=dairy_db;Uid=root;Pwd=0000;";
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        private void LoadProducts()
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM DairyProducts";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView2.DataSource = dt.Copy();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO DairyProducts (Type, Category, ShelfLife, Supplier, Name, Price) " +
                                   "VALUES (@Type, @Category, @ShelfLife, @Supplier, @Name, @Price)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Type", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Category", textBox2.Text);
                    cmd.Parameters.AddWithValue("@ShelfLife", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Supplier", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Name", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(textBox6.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product added successfully!");
                    LoadProducts();
                    ClearAddFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product: " + ex.Message);
            }
        }

        private void ClearAddFields()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text =
            textBox5.Text = textBox6.Text = "";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells["Type"].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells["Category"].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells["ShelfLife"].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells["Supplier"].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells["Price"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int productId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
                    using (MySqlConnection conn = GetConnection())
                    {
                        conn.Open();
                        string query = "UPDATE DairyProducts SET Type = @Type, Category = @Category, ShelfLife = @ShelfLife, " +
                                       "Supplier = @Supplier, Name = @Name, Price = @Price WHERE ID = @ID";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", productId);
                        cmd.Parameters.AddWithValue("@Type", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Category", textBox2.Text);
                        cmd.Parameters.AddWithValue("@ShelfLife", textBox3.Text);
                        cmd.Parameters.AddWithValue("@Supplier", textBox4.Text);
                        cmd.Parameters.AddWithValue("@Name", textBox5.Text);
                        cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(textBox6.Text));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Product updated successfully!");
                        LoadProducts();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating product: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a product to edit.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM DairyProducts WHERE Name LIKE @Name OR Supplier LIKE @Supplier";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", "%" + textBox7.Text + "%");
                    cmd.Parameters.AddWithValue("@Supplier", "%" + textBox7.Text + "%");
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    adapter.Fill(dt);
                    dataGridView2.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching products: " + ex.Message);
            }
        }
    }
}
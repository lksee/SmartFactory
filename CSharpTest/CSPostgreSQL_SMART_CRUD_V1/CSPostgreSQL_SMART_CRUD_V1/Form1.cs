using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace CSPostgreSQL_SMART_CRUD_V1
{
    public partial class Form1 : Form
    {
        // id --> autoid
        private string id = "";
        // 조회된 DataTable의 row 개수
        private int intRow = 0;

        public Form1()
        {
            InitializeComponent();
            resetMe();
        }

        private void resetMe()
        {
            this.id = string.Empty;

            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";

            if (genderComboBox.Items.Count > 0)
            {
                genderComboBox.SelectedIndex = 0;
            }

            updateButton.Text = "Update ( )";
            deleteButton.Text = "Delete ( )";

            keywordTextBox.Clear();

            if (keywordTextBox.CanSelect)
            {
                keywordTextBox.Select();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData("");
        }

        private void loadData(string keyword)
        {
            CRUD.sql = "SELECT autoid, firstname, lastname, CONCAT(firstname, ' ', lastname) AS fullname, gender FROM test_data " +
                       "WHERE CONCAT(CAST(autoid as varchar), ' ', firstname, ' ', lastname) LIKE @keyword::varchar " +
                       "OR TRIM(gender) LIKE @keyword::varchar ORDER BY autoid ASC";

            string strKeyword = string.Format("%{0}%", keyword);
            CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.con);
            CRUD.cmd.Parameters.Clear();
            CRUD.cmd.Parameters.AddWithValue("keyword", strKeyword);

            DataTable dt = CRUD.PerformCRUD(CRUD.cmd);

            if (dt.Rows.Count > 0)
            {
                intRow = Convert.ToInt32(dt.Rows.Count.ToString());
            }
            else
            {
                intRow = 0;
            }

            toolStripStatusLabel1.Text = "Number of row(s): " + intRow.ToString();

            DataGridView dgv1 = dataGridView1;

            dgv1.MultiSelect = false;
            dgv1.AutoGenerateColumns = true;
            dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv1.DataSource = dt;

            dgv1.Columns[0].HeaderText = "ID";
            dgv1.Columns[1].HeaderText = "First Name";
            dgv1.Columns[2].HeaderText = "Last Name";
            dgv1.Columns[3].HeaderText = "Full Name";
            dgv1.Columns[4].HeaderText = "Gender";

            dgv1.Columns[0].Width = 85;
            dgv1.Columns[1].Width = 170;
            dgv1.Columns[2].Width = 170;
            dgv1.Columns[3].Width = 220;
            dgv1.Columns[4].Width = 100;

        }

        // param : sql문이 select인지 update인지 delete인지 구분하기 위한 인자 값
        private void execute(string mySQL, string param)
        {
            CRUD.cmd = new NpgsqlCommand(mySQL, CRUD.con);
            addParameters(param);
            CRUD.PerformCRUD(CRUD.cmd);
        }

        /// <summary>
        /// SQL을 완성하기 위한 Parameter를 설정한다.
        /// </summary>
        /// <param name="str">Select/Delete/Update를 구분하기 위한 Parameter.</param>
        private void addParameters(string str)
        {
            CRUD.cmd.Parameters.Clear();
            CRUD.cmd.Parameters.AddWithValue("firstname", firstNameTextBox.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("lastname", lastNameTextBox.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("gender", genderComboBox.SelectedItem.ToString());

            // UPDATE와 DELETE문 SQL에는 삭제할 대상을 가르키는 id값(autoid에 해당)이 필요하다.
            if(str == "Update" || str == "Delete" && !string.IsNullOrEmpty(this.id))
            {
                CRUD.cmd.Parameters.AddWithValue("id", this.id);
            }
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstNameTextBox.Text.Trim()) || string.IsNullOrEmpty(lastNameTextBox.Text.Trim()))
            {
                MessageBox.Show("Please input first name and last name.", "Insert Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            CRUD.sql = "INSERT INTO test_data(firstname, lastname, gender) VALUES(@firstname, @lastname, @gender)";

            execute(CRUD.sql, "Insert");

            MessageBox.Show("The record has been saved.", "Insert Data", MessageBoxButtons.OK, MessageBoxIcon.Information);

            loadData("");

            resetMe();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                return;
            }

            if (string.IsNullOrEmpty(this.id))
            {
                MessageBox.Show("Please select an item from the list.", "Update Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(firstNameTextBox.Text.Trim()) || string.IsNullOrEmpty(lastNameTextBox.Text.Trim()))
            {
                MessageBox.Show("Please input first name and last name.", "Insert Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            CRUD.sql = "UPDATE test_data SET firstname = @firstname, lastname = @lastname, gender = @gender WHERE autoid = @id::integer";

            execute(CRUD.sql, "Update");

            MessageBox.Show("The record has been updated.", "Update Data", MessageBoxButtons.OK, MessageBoxIcon.Information);

            loadData("");

            resetMe();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridView dgv1 = dataGridView1;

                this.id = Convert.ToString(dgv1.CurrentRow.Cells[0].Value);
                updateButton.Text = $"Update ({this.id})";
                deleteButton.Text = $"Delete ({this.id})";

                firstNameTextBox.Text = Convert.ToString(dgv1.CurrentRow.Cells[1].Value);
                lastNameTextBox.Text = Convert.ToString(dgv1.CurrentRow.Cells[2].Value);

                genderComboBox.Text = Convert.ToString(dgv1.CurrentRow.Cells[4].Value);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                return;
            }

            if (string.IsNullOrEmpty(this.id))
            {
                MessageBox.Show("Please select an item from the list.", "Delete Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
            if (MessageBox.Show("Do you wanna permanently delete the selected record?", "Delete Data",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                CRUD.sql = "DELETE FROM test_data WHERE autoid = @id::integer";

                execute(CRUD.sql, "Delete");

                MessageBox.Show("The record has been deleted.", "Delete Data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                loadData("");

                resetMe();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(keywordTextBox.Text))
            {
                loadData("");
            }
            else
            {
                loadData(keywordTextBox.Text.Trim());
            }

            resetMe();
        }
    }
}

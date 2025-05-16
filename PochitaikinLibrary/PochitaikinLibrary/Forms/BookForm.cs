using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PochitaikinLibrary.Forms
{
    public partial class BookForm : Form
    {
        private readonly NpgsqlConnection connection;
        private readonly bool isEditMode;
        private readonly int bookId;

        public BookForm(NpgsqlConnection conn, bool editMode = false, int existingBookId = 0)
        {
            InitializeComponent();
            this.connection = conn;
            this.isEditMode = editMode;
            this.bookId = existingBookId;

            this.StartPosition = FormStartPosition.CenterScreen;
            ConfigureForm();

            if (isEditMode)
                LoadExistingBook();
        }

        private void ConfigureForm()
        {
            this.Text = isEditMode ? "Редактирование книги" : "Добавление книги";
            btnOK.Text = isEditMode ? "Сохранить изменения" : "Добавить";
            checkBoxAvailable.Checked = true; // По умолчанию книга доступна
        }

        private void LoadExistingBook()
        {
            try
            {
                string query = @"SELECT title, cost, is_available 
                                 FROM books 
                                 WHERE book_id = @bookId";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@bookId", bookId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBoxTitle.Text = reader.GetString(0);
                            numericCost.Value = reader.GetDecimal(1);
                            checkBoxAvailable.Checked = reader.GetBoolean(2);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных книги: " + ex.Message);
                this.Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTitle.Text))
            {
                MessageBox.Show("Заполните обязательное поле: Название.");
                return;
            }

            if (numericCost.Value < 0)
            {
                MessageBox.Show("Стоимость не может быть отрицательной.");
                return;
            }

            try
            {
                string title = textBoxTitle.Text;
                decimal cost = numericCost.Value;
                bool isAvailable = checkBoxAvailable.Checked;

                if (isEditMode)
                    UpdateBook(title, cost, isAvailable);
                else
                    InsertBook(title, cost, isAvailable);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message);
            }
        }

        private void InsertBook(string title, decimal cost, bool isAvailable)
        {
            string query = @"INSERT INTO books (title, cost, is_available)
                             VALUES (@title, @cost, @isAvailable)";

            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@cost", cost);
                cmd.Parameters.AddWithValue("@isAvailable", isAvailable);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Книга добавлена успешно.");
            this.DialogResult = DialogResult.OK;
        }

        private void UpdateBook(string title, decimal cost, bool isAvailable)
        {
            string query = @"UPDATE books 
                             SET title = @title, 
                                 cost = @cost,
                                 is_available = @isAvailable
                             WHERE book_id = @bookId";

            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@cost", cost);
                cmd.Parameters.AddWithValue("@isAvailable", isAvailable);
                cmd.Parameters.AddWithValue("@bookId", bookId);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Изменения успешно сохранены.");
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

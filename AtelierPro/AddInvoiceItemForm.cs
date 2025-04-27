//using Npgsql;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace AtelierPro
//{
//    public partial class AddInvoiceItemForm : Form
//    {
//        private NpgsqlConnection connection;
//        private int invoiceId;
//        private bool isIncoming;

//        public AddInvoiceItemForm(NpgsqlConnection conn, int id, bool incoming)
//        {
//            InitializeComponent();
//            connection = conn;
//            invoiceId = id;
//            isIncoming = incoming;
//            this.StartPosition = FormStartPosition.CenterScreen;
//            // Загрузка доступных материалов в ComboBox
//            LoadMaterials();
//        }

//        private void LoadMaterials()
//        {
//            // Загрузка списка материалов из базы данных
//            string query = "SELECT material_id, material_name FROM Material ORDER BY material_name";

//            using (var cmd = new NpgsqlCommand(query, connection))
//            using (var reader = cmd.ExecuteReader())
//            {
//                while (reader.Read())
//                {
//                    comboBoxMaterials.Items.Add(new KeyValuePair<int, string>(
//                        reader.GetInt32(0),
//                        reader.GetString(1)));
//                }
//            }

//            comboBoxMaterials.DisplayMember = "Value";
//            comboBoxMaterials.ValueMember = "Key";
//        }

//        private void btnOK_Click(object sender, EventArgs e)
//        {

//        }


//        public void Add_Item()
//        {
//            // Проверка введенных данных
//            if (comboBoxMaterials.SelectedItem == null ||
//                string.IsNullOrWhiteSpace(textBoxQuantity.Text) ||
//                string.IsNullOrWhiteSpace(textBoxPrice.Text))
//            {
//                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка",
//                              MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            try
//            {
//                // Получаем выбранный материал
//                var selectedMaterial = (KeyValuePair<int, string>)comboBoxMaterials.SelectedItem;
//                int materialId = selectedMaterial.Key;

//                decimal quantity = decimal.Parse(textBoxQuantity.Text);
//                decimal price = decimal.Parse(textBoxPrice.Text);

//                // Вставляем запись в соответствующую таблицу
//                string query;
//                if (isIncoming)
//                {
//                    query = @"INSERT INTO IncomingItems (invoice_id, material_id, quantity, unit_price)
//                          VALUES (@invoiceId, @materialId, @quantity, @price)";
//                }
//                else
//                {
//                    query = @"INSERT INTO OutgoingItems (outgoing_id, material_id, quantity, unit_price)
//                          VALUES (@invoiceId, @materialId, @quantity, @price)";
//                }

//                using (var cmd = new NpgsqlCommand(query, connection))
//                {
//                    cmd.Parameters.AddWithValue("@invoiceId", invoiceId);
//                    cmd.Parameters.AddWithValue("@materialId", materialId);
//                    cmd.Parameters.AddWithValue("@quantity", quantity);
//                    cmd.Parameters.AddWithValue("@price", price);

//                    cmd.ExecuteNonQuery();
//                }

//                MessageBox.Show("Элемент успешно добавлен в накладную.", "Успех",
//                              MessageBoxButtons.OK, MessageBoxIcon.Information);
//                this.Close();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Ошибка при добавлении элемента: {ex.Message}", "Ошибка",
//                              MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void btnCancel_Click(object sender, EventArgs e)
//        {
//            this.Close();
//        }
//    }
//}




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

namespace AtelierPro
{
    public partial class AddInvoiceItemForm : Form
    {
        private NpgsqlConnection connection;
        private int invoiceId;
        private bool isIncoming;
        private bool isEditMode;
        private int itemId; // Для режима редактирования

        public AddInvoiceItemForm(NpgsqlConnection conn, int id, bool incoming, bool editMode = false, int existingItemId = 0)
        {
            InitializeComponent();
            connection = conn;
            invoiceId = id;
            isIncoming = incoming;
            isEditMode = editMode;
            itemId = existingItemId;

            this.StartPosition = FormStartPosition.CenterScreen;

            // Настройка формы в зависимости от режима
            ConfigureFormForMode();

            // Загрузка доступных материалов в ComboBox
            LoadMaterials();

            // Если режим редактирования - загружаем данные существующей записи
            if (isEditMode)
            {
                LoadExistingItemData();
            }
        }

        private void ConfigureFormForMode()
        {
            if (isEditMode)
            {
                this.Text = "Редактирование элемента накладной";
                btnOK.Text = "Сохранить изменения";
            }
            else
            {
                this.Text = "Добавление элемента в накладную";
                btnOK.Text = "Добавить";
            }
        }

        private void LoadExistingItemData()
        {
            try
            {
                string query;
                if (isIncoming)
                {
                    query = @"SELECT material_id, quantity, unit_price 
                              FROM IncomingItems 
                              WHERE item_id = @itemId";
                }
                else
                {
                    query = @"SELECT material_id, quantity, unit_price 
                              FROM OutgoingItems 
                              WHERE item_id = @itemId";
                }

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@itemId", itemId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Устанавливаем выбранный материал
                            int materialId = reader.GetInt32(0);
                            for (int i = 0; i < comboBoxMaterials.Items.Count; i++)
                            {
                                var item = (KeyValuePair<int, string>)comboBoxMaterials.Items[i];
                                if (item.Key == materialId)
                                {
                                    comboBoxMaterials.SelectedIndex = i;
                                    break;
                                }
                            }

                            // Устанавливаем количество и цену
                            textBoxQuantity.Text = reader.GetDecimal(1).ToString();
                            textBoxPrice.Text = reader.GetDecimal(2).ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных элемента: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LoadMaterials()
        {
            try
            {
                comboBoxMaterials.Items.Clear();

                // Загрузка списка материалов из базы данных
                string query = "SELECT material_id, material_name FROM Material ORDER BY material_name";

                using (var cmd = new NpgsqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBoxMaterials.Items.Add(new KeyValuePair<int, string>(
                            reader.GetInt32(0),
                            reader.GetString(1)));
                    }
                }

                comboBoxMaterials.DisplayMember = "Value";
                comboBoxMaterials.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке списка материалов: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Проверка введенных данных
            if (comboBoxMaterials.SelectedItem == null ||
                string.IsNullOrWhiteSpace(textBoxQuantity.Text) ||
                string.IsNullOrWhiteSpace(textBoxPrice.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Получаем выбранный материал
                var selectedMaterial = (KeyValuePair<int, string>)comboBoxMaterials.SelectedItem;
                int materialId = selectedMaterial.Key;

                decimal quantity = decimal.Parse(textBoxQuantity.Text);
                decimal price = decimal.Parse(textBoxPrice.Text);

                if (isEditMode)
                {
                    // Режим редактирования - обновляем существующую запись
                    UpdateExistingItem(materialId, quantity, price);
                }
                else
                {
                    // Режим добавления - создаем новую запись
                    AddNewItem(materialId, quantity, price);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при {(isEditMode ? "сохранении изменений" : "добавлении элемента")}: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNewItem(int materialId, decimal quantity, decimal price)
        {
            string query;
            if (isIncoming)
            {
                query = @"INSERT INTO IncomingItems (invoice_id, material_id, quantity, unit_price)
                      VALUES (@invoiceId, @materialId, @quantity, @price)";
            }
            else
            {
                query = @"INSERT INTO OutgoingItems (outgoing_id, material_id, quantity, unit_price)
                      VALUES (@invoiceId, @materialId, @quantity, @price)";
            }

            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@invoiceId", invoiceId);
                cmd.Parameters.AddWithValue("@materialId", materialId);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@price", price);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Элемент успешно добавлен в накладную.", "Успех",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateExistingItem(int materialId, decimal quantity, decimal price)
        {
            string query;
            if (isIncoming)
            {
                query = @"UPDATE IncomingItems 
                      SET material_id = @materialId, 
                          quantity = @quantity, 
                          unit_price = @price
                      WHERE item_id = @itemId";
            }
            else
            {
                query = @"UPDATE OutgoingItems 
                      SET material_id = @materialId, 
                          quantity = @quantity, 
                          unit_price = @price
                      WHERE item_id = @itemId";
            }

            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@itemId", itemId);
                cmd.Parameters.AddWithValue("@materialId", materialId);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@price", price);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Изменения успешно сохранены.", "Успех",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

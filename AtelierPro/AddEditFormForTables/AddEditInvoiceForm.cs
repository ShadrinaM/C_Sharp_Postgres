using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace AtelierPro
{
    public partial class AddEditInvoiceForm : Form
    {
        private readonly NpgsqlConnection connection;
        private readonly bool isIncoming;
        private readonly bool isEditMode;
        private readonly int? invoiceId;

        // Свойство для возврата ID созданной накладной
        public int? CreatedInvoiceId { get; private set; }

        public AddEditInvoiceForm(NpgsqlConnection conn, bool isIncoming, bool isEditMode = false, int? invoiceId = null)
        {
            InitializeComponent();
            this.connection = conn;
            this.isIncoming = isIncoming;
            this.isEditMode = isEditMode;
            this.invoiceId = invoiceId;

            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void AddEditInvoiceForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (isIncoming)
                {
                    LoadSuppliers();
                    labelClientOrSupplier.Text = "Поставщик:";
                    labelDeliveryDate.Visible = true;
                    dateTimePickerDeliveryDate.Visible = true;
                }
                else
                {
                    LoadOrders();
                    labelClientOrSupplier.Text = "Заказчик:";
                    labelDeliveryDate.Visible = false;
                    dateTimePickerDeliveryDate.Visible = false;
                }

                if (isEditMode && invoiceId.HasValue)
                {
                    Text = isIncoming ? "Редактирование приходной накладной" : "Редактирование расходной накладной";
                    LoadInvoiceData();
                }
                else
                {
                    Text = isIncoming ? "Добавление приходной накладной" : "Добавление расходной накладной";
                    dateTimePickerInvoiceDate.Value = DateTime.Now;
                    dateTimePickerDeliveryDate.Value = DateTime.Now;
                }

                textBoxInvoiceNumber.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LoadSuppliers()
        {
            string query = "SELECT supplier_id, supplier_name FROM Suppliers ORDER BY supplier_name";
            using (var cmd = new NpgsqlCommand(query, connection))
            using (var adapter = new NpgsqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                comboBoxClientOrSupplier.DataSource = dt;
                comboBoxClientOrSupplier.DisplayMember = "supplier_name";
                comboBoxClientOrSupplier.ValueMember = "supplier_id";
            }
        }

        private void LoadOrders()
        {
            string query = "SELECT order_id, customer_name FROM Orders ORDER BY customer_name";
            using (var cmd = new NpgsqlCommand(query, connection))
            using (var adapter = new NpgsqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                comboBoxClientOrSupplier.DataSource = dt;
                comboBoxClientOrSupplier.DisplayMember = "customer_name";
                comboBoxClientOrSupplier.ValueMember = "order_id";
            }
        }

        private void LoadInvoiceData()
        {
            string query = isIncoming
                ? "SELECT invoice_number, invoice_date, delivery_date, supplier_id, notes FROM IncomingInvoices WHERE invoice_id = @id"
                : "SELECT invoice_number, invoice_date, notes, order_id FROM OutgoingInvoices WHERE outgoing_id = @id";

            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@id", invoiceId.Value);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        textBoxInvoiceNumber.Text = reader.GetString(0);
                        dateTimePickerInvoiceDate.Value = reader.GetDateTime(1);

                        if (isIncoming)
                        {
                            dateTimePickerDeliveryDate.Value = reader.IsDBNull(2) ? DateTime.Now : reader.GetDateTime(2);
                            comboBoxClientOrSupplier.SelectedValue = reader.GetInt32(3);
                            textBoxNotes.Text = reader.IsDBNull(4) ? "" : reader.GetString(4);
                        }
                        else
                        {
                            textBoxNotes.Text = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            comboBoxClientOrSupplier.SelectedValue = reader.GetInt32(3);
                        }
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                string invoiceNumber = textBoxInvoiceNumber.Text.Trim();
                DateTime invoiceDate = dateTimePickerInvoiceDate.Value;
                string notes = textBoxNotes.Text.Trim();
                int selectedId = (int)comboBoxClientOrSupplier.SelectedValue;

                if (isEditMode)
                {
                    UpdateInvoice(invoiceNumber, invoiceDate, notes, selectedId);
                }
                else
                {
                    CreatedInvoiceId = InsertInvoice(invoiceNumber, invoiceDate, notes, selectedId);

                    // Предложение добавить элементы накладной
                    if (MessageBox.Show("Накладная успешно создана. Хотите добавить элементы накладной?",
                        "Добавление элементов", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (var itemForm = new AddEditInvoiceItemForm(connection, CreatedInvoiceId.Value, isIncoming))
                        {
                            itemForm.ShowDialog(this);
                        }
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении накладной: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBoxInvoiceNumber.Text))
            {
                MessageBox.Show("Введите номер накладной.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxInvoiceNumber.Focus();
                return false;
            }

            if (comboBoxClientOrSupplier.SelectedValue == null)
            {
                MessageBox.Show(isIncoming ? "Выберите поставщика." : "Выберите заказчика.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxClientOrSupplier.Focus();
                return false;
            }

            return true;
        }

        private int InsertInvoice(string number, DateTime date, string notes, int entityId)
        {
            string query = isIncoming
                ? @"INSERT INTO IncomingInvoices (invoice_number, invoice_date, delivery_date, supplier_id, notes)
                     VALUES (@num, @date, @delivery, @supplier, @notes)
                     RETURNING invoice_id"
                : @"INSERT INTO OutgoingInvoices (invoice_number, invoice_date, order_id, notes)
                     VALUES (@num, @date, @order, @notes)
                     RETURNING outgoing_id";

            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@num", number);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@notes", string.IsNullOrWhiteSpace(notes) ? DBNull.Value : (object)notes);

                if (isIncoming)
                {
                    cmd.Parameters.AddWithValue("@delivery", dateTimePickerDeliveryDate.Value);
                    cmd.Parameters.AddWithValue("@supplier", entityId);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@order", entityId);
                }

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void UpdateInvoice(string number, DateTime date, string notes, int entityId)
        {
            string query = isIncoming
                ? @"UPDATE IncomingInvoices 
                   SET invoice_number = @num, invoice_date = @date, 
                       delivery_date = @delivery, supplier_id = @supplier, notes = @notes
                   WHERE invoice_id = @id"
                : @"UPDATE OutgoingInvoices 
                   SET invoice_number = @num, invoice_date = @date, 
                       order_id = @order, notes = @notes
                   WHERE outgoing_id = @id";

            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@num", number);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@notes", string.IsNullOrWhiteSpace(notes) ? DBNull.Value : (object)notes);
                cmd.Parameters.AddWithValue("@id", invoiceId.Value);

                if (isIncoming)
                {
                    cmd.Parameters.AddWithValue("@delivery", dateTimePickerDeliveryDate.Value);
                    cmd.Parameters.AddWithValue("@supplier", entityId);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@order", entityId);
                }

                cmd.ExecuteNonQuery();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
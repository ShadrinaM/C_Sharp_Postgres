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
    public partial class AddEditInvoiceForm : Form
    {
        private readonly NpgsqlConnection connection;
        private readonly bool isIncoming;
        private readonly bool isEditMode;
        private readonly int? invoiceId;

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
            if (isIncoming)
            {
                LoadSuppliers();
                labelClientOrSupplier.Text = "Поставщик:";
            }
            else
            {
                LoadOrders();
                labelClientOrSupplier.Text = "Заказчик:";
            }

            if (isEditMode && invoiceId.HasValue)
            {
                LoadInvoiceData();
            }

            textBoxInvoiceNumber.Focus();
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
                            dateTimePickerDeliveryDate.Value = reader.GetDateTime(2);
                            comboBoxClientOrSupplier.SelectedValue = reader.GetInt32(3);
                            textBoxNotes.Text = reader.GetString(4);
                        }
                        else
                        {
                            comboBoxClientOrSupplier.SelectedValue = reader.GetInt32(3);
                            textBoxNotes.Text = reader.GetString(2);
                            dateTimePickerDeliveryDate.Enabled = false;
                            dateTimePickerDeliveryDate.Visible = false;
                            labelDeliveryDate.Visible = false;
                        }
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string invoiceNumber = textBoxInvoiceNumber.Text.Trim();
            DateTime invoiceDate = dateTimePickerInvoiceDate.Value;
            string notes = textBoxNotes.Text.Trim();
            int selectedId = (int)comboBoxClientOrSupplier.SelectedValue;

            if (string.IsNullOrWhiteSpace(invoiceNumber))
            {
                MessageBox.Show("Введите номер накладной.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int newInvoiceId = -1;

                if (isEditMode)
                {
                    UpdateInvoice(invoiceNumber, invoiceDate, notes, selectedId);
                }
                else
                {
                    newInvoiceId = InsertInvoice(invoiceNumber, invoiceDate, notes, selectedId);

                    // Показываем форму добавления элемента
                    using (var itemForm = new AddEditInvoiceItemForm(connection, newInvoiceId, isIncoming))
                    {
                        itemForm.ShowDialog(this);
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


        private int InsertInvoice(string number, DateTime date, string notes, int entityId)
        {
            string query;
            if (isIncoming)
            {
                query = @"INSERT INTO IncomingInvoices (invoice_number, invoice_date, delivery_date, supplier_id, notes)
                  VALUES (@num, @date, @delivery, @supplier, @notes)
                  RETURNING invoice_id";
            }
            else
            {
                query = @"INSERT INTO OutgoingInvoices (invoice_number, invoice_date, order_id, notes)
                  VALUES (@num, @date, @order, @notes)
                  RETURNING outgoing_id";
            }

            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@num", number);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@notes", notes);

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
            string query;
            if (isIncoming)
            {
                query = @"UPDATE IncomingInvoices 
                          SET invoice_number = @num, invoice_date = @date, delivery_date = @delivery, supplier_id = @supplier, notes = @notes
                          WHERE invoice_id = @id";
            }
            else
            {
                query = @"UPDATE OutgoingInvoices 
                          SET invoice_number = @num, invoice_date = @date, order_id = @order, notes = @notes
                          WHERE outgoing_id = @id";
            }

            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@num", number);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@notes", notes);
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

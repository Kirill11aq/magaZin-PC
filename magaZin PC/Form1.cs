using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
namespace magaZin_PC
{
    public partial class Form1 : Form
    {
        private List<Component> component;
        private List<Component> cart;
        public Form1()
        {
            InitializeComponent();
            component = new List<Component>();
            cart = new List<Component>();
            InitializeComponents();
        }
        private void InitializeComponents()
        {
            component.Add(new Component("CPU", "Intel Core i7", "4.0 GHz", 300));
            component.Add(new Component("GPU", "Nvidia RTX 3080", "10 GB", 800));
            component.Add(new Component("RAM", "Corsair Vengeance", "16 GB", 150));
            foreach (Component c in component)
            {
                comboBox1.Items.Add(c.Name);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedProduct = comboBox1.SelectedItem.ToString();
                Component selectedComponent = component.Find(c => c.Name == selectedProduct);
                cart.Add(selectedComponent);
                listBox1.Items.Add(selectedComponent.Name);
                UpdateTotalPrice();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите товар.");
            }
        }
        private void UpdateTotalPrice()
        {
            decimal total = 0;
            foreach (Component c in cart)
            {
                total += c.Price;
            }
            label1.Text = "Общая стоимость: $" + total.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(component);
            form2.ShowDialog();
        }
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedProduct = comboBox1.SelectedItem.ToString();
                Component selectedComponent = component.Find(c => c.Name == selectedProduct);
                textBox1.Text = selectedComponent.Price.ToString();
            }
        }
    }
    public class Component
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Specifications { get; set; }
        public decimal Price { get; set; }
        public Component(string name, string description, string specifications, decimal price)
        {
            Name = name;
            Description = description;
            Specifications = specifications;
            Price = price;
        }
    }
}
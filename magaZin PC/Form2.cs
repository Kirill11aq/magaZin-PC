using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace magaZin_PC
{
    public partial class Form2 : Form
    {
        private List<Component> component;
        public Form2(List<Component> component)
        {
            InitializeComponent();
            this.component = component;
            UpdateComponentList();
        }
        private void UpdateComponentList()
        {
            listBox1.Items.Clear();
            foreach (Component c in component)
            {
                listBox1.Items.Add(c.Name);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string description = textBox2.Text;
            string specifications = textBox3.Text;
            if (decimal.TryParse(textBox4.Text, out decimal price))
            {
                Component newComponent = new Component(name, description, specifications, price);
                component.Add(newComponent);
                UpdateComponentList();
                ClearTextFields();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректную цену.");
            }
        }
        private void ClearTextFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedName = listBox1.SelectedItem.ToString();
                Component selectedComponent = component.Find(c => c.Name == selectedName);
                textBox1.Text = selectedComponent.Name;
                textBox2.Text = selectedComponent.Description;
                textBox3.Text = selectedComponent.Specifications;
                textBox4.Text = selectedComponent.Price.ToString();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedName = listBox1.SelectedItem.ToString();
                Component selectedComponent = component.Find(c => c.Name == selectedName);
                selectedComponent.Name = textBox1.Text;
                selectedComponent.Description = textBox2.Text;
                selectedComponent.Specifications = textBox3.Text;
                if (decimal.TryParse(textBox4.Text, out decimal price))
                {
                    selectedComponent.Price = price;
                    UpdateComponentList();
                    ClearTextFields();
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректную цену.");
                }
            }
        }
    }
}
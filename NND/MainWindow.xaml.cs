using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NND 
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {

        private Model.Model model;

        public MainWindow() 
        {
            InitializeComponent();
            model = new Model.Model();
            var types = model.GetLayerTypes();
            foreach (var type in types) 
            {
                model.AddNode(type);
            }
            Serialize.Serializer s = new Serialize.Serializer(model);
            System.IO.StreamWriter writer = new System.IO.StreamWriter(new System.IO.FileStream(@"D:\test.txt", System.IO.FileMode.Create, System.IO.FileAccess.Write));
            s.Serialize(writer);
            writer.Flush();
            writer.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Model.LayerType selected = (Model.LayerType)listBox.SelectedItem;
            if (selected != null)
            {
                if (listBox1.SelectedIndex == -1)
                {
                    model.AddNode(selected);
                }
                else
                {
                    model.AddNode(selected, listBox1.SelectedIndex + 1);
                }
            }
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.LayerNode selected = (Model.LayerNode)listBox1.SelectedItem;
            if (selected != null)
            {
                listBox2.ItemsSource = selected.values;
            }
        }

        private string selectedKey = "";

        private void ListBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Object obj = listBox2.SelectedItem;
            if (obj != null)
            {
                KeyValuePair<string, string> selected = (KeyValuePair<string, string>)obj;
                selectedKey = selected.Key;
                textBox.Text = selected.Value;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Model.LayerNode selectedNode = (Model.LayerNode)listBox1.SelectedItem;
            if (selectedNode != null)
            {
                selectedNode.values[selectedKey] = textBox.Text;
                listBox2.ItemsSource = null;
                listBox2.ItemsSource = selectedNode.values;
            }
        }
    }
}

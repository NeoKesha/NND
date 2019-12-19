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
using NND.Model;

namespace NND
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private StaticModel _staticModel;

        public MainWindow()
        {
            InitializeComponent();
            _staticModel = new Model.StaticModel();
            listBox.ItemsSource = _staticModel.GetLayerTypesLink();
            listBox1.ItemsSource = _staticModel.GetLayerNodesLink();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Model.LayerType selected = (Model.LayerType)listBox.SelectedItem;
            if (selected != null)
            {
                if (listBox1.SelectedIndex == -1)
                {
                    _staticModel.AddNode(selected);
                }
                else
                {
                    _staticModel.AddNode(selected, listBox1.SelectedIndex + 1);
                }
            }
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.LayerNode selected = (Model.LayerNode)listBox1.SelectedItem;
            if (selected != null)
            {
                listBox2.ItemsSource = selected.Values;
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
                selectedNode.Values[selectedKey] = textBox.Text;
                listBox2.ItemsSource = null;
                listBox2.ItemsSource = selectedNode.Values;
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                _staticModel.RemoveNode(listBox1.SelectedIndex);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "JSON File (*.json)|*.json";
            saveFileDialog.DefaultExt = ".json";
            if (saveFileDialog.ShowDialog().Value)
            {
                String fileName = saveFileDialog.FileName;
                System.IO.StreamWriter writer = new System.IO.StreamWriter(new System.IO.FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write));
                Serialize.Serializer serializer = new Serialize.Serializer(_staticModel);
                serializer.Serialize(writer);
                writer.Flush();
                writer.Close();
            }
        }
        private void Load_Click(object sender, RoutedEventArgs e) {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "JSON File (*.json)|*.json";
            openFileDialog.DefaultExt = ".json";
            if (openFileDialog.ShowDialog().Value) {
                String fileName = openFileDialog.FileName;
                System.IO.StreamReader reader = new System.IO.StreamReader(new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read));
                Serialize.Deserializer deserializer = new Serialize.Deserializer();
                deserializer.Deserialize(reader,_staticModel);
                reader.Close();
            }
        }
    }
}

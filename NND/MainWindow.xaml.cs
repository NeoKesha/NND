using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using NND.Model;

namespace NND
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly StaticModel _staticModel;
        private string _selectedKey = "";

        public MainWindow()
        {
            InitializeComponent();
            _staticModel = new Model.StaticModel();
            listBox.ItemsSource = _staticModel.GetLayerTypesLink();
            listBox1.ItemsSource = _staticModel.GetLayerNodesLink();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var selected = (LayerType) listBox.SelectedItem;
            if (selected == null)
            {
                return;
            }

            if (listBox1.SelectedIndex == -1)
            {
                _staticModel.AddNode(selected);
            }
            else
            {
                _staticModel.AddNode(selected, listBox1.SelectedIndex + 1);
            }
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = (LayerNode) listBox1.SelectedItem;
            if (selected != null)
            {
                listBox2.ItemsSource = selected.Values;
            }
        }


        private void ListBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var obj = listBox2.SelectedItem;
            if (obj == null)
            {
                return;
            }

            var selected = (KeyValuePair<string, string>) obj;
            _selectedKey = selected.Key;
            textBox.Text = selected.Value;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LayerNode selectedNode = (LayerNode) listBox1.SelectedItem;
            if (selectedNode == null)
            {
                return;
            }

            selectedNode.Values[_selectedKey] = textBox.Text;
            listBox2.ItemsSource = null;
            listBox2.ItemsSource = selectedNode.Values;
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
            var saveFileDialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "JSON File (*.json)|*.json", DefaultExt = ".json"
            };
            if (!saveFileDialog.ShowDialog().Value)
            {
                return;
            }

            var fileName = saveFileDialog.FileName;
            var writer = new System.IO.StreamWriter(
                new System.IO.FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write));
            var serializer = new Serialize.Serializer(_staticModel);
            serializer.Serialize(writer);
            writer.Flush();
            writer.Close();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "JSON File (*.json)|*.json";
            openFileDialog.DefaultExt = ".json";
            if (!openFileDialog.ShowDialog().Value)
            {
                return;
            }

            var fileName = openFileDialog.FileName;
            var reader = new System.IO.StreamReader(
                new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read));
            var deserializer = new Serialize.Deserializer();
            deserializer.Deserialize(reader, _staticModel);
            reader.Close();
        }
    }
}
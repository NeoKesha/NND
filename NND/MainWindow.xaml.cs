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

namespace NND {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            Serialize.Serializer s = new Serialize.Serializer(new Model.Model());
            System.IO.StreamWriter writer = new System.IO.StreamWriter(new System.IO.FileStream(@"D:\test.txt", System.IO.FileMode.Create, System.IO.FileAccess.Write));
            s.Serialize(writer);
            writer.Flush();
            writer.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfTreeViewExamples.Library;

namespace WpfTreeViewExamples.Controls
{
    /// <summary>
    /// Interaction logic for ucDataBinding.xaml
    /// </summary>
    public partial class ucDataBinding : UserControl
    {

        #region Constructor

        public ucDataBinding()
        {
            InitializeComponent();
        }
        
        #endregion

        #region Events

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            BindTree();
        }
        
        #endregion

        #region Private Methods

        private void BindTree()
        {
            tvMain.ItemsSource = WorldArea.GetAll();
        }
        
        #endregion

    }
}

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
    /// Interaction logic for ucDataTemplate.xaml
    /// </summary>
    public partial class ucDataTemplate : UserControl
    {

        #region Data members

        System.Collections.ObjectModel.ObservableCollection<WorldArea> _list = null;
        
        #endregion

        #region Constructor

        public ucDataTemplate()
        {
            InitializeComponent();
            _list = WorldArea.GetAll();
        }
        
        #endregion

        #region Events

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FillTree();
        }


        void ItemContainerGenerator_StatusChanged(object sender, EventArgs e)
        {


            if (tvMain.ItemContainerGenerator.Status == System.Windows.Controls.Primitives.GeneratorStatus.ContainersGenerated)
            {
                foreach (WorldArea area in _list)
                {
                    TreeViewItem item = (TreeViewItem)tvMain.ItemContainerGenerator.ContainerFromItem(area);
                    if (item == null) continue;
                    item.IsExpanded = true;
                    if (item.Items.Count == 0)
                    {

                        foreach (Country country in area.Countries)
                        {
                            item.Items.Add(country);
                        }
                    }
                }



            }

        }


        #endregion

        #region Private 


        private void FillTree()
        {

            foreach (WorldArea area in _list)
            {
                tvMain.Items.Add(area);
                tvMain.ItemContainerGenerator.StatusChanged += new EventHandler(ItemContainerGenerator_StatusChanged);
            }
        }

        
        #endregion

    }
}

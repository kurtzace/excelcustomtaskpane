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

namespace ExcelAddin.UI
{
    /// <summary>
    /// Interaction logic for PaneWpd.xaml
    /// </summary>
    public partial class PaneWpd : UserControl
    {
        public PaneWpd()
        {
            InitializeComponent();
            ProjectsControl.AddTag(new TokenizedTag.TokenizedTagItem("hi"));

        }
       
        private void ProjectsControl_TagApplied(object sender, TokenizedTag.TokenizedTagEventArgs e)
        {
            MessageBox.Show(""+ProjectsControl.EnteredTags.Count);
        }

        private void ProjectsControl_TagClick(object sender, TokenizedTag.TokenizedTagEventArgs e)
        {
            
        }

        private void ProjectsControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {

            }
        }
    }
}

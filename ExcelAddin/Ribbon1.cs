using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using ExcelAddin.UI;
using System.Windows.Forms;

namespace ExcelAddin
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RibbonControlEventArgs e)
        {
            var s = ebTitle.Text;
            //Globals.ThisAddIn.SearchForFilms(s);
            PaneWrapper obj = new PaneWrapper();
            obj.AutoSize = true;
            obj.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left);
            var pane =Globals.ThisAddIn.CustomTaskPanes.Add(obj,"App Pane");
            obj.Dock = System.Windows.Forms.DockStyle.Fill;
            pane.Visible = true;
        }
    }
}

namespace ExcelAddin
{
	partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Ribbon1()
			: base(Globals.Factory.GetRibbonFactory())
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tab1 = this.Factory.CreateRibbonTab();
			this.grpSearch = this.Factory.CreateRibbonGroup();
			this.ebTitle = this.Factory.CreateRibbonEditBox();
			this.btnSearch = this.Factory.CreateRibbonButton();
			this.tab1.SuspendLayout();
			this.grpSearch.SuspendLayout();
			// 
			// tab1
			// 
			this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
			this.tab1.Groups.Add(this.grpSearch);
			this.tab1.Label = "TabAddIns";
			this.tab1.Name = "tab1";
			// 
			// grpSearch
			// 
			this.grpSearch.Items.Add(this.ebTitle);
			this.grpSearch.Items.Add(this.btnSearch);
			this.grpSearch.Label = "Search";
			this.grpSearch.Name = "grpSearch";
			// 
			// ebTitle
			// 
			this.ebTitle.Label = "Search for title";
			this.ebTitle.Name = "ebTitle";
			// 
			// btnSearch
			// 
			this.btnSearch.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.btnSearch.Image = global::ExcelAddin.Properties.Resources.Koala;
			this.btnSearch.Label = "Search";
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.ShowImage = true;
			this.btnSearch.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSearch_Click);
			// 
			// Ribbon1
			// 
			this.Name = "Ribbon1";
			this.RibbonType = "Microsoft.Excel.Workbook";
			this.Tabs.Add(this.tab1);
			this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
			this.tab1.ResumeLayout(false);
			this.tab1.PerformLayout();
			this.grpSearch.ResumeLayout(false);
			this.grpSearch.PerformLayout();

		}

		#endregion

		internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
		internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpSearch;
		internal Microsoft.Office.Tools.Ribbon.RibbonEditBox ebTitle;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSearch;
	}

	partial class ThisRibbonCollection
	{
		internal Ribbon1 Ribbon1
		{
			get { return this.GetRibbon<Ribbon1>(); }
		}
	}
}

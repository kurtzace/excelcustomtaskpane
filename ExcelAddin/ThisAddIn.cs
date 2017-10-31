using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Ribbon;
using Chart = Microsoft.Office.Tools.Excel.Chart;
using ListObject = Microsoft.Office.Tools.Excel.ListObject;
using Worksheet = Microsoft.Office.Tools.Excel.Worksheet;

namespace ExcelAddin
{
    public partial class ThisAddIn
    {
		internal void SearchForFilmsUsingDOM(string searchCritera)
		{
			var proxy = DataAccess.ProxyFactory.CreateNetflixProxy();
			var data = proxy.GetFilms(searchCritera);

			var worksheet = this.Application.ActiveWorkbook.ActiveSheet;

			var i = 0;
			foreach (var movieTitle in data)
			{
				i++;
				string rngDesc = string.Format("A{0}:G{0}", i);
				var row = worksheet.Range[rngDesc];
				row[1, 1] = movieTitle.Id;
				row[1, 2] = movieTitle.Name;
				row[1, 3] = movieTitle.Rating;
				row[1, 4] = movieTitle.TinyUrl;
				row[1, 5] = (movieTitle.ReleaseYear == null) ? 0 : movieTitle.ReleaseYear;
				row[1, 6] = (movieTitle.AverageRating == null) ? 0 : movieTitle.AverageRating;
			}
		}

    	internal void SearchForFilms(string searchCritera)
    	{
    		var proxy = DataAccess.ProxyFactory.CreateNetflixProxy();
    		var data = proxy.GetFilms(searchCritera);

    		var worksheet = this.Application.ActiveWorkbook.ActiveSheet;

    		var listObject = FindListObject("netflixTitles");
    		if (listObject == null)
    		{
    			// Create a workhseet host item for .NET Framework 4 projects.
    			var extendedWorksheet = (Worksheet) Globals.Factory.GetVstoObject(worksheet);
    			var cell = extendedWorksheet.Range["A1:G5"];
    			listObject = extendedWorksheet.Controls.AddListObject(cell, "netflixTitles");
    		}

    		listObject.AutoSetDataBoundColumnHeaders = true;
    		listObject.SetDataBinding(data, "", "Id", "Name", "Rating", "TinyUrl", "ReleaseYear", "AverageRating");
    		listObject.ShowTotals = true;

    		AddSelectionChangeEventHandlers();
    		AddChart();
    	}

    	internal void AddChart()
    	{
    		Worksheet worksheet = Globals.Factory.GetVstoObject(
    			Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet);

    		//var currentRange = Globals.ThisAddIn.Application.ActiveWindow.RangeSelection;
    		Worksheet worksheet2 = Globals.Factory.GetVstoObject(
    			Globals.ThisAddIn.Application.ActiveWorkbook.Sheets[2]);
    		var currentRange = worksheet2.Range["A1", "H20"];

    		Chart chart = worksheet2.Controls.AddChart(currentRange, "ratings");
    		chart.ChartType = XlChartType.xlColumnClustered;

    		var listObject = FindListObject("netflixTitles");
    		var end = listObject.DataBodyRange.get_End(XlDirection.xlDown).Row;
    		Range cells = worksheet.Range["F1", "F" + end.ToString()];
    		chart.SetSourceData(cells);
    		chart.ApplyDataLabels(XlDataLabelsType.xlDataLabelsShowNone);
    	} 



    	private ListObject FindListObject(string name)
    	{
    		var sheet = this.Application.ActiveWorkbook.ActiveSheet;
    		foreach (Excel.ListObject listObject in sheet.ListObjects)
    		{
    			if (listObject.Name == name)
    			{
    				var lo = Globals.Factory.GetVstoObject(listObject);
    				return lo;
    			}
    		}
    		return null;
    	}

    	private void AddSelectionChangeEventHandlers()
    	{
    		var listObject = FindListObject("netflixTitles");
    		listObject.Selected += listObject_Selected;
    		listObject.Deselected += listObject_Deselected;
    	}

    	private void listObject_Deselected(Range Target)
    	{
    		SetRibbonControlsState(false);
    	}

    	private void listObject_Selected(Range Target)
    	{
    		SetRibbonControlsState(true);
    	}

    	private void SetRibbonControlsState(bool state)
    	{
    		var ribbon = Globals.Ribbons.Ribbon1;
    		foreach (var ribbonControl in ribbon.grpSearch.Items)
    		{
    			ribbonControl.Enabled = state;
    		}
    	}

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}

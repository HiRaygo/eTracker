/*
 * Created by SharpDevelop.
 * User: XiaoSanya
 * Date: 2015/3/31
 * Time: 20:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Web;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Net;
using System.IO;
using System.Threading;

namespace eTracker
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private string fileName = null;
		private ExpressData[] eData = null;
		private int ALLNo =0;
		private int yQS = 0;
		private int yDQ = 0;
		private int yCX = 0;
		private int yZT = 0;
		private int yCC = 0;
		private bool isQuerying = false;
		private string errorMsg = null;
		private bool stopQuery = false;
		private delegate void ShowInfoCB();
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		
		void updateCounts()
		{
			while(isQuerying)
			{
				ShowInfoCB scb = new ShowInfoCB(ShowCounts);
				this.Invoke(scb);
				Thread.Sleep(1000);
			}
		}
		
		/// <summary>
		/// Show the Query count
		/// </summary>
		void ShowCounts()
		{
			labelQS.Text = yQS.ToString();
			labelCX.Text = yCX.ToString();
			labelZT.Text = yZT.ToString();
			labelCC.Text = yCC.ToString();
			labelDQ.Text = yDQ.ToString();
			labelALLNo.Text = ALLNo.ToString();
			
		}
		
		/// <summary>
		/// Show the Error Message
		/// </summary>
		void ShowErrMsg()
		{
			labelInfo.Text = errorMsg;
		}
		
		/// <summary>
		/// Open record excel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ButtonOpenClick(object sender, EventArgs e)
		{			
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Excel File（*.xls）|*.xls";
			ofd.FilterIndex = 1;
			ofd.RestoreDirectory = true;
			
			if (ofd.ShowDialog() == DialogResult.OK) {
				fileName = ofd.FileName;
				labelFilename.Text = fileName;
				this.buttonStart.Enabled = true;
				ALLNo =0;
				yQS = 0;
				yDQ = 0;
				yCX = 0;
				yZT = 0;
				yCC = 0;
			} else {
				fileName = null;
				labelFilename.Text = "未选择文件";
			}
		}
		
		/// <summary>
		/// 开始查询
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ButtonStartClick(object sender, EventArgs e)
		{
			labelInfo.Text = "正在分析订单信息...";
			this.Cursor = Cursors.WaitCursor;
			if(ReadExceltoList()){
				Thread tt = new Thread(new ThreadStart(StartQuery));
				tt.IsBackground = true;
				tt.Start();
				isQuerying = true;
				labelInfo.Text = "查询中...";
				Thread ts = new Thread(new ThreadStart(updateCounts));
				ts.IsBackground = true;
				ts.Start();
				this.buttonStop.Enabled = true;
				this.buttonStart.Enabled = false;
				this.buttonSave.Enabled = false;
			}
			else
				labelInfo.Text = "Excel文件有错误，请检查。" + errorMsg;
			this.Cursor = Cursors.Default;
		}
		
		/// <summary>
		/// Read Excel file to the List
		/// </summary>
		/// <returns></returns>
		private bool ReadExceltoList()
		{
			Excel.Application excelApp = new Excel.Application();
			Excel.Workbook workbook = null;
			object oMissiong = System.Reflection.Missing.Value;			
			if (excelApp == null)
			{
				errorMsg = "Open excel file failed.";
				excelApp.Quit();
				return false;
			}
			excelApp.Visible = false;
			
			try {
				workbook = excelApp.Workbooks.Open(fileName, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, 
					oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
				Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];  
				if (worksheet == null)
				{
					errorMsg = "Excel file not have sheet 1.";
					excelApp.Quit();
					return false;
				}
				
				int iRowCount = worksheet.UsedRange.Rows.Count;
				
				if(iRowCount < 2)
				{
					errorMsg = "Sheet has no data.";
					excelApp.Quit();
					return false;
				}
				ALLNo = iRowCount - 1;	
				eData = new ExpressData[ALLNo];
				Excel.Range rg1, rg2;
				int itmp = 0;
				for (int n = 0; n < ALLNo; n++) {
					eData[n] = new ExpressData();
					rg1 = (Excel.Range)worksheet.Cells[n + 2, 1];					
					eData[n].ExpressNo = rg1.Value2.ToString();
					
					if(itmp < 20)
					{
						rg2 = (Excel.Range)worksheet.Cells[n + 1, 3];
						if(rg2.Value2 == null)
						{
							eData[n].Status =null;
							itmp ++;
						}
						else
						{
							eData[n].Status = rg2.Value2.ToString();
							itmp = 0;
						}
					}
				}
				
			} catch (Exception ex) 
			{
				errorMsg = ex.Message;
				excelApp.Quit();
				return false;
			} 
			excelApp.Quit();	
			return true;
		}
		
		/// <summary>
		/// Save Result List to Excel
		/// </summary>
		/// <returns></returns>
		private bool SaveListtoExcel()
		{
			Excel.Application excelApp = new Excel.Application();
			Excel.Workbook workbook = null;
			object oMissiong = System.Reflection.Missing.Value;			
			if (excelApp == null)
			{
				errorMsg = "Open excel file failed.";
				excelApp.Quit();
				return false;
			}
			excelApp.Visible = false;
			
			try {
				workbook = excelApp.Workbooks.Open(fileName, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, 
					oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
				Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];  
				if (worksheet == null)
				{
					errorMsg = "Excel file not have sheet 1.";
					excelApp.Quit();
					return false;
				}
				
				int nlen = eData.Length;
				Excel.Range rg;
				int yBC = 0;
				for( int n = 0; n< ALLNo; n++)
				{
					if(eData[n] != null)
					{
						if(eData[n].Saved)
							continue;
						rg = (Excel.Range)worksheet.Cells[n + 2, 3];
						rg.Value2 = eData[n].Status;
						rg = (Excel.Range)worksheet.Cells[n + 2, 4];
						rg.Value2 = eData[n].Recvtime;
						yBC++;
						if(yBC >= yCX)
							break;
					}
				}			
				
			} catch (Exception ex) 
			{
				errorMsg = ex.Message;
				excelApp.Quit();
				return false;
			} 
			excelApp.Quit();	
			return true;
		}
		
		/// <summary>
		/// Start to Query
		/// </summary>
		private void StartQuery()
		{
			if(eData == null)
			{
				errorMsg = "No data.";
				return;
			}
			isQuerying = true;
			
			for(int index = 0; index< ALLNo; index++)
			{
				string es = eData[index].Status;
				if((es == null)||(!string.Equals(es, "QS")))
				{
					Thread thr = new Thread(new ParameterizedThreadStart(QueryWork));
					thr.IsBackground =true;
					object oj = index;
					thr.Start(oj);
					Thread.Sleep(2000);
				}
				else{
					eData[index].Saved = true;
				}
				if(stopQuery)
					break;
			}
			isQuerying = false;
		}
		
		/// <summary>
		/// Query Work Loop
		/// </summary>
		/// <param name="oj"></param>
		private void QueryWork(object oj)
		{
			int index = (int)oj;
			string expressno = eData[index].ExpressNo;
			string url = "http://www.17track.net/r/handlertrack.ashx?callback=jQuery"+ expressno +"&num=" + expressno;
			string jsontext;
			if(GetJsonData(url, out jsontext))
			{
				if(!ParseJsonString(index, jsontext))
				{					
					yCC++;
				}
				yCX++;
			}
			else
			{
				yCC++;
				yCX++;
			}
		}
		/// <summary>
		/// Get Json data from the url
		/// </summary>
		/// <param name="getUrl">Url to query</param>
		/// <param name="jsonText">Response Json</param>
		/// <returns></returns>
		public bool GetJsonData(string getUrl, out string jsonText)
		{
			Thread.Sleep(100);
			HttpWebRequest httpWebRequest = null;
			HttpWebResponse httpWebResponse = null;
			try {
				httpWebRequest = HttpWebRequest.Create(getUrl) as HttpWebRequest;
				httpWebRequest.ContentType = "application/x-www-form-urlencoded";
				httpWebRequest.ServicePoint.ConnectionLimit = 60000;
				httpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
				httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.89 Safari/537.36";
				httpWebRequest.Method = "GET";
				httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
				jsonText = streamReader.ReadToEnd();
				streamReader.Close();
				responseStream.Close();
				httpWebRequest.Abort();
				httpWebResponse.Close();
				return true;
			} catch {
				if (httpWebRequest != null)
					httpWebRequest.Abort();
				if (httpWebResponse != null)
					httpWebResponse.Close();
				jsonText ="";
				return false;
			}
		}
		
		/// <summary>
		/// Parse Json String
		/// </summary>
		/// <param name="index"></param>
		/// <param name="jsonText"></param>
		/// <returns></returns>
		private bool ParseJsonString(int index, string jsonText)
		{	
			int len = jsonText.Length;
			if(len < 21)
			{
				eData[index].Status = "CW";
				eData[index].Recvtime = "";
				eData[index].Arrived = false;
				return false;
			}
			string jsonstring = jsonText.Substring(20, len-21);
			
			JObject jo = (JObject)JsonConvert.DeserializeObject(jsonstring);
			JToken ret;
			if(!(jo.TryGetValue("ret", out ret)))
			{
				return false;
			}
			if(ret.ToString() != "1")
			{
				return false;
			}
			JToken dat;
			if(jo.TryGetValue("dat",out dat))
			{
				int acode = dat.Value<int>("e");
				if(acode == 40)
				{
					eData[index].Status = "QS";
					eData[index].Arrived = true;
					eData[index].Recvtime = dat.SelectToken("z0.a",false).ToString().Substring(0,10);
					yQS++;
				}
				else
				{ 
					if(acode == 30)
					{
						eData[index].Status = "DQ";
						yDQ++;
					}
					else if(acode == 10)
					{
				    	eData[index].Status = "ZT";
				    	yZT++;
					}
				    else
				    {
				    	eData[index].Status = "CW";
				    	yCC++;
				    }
				    
				    eData[index].Recvtime = "";
					eData[index].Arrived = false;
				}
				return true;
			}
			else
			{
				eData[index].Status = "CW";
				eData[index].Recvtime = "";
				eData[index].Arrived = false;
				return false;
			}
		}

		
		/// <summary>
		/// 停止
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ButtonStopClick(object sender, EventArgs e)
		{
			stopQuery = true;
			labelInfo.Text = "正在停止,请稍后...";
			
			Thread tt = new Thread(new ThreadStart(StopResultUpdate));
			tt.IsBackground = true;
			tt.Start();
			
			this.buttonStart.Enabled = true;
			this.buttonSave.Enabled = true;
			this.buttonStop.Enabled = false;

		}
		
		void StopResultUpdate()
		{
			while(isQuerying)
			{
				Thread.Sleep(500);
			}
			errorMsg = "已停止查询，请保存结果。";
			ShowInfoCB scb = new ShowInfoCB(ShowErrMsg);
			this.Invoke(scb);
		}
		/// <summary>
		/// 保存查询结果
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ButtonSaveClick(object sender, EventArgs e)
		{
			labelInfo.Text = "正在保存，请稍侯...";
			Thread tt = new Thread(new ThreadStart(SaveThread));
			tt.IsBackground = true;
			tt.Start();
		}
		
		void SaveThread()
		{
			if(SaveListtoExcel())
				errorMsg = "保存成功";
			else
				errorMsg = "保存失败";
			ShowInfoCB scb = new ShowInfoCB(ShowErrMsg);
			this.Invoke(scb);
		}
		
	}
	
	public class ExpressData
	{
		public string ExpressNo {get; set;}
		public string Country {get; set;}
		public string Status {get; set;}
		public string Recvtime {get; set;}
		public bool Arrived {get; set;}
		public bool Saved{get; set;}
	}
}

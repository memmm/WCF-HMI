using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;

namespace HmiStyle.Language
{

	public class Language
	{
        public static event EventHandler OnLanguageChanged;
		public static ComponentResourceManager _resources;
		public static string _lanuage = "en";

		public static Dictionary<object, string> _translatesComponents = new Dictionary<object, string>();

		//Public Shared Sub GetAllLanguageControl(ByRef control As Control, ByVal lang As String)
		//    _resources.ApplyResources(control, control.Name, New CultureInfo(lang))
		//    For Each c As Control In control.Controls
		//        GetAllLanguageControl(c, lang)
		//    Next
		//End Sub

		//Public Shared Sub ChangeLanguageOnAllForms(lang As String, frm As Form)
		//    _resources = New ComponentResourceManager(frm.GetType())
		//    GetAllLanguageControl(frm, lang)
		//End Sub

	    public Language()
	    {
            // fire property changed event when language is changed
            //OnLanguageChanged += (s, e) => OnPropertyChanged("Item[]");
	    }
        
        [IndexerName("Item")]
	    public string this[string sText]
	    {
            get { return Translate(sText); }
	    }
        

  //      private static void GetAllLanguageControl(ref System.Windows.Forms.Control control, string sLanguage, bool bReloadLanguageFile = false, bool bSaveOriginalText = false)
		//{
		//	if ((bReloadLanguageFile)) {
		//		string sFileName = string.Format("{0}\\Language\\{1}.txt", Application.StartupPath, sLanguage);
		//		LoadLanguage(sFileName);
		//	}
		//	GetAllLanguageControl(control, bAddToList: bSaveOriginalText);
		//}


		public static string Translate(string sName)
		{
			LanguageItem li = LanguageItem.GetByName(sName);

			if ((li != null)) {
				return li.Caption;
			}

			return string.Format("@{0}", sName);
		}


		private static void Translate(object comp, bool bAddToList)
		{
			string sText = "";
			string sOriginalText = "";
			bool bTranslated = true;
			bool bInList = bAddToList && _translatesComponents.TryGetValue(comp, out sOriginalText);


			//if ((!bInList)) {
			//	if ((comp is System.Windows.Controls.Control)) {
   //                 sOriginalText = ((System.Windows.Controls.Control)comp).;
			//	} else if ((comp is ToolStripItem)) {
			//		sOriginalText = ((ToolStripItem)comp).Text;
			//	} else if ((comp is DataGridViewColumn)) {
			//		sOriginalText = ((DataGridViewColumn)comp).HeaderText;
			//	} else {
			//		return;
			//	}
			}


			//if ((!string.IsNullOrEmpty(sOriginalText))) {
			//	var iPos = sOriginalText.IndexOf('@');

			//	if ((iPos >= 0)) {
			//		string sName = sOriginalText.Substring(iPos + 1);
			//		var sLeft = "";

			//		if ((iPos > 0)) {
			//			sLeft = sOriginalText.Substring(0, iPos);
			//		}


			//		//Detect ':' in the name
			//		int iColon = sName.IndexOf(':');
			//		char cFiltered = '\0';
			//		if ((iColon > 0)) {
			//			cFiltered = sName.Substring(iColon, 1)[0];
			//			sName = sName.Substring(0, iColon);
			//		}

			//		LanguageItem li = LanguageItem.GetByName(sName);

			//		if ((li != null)) {
			//			sText = string.Format("{0}{1}{2}", sLeft, li.Caption, (iColon > 0 ? cFiltered.ToString() : ""));

   //                     if ((comp is System.Windows.Forms.Control))
   //                     {
   //                         ((System.Windows.Forms.Control)comp).Text = sText;
			//			} else if ((comp is ToolStripItem)) {
			//				((ToolStripItem)comp).Text = sText;
			//			} else if ((comp is DataGridViewColumn)) {
			//				((DataGridViewColumn)comp).HeaderText = sText;


			//			} else {
			//				bTranslated = false;
			//			}

			//			if ((bTranslated && !bInList && bAddToList)) {
			//				_translatesComponents.Add(comp, sOriginalText);
			//			}
			//		}
			//	}


			
		}


	//	private static void GetAllLanguageControl(System.Windows.Controls.Control control, bool bAddToList)
	//	{

	//		//-- <Control> Check for controls in the contro
	//		if ((control != null && control.Count > 0)) {
 //               foreach (System.Windows.Forms.Control c in control.Controls)
 //               {
	//				GetAllLanguageControl(c, bAddToList);
	//			}
	//		}

	//		//-- <ToolStrip> Check for ToolStripItems in the control
	//		if ((control is ToolStrip)) {
	//			ToolStrip ts = (ToolStrip)control;

	//			foreach (ToolStripItem item in ts.Items) {
	//				Translate(item, bAddToList);
	//			}
	//		}


	//		Translate(control, bAddToList);
	//	}

	//	public static int LoadLanguage(string sFileName)
	//	{

	//		GetLanguages();
	//		//-- Check for file
	//		if ((!File.Exists(sFileName))) {
	//			return -1;
	//			//-- file doesn't exists
	//		}

	//		using (StreamReader sr = new StreamReader(sFileName)) {
	//			while ((!sr.EndOfStream)) {
	//				string sLine = sr.ReadLine();

	//				int iPos = sLine.IndexOf('=');

	//				if ((iPos >= 0)) {
	//					string sName = sLine.Substring(0, iPos);
	//					string sCaption = sLine.Substring(iPos + 1);

	//					sCaption = sCaption.Replace("\\n", Constants.vbCrLf);
	//					LanguageItem.Create(sName, sCaption);
	//				}
	//			}
	//		}

	//	    if (OnLanguageChanged != null)
	//	    {
	//	        OnLanguageChanged(null, null);
	//	    }
	//	    return 0;
	//	}

	//	public static List<CultureInfo> GetLanguages()
	//	{
	//		dynamic cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
	//		return null;
	//	}

        


 //       public static object LoadLanguage(System.Windows.Forms.Control control, string sLanguage = "", bool bReloadLanguageFile = false, bool bSaveOriginalText = false)
	//	{
	//		GetAllLanguageControl(ref control, sLanguage, bReloadLanguageFile, bSaveOriginalText);

	//		return 0;
	//	}

	//    public event PropertyChangedEventHandler PropertyChanged;

	//    [NotifyPropertyChangedInvocator]
	//    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	//    {
	//        var handler = PropertyChanged;
	//        if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
	//    }
	//}


}



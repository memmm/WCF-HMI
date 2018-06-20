using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HmiStyle.Language
{

	public class LanguageItem : INotifyPropertyChanged
	{

		private static Dictionary<string, LanguageItem> _list = new Dictionary<string, LanguageItem>();
		private string _name = "";

		private string _caption = "";
		private LanguageItem(string sName, string sCaption)
		{
			_name = sName;
			_caption = sCaption;
		}


		public static Dictionary<string, LanguageItem> List {
			get { return _list; }
			set { _list = value; }
		}

		public string Name {
			get { return _name; }
			set {
				_name = value;
				OnPropertyChanged();
			}
		}

		public string Caption {
			get { return _caption; }
			set {
				_caption = value;
				OnPropertyChanged();
			}
		}

		public static LanguageItem GetByName(string sName)
		{
			LanguageItem li = null;
			_list.TryGetValue(sName.ToLower(), out li);
			return li;
		}

		public static int Add(LanguageItem liNew)
		{
			string sKey = liNew.Name.Trim().ToLower();

			var liOld = GetByName(sKey);

			if ((liOld != null)) {
				liOld.Caption = liNew.Caption;
				return 1;
				//-- update existing item
			}

			_list.Add(sKey, liNew);
			return 0;
			//-- Add new item
		}


		public static void Create(string sName, string sCaption)
		{
			Add(new LanguageItem(sName, sCaption));
		}

	    public event PropertyChangedEventHandler PropertyChanged;

	    
	    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	    {
	        var handler = PropertyChanged;
	        if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
	    }
	}
}


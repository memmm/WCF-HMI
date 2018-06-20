namespace HmiStyle.Language
{
    public class LanguageControl
    {
        private System.Windows.Controls.Control _control;
        private string _name;
        private LanguageItem withEventsField__languageItem = null;
        private LanguageItem _languageItem
        {
            get { return withEventsField__languageItem; }
            set
            {
                if (withEventsField__languageItem != null)
                {
                    withEventsField__languageItem.PropertyChanged -= _languageItem_PropertyChanged;
                }
                withEventsField__languageItem = value;
                if (withEventsField__languageItem != null)
                {
                    withEventsField__languageItem.PropertyChanged += _languageItem_PropertyChanged;
                }
            }

        }
        public LanguageControl(string sName, System.Windows.Controls.Control control, LanguageItem languageItem)
        {
            _name = sName;
            _control = control;
            _languageItem = languageItem;
        }

        public System.Windows.Controls.Control Control
        {
            get { return _control; }
            set { _control = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private void _languageItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if ((e.PropertyName == "Caption"))
            {
                //_control.Text = _languageItem.Caption;
            }
        }
    }
}


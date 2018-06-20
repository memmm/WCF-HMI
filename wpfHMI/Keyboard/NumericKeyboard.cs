using System;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HmiStyle.Keyboard
{
    public class NumericKeyboard : Window
    {
        #region Property & Variable & Constructor
        private static double _WidthTouchKeyboard = 310;
        private static double _HeightTouchKeyboard = 250;

        public static double WidthTouchKeyboard
        {
            get { return _WidthTouchKeyboard; }
            set { _WidthTouchKeyboard = value; }

        }

        public static double HeightTouchKeyboard
        {
            get { return _HeightTouchKeyboard; }
            set { _HeightTouchKeyboard = value; }

        }
 

        private static Window _InstanceObject;

        private static Control _CurrentControl;
        public static string NumericTextText
        {
            get
            {
                if (_CurrentControl is TextBox)
                {
                    return ((TextBox)_CurrentControl).Text;
                }
                else if (_CurrentControl is PasswordBox)
                {
                    return ((PasswordBox)_CurrentControl).Password;
                }
                else if (_CurrentControl is DataGridCell)
                {
                    //var cellInfo = ((DataGridRow)_CurrentControl);
                    //var content = cellInfo.GetIndex().ToString();
                    //return content;
                    var cont = (TextBox)((DataGridCell)_CurrentControl).Content;
                    return cont.Text;
                }
                else return "";


            }
            set
            {
                if (_CurrentControl is TextBox)
                {
                    ((TextBox)_CurrentControl).Text = value;
                }
                else if (_CurrentControl is PasswordBox)
                {
                    ((PasswordBox)_CurrentControl).Password = value;
                }
                else if (_CurrentControl is DataGridCell)
                {
                    //var cellInfo = ((DataGrid)_CurrentControl).SelectedCells[0];
                    //var content = cellInfo.Column.GetCellContent(cellInfo.Item).ToString();
                    //content = value;
                    var cont = (TextBox)((DataGridCell)_CurrentControl).Content;
                    cont.Text = value;
                }


            }

        }

        public static RoutedUICommand Cmd7 = new RoutedUICommand();
        public static RoutedUICommand Cmd8 = new RoutedUICommand();
        public static RoutedUICommand Cmd9 = new RoutedUICommand();
        public static RoutedUICommand CmdClear = new RoutedUICommand();

        public static RoutedUICommand Cmd4 = new RoutedUICommand();
        public static RoutedUICommand Cmd5 = new RoutedUICommand();
        public static RoutedUICommand Cmd6 = new RoutedUICommand();
        public static RoutedUICommand CmdBackspace = new RoutedUICommand();

        public static RoutedUICommand Cmd1 = new RoutedUICommand();
        public static RoutedUICommand Cmd2 = new RoutedUICommand();
        public static RoutedUICommand Cmd3 = new RoutedUICommand();
        public static RoutedUICommand CmdEnter = new RoutedUICommand();

        public static RoutedUICommand Cmd0 = new RoutedUICommand();
        public static RoutedUICommand CmdColon = new RoutedUICommand();
        public static RoutedUICommand CmdDot = new RoutedUICommand();


        public NumericKeyboard()
        {
            this.Width = WidthTouchKeyboard;
            this.Height = HeightTouchKeyboard;

        }

        static NumericKeyboard()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericKeyboard), new FrameworkPropertyMetadata(typeof(NumericKeyboard)));

            SetCommandBinding();
        }
        #endregion
        #region CommandRelatedCode
        private static void SetCommandBinding()
        {
            CommandBinding Cb1 = new CommandBinding(Cmd1, RunCommand);
            CommandBinding Cb2 = new CommandBinding(Cmd2, RunCommand);
            CommandBinding Cb3 = new CommandBinding(Cmd3, RunCommand);
            CommandBinding Cb4 = new CommandBinding(Cmd4, RunCommand);
            CommandBinding Cb5 = new CommandBinding(Cmd5, RunCommand);
            CommandBinding Cb6 = new CommandBinding(Cmd6, RunCommand);
            CommandBinding Cb7 = new CommandBinding(Cmd7, RunCommand);
            CommandBinding Cb8 = new CommandBinding(Cmd8, RunCommand);
            CommandBinding Cb9 = new CommandBinding(Cmd9, RunCommand);
            CommandBinding Cb0 = new CommandBinding(Cmd0, RunCommand);

            CommandBinding CbClear = new CommandBinding(CmdClear, RunCommand);
            CommandBinding CbBackspace = new CommandBinding(CmdBackspace, RunCommand);
            CommandBinding CbEnter = new CommandBinding(CmdEnter, RunCommand);
            CommandBinding CbColon = new CommandBinding(CmdColon, RunCommand);
            CommandBinding CbDot = new CommandBinding(CmdDot, RunCommand);
 

            CommandManager.RegisterClassCommandBinding(typeof(NumericKeyboard), Cb1);
            CommandManager.RegisterClassCommandBinding(typeof(NumericKeyboard), Cb2);
            CommandManager.RegisterClassCommandBinding(typeof(NumericKeyboard), Cb3);
            CommandManager.RegisterClassCommandBinding(typeof(NumericKeyboard), Cb4);
            CommandManager.RegisterClassCommandBinding(typeof(NumericKeyboard), Cb5);
            CommandManager.RegisterClassCommandBinding(typeof(NumericKeyboard), Cb6);
            CommandManager.RegisterClassCommandBinding(typeof(NumericKeyboard), Cb7);
            CommandManager.RegisterClassCommandBinding(typeof(NumericKeyboard), Cb8);
            CommandManager.RegisterClassCommandBinding(typeof(NumericKeyboard), Cb9);
            CommandManager.RegisterClassCommandBinding(typeof(NumericKeyboard), Cb0);

            CommandManager.RegisterClassCommandBinding(typeof(NumericKeyboard), CbClear);
            CommandManager.RegisterClassCommandBinding(typeof(NumericKeyboard), CbBackspace);
            CommandManager.RegisterClassCommandBinding(typeof(NumericKeyboard), CbEnter);     
            CommandManager.RegisterClassCommandBinding(typeof(NumericKeyboard), CbColon);
            CommandManager.RegisterClassCommandBinding(typeof(NumericKeyboard), CbDot);

        }
        static void RunCommand(object sender, ExecutedRoutedEventArgs e)
        {

            if (e.Command == Cmd1) //First Row
            {
                 NumericKeyboard.NumericTextText += "1";           
            }
            else if (e.Command == Cmd2)
            {    
                    NumericKeyboard.NumericTextText += "2";
            }
            else if (e.Command == Cmd3)
            { 
                    NumericKeyboard.NumericTextText += "3";
            }
            else if (e.Command == Cmd4)
            {
                    NumericKeyboard.NumericTextText += "4";

            }
            else if (e.Command == Cmd5)
            {
                    NumericKeyboard.NumericTextText += "5";
            }
            else if (e.Command == Cmd6)
            {
                    NumericKeyboard.NumericTextText += "6";
            }
            else if (e.Command == Cmd7)
            {
                    NumericKeyboard.NumericTextText += "7";
            }
            else if (e.Command == Cmd8)
            { 
                    NumericKeyboard.NumericTextText += "8";
            }
            else if (e.Command == Cmd9)
            {
                    NumericKeyboard.NumericTextText += "9";
            }
            else if (e.Command == Cmd0)
            {
                    NumericKeyboard.NumericTextText += "0";
            }


            else if (e.Command == CmdClear)
            {

                NumericKeyboard.NumericTextText = "";
            }
            else if (e.Command == CmdBackspace)
            {
                if (!string.IsNullOrEmpty(NumericKeyboard.NumericTextText))
                {
                    NumericKeyboard.NumericTextText = NumericKeyboard.NumericTextText.Substring(0, NumericKeyboard.NumericTextText.Length - 1);
                }

            }
            else if (e.Command == CmdEnter)
            {
                if (_InstanceObject != null)
                {
                    _InstanceObject.Close();
                    _InstanceObject = null;
                }
                //_CurrentControl.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
            else if (e.Command == CmdColon)
            {
                NumericKeyboard.NumericTextText += ",";
            }
            else if (e.Command == CmdDot)
            {
               NumericKeyboard.NumericTextText += ".";
                    
            }
          
            
        }
        #endregion
        #region Main Functionality
        private static void AddKeyBoardINput(char input)
        {
                    NumericKeyboard.NumericTextText += char.ToLower(input).ToString();             
        }

        //arranges the keyboard according to the position of the focused control and the screen
        private static void syncchild()
        {
            if (_CurrentControl != null && _InstanceObject != null)
            {

                Point virtualpoint = new Point(0, _CurrentControl.ActualHeight + 3);
                Point Actualpoint = _CurrentControl.PointToScreen(virtualpoint);

                if (WidthTouchKeyboard + Actualpoint.X > SystemParameters.VirtualScreenWidth)
                {
                    double difference = WidthTouchKeyboard + Actualpoint.X - SystemParameters.VirtualScreenWidth;
                    _InstanceObject.Left = Actualpoint.X - difference;
                }
                else if (!(Actualpoint.X > 1))
                {
                    _InstanceObject.Left = 1;
                }
                else
                    _InstanceObject.Left = Actualpoint.X;

                if (HeightTouchKeyboard + Actualpoint.Y > SystemParameters.VirtualScreenHeight)
                {
                    double difference = HeightTouchKeyboard + Actualpoint.Y - SystemParameters.VirtualScreenHeight;
                    _InstanceObject.Top = Actualpoint.Y - difference;
                }
                else if (!(Actualpoint.Y > 1))
                {
                    _InstanceObject.Top = 1;
                }
                else
                    _InstanceObject.Top = Actualpoint.Y;


                // _InstanceObject.Top = Actualpoint.Y;
                _InstanceObject.Show();
            }


        }

        public static bool GetNumericKeyboard(DependencyObject obj)
        {
            return (bool)obj.GetValue(NumericKeyboardProperty);
        }

        public static void SetNumericKeyboard(DependencyObject obj, bool value)
        {
            obj.SetValue(NumericKeyboardProperty, value);
        }

        public static readonly DependencyProperty NumericKeyboardProperty =
            DependencyProperty.RegisterAttached("NumericKeyboard", typeof(bool), typeof(NumericKeyboard), new UIPropertyMetadata(default(bool), NumericKeyboardPropertyChanged));



        static void NumericKeyboardPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement host = sender as FrameworkElement;
            if (host != null)
            {
                host.GotFocus += new RoutedEventHandler(OnGotFocus);
                host.LostFocus += new RoutedEventHandler(OnLostFocus);
            }
        }



        static void OnGotFocus(object sender, RoutedEventArgs e)
        {
            Control host = sender as Control;

            _CurrentControl = host;

            if (_InstanceObject == null)
            {
                FrameworkElement ct = host;
                while (true)
                {
                    if (ct is Window)
                    {
                        ((Window)ct).LocationChanged += new EventHandler(NumericKeyboard_LocationChanged);
                        ((Window)ct).Activated += new EventHandler(NumericKeyboard_Activated);
                        ((Window)ct).Deactivated += new EventHandler(NumericKeyboard_Deactivated);
                        break;
                    }
                    if (_CurrentControl.GetType() == typeof(TextBox) || _CurrentControl.GetType() == typeof(PasswordBox))
                        ct = (FrameworkElement)ct.Parent;
                    else if (_CurrentControl.GetType() == typeof(DataGridCell))
                    {
                        ct = (FrameworkElement)VisualTreeHelper.GetParent(ct);                        
                    }
                }

                _InstanceObject = new NumericKeyboard();
                _InstanceObject.AllowsTransparency = true;
                _InstanceObject.WindowStyle = WindowStyle.None;
                _InstanceObject.ShowInTaskbar = false;
                _InstanceObject.ShowInTaskbar = false;
                _InstanceObject.Topmost = true;

                host.LayoutUpdated += new EventHandler(tb_LayoutUpdated);
            }



        }

        static void NumericKeyboard_Deactivated(object sender, EventArgs e)
        {
            if (_InstanceObject != null)
            {
                _InstanceObject.Topmost = false;
            }
        }

        static void NumericKeyboard_Activated(object sender, EventArgs e)
        {
            if (_InstanceObject != null)
            {
                _InstanceObject.Topmost = true;
            }
        }



        static void NumericKeyboard_LocationChanged(object sender, EventArgs e)
        {
            syncchild();
        }

        static void tb_LayoutUpdated(object sender, EventArgs e)
        {
            syncchild();
        }



        static void OnLostFocus(object sender, RoutedEventArgs e)
        {

            Control host = sender as Control;
     
            if (_InstanceObject != null)
            {
                _InstanceObject.Close();
                _InstanceObject = null;
            }
        }

        #endregion
    }
}

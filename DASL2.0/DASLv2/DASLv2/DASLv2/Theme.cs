using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace DASLv2
{
    public class ColorScheme
    {
        public ColorScheme(string mainColor, string altColor, string bgColor)
        {
            this.mainColor = mainColor;
            this.altColor = altColor;
            this.bgColor = bgColor;
        }
        public ColorScheme()
        {
            this.mainColor = null;
            this.altColor = null;
            this.bgColor = null;
        }
//        public static string theme = Color.Orange.ToString();
        public string mainColor { get; set; }
        public string altColor { get; set; }
        public string bgColor { get; set; }
    }

    public static class Theme
    {
        public static ColorScheme orangeTheme => new ColorScheme("#ffa500", "#000000","#fff");
        public static ColorScheme blueTheme => new ColorScheme("#00bfff", "#00353b", "#fff");
        public static ColorScheme greenTheme => new ColorScheme("#499272", "#003a21", "#fff");
        public static ColorScheme purpleTheme => new ColorScheme("#ba709a", "#1f022f", "#fff");
        public static ColorScheme lowVisionTheme => new ColorScheme("#eee", "#222", "#fff");
        public static ColorScheme currentTheme = new ColorScheme();
        public static bool themeChange = false;        

        //set binding number
        private static int _currentTheme;
        public static int CurrentTheme
        {
            get { return _currentTheme; }
            set
            {
                if (_currentTheme != value)
                {
                    _currentTheme = value;
                }
            }
        }
    }
    public class ThemeViewModel : INotifyPropertyChanged
    {

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string MainColor
        {
            get { return Theme.currentTheme.mainColor; }
            set
            {
                Theme.currentTheme.mainColor = value;
                OnPropertyChanged();
            }
        }
        public string AltColor
        {
            get { return Theme.currentTheme.altColor; }
            set {
                Theme.currentTheme.altColor = value;
                OnPropertyChanged();
            }
        }
        public string ABgColor
        {
            get { return Theme.currentTheme.bgColor; }
            set
            {
                Theme.currentTheme.bgColor = value;
                OnPropertyChanged();
            }
        }
        public string ThemeNum
        {
            get { return Theme.CurrentTheme.ToString(); }
            set {
                Theme.CurrentTheme = Convert.ToInt32(value);
                ThemeChange();
                OnPropertyChanged();
                OnPropertyChanged(nameof(MainColor));
                OnPropertyChanged(nameof(AltColor));
            }
        }
        private void ThemeChange()
        {
            switch (Theme.CurrentTheme)
            {

                case 0:
                    Theme.currentTheme = Theme.orangeTheme;
                    break;
                case 1:
                    Theme.currentTheme = Theme.greenTheme;
                    break;
                case 2:
                    Theme.currentTheme = Theme.purpleTheme;
                    break;
                case 3:
                    Theme.currentTheme = Theme.blueTheme;
                    break;
                case 4:
                    Theme.currentTheme = Theme.lowVisionTheme;
                    break;
            }
            Xamarin.Forms.Application.Current.Properties["Theme"] = Theme.CurrentTheme.ToString();
            Xamarin.Forms.Application.Current.Properties["MainColor"] = Theme.currentTheme.mainColor;
            Xamarin.Forms.Application.Current.Properties["AltColor"] = Theme.currentTheme.altColor;
            Xamarin.Forms.Application.Current.Properties["BgColor"] = Theme.currentTheme.bgColor;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }


}


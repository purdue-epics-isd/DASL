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
        public string mainColor { get; set; }
        public string altColor { get; set; }
        public string bgColor { get; set; }
    }

    public static class Theme
    {
        //Define Color Schemes here
        public static ColorScheme orangeTheme => new ColorScheme("#f86501", "#291000","#ffa060");
        public static ColorScheme blueTheme => new ColorScheme("#488ada", "#0c315d", "#a6ceff");
        public static ColorScheme greenTheme => new ColorScheme("#00a32b", "#004312", "#57f781");
        public static ColorScheme redTheme => new ColorScheme("#f80d01", "#400300", "#ff8882");
        public static ColorScheme whiteTheme => new ColorScheme("#ffeda8", "#604b00", "#eee");
        public static ColorScheme currentTheme = new ColorScheme();
        public static bool themeChange = false;        

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
        public string BgColor
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
                OnPropertyChanged(nameof(BgColor));
            }
        }
        public string imgPath
        {
            get {
                if (Xamarin.Forms.Application.Current.Properties.ContainsKey("ImgPath"))
                    return Xamarin.Forms.Application.Current.Properties["ImgPath"].ToString();
                else
                    return "Images//profilepicture.jpg";
            }
            set {
                OnPropertyChanged();
                Xamarin.Forms.Application.Current.Properties["ImgPath"] = value;
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
                    Theme.currentTheme = Theme.redTheme;
                    break;
                case 3:
                    Theme.currentTheme = Theme.blueTheme;
                    break;
                case 4:
                    Theme.currentTheme = Theme.whiteTheme;
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


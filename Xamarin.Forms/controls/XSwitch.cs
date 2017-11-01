using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace YourProject.Controls
{
    public class XSwitch : ContentView
    {
        private string Platform = Device.RuntimePlatform;
        private Switch mySwitch;
        private Label myLabel;

        public Command OnToggleChanged { get; set; }
        public static readonly BindableProperty OnToggleChangedProperty = BindableProperty.Create("OnToggleChanged", typeof(Command), typeof(XSwitch), new Command(() => { }), BindingMode.TwoWay);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); OnPropertyChanged("Text"); }
        }
        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(XSwitch), "");

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); OnPropertyChanged("TextColor"); }
        }
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create("TextColor", typeof(Color), typeof(XSwitch), Color.Default);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); OnPropertyChanged("fontsize"); }
        }
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create("FontSize", typeof(double), typeof(XSwitch), Device.GetNamedSize(NamedSize.Default, typeof(Label)));

        public FontAttributes FontAttributes
        {
            get { return (FontAttributes)GetValue(FontAttributesProperty); }
            set { SetValue(FontAttributesProperty, value); OnPropertyChanged("FontAttributes"); }
        }
        public static readonly BindableProperty FontAttributesProperty = BindableProperty.Create("FontAttributes", typeof(FontAttributes), typeof(XSwitch), FontAttributes.None);

        public bool IsToggled
        {
            get { return (bool)GetValue(IsToggledProperty); }
            set { SetValue(IsToggledProperty, value); }
        }
        public static readonly BindableProperty IsToggledProperty = BindableProperty.Create("IsToggled", typeof(bool), typeof(XSwitch), false, BindingMode.TwoWay);

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }
        public new static readonly BindableProperty IsEnabledProperty = BindableProperty.Create("IsToggled", typeof(bool), typeof(XSwitch), true, BindingMode.TwoWay, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = bindable as XSwitch;
            control.mySwitch.IsEnabled = (bool)newValue;
        });

        public XSwitch()
        {
            mySwitch = new Switch();
            mySwitch.SetBinding(Switch.IsToggledProperty, new Binding("IsToggled", BindingMode.TwoWay, source: this));
            //mySwitch.SetBinding(Switch.IsEnabledProperty, new Binding("IsEnabled", BindingMode.TwoWay, source: this));

            myLabel = new Label() { Text = "Default Text", Margin = GetLabelMargin() };
            myLabel.SetBinding(Label.TextProperty, new Binding("Text", BindingMode.TwoWay, source: this));
            myLabel.SetBinding(Label.TextColorProperty, new Binding("TextColor", BindingMode.TwoWay, source: this));
            myLabel.SetBinding(Label.FontSizeProperty, new Binding("FontSize", BindingMode.TwoWay, source: this));
            myLabel.SetBinding(Label.FontAttributesProperty, new Binding("FontAttributes", BindingMode.TwoWay, source: this));
            myLabel.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    mySwitch.IsToggled = !mySwitch.IsToggled;
                })
            });

            Content = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Start,
                Margin = new Thickness(0, 10, 0, 0),
                Children = { myLabel, mySwitch }
            };
        }

        private Thickness GetLabelMargin()
        {
            Thickness labelMargin = new Thickness(0);
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                case Device.Android:
                    labelMargin = new Thickness(0, 5, 5, 0);
                    break;

                case Device.WinPhone:
                case Device.Windows:
                    labelMargin = new Thickness(0, 8, 5, 0);
                    break;
            }
            return labelMargin;
        }
    }
}
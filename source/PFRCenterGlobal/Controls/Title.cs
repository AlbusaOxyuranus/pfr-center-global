using System;
using Xamarin.Forms;

namespace PFRCenterGlobal.Controls
{
    public class Title : Label
    {
        public bool TextUpper
        {
            set => SetValue(TextUpperProperty, value);
            get => (bool)GetValue(TextUpperProperty);
        }

        public static readonly BindableProperty TextUpperProperty =
    BindableProperty.Create(nameof(TextUpper), typeof(bool), typeof(Title),
                default(string), propertyChanging: OnChangedText);

        private static void OnChangedText(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue == null)
                return;
            if (newValue != oldValue)
            {
                var control = bindable as Title;
                if ((bool)newValue)
                {
                    if(control.Text!=null)
                        control.Text = control.Text.ToUpper();
                }
            }
        }
    }
    
}

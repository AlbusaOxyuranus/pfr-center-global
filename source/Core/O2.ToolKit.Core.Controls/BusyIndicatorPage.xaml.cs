using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace O2.ToolKit.Core.Controls
{
    public partial class BusyIndicatorPage : ContentPage
    {
        private BusyIndicatorControl _busyIndicator;

        public BusyIndicatorPage()
        {
            _busyIndicator = new BusyIndicatorControl();

        }

        public BusyIndicatorControl BusyIndicator
        {
            get { return _busyIndicator; }
            set
            {
                _busyIndicator = value;

            }
        }

        protected void CreateIndicate(Grid rootGrid)
        {
            _busyIndicator.IsVisible = false;
            _busyIndicator.HorizontalOptions = LayoutOptions.Fill;
            _busyIndicator.VerticalOptions = LayoutOptions.Fill;

            rootGrid.Children.Add(_busyIndicator);
            Grid.SetRowSpan(_busyIndicator, 2);
        }
    }
}

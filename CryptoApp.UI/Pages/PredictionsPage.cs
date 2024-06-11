﻿using CryptoApp.UI.Attributes;
using CryptoApp.UI.Pages.BasePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.Pages
{
    [PageTitle("Predictions")]
    public class PredictionsPage : ApplicationPage
    {
        public PredictionsPage()
        {
            var stackLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };

            var label = new Label
            {
                Text = "PredictionsPage",
                FontSize = 24
            };

            stackLayout.Children.Add(label);

            Content = stackLayout;
        }

        protected override Layout BuildPageLayout()
        {
            var appLayout = base.BuildPageLayout();

            return appLayout;
        }
    }
}

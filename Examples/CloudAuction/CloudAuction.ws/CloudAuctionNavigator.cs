﻿using System;
using Windows.UI.Xaml.Controls;
using CloudAuction.Shared;

namespace CloudAuction
{
    class CloudAuctionNavigator : ICloudAuctionNavigator
    {
        private void Navigate(object navigationContext, Type sourcePageType)
        {
            ((Frame)navigationContext).Navigate(sourcePageType);
        }

        public void NavigateToAuctionView(object navigationContext)
        {
            Navigate(navigationContext, typeof(AuctionView));
        }
    }
}
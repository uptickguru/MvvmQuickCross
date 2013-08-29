﻿using System;
using System.Threading.Tasks;
using MvvmQuickCross;

namespace MvvmQuickCross.Templates
{
    public sealed class _APPNAME_Application : ApplicationBase
    {
        private I_APPNAME_Navigator _navigator;

        public _APPNAME_Application(I_APPNAME_Navigator navigator, object currentNavigationContext = null, TaskScheduler uiTaskScheduler = null)
            : base(currentNavigationContext, uiTaskScheduler)
        {
            // Services that have a platform-specific implementation, such as the navigator,
            // are instantiated in a platform-specific project and passed to this application 
            // as a cross-platform interface.
            _navigator = navigator;

            // TODO: Create instances for all services that have a cross-platform implementation
        }

        new public static _APPNAME_Application Instance { get { return (_APPNAME_Application)ApplicationBase.Instance; } }

        /* TODO: For each view model, add a public property with a private setter like this:
           public _VIEWNAME_ViewModel _VIEWNAME_ViewModel { get; private set; }
         */

        /* TODO: For each view, add a method (with any parameters needed) to initialize its view model
         * and then navigate to the view using the navigator, like this:
                public void ContinueTo_VIEWNAME_(bool skipNavigation = false)
                {
                    if (_VIEWNAME_ViewModel == null) _VIEWNAME_ViewModel = new _VIEWNAME_ViewModel(any parameters);
                    // Any actions to update the view model go here
                    if (!skipNavigation) RunOnUIThread(() => _navigator.NavigateTo_VIEWNAME_View(CurrentNavigationContext));
                }
         * The skipNavigation parameter is needed in cases where the OS has already navigated to the view for you;
         * in that case you only need to initialize the view model. */
    }
}
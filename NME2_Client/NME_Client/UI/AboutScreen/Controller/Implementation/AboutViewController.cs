using System;
using System.Diagnostics;
using NME2.BasicInterfaces;
using NME2.UI.AboutScreen.View;

namespace NME2.UI.AboutScreen.Controller.Implementation
{
    class AboutViewController:IAboutViewController
    {

        private readonly IAboutView _attachedView;
        private const string Link = "http://www.berndnet-2000.de";


        public AboutViewController(IAboutView attachedView)
        {
            _attachedView = attachedView;
            _attachedView.RequestOpenLink += _attachedView_RequestOpenLink;
            _attachedView.SetAboutLink(26, Link);
        }

        void _attachedView_RequestOpenLink(object sender, EventArgs e)
        {
            Process.Start(Link);
        }

        public IBaseView GetAttachedView()
        {
            return _attachedView;
        }
    }
}

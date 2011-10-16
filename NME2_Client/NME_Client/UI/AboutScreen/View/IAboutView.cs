using System;
using NME2.BasicInterfaces;

namespace NME2.UI.AboutScreen.View
{
    public interface IAboutView: IBaseView
    {
        void SetAboutLink(int length, string link);

        event EventHandler RequestOpenLink;
    }
}
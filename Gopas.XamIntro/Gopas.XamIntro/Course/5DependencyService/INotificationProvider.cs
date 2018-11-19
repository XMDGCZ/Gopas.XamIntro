using System;
using System.Collections.Generic;
using System.Text;

namespace Gopas.XamIntro.Course._5DependencyService
{
    public interface INotificationProvider
    {
        void ShowNotification(string Title, string Text);
    }
}

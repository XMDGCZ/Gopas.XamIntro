using System;
using System.Collections.Generic;
using System.Text;

namespace Gopas.XamIntro.Course._5Firebase
{
    public interface IFCMService
    {
        bool CheckGooglePlayServicesAvailibility();

        string GetToken();

        string GetGoogleAppID();
    }

}

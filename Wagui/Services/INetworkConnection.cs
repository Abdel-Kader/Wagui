using System;
using System.Collections.Generic;
using System.Text;

namespace Wagui.Services
{
    public interface INetworkConnection
    {
        bool IsConnected { get; }
        void CheckNetworkConnection();
    }
}

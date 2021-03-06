﻿using Toggl.Ultrawave;
using Toggl.Ultrawave.Network;

namespace Toggl.Foundation.MvvmCross.Services
{
    public interface IApiFactory
    {
        ITogglClient CreateApiWith(Credentials credentials);
    }
}

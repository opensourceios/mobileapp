﻿﻿using System;
using Toggl.Multivac.Models;
using Toggl.Ultrawave.Tests.Integration.BaseTests;

namespace Toggl.Ultrawave.Tests.Integration
{
    public class UserClientTests
    {
        public class TheGetMethod : AuthenticatedEndpointBaseTests<IUser>
        {
            protected override IObservable<IUser> CallEndpointWith(ITogglClient togglClient)
                => togglClient.User.Get();

            // TODO: check that expected data is returned
        }
    }
}

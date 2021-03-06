﻿﻿using System;
using Toggl.Multivac;
using Toggl.PrimeRadiant;
using Toggl.Ultrawave;

namespace Toggl.Foundation.DataSources
{
    public sealed class TogglDataSource : ITogglDataSource
    {
        public TogglDataSource(ITogglDatabase database, ITogglClient client)
        {
            Ensure.ArgumentIsNotNull(client, nameof(client));
            Ensure.ArgumentIsNotNull(database, nameof(database));

            User = new UserDataSource(database.User, client.User);
        }

        public IUserSource User { get; }
        public ITagsSource Tags => throw new NotImplementedException();
        public ITasksSource Tasks => throw new NotImplementedException();
        public IClientsSource Clients => throw new NotImplementedException();
        public IProjectsSource Projects => throw new NotImplementedException();
        public IWorkspacesSource Workspaces => throw new NotImplementedException();
        public ITimeEntriesSource TimeEntries => throw new NotImplementedException();
    }
}

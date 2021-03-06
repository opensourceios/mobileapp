﻿using System;
using Realms;
using Toggl.PrimeRadiant.Models;

namespace Toggl.PrimeRadiant.Realm
{
    internal partial class RealmClient : RealmObject, IDatabaseClient
    {
        public int WorkspaceId { get; set; }

        public string Name { get; set; }

        public DateTimeOffset At { get; set; }
    }
}

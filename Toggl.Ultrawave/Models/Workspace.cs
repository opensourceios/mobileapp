﻿using System;
﻿using Newtonsoft.Json;
using Toggl.Multivac.Models;

namespace Toggl.Ultrawave
{
    public sealed class Workspace : IWorkspace
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Profile { get; set; }

        public bool Premium { get; set; }

        public bool BusinessWs { get; set; }

        public bool Admin { get; set; }

        [JsonProperty("SuspendedAt")]
        public DateTimeOffset? SuspendedAt { get; set; }

        public DateTimeOffset? ServerDeletedAt { get; set; }

        public double? DefaultHourlyRate { get; set; }

        public string DefaultCurrency { get; set; }

        public bool OnlyAdminsMayCreateProjects { get; set; }

        public bool OnlyAdminsSeeBillableRates { get; set; }

        public bool OnlyAdminsSeeTeamDashboard { get; set; }

        public bool ProjectsBillableByDefault { get; set; }

        public int Rounding { get; set; }

        public int RoundingMinutes { get; set; }

        public DateTimeOffset? At { get; set; }

        public string LogoUrl { get; set; }
    }
}
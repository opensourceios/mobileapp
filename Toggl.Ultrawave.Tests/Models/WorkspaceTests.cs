﻿using System;
using System.Collections.Generic;
using Xunit;

namespace Toggl.Ultrawave.Tests.Models
{
    public class WorkspaceTests
    {
        public class TheWorkspaceModel
        {
            [Theory]
            [MemberData("SerializationCases")]
            public void CanBeSerialized(string validJson, Workspace validObject)
            {
                SerializationHelper.CanBeSerialized(validJson, validObject);
            }
            
            [Theory]
            [MemberData("DeserializationCases")]
            public void CanBeDeserialized(string validJson, Workspace validObject)
            {
                SerializationHelper.CanBeDeserialized(validJson, validObject);
            }

            public static IEnumerable<object[]> SerializationCases
                => new[]
                {
                    new object[] { completeJson, completeObject },
                    new object[] { jsonWithNulls, objectWithNulls }
                };

            public static IEnumerable<object[]> DeserializationCases
                => new[]
                {
                    new object[] { completeJson, completeObject },
                    new object[] { jsonWithNulls, objectWithNulls },
                    new object[] { jsonWithoutSomeFields, objectWithNulls }
                };

            private const string completeJson =
                   "{\"id\":1234,\"name\":\"Default workspace\",\"profile\":0,\"premium\":false,\"business_ws\":false,\"admin\":true,\"SuspendedAt\":\"2018-04-24T12:16:48+00:00\",\"server_deleted_at\":\"2017-04-20T12:16:48+00:00\",\"default_hourly_rate\":0.0,\"default_currency\":\"USD\",\"only_admins_may_create_projects\":false,\"only_admins_see_billable_rates\":false,\"only_admins_see_team_dashboard\":false,\"projects_billable_by_default\":true,\"rounding\":0,\"rounding_minutes\":0,\"at\":\"2017-04-24T12:16:48+00:00\",\"logo_url\":\"https://assets.toggl.com/images/workspace.jpg\"}";

            private const string jsonWithNulls =
                "{\"id\":1234,\"name\":\"Default workspace\",\"profile\":0,\"premium\":false,\"business_ws\":false,\"admin\":true,\"SuspendedAt\":null,\"server_deleted_at\":null,\"default_hourly_rate\":null,\"default_currency\":\"USD\",\"only_admins_may_create_projects\":false,\"only_admins_see_billable_rates\":false,\"only_admins_see_team_dashboard\":false,\"projects_billable_by_default\":true,\"rounding\":0,\"rounding_minutes\":0,\"at\":null,\"logo_url\":\"https://assets.toggl.com/images/workspace.jpg\"}";

            private const string jsonWithoutSomeFields =
                "{\"id\":1234,\"name\":\"Default workspace\",\"profile\":0,\"premium\":false,\"business_ws\":false,\"admin\":true,\"default_currency\":\"USD\",\"only_admins_may_create_projects\":false,\"only_admins_see_billable_rates\":false,\"only_admins_see_team_dashboard\":false,\"projects_billable_by_default\":true,\"rounding\":0,\"rounding_minutes\":0,\"logo_url\":\"https://assets.toggl.com/images/workspace.jpg\"}";

            private static readonly Workspace completeObject = new Workspace
            {
                Id = 1234,
                Name = "Default workspace",
                Profile = 0,
                Premium = false,
                BusinessWs = false,
                Admin = true,
                SuspendedAt = new DateTimeOffset(2018, 4, 24, 12, 16, 48, TimeSpan.Zero),
                ServerDeletedAt = new DateTimeOffset(2017, 4, 20, 12, 16, 48, TimeSpan.Zero),
                DefaultHourlyRate = 0,
                DefaultCurrency = "USD",
                OnlyAdminsMayCreateProjects = false,
                OnlyAdminsSeeBillableRates = false,
                OnlyAdminsSeeTeamDashboard = false,
                ProjectsBillableByDefault = true,
                Rounding = 0,
                RoundingMinutes = 0,
                At = new DateTimeOffset(2017, 4, 24, 12, 16, 48, TimeSpan.Zero),
                LogoUrl = "https://assets.toggl.com/images/workspace.jpg"
            };

            private static readonly Workspace objectWithNulls = new Workspace
            {
                Id = 1234,
                Name = "Default workspace",
                Profile = 0,
                Premium = false,
                BusinessWs = false,
                Admin = true,
                SuspendedAt = null,
                ServerDeletedAt = null,
                DefaultHourlyRate = null,
                DefaultCurrency = "USD",
                OnlyAdminsMayCreateProjects = false,
                OnlyAdminsSeeBillableRates = false,
                OnlyAdminsSeeTeamDashboard = false,
                ProjectsBillableByDefault = true,
                Rounding = 0,
                RoundingMinutes = 0,
                At = null,
                LogoUrl = "https://assets.toggl.com/images/workspace.jpg"
            };
        }
    }
}
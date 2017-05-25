﻿using System;
using Toggl.Ultrawave.Network;
using Toggl.Ultrawave.Serialization;

namespace Toggl.Ultrawave.ApiClients
{
    internal sealed class UserApi : BaseClient, IUserApi
    {
        private readonly UserEndpoints endPoints;

        public UserApi(UserEndpoints endPoints, IApiClient apiClient, IJsonSerializer serializer,
            Credentials credentials)
            : base(apiClient, serializer, credentials)
        {
            this.endPoints = endPoints;
        }

        public IObservable<User> Get()
            => CreateObservable<User>(endPoints.Get, AuthHeader);

        public IObservable<User> Get(Credentials credentials)
            => CreateObservable<User>(endPoints.Get, credentials.Header);
    }
}

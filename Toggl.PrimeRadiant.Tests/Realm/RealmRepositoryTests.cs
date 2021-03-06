﻿using Toggl.PrimeRadiant.Realm;

namespace Toggl.PrimeRadiant.Tests.Realm
{
    public class RealmRepositoryTests : RepositoryTests<TestModel>
    {
        protected override IRepository<TestModel> Repository { get; } = new Repository<TestModel>(new TestAdapter());

        protected override TestModel GetModelWith(int id) => new TestModel { Id = id };
    }
}

using Toggl.Multivac.Models;

namespace Toggl.PrimeRadiant.Tests
{
    public interface ITestModel : IBaseModel, IDatabaseSyncable { }

    public sealed class TestModel : ITestModel
    {
        public int Id { get; set; }

        public bool IsDirty { get; set; }
    }
}
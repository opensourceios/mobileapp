using Xunit;

namespace Toggl.Ultrawave.Tests
{
    public abstract class BaseModelTests<T>
    {
        protected abstract string ValidJson { get; }

        protected abstract T ValidObject { get; }

        [Fact]
        public void CanBeSerialized()
        {
            SerializationHelper.CanBeSerialized(ValidJson, ValidObject);
        }

        [Fact]
        public void TestCanBeDeserialized()
        {
            SerializationHelper.CanBeDeserialized(ValidJson, ValidObject);
        }
    }
}

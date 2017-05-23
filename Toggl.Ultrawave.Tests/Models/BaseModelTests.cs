using FluentAssertions;
using Toggl.Ultrawave.Serialization;

namespace Toggl.Ultrawave.Tests
{
    public abstract class BaseModelTests<T>
    {
        private readonly JsonSerializer serializer = new JsonSerializer();

        protected void CanBeDeserialized(string validJson, T validObject)
        {
            var actual = serializer.Deserialize<T>(validJson);

            actual.Should().NotBeNull();
            actual.ShouldBeEquivalentTo(validObject);
        }

        protected void CanBeSerialized(string validJson, T validObject)
        {
            var actualJson = serializer.Serialize(validObject);

            actualJson.Should().Be(validJson);
        }
    }
}

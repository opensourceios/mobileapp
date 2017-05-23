using System;
using Xunit;

namespace Toggl.Ultrawave.Tests.Models
{
    public class TagTests : BaseModelTests<Tag>
    {
        private string validJson =>
            "{\"id\":2024667,\"wid\":424213,\"name\":\"mobile\"}";

        private Tag validObject => new Tag
        {
            Id = 2024667,
            WorkspaceId = 424213,
            Name = "mobile"
        };

        [Fact]
        public void TestCanBeSerialized()
        {
            CanBeSerialized(validJson, validObject);
        }

        [Fact]
        public void TestCanBeDeserialized()
        {
            CanBeDeserialized(validJson, validObject);
        }
    }
}

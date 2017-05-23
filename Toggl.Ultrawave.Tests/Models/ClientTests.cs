using System;
using Xunit;

namespace Toggl.Ultrawave.Tests.Models
{
    public class ClientTests
    {
        public class TheClientModel : BaseModelTests<Client>
        {
            private string validJson =>
                "{\"id\":23741667,\"wid\":1427273,\"name\":\"Test\",\"at\":\"2014-04-25T10:10:13+00:00\"}";

            private Client validObject => new Client
            {
                Id = 23741667,
                WorkspaceId = 1427273,
                Name = "Test",
                At = new DateTimeOffset(2014, 04, 25, 10, 10, 13, TimeSpan.Zero)
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
}

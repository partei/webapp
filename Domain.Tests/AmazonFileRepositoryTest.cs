using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Amazon.S3.Transfer;
using FluentAssertions;
using Moq;
using Xunit;

namespace Domain.Tests
{
    public class AmazonFileRepositoryTest
    {
        [Fact]
        public void StorePhoto()
        {
            var guidServiceMock = new Mock<IGuidService>();
            guidServiceMock.Setup(guidService => guidService.NewGuid()).Returns(new Guid("644e1dd7-2a7f-18fb-b8ed-ed78c3f92c2b"));
            var transferUtilityMock = new Mock<ITransferUtility>();
            var someStream = new MemoryStream(Encoding.UTF8.GetBytes("some data"));
            transferUtilityMock.Setup(transferUtility => transferUtility.UploadAsync(someStream, "partei-photos", "644e1dd7-2a7f-18fb-b8ed-ed78c3f92c2b", default(CancellationToken))).Returns(Task.CompletedTask);

            var task = new AmazonFileRepository(transferUtilityMock.Object, guidServiceMock.Object).StorePhoto(someStream);

            task.Should().Be(Task.CompletedTask);

        }
    }
}

using System.Collections.Generic;
using Domain.Entities;
using Domain.Enums;
using FluentAssertions;
using Infrastructure.Repositories;
using NUnit.Framework;

namespace Infrastructure.IntegrationTests.Repositories
{
    public class NotificationRepositoryTests
    {
        // Repository under testing
        private NotificationRepository _repository;

        [OneTimeSetUp]
        public void BeforeTestSetup()
        {
            _repository = new NotificationRepository();
        }

        [TestCaseSource(nameof(CreateAndGetStatusCases))]
        public void CreateAndGetStatus_ShouldCreateNewRow(string caseName, NotificationType type, NotificationStatus status)
        {
            // Arrange
            _ = caseName;
            var record = CreateNewRecord(type, status);

            // Act
            var result = _repository.Create(record);

            // Assert
            var persisted = _repository.GetStatusById(result);

            result.Should().Be(record.Id);
            persisted.Should().BeEquivalentTo(record.Status);
        }

        public static IEnumerable<TestCaseData> CreateAndGetStatusCases()
        {
            yield return new TestCaseData(
                "With android delivered notification",
                NotificationType.Android,
                NotificationStatus.Delivered);

            yield return new TestCaseData(
                "With android not delivered notification",
                NotificationType.Android,
                NotificationStatus.NotDelivered);

            yield return new TestCaseData(
                "With iOs delivered notification",
                NotificationType.iOs,
                NotificationStatus.Delivered);

            yield return new TestCaseData(
                "With iOs not delivered notification",
                NotificationType.iOs,
                NotificationStatus.NotDelivered);
        }

        private Notification CreateNewRecord(NotificationType type, NotificationStatus status)
        {
            // New record to create in database
            return new(null, type, status);
        }
    }
}

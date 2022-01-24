using System.Collections.Generic;
using Application.Common.Helpers;
using Domain.Enums;
using FluentAssertions;
using NUnit.Framework;

namespace Application.UnitTests.Common.Helpers
{
    public static class NotificationStatusHelperTests
    {
        [TestCaseSource(nameof(GetByCountNotificationCases))]
        public static void GetByCountNotification_ShouldReturnCorrectNotificationStatus(string caseName, int countNotification, NotificationStatus expectedStatus)
        {
            // Arrange
            _ = caseName;

            // Act
            var result = NotificationStatusHelper.GetByCountNotification(countNotification);

            // Assert
            result.Should().Be(expectedStatus);
        }

        public static IEnumerable<TestCaseData> GetByCountNotificationCases()
        {
            yield return new TestCaseData(
                "With countNotification a multiple of 5",
                20,
                NotificationStatus.NotDelivered);

            yield return new TestCaseData(
                "With countNotification not a multiple of 5",
                11,
                NotificationStatus.Delivered);
        }
    }
}

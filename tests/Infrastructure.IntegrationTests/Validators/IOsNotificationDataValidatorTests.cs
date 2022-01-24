using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Infrastructure.Services.IOsNotification;
using Infrastructure.Validators;
using NUnit.Framework;

namespace Infrastructure.IntegrationTests.Validators
{
    public class IOsNotificationDataValidatorTests
    {
        [TestCaseSource(nameof(CreateIOsNotificationDataInstanceCases))]
        public void CreateIOsNotificationDataInstance_ShouldCorrectCreateInstance(string caseName, IOsNotificationData data, IOsNotificationData expectedData)
        {
            // Arrange
            _ = caseName;

            // Act

            // Assert
            data.Should().BeEquivalentTo(expectedData);
        }

        private static IEnumerable<TestCaseData> CreateIOsNotificationDataInstanceCases()
        {
            yield return new TestCaseData(
                "With default params",
                new IOsNotificationData
                {
                    PushToken = "PushToken",
                    Alert = "Alert"
                },
                new IOsNotificationData
                {
                    PushToken = "PushToken",
                    Alert = "Alert",
                    Priority = 10,
                    IsBackground = true
                });

            yield return new TestCaseData(
                "With default priority",
                new IOsNotificationData
                {
                    PushToken = "PushToken",
                    Alert = "Alert",
                    IsBackground = false
                },
                new IOsNotificationData
                {
                    PushToken = "PushToken",
                    Alert = "Alert",
                    Priority = 10,
                    IsBackground = false
                });

            yield return new TestCaseData(
                "With default IsBackground property",
                new IOsNotificationData
                {
                    PushToken = "PushToken",
                    Alert = "Alert",
                    Priority = 11
                },
                new IOsNotificationData
                {
                    PushToken = "PushToken",
                    Alert = "Alert",
                    Priority = 11,
                    IsBackground = true
                });

            yield return new TestCaseData(
                "With all initialized params",
                new IOsNotificationData
                {
                    PushToken = "PushToken",
                    Alert = "Alert",
                    Priority = 11,
                    IsBackground = false
                },
                new IOsNotificationData
                {
                    PushToken = "PushToken",
                    Alert = "Alert",
                    Priority = 11,
                    IsBackground = false
                });
        }

        [TestCaseSource(nameof(ValidateIOsNotificationDataCases))]
        public void ValidateIOsNotificationData_ShouldCorrectValidation(string caseName, IOsNotificationData data, bool expectedIsValid, IList<string> expectedErrorPropertyNames)
        {
            // Arrange
            _ = caseName;
            var validator = new IOsNotificationDataValidator();

            // Act
            var result = validator.Validate(data);

            // Assert
            result.IsValid.Should().Be(expectedIsValid);
            result.Errors.Select(x => x.PropertyName).Should().BeEquivalentTo(expectedErrorPropertyNames);
        }

        private static IEnumerable<TestCaseData> ValidateIOsNotificationDataCases()
        {
            yield return new TestCaseData(
                "With invalid required fields",
                new IOsNotificationData
                {
                    PushToken = "PushToken ".PadRight(51, '*'),
                    Alert = "Alert".PadRight(2001, '*')
                },
                false,
                new List<string> { nameof(IOsNotificationData.PushToken), nameof(IOsNotificationData.Alert) });

            yield return new TestCaseData(
                "With required fields are empty",
                new IOsNotificationData
                {
                    PushToken = null,
                    Alert = null
                },
                false,
                new List<string> { nameof(IOsNotificationData.PushToken), nameof(IOsNotificationData.Alert) });

            yield return new TestCaseData(
                "With all fields are filled correct",
                new IOsNotificationData
                {
                    PushToken = "PushToken",
                    Alert = "Alert"
                },
                true,
                new List<string>(0));
        }
    }
}

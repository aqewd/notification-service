using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Infrastructure.Services.AndroidNotification;
using Infrastructure.Validators;
using NUnit.Framework;

namespace Infrastructure.IntegrationTests.Validators
{
    public class AndroidNotificationDataValidatorTests
    {
        [TestCaseSource(nameof(ValidateAndroidNotificationDataCases))]
        public void ValidateAndroidNotificationData_ShouldCorrectValidation(string caseName, AndroidNotificationData data, bool expectedIsValid,IList<string> expectedErrorPropertyNames)
        {
            // Arrange
            _ = caseName;
            var validator = new AndroidNotificationDataValidator();

            // Act
            var result = validator.Validate(data);

            // Assert
            result.IsValid.Should().Be(expectedIsValid);
            result.Errors.Select(x => x.PropertyName).Should().BeEquivalentTo(expectedErrorPropertyNames);
        }

        public static IEnumerable<TestCaseData> ValidateAndroidNotificationDataCases()
        {
            yield return new TestCaseData(
                "With invalid required fields",
                new AndroidNotificationData
                {
                    DeviceToken = "DeviceTokenName".PadRight(51, '*'),
                    Message = "Message".PadRight(2001, '*'),
                    Title = "Title".PadRight(256, '*'),
                    Condition = null
                },
                false,
                new List<string> { nameof(AndroidNotificationData.DeviceToken), nameof(AndroidNotificationData.Message), nameof(AndroidNotificationData.Title) });

            yield return new TestCaseData(
                "With required fields are empty",
                new AndroidNotificationData
                {
                    DeviceToken = null,
                    Message = null,
                    Title = null,
                    Condition = null
                },
                false,
                new List<string> { nameof(AndroidNotificationData.DeviceToken), nameof(AndroidNotificationData.Message), nameof(AndroidNotificationData.Title) });

            yield return new TestCaseData(
                "With invalid condition field",
                new AndroidNotificationData
                {
                    DeviceToken = "DeviceToken",
                    Message = "Message",
                    Title = "Title",
                    Condition = "Condition".PadRight(256, '*')
                },
                false,
                new List<string> { nameof(AndroidNotificationData.Condition) });

            yield return new TestCaseData(
                "With all fields are filled correct",
                new AndroidNotificationData
                {
                    DeviceToken = "DeviceToken",
                    Message = "Message",
                    Title = "Title",
                    Condition = "Condition"
                },
                true,
                new List<string>(0));

            yield return new TestCaseData(
                "With only required fields are filled correct",
                new AndroidNotificationData
                {
                    DeviceToken = "DeviceToken",
                    Message = "Message",
                    Title = "Title",
                    Condition = null
                },
                true,
                new List<string>(0));
        }
    }
}

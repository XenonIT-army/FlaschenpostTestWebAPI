using Bogus;
using FlaschenpostTestDAL.Context;
using FlaschenpostTestWebAPI.Interface;
using FlaschenpostTestWebAPI.Model;
using FlaschenpostTestWebAPI.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace FlaschenpostTestxUnit.DataValidationTest
{
    public class EmptyOrWithinRangeAttributeTests 
    {
        const int MinValueStart = 5;
        const int MinValueEnd = 10;
        const int MaxValueStart = 11;
        const int MaxValueEnd = 15;
        readonly EmptyOrWithinRangeAttribute sut;
        public EmptyOrWithinRangeAttributeTests()
        {
            sut = new Faker<EmptyOrWithinRangeAttribute>()
                .RuleFor(r => r.MinLength, f => f.Random.Int(MinValueStart, MinValueEnd))
                 .RuleFor(r => r.MaxLength, f => f.Random.Int(MaxValueStart, MaxValueEnd)).Generate();
        }

        [Fact]
        public void Value_TooShort_IsNotValid()
        {
            //Arrange
            var input = new Faker().Random.String2(1, MinValueStart - 1);
            //Act
            var isValid = sut.IsValid(input);
            //Assert
            Assert.False(isValid);
        }
        [Fact]
        public void Value_WithinRange_IsValid()
        {
            //Arrange
            var input = new Faker().Random.String2(sut.MinLength, sut.MaxLength);
            //Act
            var isValid = sut.IsValid(input);
            //Assert
            Assert.True(isValid);
        }
        [Fact]
        public void Value_Empty_IsValid()
        {
            //Arrange
            var input = string.Empty;
            //Act
            var isValid = sut.IsValid(input);
            //Assert
            Assert.True(isValid);
        }
    }

    public class EmptyOrWithinRangeAttribute : ValidationAttribute
    {
        public int MinLength { get; set; }
        public int MaxLength { get; set; }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string valueAsString && (
                string.IsNullOrEmpty(valueAsString) ||
                (valueAsString.Length >= MinLength
                && valueAsString.Length <= MaxLength)))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"The value should be between {MinLength} and {MaxLength} characters long, or empty.");

            }
        }
    }
}

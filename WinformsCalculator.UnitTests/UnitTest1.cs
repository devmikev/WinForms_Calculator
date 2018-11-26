using System;
using System.Collections.Generic;
using NUnit.Framework;
using WindowsFormsApp1;

namespace WinformsCalculator.UnitTests
{
    [TestFixture]
    public class OperatorTests
    {
        [Test] // MethodName_Scenario_ExpectedBehavior
        public void ApplyOperator_UsingAdditionOperator_ReturnSumOfArguemnts()
        {
            // Arrange
            IEnumerable<IOperator> operations = new IOperator[] { new AdditionOperator(), new SubtractionOperator(), new MultiplicationOperator(), new DivisionOperator() };
            ICalculator calc = new Calculator(operations);
            calc.InputNumber1(1);
            calc.InputNumber2(2);
            calc.Operator = AdditionOperator();

            // Act
            var result = calc.ApplyOperator();

            // Assert
            Assert.That(result, Is.EqualTo(3));
        }
    }
}

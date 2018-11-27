using System;
using System.Collections.Generic;
using NUnit.Framework;
using WindowsFormsApp1;

namespace WinformsCalculator.UnitTests
{
    [TestFixture]
    public class OperatorTests
    {
        private IEnumerable<IOperator> operations = new IOperator[] { new AdditionOperator(), new SubtractionOperator(), new MultiplicationOperator(), new DivisionOperator() };
        private ICalculator _calc;
        public enum Oper
        {
            Addition,
            Subtraction,
            Multiplication,
            Division
        }

        [SetUp]
        public void SetUp()
        {
            _calc = new Calculator(operations);

        }

        

        [Test] // MethodName_Scenario_ExpectedBehavior
        [TestCase(Oper.Addition, 1, 2, 3)]
        [TestCase(Oper.Subtraction, 2, 1, 1)]
        [TestCase(Oper.Multiplication, 2, 3, 6)]
        [TestCase(Oper.Division, 6, 2, 3)]
        public void ApplyOperator_WhenCalled_ReturnResultOfExpression(Oper oper, decimal a, decimal b, decimal expectedResult)
        {
            // Arrange
            SetCalculator(oper, a, b);


            // Act
            var result = _calc.ApplyOperator();

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        private void SetCalculator(Oper oper, decimal a, decimal b)
        {
            switch (oper)
            {
                case Oper.Addition:
                    _calc.Operator = new AdditionOperator();
                    break;
                case Oper.Subtraction:
                    _calc.Operator = new SubtractionOperator();
                    break;
                case Oper.Multiplication:
                    _calc.Operator = new MultiplicationOperator();
                    break;
                case Oper.Division:
                    _calc.Operator = new DivisionOperator();
                    break;
                                
            }
            _calc.InputNumber1(a);
            _calc.InputNumber2(b);
        }
    }
}

using NUnit.Framework;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReqnrollCalculatorR.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
       Calculations calculations = new Calculations();
        private int actualResult;
        private string actualResultEvenorOdd;

        [Given("the first number is {int}")]
        public void GivenTheFirstNumberIs(int firstnumber)
        {
            calculations.FirstNumber = firstnumber;

        }

        [Given("the second number is {int}")]
        public void GivenTheSecondNumberIs(int secondnumber)
        {
           calculations.SecondNumber = secondnumber;
        }

        [When ("the two numbers are (.*)")]
        public void WhenTheTwoNumbersAre(string operation)
        {
            switch (operation)
            {
                case "added":
                    actualResult = calculations.AddNumbers();
                    break;
                case "subtracted":
                    actualResult = calculations.SubtractNumbers();
                    break;
                case "multiplied":
                    actualResult = calculations.MultiplyNumbers();
                    break;
                case "divided":
                    actualResult = calculations.DivideNumbers();
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported operation: {operation}");
            }
        }


        [Given("the number is {int}")]
        public void GivenTheNumberIs(int number1)
        {
            calculations.numberIs = number1;
        }

        [When("the number is checked for even or odd")]
        public void WhenTheNumberIsCheckedForEvenOrOdd()
        {
            actualResultEvenorOdd = calculations.CheckEvenOrOdd();
        }

        [Then("the result should be {string}")]
        public void ThenTheResultShouldBe(string expectedResultEvenorOdd)
        {
            Assert.That(this.actualResultEvenorOdd, Is.EqualTo(expectedResultEvenorOdd));
        }

        [Then("the result should be {int}")]
        public void ThenTheResultShouldBe(int expextedResult)
        {

            Assert.That(this.actualResult, Is.EqualTo(expextedResult));
        }

    }
}

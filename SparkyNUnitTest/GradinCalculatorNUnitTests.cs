using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Sparky;
namespace Sparky
{
    [TestFixture]
    class GradinCalculatorNUnitTests
    {
        GradingCalculator gradingCalculator;

        [SetUp]
        public void SetUp()
        {
            gradingCalculator = new GradingCalculator();
        }

        [Test]
        [TestCase(95,90)]
        [TestCase(91, 71)]
        public void GetGrade_Score90AndMoreAttendance70AndMore_RetrunGradeA(int score, int attendance)
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;

            Assert.That(gradingCalculator.GetGrade(), Is.EqualTo("A"));
        }

        [Test]
        [TestCase(85, 90)]
        [TestCase(95, 65)]
        public void GetGrade_Score80AndMoreAttendance60AndMore_RetrunGradeB(int score, int attendance)
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;

            Assert.That(gradingCalculator.GetGrade(), Is.EqualTo("B"));
        }

        [Test]
        [TestCase(65, 90)]
        [TestCase(61, 71)]
        public void GetGrade_Score60AndMoreAttendance60AndMore_RetrunGradeC(int score, int attendance)
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;

            Assert.That(gradingCalculator.GetGrade(), Is.EqualTo("C"));
        }

        [Test]
        [TestCase(60, 60)]
        [TestCase(50, 71)]
        public void GetGrade_Score60AndLessAttendance60AndLess_RetrunGradeF(int score, int attendance)
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;

            Assert.That(gradingCalculator.GetGrade(), Is.EqualTo("F"));
        }

        [Test]
        [TestCase(95, 55)]
        [TestCase(65, 55)]
        public void GetGradeF_ScoreAttendanceInput_ReturnGradeF(int score, int attendnce)
        {
            gradingCalculator = new GradingCalculator { Score = score, AttendancePercentage = attendnce };
            Assert.That(gradingCalculator.GetGrade(), Is.EqualTo("F"));
        }

        [Test]
        [TestCase(95, 90, ExpectedResult = "A")]
        [TestCase(85, 90, ExpectedResult = "B")]
        [TestCase(65, 90, ExpectedResult = "C")]
        [TestCase(95, 65, ExpectedResult = "B")]
        [TestCase(95, 55, ExpectedResult = "F")]
        [TestCase(65, 55, ExpectedResult = "F")]
        [TestCase(50, 90, ExpectedResult = "F")]
        public string GradeCalc_ScoreAttendanceInput_GetGradeA_F(int score, int attendance)
        {
            gradingCalculator = new GradingCalculator { Score = score, AttendancePercentage = attendance };

            return gradingCalculator.GetGrade();
    }
    }

    
}

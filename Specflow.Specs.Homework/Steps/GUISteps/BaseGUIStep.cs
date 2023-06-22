using NUnit.Framework;
using OpenQA.Selenium;
using TAF_TMS_C1onl.Core;

namespace Specflow.Specs.Homework.Steps.GUISteps
{
    internal class BaseGUIStep
    {
        protected readonly IWebDriver Driver;

        public BaseGUIStep(Browser browser)
        {
            Driver = browser!.Driver!;
        }

        protected void CheckTitle(string title)
        {
            Assert.That(title, Is.EqualTo(Driver!.Title));
        }
    }
}
using YutyFramework;
using OpenQA.Selenium;
using System;
using NUnit.Framework;
using System.Collections.ObjectModel;
using DataObjectLibrairies.Enums;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace SampleApplication
{
    public class SampleApplicationPage : BasePageObject
    {

        public SampleApplicationPage(IWebDriver driver) : base(driver) { }

        public bool IsVisible
        {
            get
            {
                try { return Driver.Title.Contains(PageTitle); }
                catch (NoSuchElementException )
                {
                    return false;
                }
            }
            private set { }
        }

        private IWebElement FirstNameField => Driver.FindElement(By.Id("f1"));
        private IWebElement LastNameField => Driver.FindElement(By.Id("l1"));
        private IWebElement SubmitButton => Driver.FindElement(By.Id("submit1"));
        private IWebElement FemaleGenderRadio => Driver.FindElement(By.Id("radio1-f"));
        private IWebElement MaleGenderRadio => Driver.FindElement(By.Id("radio1-m"));
        private IWebElement OtherGenderRadio => Driver.FindElement(By.Id("radio1-0"));
        private IWebElement EmergencyFirstNameField => Driver.FindElement(By.Id("f2"));
        private IWebElement EmergencyLastNameField => Driver.FindElement(By.Id("l2"));
        private IWebElement EmergencyFemaleGenderRadio => Driver.FindElement(By.Id("radio2-f"));
        private IWebElement EmergencyMaleGenderRadio => Driver.FindElement(By.Id("radio2-m"));
        private IWebElement EmergencyOtherGenderRadio => Driver.FindElement(By.Id("radio2-0"));
     
        private string PageTitle => "Sample Application Lifecycle - Sprint 4 - Ultimate QA";

        public Actions WebDriverActions { get; private set; }

        public void GoTo()
        {
            Driver.Navigate().GoToUrl($"https://www.ultimateqa.com/sample-application-lifecycle-sprint-4/");
            Assert.IsTrue(IsVisible,
                $"Sample Application Page was not visible. Expected=>{PageTitle}." +
                $"Actual =>{Driver.Title}");

        }

        public UltimateQAHomePage FillOutFormAndSubmit(TestUser user)
        {
            SynchronisePage();
            FirstNameField.SendKeys(user.FirstName);
            LastNameField.SendKeys(user.LastName);
            SynchronisePage();
            SetGender(user);
            SubmitButton.Click();
            return new UltimateQAHomePage(Driver);
        }
        public void FillOutEmergencyForm(TestUser user)
        {
            SynchronisePage();
            EmergencyFirstNameField.SendKeys(user.FirstName);
            EmergencyLastNameField.SendKeys(user.LastName);
            SetEmergencyGender(user);
        }
        private void SetEmergencyGender(TestUser user)
        {
            switch (user.GenderType)
            {
                case Gender.Male:
                    EmergencyMaleGenderRadio.Click();
                    break;
                case Gender.Female:
                    EmergencyFemaleGenderRadio.Click();
                    break;
                case Gender.Other:
                    EmergencyOtherGenderRadio.Click();
                    break;
            }
        }

        private void SetGender(TestUser user)
        {
            switch (user.GenderType)
            {
                case Gender.Male:
                    MaleGenderRadio.Click();
                    break;
                case Gender.Female:
                    FemaleGenderRadio.Click();
                    break;
                default:
                    OtherGenderRadio.Click();
                    break;
            }
        }
        private void SynchronisePage()
        {
            WebDriverActions = new Actions(Driver);

            WebDriverActions.SendKeys(Keys.PageUp).Build().Perform();

        }

    }
}
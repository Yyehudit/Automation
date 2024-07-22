using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestProject2
{
    public class UnitTest3
    {
        private IWebDriver driver;


        [OneTimeSetUp]
        public void SetUp()
        {
            string path = "T:\\הנדסת תוכנה\\שנה ב\\קבוצה א\\משתלמות\\יהודית פרידמן\\אוטומציה\\‏‏SeleniumProject - עותק\\SeleniumProject";

            //Creates the ChomeDriver object, Executes tests on Google Chrome

            driver = new ChromeDriver(path + @"\drivers\");

        }

        [Test]
        public void TestSearch()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/alerts");

            var alertButton = driver.FindElements(By.Id("promtButton"))[0];

            alertButton.Click();


            IAlert alert = WaitForAlert(driver, TimeSpan.FromSeconds(10));
            //ClassicAssert.IsNotNull(alert, "Alert was not displayed.");

            alert.Accept();

            driver.Navigate().Back();
        }
        private IAlert WaitForAlert(IWebDriver driver, TimeSpan timeout)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, timeout);
                return wait.Until(ExpectedConditions.AlertIsPresent());
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
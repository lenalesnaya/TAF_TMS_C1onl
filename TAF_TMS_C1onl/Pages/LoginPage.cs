using OpenQA.Selenium;
using TAF_TMS_C1onl.Wrappers;

namespace TAF_TMS_C1onl.Pages
{
    public class LoginPage : BasePage
    {
        private static string END_POINT = "";
        
        // Описание элементов
        private static readonly By EmailInputBy = By.Id("name");
        private static readonly By PswInputBy = By.Id("password");
        private static readonly By RememberMeCheckboxBy = By.Id("rememberme");
        private static readonly By LoginInButtonBy = By.Id("button_primary");
        
        // Инициализация класса
        public LoginPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }
        public LoginPage(IWebDriver driver) : base(driver, false)
        {
        }
        
        public override bool IsPageOpened()
        {
            return WaitService.GetVisibleElement(LoginInButtonBy) != null;
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        // Методы
        public Input EmailInput => new(Driver, EmailInputBy);

        public Input PswInput => new(Driver, PswInputBy);

        public UIElement RememberMeCheckbox => new(Driver, RememberMeCheckboxBy);

        public Button LoginInButton => new(Driver, LoginInButtonBy);

        public DashboardPage Login(string username, string password)
        {
            TryToLogin(username, password);

            return new DashboardPage(Driver);
        }

        public LoginPage TryToLogin(string username, string password)
        {
            EmailInput.SendKeys(username);
            PswInput.SendKeys(password);
            LoginInButton.Click();

            return this;
        }
    }
}
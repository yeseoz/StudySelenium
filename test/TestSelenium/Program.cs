using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;

namespace ChromeAgent
{
    class Program
    {

        static void Main(string[] args)
        {


            ChromeDriverService _driverService = null;
            ChromeOptions _options = null;
            ChromeDriver _driver = null;
            Console.WriteLine("접속중...");

            try
            {
                _driverService = ChromeDriverService.CreateDefaultService(); // 초기 상태 만들기
                _driverService.HideCommandPromptWindow = true; // 창숨기기

                _options = new ChromeOptions();
                _options.AddArgument("disabel-gpu"); // AddArgument => options의 속성 설정  "--start-maximized" :  전체화면 /  "--disable=gpu" : GPU 가속을 비활성화
                _options.AddArgument("--start-maximized");
            }
            catch(Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }

            _driver = new ChromeDriver(_driverService, _options);
            _driver.Navigate().GoToUrl("https://www.daum.net");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // 10초동안 페에지가 로딩이 완료가 되지 않을시 에러를 일으킴

            var element = _driver.FindElement(By.XPath("//*[@id=\"inner_login\"]/a[1]"));
            element.Click(); // 버튼 클릭

            var loginBox = _driver.FindElement(By.XPath("//*[@id=\"loginId--1\"]"));
            loginBox.SendKeys("kys021697@naver.com");

            var passBox = _driver.FindElement(By.XPath("//*[@id=\"password--2\"]"));
            passBox.SendKeys("ftisland0302!");

            var logButton = _driver.FindElement(By.XPath("//*[@id=\"mainContent\"]/div/div/form/div[4]/button[1]"));
            logButton.Click();
        }
    }
}
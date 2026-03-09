// See https://aka.ms/new-console-template for more information
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

IWebDriver driver = new ChromeDriver();
try
{
    driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
    driver.FindElement(By.Id("username")).SendKeys("student");
    driver.FindElement(By.Id("password")).SendKeys("Password123");
    driver.FindElement(By.Id("submit")).Click();
    
    // Check for success message
    var successElement = driver.FindElement(By.ClassName("post-title"));
    if (successElement.Text.Contains("Logged In Successfully"))
    {
        Console.WriteLine("Login test passed!");
    }
    else
    {
        Console.WriteLine("Login test failed!");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
finally
{
    driver.Quit();
}
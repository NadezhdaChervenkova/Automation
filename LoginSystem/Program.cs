// See https://aka.ms/new-console-template for more information
using Microsoft.Playwright;

using var playwright = await Playwright.CreateAsync();
await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
var page = await browser.NewPageAsync();

try
{
    await page.GotoAsync("https://practicetestautomation.com/practice-test-login/");
    await page.FillAsync("#username", "student");
    await page.FillAsync("#password", "Password123");
    await page.ClickAsync("#submit");
    
    // Check for success message
    var successText = await page.TextContentAsync(".post-title");
    if (successText.Contains("Logged In Successfully"))
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
    await browser.CloseAsync();
}
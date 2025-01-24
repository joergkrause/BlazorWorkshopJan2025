using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using System.Diagnostics;

namespace Workshop.E2ETests
{
  [TestClass]
  public sealed class Test1
  {
    private IBrowser? _browser;
    private IBrowserContext? _context;
    private IPage? _page;

    [TestInitialize]
    public async Task TestInit()
    {
      var playwright = await Playwright.CreateAsync();
      _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
      _context = await _browser.NewContextAsync();
      _page = await _context.NewPageAsync();

      // Process.Start()
    }

    [TestCleanup]
    public async Task TestCleanup()
    {
      await _browser!.CloseAsync();
    }

    [TestMethod]
    public async Task TestMethod1()
    {
      // Arrange
      await _page!.GotoAsync("https://localhost:7020/");
      
      // Act
      //await _page!.ClickAsync("text=Show Claims");
      var body = await _page.InnerHTMLAsync("body");

      var backdrop = await _page.QuerySelectorAsync("#backDrop");

      // Assert
      Assert.IsNotNull(backdrop);
    }
  }
}

using Microsoft.Playwright;

namespace ProeyctoDePruebas
{
    [TestClass]
    public class Test1 : PageTest
    {
        [TestMethod]
        public async Task LoginConUsuarioInvalidoMuestraError()
        {
            await Page.GotoAsync("https://the-internet.herokuapp.com/login");
            await Page.GetByRole(AriaRole.Heading, new() { Name = "This is where you can log" }).ClickAsync();
            await Page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
            await Page.GetByText("Your username is invalid! ×").ClickAsync();
            await Page.GetByRole(AriaRole.Textbox, new() { Name = "Username" }).ClickAsync();
            await Page.GetByRole(AriaRole.Textbox, new() { Name = "Username" }).FillAsync("marcelo");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
            await Expect(Page.Locator("#flash")).ToContainTextAsync("Your username is invalid!");
        }
        [TestMethod]
        public async Task LoginConUsuarioYContraseñaVacio()
        {
            await Page.GotoAsync("https://the-internet.herokuapp.com/login");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
            await Expect(Page.Locator("#flash")).ToContainTextAsync("Your username is invalid!");
        }
        [TestMethod]
        public async Task LoginConUsuarioYContraseñaCorrectos()
        {
            await Page.GotoAsync("https://the-internet.herokuapp.com/login");
            await Page.GetByRole(AriaRole.Textbox, new() { Name = "Username" }).FillAsync("tomsmith");
            await Page.GetByRole(AriaRole.Textbox, new() { Name = "Password" }).FillAsync("SuperSecretPassword!");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
            await Expect(Page.Locator("#flash")).ToContainTextAsync("You logged into a secure area");
        }
    }
}

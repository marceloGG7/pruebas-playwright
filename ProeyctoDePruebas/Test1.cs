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
            //await Page.GetByText("Your username is invalid! ×").ClickAsync();
            await Expect(Page.Locator("#flash")).ToContainTextAsync("Your username is invalid!");
        }
    }
}

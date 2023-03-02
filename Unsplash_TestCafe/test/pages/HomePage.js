import { Selector } from "testcafe";
import BasePage from "../common/BasePage";
import getElementsByXPath from "../helper/XPathHelper"

class HomePage extends BasePage {
    constructor() {
        super();
        this.homePageLabel = Selector('[alt="Website for automation practice"]')
        this.loginAndSignupElement = Selector(getElementsByXPath("(//a[contains(@href, '/login')])"))
    }

    async verifyHomepage() {
        await this.verifyElementExisted(this.homePageLabel)
    }

    async goToSignUpAndLoginPage() {
        await this.clickElement(this.loginAndSignupElement)
    }
}
export default HomePage;
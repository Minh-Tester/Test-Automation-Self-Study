import { Selector } from "testcafe";
import BasePage from "../../common/BasePage";
import getElementsByXPath from "../../helper/XPathHelper"


class LoginActionPage extends BasePage {
    constructor() {
        super();
        this.loginElement = Selector(getElementsByXPath("(//a[contains(@class, 'cLLOA p1cWU jpBZ0 EzsBC KHq0c XHI2L')])[1]"))
        this.inputEmail = Selector('[type="email"]')
        this.inputPassword = Selector('[type="password"]')
        this.submitBtn = Selector('[type="submit"]')

    }

    async LoginAction(email, password) {
        this.clickElement(this.loginElement)
        this.inputValueToFieldTextBox(this.inputEmail, email)
        this.inputValueToFieldTextBox(this.inputPassword, password)
        this.clickButton(this.submitBtn)
    }
}
export default LoginActionPage;
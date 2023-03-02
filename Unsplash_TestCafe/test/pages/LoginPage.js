import { Selector } from "testcafe";
import BasePage from "../common/BasePage";

class LoginPage extends BasePage {
    constructor () {
        super();
        this.newUserSignupLabel = Selector('h2').withText('New User Signup!')
    }

    async verifyNewUserSignupLabel() {
        await this.verifyElementExisted(this.newUserSignupLabel)
    }

}
export default LoginPage;
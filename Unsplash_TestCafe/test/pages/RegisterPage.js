import { Selector } from "testcafe";
import BasePage from "../common/BasePage";
import getElementsByXPath from "../helper/XPathHelper"

class RegisterPage extends BasePage {
    constructor() {
        super();
        //Signup action
        this.nameInput = Selector('[data-qa="signup-name"]')
        this.emailInput = Selector('[data-qa="signup-email"]')
        this.signupBtn = Selector('[data-qa="signup-button"]')
        //Label
        this.accountInformationLabel = Selector(getElementsByXPath("(//h2[contains(@class, 'title text-center')])[1]"))
        //Gender
        this.genderRadio = '[id="id_gendernumber"]'
        //Password
        this.passwordInput = Selector(getElementsByXPath(" (//input[contains(@type, 'password')])"))
        //DOB
        this.daySelect = Selector('[data-qa="days"]')
        this.monthSelect = Selector('[data-qa="months"]')
        this.yearSelect = Selector('[data-qa="years"]')
        //DOB Select
        this.dobOption = "//option[text()='dob']"
        //CheckBox
        this.checkBoxSignup = "(//input[contains(@type, 'checkbox')])[number]"

    }

    async signUpAction(name, email) {
        await this.inputValueToFieldTextBox(this.nameInput, name)
        await this.inputValueToFieldTextBox(this.emailInput, email)
        await this.clickButton(this.signupBtn)
    }

    async verifyEnterAccountInformationLabelExists() {
        await this.verifyElementExisted(this.accountInformationLabel)
    }

    async filterTitle(arrayTitleNumber) {
        for (let i = 0; i < arrayTitleNumber.length; i++) {
            let path = await this.replaceValue(this.genderRadio, 'number', arrayTitleNumber[i])
            console.log(path)
            await this.clickButton(Selector(path))
        }
    }

    async inputPassword(password) {
        await this.inputValueToFieldTextBox(this.passwordInput, password)
    }

    async selectDOB(day, month, year) {
        //daySelect
        await this.clickButton(this.daySelect)
        let dayOp = this.dobOption.replace('dob', day)
        console.log(dayOp)
        await this.clickButton(getElementsByXPath(dayOp))
        //monthSelect
        await this.clickButton(this.monthSelect)
        let monthOp = this.dobOption.replace('dob', month)
        console.log(monthOp)
        await this.clickButton(getElementsByXPath(monthOp))
        //yearSelect
        await this.clickButton(this.yearSelect)
        let yearOp = this.dobOption.replace('dob', year)
        console.log(yearOp)
        await this.clickButton(getElementsByXPath(yearOp))
    }

    async selectCheckBox(checkBoxArray) {
        for (let i = 1; i < checkBoxArray.length; i++) {
            let path = await this.replaceValue(this.checkBoxSignup, 'number', checkBoxArray[i])
            console.log(path)
            await this.clickButton(getElementsByXPath(path))
        }
    }






}
export default RegisterPage;
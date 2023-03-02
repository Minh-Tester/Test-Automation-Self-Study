import HomePage from "../../pages/HomePage"
import LoginPage from "../../pages/LoginPage"
import RegisterPage from "../../pages/RegisterPage"

const homePage = new HomePage()
const loginPage = new LoginPage()
const registerPage = new RegisterPage

const loginData = require('../../data/LoginRegisterData.json')

fixture('Scenario 1')
test('RegisterUser', async t =>{
    await homePage.verifyHomepage()
    await homePage.goToSignUpAndLoginPage()
    await loginPage.verifyNewUserSignupLabel()
    await registerPage.signUpAction(loginData.Name, loginData.Email)
    await registerPage.verifyEnterAccountInformationLabelExists()
    await registerPage.filterTitle(loginData.TitleMr)
    await registerPage.inputPassword(loginData.Password)
    await registerPage.selectDOB(21, "September", 2000)

    
    await t.debug()

})
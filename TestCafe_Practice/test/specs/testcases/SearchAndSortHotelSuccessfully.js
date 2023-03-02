import HomePage from "../../pages/HomePage.js";
import CalendarPage from "../../pages/CalendarPage.js";
import SortPage from "../../pages/SortPage.js";

const homePage = new HomePage();
const calendarPage = new CalendarPage();
const sortPage = new SortPage();

fixture('Search And Sort Hotel')
test('Search And Sort Hotel Test', async t =>{
    await homePage.skipAd()
    await homePage.inputDestination("Da Nang")
    await calendarPage.selectFutureDate("Fri Mar 10 2023", "Thu Mar 30 2023")
    await homePage.goToOccupancyBox('Family travelers', 2, 4)
    await homePage.clickSearchButton()
    await sortPage.showSearchResult(5)
    await sortPage.goToLowestPriceFirst()
    await sortPage.sortLowestPrice(5)
})

import HomePage from "../../pages/HomePage.js";
import CalendarPage from "../../pages/CalendarPage.js";
import SortPage from "../../pages/SortPage.js";
import FilterPage from "../../pages/FilterPage.js";

const homePage = new HomePage();
const calendarPage = new CalendarPage();
const sortPage = new SortPage();
const filterpage = new FilterPage();


fixture('Search and Filter Hotel')
test('Search and Filter Hotel Test', async t =>{
    await homePage.skipAd()
    await homePage.inputDestination("Da Nang")
    await calendarPage.selectFutureDate("Fri Mar 10 2023", "Thu Mar 30 2023")
    await homePage.goToOccupancyBox('Family travelers', 2, 4)
    await homePage.clickSearchButton()
    await sortPage.showSearchResult(5)
    await filterpage.filterPriceAndStar("500000", "1000000", [3,4])
    await sortPage.goToBestMatch()
    await filterpage.showFilteredResult(5, "500000", "1000000", [3,4])
    await sortPage.resetPriceSlice(5)

})

import HomePage from "../../pages/HomePage.js";
import CalendarPage from "../../pages/CalendarPage.js";
import SortPage from "../../pages/SortPage.js";
import FilterPage from "../../pages/FilterPage.js";
import ArrayHelper from "../../helper/ArrayHelper.js";
import HotelSearchResultPage from "../../pages/HotelSearchResultPage.js";
import DetailedResultInfoPage from "../../pages/DetailedResultInfo.js";

const homePage = new HomePage();
const calendarPage = new CalendarPage();
const sortPage = new SortPage();
const filterPage = new FilterPage();
const arrayHelper = new ArrayHelper();
const hotelSearchReSultPage = new HotelSearchResultPage();
const detailedResultInfoPage = new DetailedResultInfoPage();
const assert = require ("chai")

fixture('Displays Correct Information')
test('Displays Correct Information Test', async t =>{
    await homePage.skipAd()
    await homePage.inputDestination("Da Nang")
    await calendarPage.selectFutureDate("Fri Mar 10 2023", "Thu Mar 30 2023")
    await homePage.goToOccupancyBox('Family travelers', 2, 4)
    await homePage.clickSearchButton()
    await sortPage.showSearchResult(5)
    await filterPage.filterFacility(["Non-smoking"])
    await filterPage.detailedReviewPoints()
    let reviewPointsOfSelectedResult = await hotelSearchReSultPage.getSearchDetailedResult()
    let reviewHotelName = await hotelSearchReSultPage.getHotelName()
    let reviewDestination = await hotelSearchReSultPage.getHotelDestination()
    let reviewFacility = await hotelSearchReSultPage.getHotelFacility()

    assert
        .expect(detailedResultInfoPage.CorrectResultInfo.Name)
        .equal(hotelSearchReSultPage.hotelSearchResult.Name)
    assert
        .expect(detailedResultInfoPage.CorrectResultInfo.Destination)
        .equal(reviewDestination)
    assert
        .expect(detailedResultInfoPage.CorrectResultInfo.Facility)
        .equal(reviewFacility)
    assert
        .expect(detailedResultInfoPage.getDetailedResultInfo.Category_Points)
        .deep.equal(reviewPointsOfSelectedResult)
})

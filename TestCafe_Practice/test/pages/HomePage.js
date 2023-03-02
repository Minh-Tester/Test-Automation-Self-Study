import { Selector, t } from "testcafe";
import BasePage from "../common/BasePage";
import SegmentOccupancyPage from "./SegmentOccupancyPage";
import getElementsByXPath from "../helper/XPath"


const segmentOccupancy = new SegmentOccupancyPage();

class HomePage extends BasePage{
    constructor(){
        super();
        //SubTitile
        this.welcomeMessage = Selector('hi').withText('HOTELS, RESORTS, HOSTELS & MORE')
        //Tab List
        this.hotelsAndHomesTab = Selector('li[data-element-name="all-rooms-tab"]')
        this.privateStaysTab = Selector('li[data-element-name="home"]')
        this.flightHotelTab = Selector('lli[data-element-name="packages-tab"]')
        this.flightsTab = Selector('li[data-element-name="flight-tab"]')
        this.longStaysTab = Selector('li[data-element-name="long-stay-tab"]')
        this.activitiesTab = Selector('li[data-element-name="activities-tab"]r')


        this.overnightStays = Selector('span').withText('Overnight Stays')
        this.dayUseStays = Selector('span').withText('Day Use Stays')

        this.destinationAndProtertySearch = Selector('div[data-element-name="autocomplete-box"]')
        this.firstValue = Selector(getElementsByXPath("(//li[contains(@data-selenium, 'autosuggest-item')])[1]"))
        
        //Calendar
        this.checkinIconBox = Selector('div[data-element-name="check-in-box"]')
        this.checkoutIconBox = Selector('div[data-element-name="check-out-box"]')

        //Occupancy
        this.occupancyIconBox = Selector("i[class ='ficon ficon ficon-12 ficon-thin-arrow-down']")
        this.soloTravelerSegment = this.occupancyIconBox.find('span').withText('Solo traveler')
        this.couplePairSegment = this.occupancyIconBox.find('div').withText('Couple/Pair')
        this.familyTravelersSegment = Selector("div[data-element-name='traveler-families']")
        this.groupTravelersSegment = this.occupancyIconBox.find('div').withText('Group travelers')
        this.businessTravelersSegment = this.occupancyIconBox.find('div').withText('Business travelers')

        this.addFlight = Selector("div[data-element-name='data-element-name']")
        this.addHotel = Selector("button[aria-label='Add Room']")
        this.addAdult = Selector("button[aria-label='Add Adult']")

        //Add and Minus Room
        this.addRooms = Selector("button[aria-label='Add Room']")
        this.addAdults = Selector("button[aria-label='Add Adults']")

        //Ad
        this.skipAdButton = Selector('button.ab-message-button').withText('No thanks')

        //Search
        this.searchBtn = Selector("button[data-element-name='search-button']")

    }
    
    async goToHomePage(){
        await this.GoToHomePage()
    }

    async goToCheckinCalendar(){
        await this.clickButton(this.checkinIconBox)
    }

    async skipAd() {
        await this.clickButton(this.skipAdButton)
    }

    async inputDestination(value) {
        await this.clickButton(this.destinationAndProtertySearch)
        await this.inputValueToFieldTextBox(this.destinationAndProtertySearch, value)
        await this.clickButton(this.firstValue);
    }

    async goToOccupancyBox(option, roomNumber, adultNumber) {
       // await this.clickButton(this.occupancyIconBox)
        await segmentOccupancy.selectTravalerOpiton(option, roomNumber, adultNumber)
    }

    async clickSearchButton() {
        await this.clickButton(this.searchBtn)
    }

}
export default HomePage;

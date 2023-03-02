import { Selector } from "testcafe";
import BasePage from "../common/BasePage";

class SegmentOccupancyPage extends BasePage {
    constructor() {
        super();
        this.occupancyIconBox = Selector("i[class ='ficon ficon ficon-12 ficon-thin-arrow-down']")
        this.segmentOccupancyNew = Selector("div[class = 'SegmentOccupancy__travelType']")
        this.familyTravelersSegment = Selector("div[data-element-name='traveler-families']")
        this.labelRoom = Selector('div[data-component="desktop-occ-room-value"]')
        this.addRooms = Selector('[data-selenium="plus"][data-element-name="occupancy-selector-panel-rooms"]')
        this.addAdults = Selector('[data-selenium="plus"][data-element-name="occupancy-selector-panel-adult"]')
        this.segmentOccupancyOld = Selector("div[class = 'SegmentOccupancy__occupancy']")

        //Old
        this.substractRoomBtn = Selector('[data-element-name="occupancy-selector-panel-rooms"][data-selenium="minus"]')
        this.addRoomBtn = Selector('[data-element-name="occupancy-selector-panel-rooms"][data-selenium="plus"]')
        this.substractAdultBtn = Selector('[data-element-name="occupancy-selector-panel-adult"][data-selenium="minus"]')
        this.addAdultsBtn = Selector(' [data-element-name="occupancy-selector-panel-adult"][data-selenium="plus"]')
        this.numberOfRooms = Selector('span[data-component="desktop-occ-room-value"]')
        this.numberOfAdults = Selector('span[data-component="desktop-occ-adult-value"]')
        this.numberOfChildren = Selector('span[data-component="desktop-occ-children-value"]')
        this.oldUXNumberOfRoom = Selector('[data-component="desktop-occ-room-value"][data-selenium="desktop-occ-room-value"]')
        this.oldUXNumberOfAdults = Selector('[data-component="desktop-occ-adult-value"][data-selenium="desktop-occ-adult-value"]')
    }

    async selectRoomNumber(diff) {
        if (diff > 0) {
            await this.clickUntilEqual(diff, this.addRoomBtn)
        }
        else if (diff < 0) {
            await this.clickUntilEqual(diff, this.substractRoomBtn)
        }
    }

    async selectAdultNumber(diff) {
        if (diff > 0) {
            await this.clickUntilEqual(diff, this.addAdultsBtn)
        }
        else if (diff < 0) {
            await this.clickUntilEqual(diff, this.substractAdultBtn)
        }
    }

    async selectTravalerOpiton(option, roomNumber, adultNumber) {
        let diffRoom
        let diffAdult

        if (await this.addRoomBtn.exists) {
            diffRoom = roomNumber - parseInt(await this.oldUXNumberOfRoom.textContent)
            diffAdult = adultNumber - parseInt(await this.oldUXNumberOfAdults.textContent)
            await this.selectAdultNumber(diffAdult)
            await this.selectRoomNumber(diffRoom)
        }
        else {
            const travelerOpiton = Selector('div.TravellerSegment__row.TravellerSegment__title').withText(option)
            await this.clickButton(travelerOpiton)
            if (this.numberOfRooms.exists) {
                diffRoom = roomNumber - parseInt(await this.numberOfRooms.textContent)
                diffAdult = adultNumber - parseInt(await this.numberOfAdults.textContent)
                await this.selectAdultNumber(diffAdult)
                await this.selectRoomNumber(diffRoom)
            }
        }
        await this.clickButton(this.occupancyIconBox)
    }
}
export default SegmentOccupancyPage

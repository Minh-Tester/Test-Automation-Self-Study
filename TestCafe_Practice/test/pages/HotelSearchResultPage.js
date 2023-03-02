import { Selector } from "testcafe";
import BasePage from "../common/BasePage";
import getElementsByXPath from "../helper/XPath"

class HotelSearchResultPage extends BasePage {
    constructor() {
        super();
        this.detailedHotelName = '(//h3[@data-selenium="hotel-name"])[1]'
        this.detailedHotelDestination = '(//span[@data-selenium="area-city-text"])[1]'
        this.detailedHotelFacility = '(//span[@data-selenium="filter-item-text"])[1]'
        this.detailedReviewPoint = '(//strong[@data-selenium="review-point"])[number]'

        this.hotelSearchResult = 
        {
            Name: null,

        }
    }
    async getSearchDetailedResult() {
        await this.hoverElement(getElementsByXPath("(//p[contains(@class, 'Typographystyled__TypographyStyled-sc-j18mtu-0 Hkrzy kite-js-Typography')])[1]"))        
        let categoryPoints = []
        for (let i = 1; i < 6; i++) {
            let categoryPoint = await getElementsByXPath(this.detailedReviewPoint.replace("number", i)).textContent
            categoryPoints.push(categoryPoint)
            
        }
        let reviewInfo = {
            Cleaniness: categoryPoints[0],
            Facilities: categoryPoints[1],
            Location: categoryPoints[2],
            Service: categoryPoints[3],
            ValueForMoney: categoryPoints[4]
        }
        console.log(reviewInfo)
        return reviewInfo.toString()
    }

    async getHotelName() {
        let nameHotel = await getElementsByXPath(this.detailedHotelName).textContent
        this.hotelSearchResult.Name = nameHotel
        console.log(this.hotelSearchResult.Name)
        return this.hotelSearchResult.Name
    }

    async getHotelDestination() {
        let destinationHotel = await getElementsByXPath(this.detailedHotelDestination).textContent
        let reviewDestination = destinationHotel
        console.log(reviewDestination)
        return reviewDestination
    }

    async getHotelFacility() {
        let facilityHotel = await getElementsByXPath(this.detailedHotelFacility).textContent
        let reviewFaciity = facilityHotel
        console.log(reviewFaciity)
        return reviewFaciity
    }



}
export default HotelSearchResultPage;

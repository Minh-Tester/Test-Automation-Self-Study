import BasePage from "../common/BasePage";
import { Selector, t } from "testcafe";
import getElementsByXPath from  "../helper/XPath"

class DetailedResultInfoPage extends BasePage {
    constructor() {
        super();
        this.resultReviewPointCategories = '(//strong[@data-selenium="review-point"])[number]'

        this.detailedReviewPoint = '(//p[@class="Typographystyled__TypographyStyled-sc-j18mtu-0 gegXOb kite-js-Typography "])[number]'
        this.detailedHotelName = '[data-selenium="hotel-header-name"]'
        this.detailedHotelDestination = '(//span[@data-selenium="hotel-address-map"])'
        this.detailedHotelFacility = '(//span[@class="Spanstyled__SpanStyled-sc-16tp9kb-0 gwICfd kite-js-Span "])[86]'

        this.getDetailedResultInfo = 
        {
            Name: null,
            Destination: null,
            Facility: null,
            Category_Points: null
        }

        this.CorrectResultInfo = 
        {
            Name: null,
            Destination: null,
            Facility: null,
            Category_Points: null
        }

    }
    async getDetailedResult() {
        let categoryPoints = []
        for (let i = 1; i < 6; i++) {
            let categoryPoint = await getElementsByXPath(this.resultReviewPointCategories.replace("number", i)).textContent
            categoryPoints.push(categoryPoint)
            
        }
        this.getDetailedResultInfo.Category_Points = {
            Cleaniness: categoryPoints[0],
            Facilities: categoryPoints[1],
            Location: categoryPoints[2],
            Service: categoryPoints[3],
            ValueForMoney: categoryPoints[4]
        }
        console.log(this.getDetailedResultInfo.Category_Points)
        return this.getDetailedResultInfo.Category_Points
    }

    async getCorrectInfo() {
        await t.maximizeWindow()
        await this.hoverElement(getElementsByXPath('(//div[@class="ReviewScoreCompact__section"])'))
        let nameHotel = await Selector(this.detailedHotelName).textContent
        let destinationHotel = await getElementsByXPath(this.detailedHotelDestination).textContent
        let facilityHotel = await getElementsByXPath(this.detailedHotelFacility).textContent

        let detailedReviewPoints = []
        for (let i = 1; i < 6; i++) {
            let detailedReviewPoint = await getElementsByXPath(this.detailedReviewPoint.replace("number", i)).textContent
            detailedReviewPoints.push(detailedReviewPoint)
            
        }
        this.CorrectResultInfo.Name = nameHotel
        this.CorrectResultInfo.Destination = destinationHotel
        this.CorrectResultInfo.Facility = facilityHotel
        this.CorrectResultInfo.Category_Points = {
            Cleaniness: detailedReviewPoints[0],
            Facilities: detailedReviewPoints[1],
            Location: detailedReviewPoints[2],
            Service: detailedReviewPoints[3],
            ValueForMoney: detailedReviewPoints[4]
        }
        console.log( this.CorrectResultInfo.Name)
        console.log( this.CorrectResultInfo.Destination)
        console.log( this.CorrectResultInfo.Facility)
        console.log( this.CorrectResultInfo.Category_Points)
    }
}
export default DetailedResultInfoPage;

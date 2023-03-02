import { Selector } from "testcafe";
import BasePage from "../common/BasePage";
import getElementsByXPath from "../helper/XPath"
import ArrayHelper from "../helper/ArrayHelper";
import DetailedResultInfoPage from "./DetailedResultInfo";

const arrayPage = new ArrayHelper();
const detailedResultInfoPage = new DetailedResultInfoPage

class FilterPage extends BasePage {
    constructor() {
        super();
        //Price
        this.minimumPriceFilterText = Selector(getElementsByXPath("(//input[contains(@aria-label, 'Minimum price filter')])[1]"))
        this.maximumPriceFilterText = Selector(getElementsByXPath("(//input[contains(@aria-label, 'Maximum price filter')])[1]"))

        //Stars
        this.fourStarRating = Selector(getElementsByXPath("(//span[contains(@aria-label, 'list-filter-item-label-1')])[1]"))

        //Clear
        this.clearBtn = Selector('[aria-label="Clear filter Your filters"][data-hammerhead-focused="true"]')

        //detailedInfo
        this.firstDetailedInfo = Selector(getElementsByXPath("(//p[contains(@class, 'Typographystyled__TypographyStyled-sc-j18mtu-0 Hkrzy kite-js-Typography')])[1]"))

    }

    async filterPriceAndStar(miniPrice, maxPrice, starRating) {
        await this.clickButton(this.minimumPriceFilterText)
        await this.inputValueToFieldTextBox(this.minimumPriceFilterText, miniPrice)
        await this.clickButton(this.maximumPriceFilterText)
        await this.inputValueToFieldTextBox(this.maximumPriceFilterText, maxPrice)
        await arrayPage.filterHotelByStarrating(starRating)
    }

    async showFilteredResult(numbOfHotels, miniPrice, maxPrice, starRating) {
        await arrayPage.getStringArray("//div[contains(@aria-label, 'Nearest transportation options')]", numbOfHotels)
        await arrayPage.verifyArrayPriceSorted(await arrayPage.getNumberArray("//span[contains(@data-selenium, 'display-price')]", numbOfHotels), miniPrice, maxPrice)
        await arrayPage.verifyFilterByStarratingCorrectly(numbOfHotels, starRating) 
    }

    async filterFacility(propFacility) {
        await arrayPage.filterHotelByPropertyFacilities(propFacility)
    }

    async detailedReviewPoints() {
        await this.hoverElement(this.firstDetailedInfo)
        await detailedResultInfoPage.getDetailedResult()
        await this.clickElement(this.firstDetailedInfo)
        await detailedResultInfoPage.getCorrectInfo()
        //await arrayPage.verifyDetailedResultDisplayCorrectly()
    }
}
export default FilterPage;

import { Selector,t } from "testcafe";
import BasePage from "../common/BasePage";
import ArrayHelper from "../helper/ArrayHelper";

const arrayHelper = new ArrayHelper();

class SortPage extends BasePage {
    constructor() {
        super();
        //Lowest price first
        this.lowestPriceFirst = Selector('a[data-element-name="search-sort-price"]')

        //Best match
        this.bestMatch = Selector('a[data-element-name="search-sort-recommended"]')
    }

    async goToLowestPriceFirst() {
        await this.clickButton(this.lowestPriceFirst)
    }

    async goToBestMatch() {
        await this.clickButton(this.bestMatch)
    }


    async sortLowestPrice(numbOfHotels) {
        await arrayHelper.verifyArrayNumberSorted(await arrayHelper.getNumberArray("//span[contains(@data-selenium, 'display-price')]", numbOfHotels));
    }

    async showSearchResult(numbOfHotels) {
        await arrayHelper.getStringArray("//div[contains(@aria-label, 'Nearest transportation options')]", numbOfHotels);
    }

    async resetPriceSlice(numbOfHotels) {
        let searchBtnForResetPrice = Selector('[data-selenium="searchButton"][data-element-name="search-button"]')
        await this.clickButton(searchBtnForResetPrice)
        await arrayHelper.getStringArray("//div[contains(@aria-label, 'Nearest transportation options')]", numbOfHotels);
        await arrayHelper.getNumberArray("//span[contains(@data-selenium, 'display-price')]", numbOfHotels)
    }
}
export default SortPage;

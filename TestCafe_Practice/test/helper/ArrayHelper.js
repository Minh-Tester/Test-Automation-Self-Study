import { Selector, t } from "testcafe";
import BasePage from "../common/BasePage";
import getElementsByXPath from "./XPath";


class ArrayHelper extends BasePage{
    constructor(){
        super();
        
        //Star Rating
        this.StarratingCheckBox = '[aria-label=" number-Star rating "][role="checkbox"]'
        this.StarratingPath = '(//div[@class="sc-bdfBwQ sc-gsTCUz  jZvduX"])[number]//*[@href="#StarSymbolFillIcon"]'

        //Facilities
        this.showMoreFacilitiesWithA = Selector(getElementsByXPath('(//a[@aria-label="Show 13 more Facilities"])'))
        this.ShowMoreFacilitiesWithDiv =Selector(getElementsByXPath('(//div[@aria-label="Show 13 more Facilities"])'))
        this.ShowMoreFacilitiesWithSpan = Selector(getElementsByXPath('(//span[@class="sc-iBPRYJ sc-fubCfw dyNXNh iNNsXg sc-pFZIQ gbgfMs"])[8]'))
        this.ShowMoreFacilities= Selector('[aria-controls="f1684f8b45cbb"]')
        this.NonSmokingCheckBox = '[aria-label="facility"]'

        //ReviewResults
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
    }


    async getStringArray(xpahtList, expNum){
        let array = []
        let path = `(${xpahtList})[number]`

        for (let i = 1; i < expNum + 1; i++) {
            let element = Selector(getElementsByXPath(path.replace('number', i)))
            await t
                .scrollIntoView(element)
            array[i - 1] = (await element.innerText)
        }
        console.log(array)
        return array;
    }
    
    async getNumberArray(xpahtList, expNum) {
        let array = []
        let path = `(${xpahtList})[number]`

        for (let i = 1; i < expNum + 1; i++) {
            let element = Selector(getElementsByXPath(path.replace('number', i)))
            await t 
                .scrollIntoView(element)
            array[i - 1] = parseFloat((await element.innerText).replace(/,/g, ''))
        }
        console.log(array)
        return array;
    }

    async verifyArrayNumberSorted(array) {
        let result = false
        for (let i = 0; i < array.length; i++) {
            if (array[i] <= array[i+1]) {
                result = true
            }
            
        }
        console.log(result)
        return result;
    }

    async verifyArrayPriceSorted(array, minNumb, maxNumb) {
        let result = false
        for (let i = 0; i < array.length; i++) {
            if (minNumb <= array[i] <= maxNumb) {
                result = true
            }
            
        }
        console.log(result)
        return result;
    }

    async filterHotelByStarrating(arrayStar) {
        for (let i = 0; i < arrayStar.length; i++) {
            let path = await this.replaceValue(this.StarratingCheckBox, 'number', arrayStar[i])
            console.log(path)
            await this.clickButton(Selector(path))
        }
    }

    async verifyFilterByStarratingCorrectly(numbHotels, arrayStar) {
        let result = false
        for (let i = 1; i < numbHotels + 1; i++) {
            let path = await this.replaceValue(this.StarratingPath, 'number', i)
            let number = await Selector(getElementsByXPath(path)).count
            console.log(number)
            for (let j = 0; j < arrayStar.length; j++) {
                if (number == arrayStar[j]) {
                    result = true
                } else {
                    result = false
                }                   
            }            
        }
        await t 
            .expect(result).ok()
    }

    async filterHotelByPropertyFacilities(arrayFacilities) {
        if (await this.showMoreFacilitiesWithA.exists) {
            await this.clickButton(this.showMoreFacilitiesWithA)
            for (let i = 0; i < arrayFacilities.length; i++) {
                let path = await this.replaceValue(this.NonSmokingCheckBox, 'facility', arrayFacilities[i])
                console.log(path)
                await this.clickButton(Selector(path))
            
            }
        }
        else if (await this.ShowMoreFacilities.exists) {
            await this.clickButton(this.ShowMoreFacilities)
            for (let i = 0; i < arrayFacilities.length; i++) {
                let path = await this.replaceValue(this.NonSmokingCheckBox, 'facility', arrayFacilities[i])
                console.log(path)
                await this.clickButton(Selector(path))
            
            }
        }
        else if (await  this.ShowMoreFacilitiesWithSpan.exists) {
            await this.clickButton(this.ShowMoreFacilitiesWithSpan)
            for (let i = 0; i < arrayFacilities.length; i++) {
                let path = await this.replaceValue(this.NonSmokingCheckBox, 'facility', arrayFacilities[i])
                console.log(path)
                await this.clickButton(Selector(path))
            }
        }
        else if (await  this.ShowMoreFacilitiesWithDiv.exists) {
            await this.clickButton(this.ShowMoreFacilitiesWithDiv)
            for (let i = 0; i < arrayFacilities.length; i++) {
                let path = await this.replaceValue(this.NonSmokingCheckBox, 'facility', arrayFacilities[i])
                console.log(path)
                await this.clickButton(Selector(path))
            }
        }
        else {
            for (let i = 0; i < arrayFacilities.length; i++) {
                let path = await this.replaceValue(this.NonSmokingCheckBox, 'facility', arrayFacilities[i])
                console.log(path)
                await this.clickButton(Selector(path))
            
            }
        }   
        return arrayFacilities
    }



    async verifyDetailedResultDisplayCorrectly (){
        await t.expect(this.getDetailedResult).eql(this.getCorrectInfo)
    }
}
export default ArrayHelper

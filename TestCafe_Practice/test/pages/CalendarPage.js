import { Selector,t } from "testcafe";
import BasePage from "../common/BasePage";
import MomentHelper from "../helper/MomentHelper";


const momentHelper = new MomentHelper();

class CalendarPage extends BasePage {
    constructor(){
        super();
        this.nextMonthBtn = Selector('[data-selenium="calendar-next-month-button"]')
        this.dayPicker = Selector('[class="Popup__content"]')
        this.priceNoti = Selector('[class="CalendarLegendItem__Text--PriceTrendText"]').withText("Approximate prices (in VND) for one night stay in a 3-star property for the searched location");
        this.startDate = 'div[aria-label="startDate"]'
        this.endDate = 'div[aria-label="endDate"]'

    }
    async selectBookingDate(startDow, days) {
        let checkInDate = Selector('div').withAttribute('aria-label', await momentHelper.getNextDayOfWeek(startDow))
        let checkOutDate = Selector('div').withAttribute('aria-label', await momentHelper.getNextDayOfWeek(startDow, days));
        let previousMonthButton = Selector("span[data-selenium='calendar-previous-month-button']")
        await this.clickButton(previousMonthButton)
        await this.clickButton(checkInDate)
        await this.clickButton(checkOutDate)
    }

    async selectDate(dayOfWeek, dayAfterDestDay, format) {
        let formattedDate = momentHelper.getDestDay(dayOfWeek, dayAfterDestDay, format);
        let dateSelector = Selector(`div[aria-label="${formattedDate}"]`);
        // TODO: If/Else here to nexth month
        // Click next month and check if present
        // NOTE: Next month btn is not pressed
        await t.scrollIntoView(this.dayPicker)
        if (!(await dateSelector.exists))
        {
          await this.clickButton(this.nextMonthBtn)
          await this.selectDate1(dayOfWeek, dayAfterDestDay, format);
        }
            await t.scrollIntoView(dateSelector)
            await this.clickElement(dateSelector)
    }

    async selectFutureDate(checkinDate, checkoutDate) {
        if (await this.dayPicker.exists) {
            let startDate = this.startDate.replace("startDate", momentHelper.formatDate(checkinDate)) 
            let endDate = this.endDate.replace("endDate", momentHelper.formatDate(checkoutDate))
            await this.clickUntilExist(Selector(startDate), this.nextMonthBtn)
            await this.clickUntilExist(Selector(endDate), this.nextMonthBtn)
        }
    }
}
export default CalendarPage;

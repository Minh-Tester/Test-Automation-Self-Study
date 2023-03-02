import moment from "moment/moment";
import { Selector, t } from "testcafe";
import BasePage from "../common/BasePage";



class MomentHelper extends BasePage{
    constructor(){
        super();
        this.nextMonthBtn = Selector('[data-selenium="calendar-next-month-button"]')
        this.dayPicker = Selector('[class="DayPicker-wrapper"]')
    }

    async getNextDayOfWeek(dayOfWeek,format) {
        let resultDate
        //if we haven't yet passed the dayofWeek that I need:
        //For example dayOfWeek = 5 (Friday)
        if (moment().isoWeekday() < dayOfWeek) {
            //then give me this week's instance of that Friday
            resultDate = moment().isoWeekday(dayOfWeek);
        } else {
            // if we have passed Friday that I need, we'll move to next week
            resultDate = moment().add(1, 'weeks').isoWeekday(dayOfWeek);
        }
        return moment(resultDate).format(format); // Turns that Friday neither this week or next week to a format
    }

    async getDayFromNextDay(startDow, days, format) {
        var dayINeed = moment(await this.getDayFromNextDay(startDow)).add(days, 'days');
        return moment(dayINeed).format(format); //Returns format
    }

    async selectDate(dayOfWeek) {
        let formattedDate = this.getNextDayOfWeek(dayOfWeek);
        let dateSelector = Selector(`div[aria-label="${formattedDate}"]`);
        // TODO: If/Else here to nexth month
        // Click next month and check if present
        // NOTE: Next month btn is not pressed
        await t.scrollIntoView(this.dayPicker)
        if (! await dateSelector.exists)
        {
          await t.click(this.nextMonthBtn)
          await this.selectDate(dayOfWeek);
        }
        await t.scrollIntoView(dateSelector)
        await this.clickElement(dateSelector);
        
    }

    async getDestDay(dayOfWeek, dayAfterDestDay, format) {
        var goDate
        if (moment().isoWeekday() < dayOfWeek) {
            goDate = moment().isoWeekday(dayOfWeek + dayAfterDestDay)
        } else {
            goDate = moment().add(1, "weeks").isoWeekday(dayOfWeek + dayAfterDestDay)
        }
        return goDate.format(format);
    }
    
    formatDate(date) {
        return moment(date).format("ddd MMM DD YYYY")
    }
    
}
export default MomentHelper;

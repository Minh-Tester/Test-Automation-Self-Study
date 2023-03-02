using CoreFramework.Reporter;
using DriverManager = CoreFramework.DriverCore.WebDriverManager;
using FluentAssertions;
using Newtonsoft.Json;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Globalization;

namespace CoreFramework.DriverCore;
public class WebDriverAction
{
    public IWebDriver Driver;
    private WebDriverWait _explicitWait;
    private Actions _actions;
    public IJavaScriptExecutor Javascript;
    private int _timeWait = 60;

    public WebDriverAction()
    {
        Driver = DriverManager.GetCurrentDriver();
        _actions = new Actions(Driver);
        _explicitWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(_timeWait));
    }
    public void GoToUrl(string url)
    {
        Driver.Navigate().GoToUrl(url);
        HtmlReport.Pass("Go to URL [" + url + "]");
    }

    #region  MOVEMENTS
    public void MoveForward()
    {
        Driver.Navigate().Forward();

    }
    public void MoveBackward()
    {
        Driver.Navigate().Back();

    }
    public void RefreshPage()
    {
        Driver.Navigate().Refresh();

    }
    public void ScrollToBottomOfPage()
    {
        Javascript.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        Thread.Sleep(1000);
    }
    public void ScrollToTopOfPage()
    {
        Javascript.ExecuteScript("window.scrollTo(0, -document.body.scrollHeight)");
        Thread.Sleep(1000);
    }
    #endregion

    #region INTERACTING WITH ELEMENTS
    public By GetXpath(string locator)
    {
        return By.XPath(locator);
    }
    public string GetTitle()
    {
        return Driver.Title;
    }
    public string GetUrl()
    {
        return Driver.Url;
    }
    public string GetText(string locator)
    {
        return Driver.FindElement(By.XPath(locator)).Text;
    }
    public string GetTextFromIWebElem(IWebElement e)
    {
        return e.Text;
    }

    public IWebElement FindElementByXpath(string locator)
    {
        IWebElement e = Driver.FindElement(GetXpath(locator));
        HighlightElem(e);
        return e;
    }

    public IList<IWebElement> FindElementsByXpath(string locator)
    {
        return Driver.FindElements(GetXpath(locator));
    }


    public void PressEnter(string locator)
    {
        try
        {
            FindElementByXpath(locator).SendKeys(Keys.Enter);
            HtmlReport.Pass("Press enter on element [" + locator + "] passed");

        }
        catch (Exception excep)
        {
            HtmlReport.Fail("Press enter on element [" + locator + "] failed", TakeScreenShot());
            throw excep;
        }
    }
    public void Clear(string locator)
    {
        try
        {
            FindElementByXpath(locator).Clear();
            HtmlReport.Pass("Clear previous input in element [" + locator + "] passed");

        }
        catch (Exception excep)
        {
            HtmlReport.Fail("Clear previous input in element [" + locator + "] failed", TakeScreenShot());
            throw excep;
        }
    }
    public void Click(string locator)
    {
        try
        {
            IWebElement btnToClick = WaitToBeClickable(locator);
            HighlightElem(btnToClick);
            btnToClick.Click();
            HtmlReport.Pass("Clicking on element [" + locator + "] passed");

        }
        catch (Exception excep)
        {
            HtmlReport.Fail("Clicking on element [" + locator + "] failed", TakeScreenShot());
            throw excep;
        }
    }
    public void JSExeClick(string locator)
    {
        try
        {
            IWebElement btnToClick = WaitToBeClickable(locator);
            HighlightElem(btnToClick);
            Javascript.ExecuteScript("arguments[0].click();", btnToClick);
            HtmlReport.Pass("Clicking on element [" + locator + "] passed");

        }
        catch (Exception excep)
        {
            HtmlReport.Fail("Clicking on element [" + locator + "] failed");
            throw excep;
        }
    }
    public void DoubleClick(string locator)
    {
        try
        {
            IWebElement btnToDoubleClick = WaitToBeClickable(locator);
            HighlightElem(btnToDoubleClick);
            _actions.DoubleClick(btnToDoubleClick).Perform();
            HtmlReport.Pass("Double click on element [" + locator + "] successfuly");
        }
        catch (Exception ex)
        {
            HtmlReport.Fail("Double click on element [" + locator + "] failed");
            throw ex;
        }
    }
    public void HoverBtn(string locator)
    {
        try
        {
            IWebElement btnToHover = WaitToBeVisible(locator);
            HighlightElem(btnToHover);
            _actions.MoveToElement(btnToHover).Perform();
            HtmlReport.Pass("Hover on element [" + locator + "] successfuly");
        }
        catch (Exception ex)
        {
            HtmlReport.Fail("Hover on element [" + locator + "] failed");
            throw ex;
        }
    }
    public void JSExeDoubleClick(string locator)
    {

        try
        {
            IWebElement btnToDoubleClick = WaitToBeClickable(locator);
            HighlightElem(btnToDoubleClick);
            Javascript.ExecuteScript("arguments[0].dblclick();", btnToDoubleClick);
            HtmlReport.Pass("Double click on element [" + locator + "] successfuly");
        }
        catch (Exception ex)
        {
            HtmlReport.Fail("Double click on element [" + locator + "] failed");
            throw ex;
        }
    }
    public void RightClick(string locator)
    {
        try
        {
            IWebElement btnToRightClick = WaitToBeClickable(locator);
            HighlightElem(btnToRightClick);
            _actions.ContextClick(btnToRightClick).Perform();
            HtmlReport.Pass("Right click on element [" + locator + "] successfuly");
        }
        catch (Exception ex)
        {
            HtmlReport.Fail("Right click on element [" + locator + "] failed");
            throw ex;
        }
    }

    public void SendKeys(string locator, string key)
    {
        try
        {
            FindElementByXpath(locator).SendKeys(key);
            HtmlReport.Pass("Sendkeys to element [" + locator + "] passed");
        }
        catch (Exception excep)
        {
            HtmlReport.Fail("Sendkeys to element [ " + locator + " ] failed", TakeScreenShot());
            throw excep;
        }
    }
    public void ReplaceKey(string locator, string key)
    {
        try
        {
            Clear(locator);
            SendKeys(locator, key);
            HtmlReport.Pass("Clearing previous input in [" + locator + "] and " +
                "replacing it with [" + key + "] passed", TakeScreenShot());
        }
        catch (Exception excep)
        {
            HtmlReport.Fail("Clearing previous input in [" + locator + "] and " +
                "replacing it with [" + key + "] failed", TakeScreenShot());
            throw excep;
        }
    }

    public IWebElement HighlightElem(IWebElement e)
    {
        try
        {
            IJavaScriptExecutor jsDriver = (IJavaScriptExecutor)Driver;
            string highlightJavascript = "arguments[0].style.border='2px solid red'";
            jsDriver.ExecuteScript(highlightJavascript, new object[] { e });
            HtmlReport.Pass("Highlight element [" + e.ToString() + "] passed", TakeScreenShot());
            return e;

        }
        catch (Exception excep)
        {
            HtmlReport.Fail("Highlight element [" + e.ToString() + "] failed", TakeScreenShot());
            throw excep;

        }
    }
    public void SelectOption(string locator, string key)
    {
        try
        {
            IWebElement mySelectOption = FindElementByXpath(locator);
            SelectElement dropdown = new SelectElement(mySelectOption);
            dropdown.SelectByText(key);
            HtmlReport.Pass("Select element " + locator + " successfuly with " + key);
        }
        catch (Exception excep)
        {
            HtmlReport.Fail("Select element " + locator + " failed with " + key, TakeScreenShot());
            throw excep;
        }
    }

    public void ClosePopUp(string locator)
    {
        try
        {
            IWebElement popUpCloseButton = WaitToBeClickable(locator);
            popUpCloseButton.Click();
            HtmlReport.Pass("Close Pop up successfully");
        }
        catch (Exception excep)
        {
            HtmlReport.Fail("Close Pop up fail", TakeScreenShot());
            throw excep;

        }
    }
    #endregion

    #region WAIT TIME
    /// <summary>
    /// Explicit waits to check Visible/Clickable/Selectable
    /// </summary>
    public IWebElement WaitToBeVisible(string locator)
    {
        var btnToClick = _explicitWait.Until(
            ExpectedConditions.ElementIsVisible(GetXpath(locator)));
        return btnToClick;
    }
    public IWebElement WaitToBeClickable(string locator)
    {
        var btnToClick = _explicitWait.Until(
            ExpectedConditions.ElementToBeClickable(GetXpath(locator)));
        return btnToClick;
    }
    public bool WaitToBeSelected(string locator)
    {
        var btnToClick = _explicitWait.Until(
            ExpectedConditions.ElementToBeSelected(GetXpath(locator)));
        return btnToClick;
    }
    public void WaitForQueryResult(int waitTime)
    {
        Thread.Sleep(waitTime);
    }
    #endregion

    #region CAPTURE SCREENSHOT
    public string TakeScreenShot()
    {
        try
        {
            string path = HtmlReportDirectory.SCREENSHOT_PATH + ("/screenshot_" +
                DateTime.Now.ToString("yyyyMMddHHmmss")) + ".png"; // Dynamic name
            Screenshot ss = ((ITakesScreenshot)Driver).GetScreenshot();
            ss.SaveAsFile(path, ScreenshotImageFormat.Png);
            HtmlReport.Pass("Take screenshot successfully");
            return path;
        }
        catch (Exception excep)
        {
            HtmlReport.Fail("Take screenshot failed");
            throw excep;
        }
    }
    public string TakeScreenshotIf404()
    {
        string title = GetTitle();
        string path;
        if (title.Contains("404"))
        {
            path = TakeScreenShot();
            HtmlReport.Warning("Error 404 - Screenshot taken");
            return path;

        }
        path = TakeScreenShot();
        return path;
    }
    #endregion

    #region ADDING TIMESTAMP
    public string GetDateTimeStamp()
    {
        var VNCulture = new CultureInfo("vi-VN");
        var utcDate = DateTime.UtcNow;
        var VNDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(utcDate, "SE Asia Standard Time");
        string currentTimeVN = VNDate.ToString("yyyy_MM_dd_HH_mm_ss", VNCulture);
        return currentTimeVN;
    }
    #endregion

    #region VERIFYING / COMPARING / ASSERTING ACTIONS
    public bool VerifyElementIsDisplayed(string locator)
    {
        IWebElement e = Driver.FindElement(GetXpath(locator));

        if (e == null)
        {
            HtmlReport.Fail("Element is not displayed");
            return false;
        }
        else
        {
            HighlightElem(e);
            HtmlReport.Pass("Element [" + e.Text + "] is displayed", TakeScreenShot());
            return true;
        }
    }

    public List<bool> VerifyElementsAreDisplayed(List<string> locators)
    {
        List<bool> result = new List<bool>();
        foreach(string locator in locators)
        {
            IWebElement e = Driver.FindElement(GetXpath(locator));
            if (e == null)
            {
                HtmlReport.Fail("Element is not displayed", TakeScreenShot());
                result.Add(false);
            }
            else
            {
                HighlightElem(e);
                HtmlReport.Pass("Element [" + e.Text + "] is displayed", TakeScreenShot());
                result.Add(true);
            }
        }
        return result;

    }
    public void CompareTitles(string expectedTitle)
    {
        try
        {
            string actualTitle = GetTitle();
            actualTitle.Should().Match(expectedTitle);
            HtmlReport.Pass("Actual title [" + actualTitle + "] matches [" + expectedTitle + "]", 
                TakeScreenShot());
        }
        catch (Exception excep)
        {
            HtmlReport.Fail("Titles do not match", TakeScreenshotIf404());
            throw excep;
        }
    }
    public void CompareUrls(string expectedUrl)
    {
        try
        {
            string actualUrl = GetUrl();
            actualUrl.Should().Match(expectedUrl);
            HtmlReport.Pass("Actual Url [" + actualUrl + "] matches with expected Url [" + expectedUrl + "]", 
                TakeScreenShot());
        }
        catch (Exception excep)
        {
            HtmlReport.Fail("Urls do not match", TakeScreenshotIf404());
            throw excep;
        }
    }
    public void AssertEquals(object actual, object expected)
    {
        try
        {
            actual.Should().BeEquivalentTo(expected);
            HtmlReport.Pass("Actual data [" + actual.ToString() + "] matches " +
                "with expected data [" + expected.ToString() + "]");
        }
        catch (Exception excep)
        {
            HtmlReport.Fail("Actual data [" + actual + "] does not match " +
                "with expected data [" + expected + "]");
            throw excep;
        }
    }
    public void AssertListAscending(List<string> list)
    {
        try
        {
            list.Should().BeInAscendingOrder();
            HtmlReport.Pass("List is sorted in ascending order" + list.ToString());
        }
        catch (Exception excep)
        {
            HtmlReport.Fail("List is not sorted in ascending order" + list.ToString());
            throw excep;
        }
    }
    public void AssertListDescending(List<string> list)
    {
        try
        {
            list.Should().BeInDescendingOrder();
            HtmlReport.Pass("List is sorted in descending order" + list.ToString());
        }
        catch (Exception excep)
        {
            HtmlReport.Fail("List is not sorted in descending order" + list.ToString());
            throw excep;
        }
    }
    #endregion

    #region DEALING WITH GRID
    public string GetRowIndex(string rowLocator, string cellLocator, int index)
    {
        // return an indexed row
        return rowLocator + "[" + index + "]" + cellLocator;
    }

    public IList<IWebElement> GetAllRows(string rowLocator)
    {
        IList<IWebElement> allRows = FindElementsByXpath(rowLocator);
        return allRows;
    }

    public List<string> GetTextFromAllCellsOfOneRow(string rowLocator, string cellLocator, int index)
    {
        /// Return a list of cell web elements fow an indexed row
        /// Get texts from all cells of one row and add them to a list of strings
        
        List<string> valuesFromCells = new List<string>();
        IList<IWebElement> allCells = FindElementsByXpath
            (GetRowIndex(rowLocator, cellLocator, index));
        foreach (IWebElement cell in allCells)
        {
            valuesFromCells.Add(GetTextFromIWebElem(cell));
        }
        return valuesFromCells;
    }
    public object ConvertToJson(object obj)
    {
        var list = JsonConvert.SerializeObject(obj);
        return list;
    }
    #endregion

}


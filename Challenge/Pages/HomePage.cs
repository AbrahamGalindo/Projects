using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Challenge.Helpers;
using System.Text.RegularExpressions;

namespace Challenge.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) { Driver = driver; }

        protected By lblNumberItems = By.XPath("//h1[@class='ng-binding']");
        protected By btnSelectFile = By.Id("inputImage");
        protected By txtDescription = By.Name("text");
        protected By btnCreateItem = By.XPath("//button[@class='btn pull-right btn-success']");
        protected By btnEditItem = By.XPath("//button[@ng-click='strangerlist.setCurrentItem(item)']");
        protected By btnUpdateItem = By.XPath("//button[@ng-click='strangerlist.updateItem(strangerlist.detailsForm.imageSrc)']");
        protected By lblDescriptionItem = By.XPath("//p[@class='story ng-binding']");
        protected By btnDeleteItem = By.XPath("//button[@ng-click='strangerlist.open(item)']");
        protected By btnDeleteConfirItem = By.XPath("//button[@ng-click='submit()']");

        public int itemNumber;
        public string newItemDescriprion;
        public int getNumberOfItems()
        {
            string text = getText(findElement(lblNumberItems));
            Match number = Regex.Match(text, "(\\d+)");
            return Int32.Parse(number.Value);
        }

        public string getDescriptionOfItem(int item) => getText(findElements(lblDescriptionItem)[item]);


        public void insertItem(string item)
        {
            item = Helper.GetCurrentPath(item + ".jpg");
            sendKeys(btnSelectFile, item);
        }

        public void insertDescription(string description)
        {
            newItemDescriprion = description + Helper.GenerateLetters(5);
            clear(findElement(txtDescription));
            sendKeys(txtDescription, newItemDescriprion);
        }

        public void insertDescription(int longDescription)
        {
            clear(findElement(txtDescription));
            sendKeys(txtDescription, Helper.GenerateLetters(longDescription));
        }

        public void clickCreateItem()
        {
            if (isEnabled(findElement(btnCreateItem)))
            {
                click(btnCreateItem);
            }
        }

        public int lastNumberOfItems() => getNumberOfItems();

        public void clickEditItem()
        {
            int numberOfButtons = findElements(btnEditItem).Count;
            itemNumber = Helper.GenerateRandomNumber(0, numberOfButtons - 1);
            click(findElements(btnEditItem)[itemNumber]);
        }

        public void clickUpdateItem() => click(btnUpdateItem);


        public void clickDeleteItem()
        {
            int numberOfButtons = findElements(btnDeleteItem).Count;
            for (int i = 0; i < numberOfButtons; i++)
            {
                if (getText(findElements(lblDescriptionItem)[i]).Contains("description for this item was created"))
                {
                    click(findElements(btnDeleteItem)[i]);
                }
            }
        }

        public void clickConfirmDeleteItem() => click(btnDeleteConfirItem);


        public bool hasItem()
        {
            bool hasItem = false;
            int numberOfButtons = findElements(btnDeleteItem).Count;
            for (int i = 0; i < numberOfButtons; i++)
            {
                if (getText(findElements(lblDescriptionItem)[i]).Contains("description for this item was created"))
                {
                    hasItem = true;
                    return hasItem;
                }
            }
            return hasItem;
        }

        public bool isEnabledButton() => isEnabled(findElement(btnCreateItem));

        public bool thereIsText(string text)
        {
            bool hasItem = false;
            int numberOfLabels = findElements(lblDescriptionItem).Count;
            for (int i = 0; i < numberOfLabels; i++)
            {
                if (getText(findElements(lblDescriptionItem)[i]).Contains(text))
                {
                    hasItem = true;
                    return hasItem;
                }
            }
            return hasItem;
        }
    }
}

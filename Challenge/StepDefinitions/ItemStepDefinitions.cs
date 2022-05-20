using AventStack.ExtentReports;
using Challenge.Helpers;
using Challenge.Pages;
using NUnit.Framework;
using System;
using System.Data;
using System.Diagnostics;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Challenge.StepDefinitions
{
    [Binding]
    public class ItemStepDefinitions : Base
    {
        HomePage home = new HomePage(Driver);
        int numberOfItems;
        string newItemDescription;
        string oldItemDescription;

        [Given(@"Open browser")]
        public void GivenOpenBrowser()
        {
            numberOfItems = home.getNumberOfItems();
        }

        [Given(@"Add the file (.*)")]
        public void GivenAddTheFile(string itemName)
        {
            home.insertItem(itemName);
        }

        [Given(@"Add the description")]
        public void GivenAddTheDescription()
        {
            home.insertDescription("description for this item was created");
        }

        [Given(@"Click on create Item")]
        public void GivenClickOnCreateItem()
        {
            home.clickCreateItem();
        }

        [Then(@"Confirm the item was created (.*)")]
        public void ThenConfirmTheItemWasCreated(string result)
        {
            if (result.Equals("false"))
            {
                Assert.AreEqual(numberOfItems, home.lastNumberOfItems());
            }
            else
            {
                Helper.Wait(Helper.tLow);
                Assert.AreEqual(numberOfItems + 1, home.lastNumberOfItems());
            }
        }

        [Given(@"Click on edit button random item")]
        public void GivenClickOnEditButtonRandomItem()
        {
            home.clickEditItem();
            oldItemDescription = home.getDescriptionOfItem(home.itemNumber);
        }

        [Given(@"Edit Item (.*) (.*)")]
        public void GivenEditItem(string itemToEdit, string itemName)
        {
            if (itemToEdit.Equals("image"))
            {
                home.insertItem(itemName);
            }
            else
            {
                home.insertDescription(itemName);

            }
        }

        [Given(@"Click on update Item")]
        public void GivenClickOnUpdateItem()
        {
            home.clickUpdateItem();
            newItemDescription = home.getDescriptionOfItem(home.itemNumber);
        }

        [Then(@"Confirm the item was updated (.*)")]
        public void ThenConfirmTheItemWasUpdated(string itemToEdit)
        {
            if (itemToEdit.Equals("image"))
            {
                Assert.AreEqual(oldItemDescription, newItemDescription);
            }
            else
            {
                Assert.AreEqual(newItemDescription, home.newItemDescriprion);
            }
        }

        [Given(@"Click on delete button of item created")]
        public void GivenClickOnDeleteButtonOfItemCreated()
        {
            home.clickDeleteItem();
        }

        [Given(@"Confirm delete item")]
        public void GivenConfirmDeleteItem()
        {
            home.clickConfirmDeleteItem();
        }

        [Then(@"Confirm the item was deleted")]
        public void ThenConfirmTheItemWasDeleted()
        {
            Helper.Wait(Helper.tLow);
            Assert.IsFalse(home.hasItem());
        }

        [Given(@"Add the description with specific long (.*)")]
        public void GivenAddTheDescriptionWithSpecificLong(int longDescription)
        {
            home.insertDescription(longDescription);
        }

        [Then(@"Validate the confirm buttom (.*)")]
        public void ThenValidateTheConfirmButtom(string enabledButton)
        {
            bool result = Convert.ToBoolean(enabledButton);
            Assert.AreEqual(result, home.isEnabledButton());
        }

        [Then(@"Validate if exits the text (.*)")]
        public void ThenValidateIfExitsTheText(string text)
        {
            Assert.IsTrue(home.thereIsText(text));
        }

    }
}

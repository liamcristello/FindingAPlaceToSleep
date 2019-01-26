using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // Number of item slots
    public const int numItemSlots = 4;
    /* 
     * Int and item arrays used to store necessary inventory items
     * and corresponding images. Each length is set to our   
     * numItemSlots variable.s
     */   
    public Image[] itemImages = new Image[numItemSlots];
    public Item[] items = new Item[numItemSlots];

    // Add item to inventory.
    public void AddItem(Item itemToAdd)
    {
        /*
         * Loops through items until finding an empty slot,
         * adds in and displays itemToAdd. Updates both items and
         * itemImages arrays so item is displayed correctly.
         */
         for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                itemImages[i].sprite = itemToAdd.sprite;
                itemImages[i].enabled = true;
                return;
            }
        }
    }

    // Remove item from inventory.
    public void RemoveItem(Item itemToRemove)
    {
        /*
         * Loops through items until finding itemToRemove,
         * and removes it. Updates both items and
         * itemImages arrays.
         */
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToRemove)
            {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                return;
            }
        }
    }
}

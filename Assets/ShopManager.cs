using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public ShopItem[] items;
    public ClimateChangeController climateChangeController;

    // Start is called before the first frame update
    void Start()
    {
        UpdateShopListing();
    }

    public void UpdateShopListing()
    {
        foreach (ShopItem shopItem in items) {
            if (shopItem.price <= climateChangeController.GetMoney() && (climateChangeController.GetProgress() / climateChangeController.maxProgress) <= 0.85) {
                shopItem.gameObject.SetActive(true);
            } else {
                shopItem.gameObject.SetActive(false);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DoozyUI;


public class storeScript : MonoBehaviour {

    public Text currentCPText;

    public GameObject storeList;
    public GameObject premiumStoreList;


    public class StoreItems
    {
        public string ItemName;
        public float itemPriceInCp;
        public float itemPriceInDollars;


        public StoreItems(string ItemNameConst, float itemPriceInCpConst, float itemPriceInDollarsConst)
        {
            ItemName = ItemNameConst;
            itemPriceInCp = itemPriceInCpConst;
            itemPriceInDollars = itemPriceInDollarsConst;
        }


    }


    public List<StoreItems> itemsList = new List<StoreItems>();



    public void Start()
    {
        StoreItems extraLife1 = new StoreItems("ExtraLife1", 30000f, 3f);
        StoreItems extraLife2 = new StoreItems("ExtraLife2", 100000f, 3f);
        StoreItems skipStage1 = new StoreItems("skipStage1", 100000f, 3f);
        StoreItems skipStage2 = new StoreItems("skipStage2", 200000f, 3f);
        StoreItems skipStage3 = new StoreItems("skipStage3", 500000f, 3f);
        StoreItems hiddenMode = new StoreItems("hiddenMode", 1000000f, 3f);

        itemsList.Add(extraLife1);
        itemsList.Add(extraLife2);
        itemsList.Add(skipStage1);
        itemsList.Add(skipStage2);
        itemsList.Add(skipStage3);
        itemsList.Add(hiddenMode);


        if (PlayerPrefs.HasKey("currentCP"))
        {
            int userPts = PlayerPrefs.GetInt("currentCP");
            currentCPText.text =  userPts.ToString();

            int currentCMP = 0;
            if (PlayerPrefs.HasKey("currentCPM"))
                currentCMP = PlayerPrefs.GetInt("currentCPM");

            if (userPts > 1000000000)
            {
                userPts -= 1000000000;
                currentCMP += 1;
                PlayerPrefs.SetInt("currentCP", userPts);
                PlayerPrefs.SetInt("currentCPM", currentCMP);
            }

            if (currentCMP > 0)
                currentCPText.text =  currentCMP.ToString() + "M";

        }
        else
            currentCPText.text = " 0";


    }

    public void askPurchase()
    {
        UIManager.ShowNotification("UINotification",20f,false);
    }

    public void backToMainMenu()
    {
        if (storeList.activeInHierarchy)
            SceneManager.LoadScene(0);
        else if (premiumStoreList.activeInHierarchy) {
            premiumStoreList.SetActive(false);
            storeList.SetActive(true);
        }

    }

    public void openPremiumShop() {
        storeList.SetActive(false);
        premiumStoreList.SetActive(true);
    }


}

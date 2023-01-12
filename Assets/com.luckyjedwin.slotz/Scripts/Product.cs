using System;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Product : MonoBehaviour
{
    private bool WasBought
    {
        get => PlayerPrefs.HasKey($"{productType}({price})");
    }

    public int price;
    [SerializeField] ProductType productType;

    public static Func<int, bool> OnBuyItem { get; set; }
    public static Action<ProductType, int> OnProductSelected { get; set; }

    private void Start()
    {
        transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() =>
        {
            OnProductSelected.Invoke(productType, transform.GetSiblingIndex());

            var products = FindObjectsOfType<Product>().Where(product => product.productType == productType);
            foreach (Product product in products)
            {
                product.SetActive(product.transform.GetSiblingIndex() == transform.GetSiblingIndex());
            }

            PlayerPrefsUtility.SetActiveProduct(productType, transform.GetSiblingIndex());
        });

        if (WasBought)
        {
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);

            var products = FindObjectsOfType<Product>().Where(product => product.productType == productType);
            foreach (Product product in products)
            {
                product.SetActive(product.transform.GetSiblingIndex() == PlayerPrefsUtility.GetActiveProduct($"{productType}"));
            }

            return;
        }

        GetComponent<Button>().onClick.AddListener(() =>
        {
            if(OnBuyItem.Invoke(price))
            {
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(true);

                PlayerPrefs.SetInt($"{productType}({price})", 1);
                PlayerPrefs.Save();
            }
        });
    }

    public void SetActive(bool IsActive)
    {
        if(!WasBought)
        {
            return;
        }

        transform.GetChild(1).gameObject.SetActive(!IsActive);
        transform.GetChild(2).gameObject.SetActive(!IsActive);
        transform.GetChild(3).gameObject.SetActive(IsActive);
    }
}

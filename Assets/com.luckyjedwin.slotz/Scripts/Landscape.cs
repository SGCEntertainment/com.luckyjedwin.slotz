using UnityEngine.UI;
using UnityEngine;

public class Landscape : MonoBehaviour
{
    private Image Image { get; set; }
    private void Awake()
    {
        Image = GetComponent<Image>();

        Product.OnProductSelected += (type, id) =>
        {
            if (type == ProductType.Airplane)
            {
                return;
            }

            PlayerPrefsUtility.SetBackgroundSprite(id);
            Image.sprite = PlayerPrefsUtility.GetBackgroundSprite;
        };
    }

    private void OnEnable()
    {
        Image.sprite = PlayerPrefsUtility.GetBackgroundSprite;
    }
}

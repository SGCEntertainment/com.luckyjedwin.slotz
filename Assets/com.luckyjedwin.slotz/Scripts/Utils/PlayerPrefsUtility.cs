using UnityEngine;

public static class PlayerPrefsUtility
{
    public static int GetActiveAirplane
    {
        get => PlayerPrefs.GetInt("airplane");
    }

    public static Sprite GetAirplaneplaneSprite
    {
        get => Resources.Load<Sprite>($"Airplanes/{GetActiveAirplane}");
    }

    public static void SetAirplaneSprite(int id)
    {
        PlayerPrefs.SetInt("airplane", id);
    }

    public static int GetActiveBackground
    {
        get => PlayerPrefs.GetInt("background");
    }

    public static Sprite GetBackgroundSprite
    {
        get => Resources.Load<Sprite>($"Backgrounds/{GetActiveBackground}");
    }

    public static void SetBackgroundSprite(int id)
    {
        PlayerPrefs.SetInt("background", id);
    }

    public static int GetActiveProduct(string productType)
    {
        return PlayerPrefs.GetInt(productType, 0);
    }

    public static void SetActiveProduct(ProductType productType, int id)
    {
        PlayerPrefs.SetInt($"{productType}", id);
        PlayerPrefs.Save();
    }
}

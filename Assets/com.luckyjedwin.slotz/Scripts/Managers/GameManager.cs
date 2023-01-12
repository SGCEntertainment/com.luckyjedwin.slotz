using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    public static Action OnGameStarted { get; set; }

    public int bidCount = 0;

    public void StartGame()
    {
        if(Product.OnBuyItem.Invoke(bidCount))
        {
            OnGameStarted?.Invoke();
        }
    }
}
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public int MaxNumberOfShots = 3;

    private int _usedNumberOfShots;
    
    private IconHandler _iconHandler;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        _iconHandler = FindAnyObjectByType<IconHandler>();
    }

    public void UseShot()
    {
        _usedNumberOfShots++;
        _iconHandler.UseShot(_usedNumberOfShots);
    }
    
    public bool HasEnoughShots()
    {
        return _usedNumberOfShots < MaxNumberOfShots;
    }
}

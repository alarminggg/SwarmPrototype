using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // DESIGN PATTERN: SINGLETON
    public static GameManager Instance { get; private set; }
    public UIManager UIManager { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        UIManager = GetComponent<UIManager>();
       
    }

    void Update()
    {
        
        
    }

    public void GameOver()
    {
        Instance.UIManager.ActivateEndGame();
        MenuController.IsGamePaused = true;
        
    }
}

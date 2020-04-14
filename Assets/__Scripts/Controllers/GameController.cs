using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Variables
    // score text etc

    // Private Variables
    private int playerScore;
    private int playerHealth;
    private float timeDelay = 1.5f; // Used to delay menu when player dies
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable() {
        //Killed Enemy
        Enemy.EnemyKilledEvent += OnEnemyKilledEvent;
    }
    private void OnDisable()
    {
        Enemy.EnemyKilledEvent -= OnEnemyKilledEvent;
    }
    private void OnEnemyKilledEvent(Enemy enemy)
    {
        //Add Score here
        
    }

}

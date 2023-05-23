using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryScreen : MonoBehaviour
{
    public TMP_Text defEnemyCount;
    public TMP_Text gmStatus;
    int defEnemy = 0;
    public Canvas pUI;
    public Canvas vicScreen;

    public void updateDefEnemy(){
        defEnemy++;
    }
    
    public void gameClear(string a){
        gmStatus.text = a;
        Cursor.lockState = CursorLockMode.None;
        defEnemyCount.text = "Enemy Defeated:\n"+defEnemy.ToString();
        vicScreen.planeDistance = 0.5f;
        pUI.enabled = false;
    } 
}

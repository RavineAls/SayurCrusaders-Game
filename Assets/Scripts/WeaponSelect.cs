using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponSelect : MonoBehaviour
{
    string selectedLevel;

    // Start is called before the first frame update
    void Start()
    {
        selectedLevel = "SampleScene";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectGolok()
    {
        selectedLevel = "SampleScene";
    }

    public void selectKeris()
    {
        selectedLevel = "KerisScene";
    }

    public void selectKujang()
    {
        selectedLevel = "KujangScene";
    }

    public void selectPan()
    {
        selectedLevel = "PanScene";
    }

    public void GotoGame()
    {
        SceneManager.LoadScene(selectedLevel);
    }
}

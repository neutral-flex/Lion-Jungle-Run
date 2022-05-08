using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public static Restart instance;

    public bool IsReset = false;
    public GameObject[] onObjects;
    public GameObject[] ofObjects;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        if (PlayerPrefs.GetInt("Restart") == 1)
        {
            ofObjects[0].SetActive(false);
            ofObjects[1].SetActive(false);


            onObjects[0].SetActive(true);
            onObjects[1].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

        

    }

    private void OnApplicationFocus(bool focus)
    {
        PlayerPrefs.SetInt("Restart", 0);

    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Restart", 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Count : MonoBehaviour
{
    TMPro.TMP_Text txt;
    int count;
    private void Awake()
    {
        txt = GetComponent<TMPro.TMP_Text>();
    }

    private void Update()
    {
        if (count == 31)
        {
            SceneManager.LoadScene(5);

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnEnable() => Coin.OnCoinCollected += OnCollectibleCollected;
    private void OnDisable() => Coin.OnCoinCollected -= OnCollectibleCollected;



    void OnCollectibleCollected()
    {
        count++;
        txt.text = (count).ToString();
        
    }
}



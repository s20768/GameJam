using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    
    void Start()
    {
        

    }

    
    void Update()
    {
        StartCoroutine(Hide());
    }
    private IEnumerator Hide()
    {
        
        yield return new WaitForSeconds(16);

        
            SceneManager.LoadScene(2);
        
    }

}

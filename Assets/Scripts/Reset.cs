using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Bryann Alfaro
 * Clase que reinicia la escena o la quita
 * Referencia: Laboratorios pasados
 */
public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    
    }

    public void QuitGame()
    {

        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();

    }
}

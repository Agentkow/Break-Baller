using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuChange : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private MenuManager manager;

    [SerializeField]
    private GameObject creditsMenu;
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (manager.menuCheck == 0)
            {
                SceneManager.LoadScene("Level");
            }
            else if (manager.menuCheck == 1)
            {
                creditsMenu.SetActive(true);
            }
            else if (manager.menuCheck == 2)
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
               Application.Quit ();
#endif
            }
        }
    }
}

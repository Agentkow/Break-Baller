using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuChange : MonoBehaviour
{
    [SerializeField]
    private MenuManager manager;

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

            }
            else if (manager.menuCheck == 2)
            {

            }
            else if (manager.menuCheck == 3)
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

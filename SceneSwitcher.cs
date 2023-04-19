using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class SceneSwitcher : MonoBehaviour
    {
        public void SwitchToScene(int index)
        {
            SceneManager.LoadScene(index);
        }
        public void ExitApplication()
        {
            Application.Quit();
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
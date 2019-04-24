using UnityEngine;

namespace ComputerGraphics
{
    public class QuitApp : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
                Quit();
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
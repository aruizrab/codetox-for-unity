using UnityEngine;

namespace Codetox.UI
{
    public class Billboard : MonoBehaviour
    {
        private void Update()
        {
            transform.forward = Camera.main.transform.forward;
        }
    }
}
using UnityEngine;

public class WinCube : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SetGameWin();
        }
    }
}

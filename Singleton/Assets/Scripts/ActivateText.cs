using UnityEngine;

public class ActivateText : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
        GameManager.Instance.DoSomething();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideController : MonoBehaviour
{
    public delegate void TakeItemAction(int sum);
    public static event TakeItemAction OnAddScore;
    public static event TakeItemAction OnMultiplyScore;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Money": OnAddScore?.Invoke(2); break;
            case "Education": OnAddScore?.Invoke(20); break;
            case "Alcohol": OnAddScore?.Invoke(-20); break;
            case "Party": OnAddScore?.Invoke(-20); break;
            case "Door": OnMultiplyScore?.Invoke(other.GetComponent<Door>().Multiplier); return;

        }

        Destroy(other.gameObject);
    }


}

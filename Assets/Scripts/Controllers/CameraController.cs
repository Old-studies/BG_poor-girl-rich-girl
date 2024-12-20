using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ButchersGames
{
    public class CameraController : MonoBehaviour
    {

        [SerializeField] GameObject target;
        private void Start()
        {
            Camera.main.orthographicSize = Screen.height / (Screen.width / 9f); // ratio 9:16
        }

        private void Update()
        {
            transform.position = target.transform.position;
            transform.rotation = target.transform.rotation;
        }

    }
}
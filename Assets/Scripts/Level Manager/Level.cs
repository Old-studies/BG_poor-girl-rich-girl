using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace ButchersGames
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform playerSpawnPoint;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (playerSpawnPoint != null)
        {
            Gizmos.color = Color.magenta;
            var m = Gizmos.matrix;
            Gizmos.matrix = playerSpawnPoint.localToWorldMatrix;
            Gizmos.DrawSphere(Vector3.up * 0.5f + Vector3.forward, 0.5f);
            Gizmos.DrawCube(Vector3.up * 0.5f, Vector3.one);
            Gizmos.matrix = m;
        }
    }
#endif

        [SerializeField] TextMeshProUGUI scoreTMP;

        private int currentScore = 0;

        private void Start()
        {
            scoreTMP.text = currentScore.ToString();
        }

        private void OnEnable()
        {
            CollideController.OnAddScore += AddScore;
            CollideController.OnMultiplyScore += MultiplyScore;
        }

        private void OnDisable()
        {
            CollideController.OnAddScore -= AddScore;
            CollideController.OnMultiplyScore -= MultiplyScore;
        }

        private void AddScore(int sum)
        {
            currentScore += sum;
            scoreTMP.text = currentScore.ToString();
        }

        private void MultiplyScore(int multiplier)
        {
            currentScore *= multiplier;
            scoreTMP.text = currentScore.ToString();
        }
    }
}
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace ButchersGames
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] List<GameObject> bodyes;

        private BodyState bodyState = BodyState.Casual;

        [SerializeField] SplineContainer spline;
        [SerializeField] float speed = 0.04f;
        [SerializeField] float swipeSensitivity = 0.5f;
        [SerializeField] float returnSpeed = 3f;
        [SerializeField] float maxOffset = 2.0f;
        [SerializeField] float rotationSpeed = 1f;

        private float progress = 0f;
        private float lateralOffset = 0f;
        private Quaternion startRotation;

        private void Start()
        {
            startRotation = transform.rotation;
        }

        void Update()
        {
            // Обрабатываем свайпы
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    lateralOffset += touch.deltaPosition.x * swipeSensitivity * Time.deltaTime;
                    lateralOffset = Mathf.Clamp(lateralOffset, -maxOffset, maxOffset); // Ограничиваем смещение
                }
            }

            // Движение по сплайну
            progress += speed * Time.deltaTime;
            if (progress > 1f)
            {
                progress = 0f;
                lateralOffset = 0;
                transform.rotation = startRotation;
            }

            // Вычисляем позицию на сплайне с учетом поперечного смещения
            Vector3 position = spline.EvaluatePosition(progress);
            Vector3 tangent = ((Vector3)spline.EvaluateTangent(progress)).normalized;

            // Вращаем объект в направлении касательного вектора
            if (tangent != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(tangent);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed); // rotationSpeed регулирует скорость поворота
            }

            Vector3 normal = Vector3.Cross(tangent, Vector3.up).normalized;

            Vector3 offsetPosition = position + normal * lateralOffset;
            transform.position = offsetPosition;
        }
    }
}

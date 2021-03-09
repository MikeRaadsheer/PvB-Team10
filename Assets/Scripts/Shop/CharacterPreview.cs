using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shop {

    public class CharacterPreview : MonoBehaviour
    {

        [SerializeField]
        private float _rotationSpeed = 1f;
        private float _rotation = 180f;

        void Update()
        {
            GetComponent<Transform>().Rotate(0, _rotationSpeed * Time.deltaTime, 0, Space.Self);
        }
    }
}



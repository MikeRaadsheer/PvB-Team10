using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Shop {

    public class CharacterPreview : MonoBehaviour
    {

        [SerializeField]
        private float _rotationSpeed = 1f;
        private float _rotation = 180f;

        [SerializeField]
        private List<Shop.Hat> _hats = new List<Shop.Hat>();
        private List<string> _ownedHats = new List<string>();
        private int _hatIndex = 0;
        private int _previousIndex;

        [SerializeField]
        private Vector3 _hatOffset = new Vector3(0, 1.7f, 0);
        private Transform _character;

        private void Awake()
        {
            _ownedHats.Add("none");
            _character = GetComponent<Transform>();
        }

        void Update()
        {
            GetComponent<Transform>().Rotate(0, _rotationSpeed * Time.deltaTime, 0, Space.Self);
        }

        public void NextHat()
        {
            _previousIndex = _hatIndex;
            CheckOwnedHats();
            // Remove current hat
            if (_ownedHats[_previousIndex] != "none") Destroy(_character.transform.Find("Hat").gameObject);

            // Increase hat index
            ++_hatIndex;
            _hatIndex %= _ownedHats.Count;

            // Place new hat
            if(_ownedHats[_hatIndex] != "none")
            {
                GameObject newHat;
                newHat = Instantiate(RetrieveHat(_ownedHats[_hatIndex]).model);
                newHat.transform.parent = _character;
                newHat.transform.localPosition = _hatOffset;
                newHat.name = "Hat";
                newHat.transform.eulerAngles = new Vector3(0, 0, 0);
            }
                
        }

        public void PreviousHat()
        {
            _previousIndex = _hatIndex;
            CheckOwnedHats();
            // Remove current hat
            if (_ownedHats[_previousIndex] != "none") Destroy(_character.transform.Find("Hat").gameObject);

            // Increase hat index
            --_hatIndex;
            if (_hatIndex < 0) _hatIndex = _ownedHats.Count - 1;

            // Place new hat
            if (_ownedHats[_hatIndex] != "none")
            {
                GameObject newHat;
                newHat = Instantiate(RetrieveHat(_ownedHats[_hatIndex]).model);
                newHat.transform.parent = _character;
                newHat.transform.localPosition = _hatOffset;
                newHat.name = "Hat";
                newHat.transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }

        private void CheckOwnedHats()
        {
            for(int i = 0; i < +_hats.Count; ++i)
            {
                if(_hats[i].bought && !_ownedHats.Contains(_hats[i].hatName))
                {
                    _ownedHats.Add(_hats[i].hatName);
                }
            }
        }

        private Shop.Hat RetrieveHat(string name)
        {
            for (int i = 0; i < +_hats.Count; ++i)
            {
                if (name == _hats[i].hatName)
                {
                    return _hats[i];
                }
            }
            throw new Exception("Could not find hat!");
        }

    }
}



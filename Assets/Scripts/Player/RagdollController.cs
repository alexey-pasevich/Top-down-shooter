using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    public class RagdollController : MonoBehaviour
    {

        private void Awake()
        {
            SetActive(false);
        }

        public void SetActive(bool value)
        {
            var bodys = GetComponentsInChildren<Rigidbody>();
            foreach (var body in bodys) 
            {
                body.isKinematic = !value;
            }

            var colliders = GetComponentsInChildren<Collider>();
            foreach (var collider in colliders)
            { 
                collider.enabled = value;
            }
        }
    }
}

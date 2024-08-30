using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    public class ShowDialogTemp : MonoBehaviour
    {
        public string id;

        private void OnTriggerEnter(Collider other)
        {
            if (other != null && other.CompareTag("Player"))
            {
                States.instance.Push<DialogState>().ShowDialog(id);
            }
        }
    }
}

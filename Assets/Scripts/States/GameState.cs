using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    public abstract class GameState : MonoBehaviour
    {
        public List<GameObject> views;

        protected virtual void OnEnter()
        {
        }

        protected virtual void OnExit()
        {
        }

        public void Activate()
        {
            gameObject.SetActive(true);
            SetActivateView(true);
        }

        public void Deactivate()
        {
            SetActivateView(false);
            gameObject.SetActive(false);
        }

        public void Enter()
        {
            OnEnter();
        }

        public void Exit()
        {
            OnExit();
        }

        public void SetActivateView(bool state)
        {
            foreach (var item in views)
            {
                if (item)
                {
                    item.SetActive(state);
                }
            }
        }

    }
}

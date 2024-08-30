using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    public class States : MonoBehaviour
    {
        public static States instance { private set; get; }

        private List<GameState> m_states = new();

        [SerializeField] private GameState m_startState;

        private Stack<GameState> m_stack = new Stack<GameState>();
        private GameState m_currentState;

        private void Awake()
        {
            instance = this;

            GetComponentsInChildren(true, m_states);
        }

        private void OnDestroy()
        {
            ClearStack();
            if (m_currentState)
            {
                m_currentState.Deactivate();
                m_currentState.Exit();
            }
        }

        private void Start()
        {
            m_states.ForEach(x =>
            {
                x.gameObject.SetActive(false);
                x.SetActivateView(false);
            });

            m_currentState = m_startState;
            m_currentState.Enter();
            m_currentState.Activate();
        }

        public T Swap<T>() where T : GameState
        {
            if (m_currentState)
            {
                m_currentState.Deactivate();
                m_currentState.Exit();
            }

            ClearStack();

            return Activate<T>();
        }

        private void ClearStack()
        {
            foreach (var state in m_stack)
            {
                if (state)
                {
                    state.Exit();
                }
            }
            m_stack.Clear();
        }

        private T Activate<T>() where T : GameState
        {
            var nextState = m_states.Find(x => x is T);
            if (nextState)
            {
                if (m_stack.Contains(nextState))
                {
                    while (m_stack.Count > 0)
                    {
                        var state = m_stack.Pop();
                        if (nextState == state)
                        {
                            break;
                        }
                        state.Exit();
                    }
                }
                else
                {
                    nextState.Enter();
                }
                nextState.Activate();
                m_currentState = nextState;

                return (T)nextState;
            }

            return null;
        }

        public T Push<T>() where T : GameState
        {
            if (m_currentState)






            {
                m_currentState.Deactivate();
                m_stack.Push(m_currentState);
            }

            return Activate<T>();
        }

        public void Pop()
        {


            if (m_stack.Count == 0)
            {
                return;
            }

            if (m_currentState)
            {
                m_currentState.Deactivate();
                m_currentState.Exit();
            }

            m_currentState = m_stack.Pop();
            m_currentState.Activate();
        }
    }

}

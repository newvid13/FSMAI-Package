using System;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace FSMAI
{
    public class StateMachine : MonoBehaviour
    {
        [SerializeField] FSMGraph AIGraph;
        [SerializeField] bool isActive;
        [SerializeField] float updateFrequency;

        [HideInInspector] public FSMState currentState;
        FSMState_Any anyState;
        Dictionary<Type, Component> components = new Dictionary<Type, Component>();

        #region Initialize

        private void Awake()
        {
            FindStartingState();
            FindAnyState();
            InvokeRepeating(nameof(RunMachine), updateFrequency, updateFrequency);
        }

        private void FindStartingState()
        {
            foreach (Node startNode in AIGraph.nodes)
            {
                if (startNode is FSMState_Initial)
                {
                    NodePort outPort = startNode.GetOutputPort("exit").Connection;
                    if (outPort != null)
                    {
                        ChangeState(outPort.node as FSMState);
                        return;
                    }
                }
            }

            throw new Exception("No Starting Node Found");
        }

        private void FindAnyState()
        {
            foreach (Node anyNode in AIGraph.nodes)
            {
                if (anyNode is FSMState_Any)
                {
                    anyState = anyNode as FSMState_Any;
                    return;
                }
            }
        }

        #endregion

        #region Run and Change State

        private void RunMachine()
        {
            if (!isActive)
                return;

            if (anyState != null)
                anyState.OnUpdate(this);
            currentState.OnUpdate(this);
        }

        public void ChangeState(FSMState newState)
        {
            if (newState == currentState)
                Debug.Log("Tried to change into current state");

            if (currentState != null)
                currentState.OnExit(this);
            currentState = newState;
            currentState.OnEnter(this);
        }

        #endregion

        #region GetComponent and Enable/Disable

        public new T GetComponent<T>() where T : Component
        {
            if (components.ContainsKey(typeof(T)))
                return components[typeof(T)] as T;

            Component component = base.GetComponent<T>();
            if (component != null)
            {
                components.Add(typeof(T), component);
                return component as T;
            }

            Debug.Log("No Such Component");
            return null;
        }

        public void ToggleActive(bool state)
        {
            isActive = state;
        }

        #endregion
    }

}
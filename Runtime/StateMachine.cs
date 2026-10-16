using System;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace FSMAI
{
    public class StateMachine : MonoBehaviour
    {
        [SerializeField] FSMGraph AIGraph;
        [SerializeField] float updateFrequency;

        FSMState currentState;
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
                        currentState = outPort.node as FSMState;
                        currentState.OnEnter(this);
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
            anyState.OnUpdate(this);
            currentState.OnUpdate(this);
        }

        public void ChangeState(FSMState newState)
        {
            if (newState == currentState)
                Debug.Log(gameObject.name + " new state the same as current state");

            currentState.OnExit(this);
            currentState = newState;
            currentState.OnEnter(this);
        }

        #endregion

        #region GetComponents

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

        #endregion
    }

}
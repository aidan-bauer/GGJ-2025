using Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class GameEventListenerString : MonoBehaviour
    {
        public GameEventString Event;
        public UnityEvent<string> Response;

        private void OnEnable()
        { Event.RegisterListener(this); }

        private void OnDisable()
        { Event.UnregisterListener(this); }

        public void OnEventRaised(string value)
        { Response.Invoke(value); }
    }
}
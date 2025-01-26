using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(fileName = "New GameEventString", menuName = "Event/Create New GameEventString")]
    public class GameEventString : ScriptableObject
    {
        private List<GameEventListenerString> listeners =
            new List<GameEventListenerString>();

        public void Raise(string value)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnEventRaised(value);
        }

        public void RegisterListener(GameEventListenerString listener)
        { listeners.Add(listener); }

        public void UnregisterListener(GameEventListenerString listener)
        { listeners.Remove(listener); }
    }
}
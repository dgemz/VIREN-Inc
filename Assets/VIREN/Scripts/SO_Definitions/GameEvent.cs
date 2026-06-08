using System.Collections.Generic;
using UnityEngine;

namespace VIREN.Events
{
    [CreateAssetMenu(fileName = "NewGameEvent", menuName = "VIREN/SO/Eventos/Game Event")]
    public class GameEvent : ScriptableObject
    {
        // Lista de todos los scripts que están "escuchando" este evento
        private readonly List<GameEventListener> listeners = new List<GameEventListener>();

        // Método que llama el emisor (ej. el GameManager) para disparar el evento
        public void Raise()
        {
            // Recorremos la lista en reversa para evitar problemas si alguien se desuscribe durante la ejecución
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised();
            }
        }

        // Métodos para suscribirse y desuscribirse
        public void RegisterListener(GameEventListener listener)
        {
            if (!listeners.Contains(listener))
                listeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            if (listeners.Contains(listener))
                listeners.Remove(listener);
        }
    }
}
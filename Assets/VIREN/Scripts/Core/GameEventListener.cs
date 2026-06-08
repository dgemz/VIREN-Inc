using UnityEngine;
using UnityEngine.Events;

namespace VIREN.Events
{
    public class GameEventListener : MonoBehaviour
    {
        [Tooltip("El evento al que este objeto va a reaccionar.")]
        public GameEvent Event;

        [Tooltip("Lo que hará este objeto cuando el evento se dispare.")]
        public UnityEvent Response;

        private void OnEnable()
        {
            if (Event != null)
                Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            if (Event != null)
                Event.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            Response.Invoke();
        }
    }
}
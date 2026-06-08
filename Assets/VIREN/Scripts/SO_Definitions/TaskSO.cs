using UnityEngine;
using VIREN.Events; // Necesitaremos los eventos para avisar cuando se cumpla la misión

namespace VIREN.Core
{
    [CreateAssetMenu(fileName = "NewTask", menuName = "VIREN/SO/Tareas/Task Definition")]
    public class TaskSO : ScriptableObject
    {
        [Header("Información de la Misión")]
        [Tooltip("Identificador único (ej: purificar_fuente_01)")]
        public string taskID;
        
        [TextArea(2, 4)]
        [Tooltip("Descripción para la UI o para documentación interna del equipo.")]
        public string taskDescription;

        [Header("Estado")]
        public bool isCompleted = false;

        [Header("Eventos de Consecuencia")]
        [Tooltip("Evento que se disparará automáticamente al completar esta tarea.")]
        public GameEvent onTaskCompleted;

        // Método para reiniciar el estado (útil al reiniciar el nivel)
        public void ResetTask()
        {
            isCompleted = false;
        }

        // Método para completar la tarea y disparar su evento
        public void CompleteTask()
        {
            if (isCompleted) return; // Evita que se complete dos veces

            isCompleted = true;
            Debug.Log($"[TaskSO] Tarea completada: {taskID}");

            if (onTaskCompleted != null)
            {
                onTaskCompleted.Raise();
            }
        }
    }
}
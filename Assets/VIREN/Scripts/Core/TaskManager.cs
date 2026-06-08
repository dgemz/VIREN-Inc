using System.Collections.Generic;
using UnityEngine;

namespace VIREN.Core
{
    public class TaskManager : MonoBehaviour
    {
        [Header("Registro de Misiones")]
        [Tooltip("Arrastra aquí los ScriptableObjects (TaskSO) que se deben completar en este nivel.")]
        public List<TaskSO> levelTasks = new List<TaskSO>();

        public void InitializeTasks()
        {
            if (levelTasks.Count == 0)
            {
                Debug.LogWarning("[TaskManager] La lista está vacía. No hay misiones asignadas para este nivel.");
                return;
            }

            // Reiniciar el estado de todas las misiones al cargar la escena
            foreach (var task in levelTasks)
            {
                task.ResetTask();
                Debug.Log($"[TaskManager] Tarea preparada y reseteada: {task.taskID}");
            }
        }

        // Método de utilidad rápida: Cualquier otro script puede llamar a esto
        // pasándole el ID de la misión para completarla al instante.
        public void CompleteTaskByID(string id)
        {
            foreach (var task in levelTasks)
            {
                if (task.taskID == id)
                {
                    task.CompleteTask(); // Este método ya imprime su propio Debug.Log y dispara el evento
                    return;
                }
            }
            Debug.LogWarning($"[TaskManager] Intento fallido: La tarea con ID '{id}' no se encontró en la lista.");
        }
    }
}
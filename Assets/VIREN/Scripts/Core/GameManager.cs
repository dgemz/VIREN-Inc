using UnityEngine;
using VIREN.Events;

namespace VIREN.Core
{
    public class GameManager : MonoBehaviour
    {
        [Header("Archivos de Configuración (ScriptableObjects)")]
        [Tooltip("La configuración de datos para el nivel actual.")]
        [SerializeField] private LevelConfig currentLevelConfig;
        
        [Tooltip("El gestor de tareas o misiones de este nivel.")]
        [SerializeField] private TaskManager taskManager;

        [Header("Eventos Globales")]
        [Tooltip("Evento que se dispara cuando el nivel está configurado y listo.")]
        [SerializeField] private GameEvent onGameInitialized;

        private void Start()
        {
            InitializeProject();
        }

        private void InitializeProject()
        {
            // 1. Validaciones de seguridad
            if (currentLevelConfig == null)
            {
                Debug.LogError("[GameManager] Falla crítica: LevelConfig no asignado en el Inspector.");
                return;
            }

            Debug.Log($"[GameManager] Inicializando entorno para: {currentLevelConfig.levelName}");

            // 2. Preparar el estado del nivel (Misiones/Tareas)
            if (taskManager != null)
            {
                // Suponiendo que el TaskManager tiene un método para resetear o cargar tareas
                taskManager.InitializeTasks(); 
                Debug.Log("[GameManager] TaskManager configurado.");
            }

            // 3. Notificar a los demás sistemas (Audio, UI, Spawners) que el juego arrancó
            if (onGameInitialized != null)
            {
                onGameInitialized.Raise();
                Debug.Log("[GameManager] Evento onGameInitialized disparado.");
            }
        }
    }
}
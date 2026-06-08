using UnityEngine;

namespace VIREN.Core
{
    [CreateAssetMenu(fileName = "NewLevelConfig", menuName = "VIREN/SO/Niveles/Level Config")]
    public class LevelConfig : ScriptableObject
    {
        [Header("Información General")]
        public string levelName = "Nivel Desconocido";
        public string sceneToLoad;

        [Header("Configuración de Entorno")]
        [Tooltip("Tiempo límite en segundos, si aplica para las misiones de este nivel.")]
        public float timeLimit = 300f;
        
        // Aquí podrías añadir referencias a la música ambiental corporativa/tensa 
        // o parámetros específicos de tus mecánicas de rompecabezas.
    }
}
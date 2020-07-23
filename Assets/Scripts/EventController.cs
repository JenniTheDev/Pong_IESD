using UnityEngine;

public class EventController : MonoBehaviour {
    #region Singleton
    private static bool isQuitting;
    private static EventController instance = null;
    public static EventController Instance {
        get {
            if(instance == null && !isQuitting) {
                FindOrCreateInstance();
                Application.quitting += () => isQuitting = true;
            }
            return instance;
        }
    }

    /// <summary>Looks for an existing instance, if not found creates one. If multiple are found, reports error.</summary>
    private static void FindOrCreateInstance() {
        EventController[] instanceArray = FindObjectsOfType<EventController>();
        if(instanceArray.Length == 0) {
            GameObject singleton = new GameObject(typeof(EventController).Name);
            instance = singleton.AddComponent<EventController>();
            DontDestroyOnLoad(singleton);
        } else if(instanceArray.Length == 1) {
            instance = instanceArray[0];
            DontDestroyOnLoad(instance);
        } else if(instanceArray.Length > 1) {
            Debug.LogError("<color=yellow>Multiple instances of the singleton [" + typeof(EventController).Name + "] exists.</color>");
            Debug.Break();
        }
    }
    #endregion

    #region Events & Delegates
    public delegate void OnResetHandler();
    public event OnResetHandler OnReset;
    #endregion

    #region Class Methods
    public void BroadcastReset() {
        OnReset?.Invoke();
    }
    #endregion
}

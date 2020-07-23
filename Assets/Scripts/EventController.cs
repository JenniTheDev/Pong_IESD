using UnityEngine;

public class EventController {
    #region Singleton
    private static bool isQuitting = false;
    private static EventController instance = null;
    public static EventController Instance {
        get {
            if(instance == null && !isQuitting) {
                instance = new EventController();
                Application.quitting += () => isQuitting = true;
            }
            return instance;
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

using Sirenix.OdinInspector;

public abstract class LiverBehaviour : SerializedMonoBehaviour {
    private bool _started;
    
    public virtual void Start() {
        if (enabled) {
            StartOrEnable();
        }

        _started = true;
    }

    public virtual void OnEnable() {
        if (_started) {
            StartOrEnable();
        }
    }

    public virtual void StartOrEnable() {
    }
}
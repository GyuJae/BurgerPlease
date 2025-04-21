using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T _instance;
    static bool _initialized = false;

    public static T Instance {
        get {
            if (_instance != null) return _instance;

            _instance = FindAnyObjectByType<T>();

            if (_instance == null) {
                GameObject go = new GameObject($"@{typeof(T).Name}");
                _instance = go.AddComponent<T>();
            }

            if (_initialized) return _instance;

            DontDestroyOnLoad(_instance.gameObject);
            _initialized = true;

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null) {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
            _initialized = true;
        }
        else if (_instance != this) {
            Destroy(gameObject); // 중복 방지
        }
    }
}

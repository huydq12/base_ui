using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    private static T Current;
    private static bool IsQuitting;
    public static T Instance
    {
        get
        {
            if (IsQuitting && Time.frameCount == 0) IsQuitting = false;
            if (IsQuitting || !Application.isPlaying) return null;
            if (Current == null) Current = FindObjectOfType<T>();
            if (Current == null) Current = new GameObject(typeof(T).Name).AddComponent<T>();
            return Current;
        }
    }

    public static T TryGetInstance()
    {
        if (IsQuitting && Time.frameCount == 0) IsQuitting = false;
        if (IsQuitting) return null;
        if (Current == null) Current = FindObjectOfType<T>();
        return Current;
    }

    private void ClearInstance()
    {
        if (Current == this) Current = null;
    }
    protected virtual void Awake()
    {
        if (Current == null) Current = this as T;
        else if (Current != this) Destroy(gameObject);
    }
    protected virtual void OnDestroy() => ClearInstance();
    protected virtual void OnApplicationQuit()
    {
        IsQuitting = true;
        ClearInstance();
    }
}
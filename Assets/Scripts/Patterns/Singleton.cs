using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Singleton<T> : MonoBehaviour, ISingleton where T : Component
{
    private static GameObject Parent = null;
    private static T _Instance = null;
    private static bool _ShuttingDown = false;

    /// <summary>
    /// PatentObject 확인 및 생성
    /// </summary>
    public static GameObject ParentObj
    {
        get
        {
            if (Parent == null)
            {
                Parent = GameObject.Find("ParentObj");
                if (Parent == null)
                {
                    Parent = new GameObject("ParentObj");
                    DontDestroyOnLoad(Parent);
                }
            }
            return Parent;
        }
    }

    /// <summary>
    /// Singletone Manager 확인 및 생성
    /// </summary>
    public static T Instance
    {
        get
        {
            if (_ShuttingDown)
            {
                return default(T);
                //throw new System.Exception($"[Singleton] Instance {typeof(T)} already destroyed. Returning null");
            }

            if (_Instance == null)
            {
                _Instance = (T)FindObjectOfType(typeof(T));

                if (_Instance == null)
                {
                    GameObject singletonObj = new GameObject();
                    _Instance = singletonObj.AddComponent<T>();
                    singletonObj.name = $"[{typeof(T).ToString()}]";
                    if (singletonObj.GetComponent<IDestroy>() == null)
                        singletonObj.transform.SetParent(ParentObj.transform);

                    singletonObj.tag = "Singleton";
                }
            }
            if (_Instance.transform.parent == null)
            {
                if (_Instance.GetComponent<IDestroy>() == null)
                    _Instance.transform.SetParent(ParentObj.transform);
            }

            return _Instance;
        }
    }

    private void Awake()
    {
        Init();
    }

    /// <summary>
    /// Init시에 Manager의 이름을 출력한다.
    /// </summary>
    protected virtual void Init()
    {
        Debug.Log($"Init : [{typeof(T).ToString()}]");
    }

    private void OnApplicationQuit()
    {
        _ShuttingDown = true;
    }

    public void Release()
    {
        Destroy(_Instance.gameObject);
        _Instance = null;
    }

    public virtual void Trigger() { }
}


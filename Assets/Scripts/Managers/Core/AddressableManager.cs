using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using static TreeEditor.TreeEditorHelper;

public class AddressableManager : Singleton<AddressableManager>
{
    #region State
    AddressableType _upDateMode = AddressableType.Wait;

    AddressableType UpdateMode
    {
        get
        {
            return _upDateMode;
        }
        set
        {
            _upDateMode = value;
        }
    }
    #endregion

    string[] keys = { };

    protected override void Init()
    {
        base.Init();

        StartReset();
    }

    void StartReset()
    {
        // var = AsyncOperationHandle 타입
        var async = Addressables.InitializeAsync(); // 모든 캐쉬를 초기화 한다.
        async.Completed += (op) =>
        {
            UpdateMode = AddressableType.ClearChache;
            Addressables.Release(async); // 작업이 끝나면 릴리스를 해서 캐쉬를 없앤다.
        };
    }

    void DownloadAsset()
    {
        for (int i = 0; i < keys.Length; i++)
        {
            // 다운로드할 크기를 얻어온다.
            Addressables.GetDownloadSizeAsync(keys[i]).Completed += (opSize) =>
            {
                if (opSize.Status == AsyncOperationStatus.Succeeded && opSize.Result > 0)
                {
                    Addressables.DownloadDependenciesAsync(keys[i], true).Completed += (opDownload) =>
                    {
                        if (opDownload.Status != AsyncOperationStatus.Succeeded)
                            throw new System.Exception("Addressable Download Error");

                        Debug.Log("Download Completed");
                        LoadAsset();
                    };
                }
                else
                {
                    //Result 값이 0이라면 이미 다운로드 된 상태이다.
                    //Local만 사용할때는 다운로드할 값이 없어서 Size가 0이 된다.
                    Debug.Log("Download Size = 0");
                    LoadAsset();
                }
            };

        }
        UpdateMode = AddressableType.Downloaded;
    }

    void LoadAsset()
    {
        for (int i = 0; i < keys.Length; i++)
        {
            Addressables.LoadAssetAsync<GameObject>(keys[i]).Completed += (op) =>
            {
                if (op.Status != AsyncOperationStatus.Succeeded)
                    throw new System.Exception("Addressable Load Error");

                //OnLoadDone();
            };
        }
        UpdateMode = AddressableType.Loaded;
    }

    public void ClearAddressableAsset()
    {
        for (int i = 0; i < keys.Length; i++)
        {
            Addressables.ClearDependencyCacheAsync(keys[i]);
        }
        UpdateMode = AddressableType.Clear;
    }

    public T Load<T>(string key)
    {
        return Addressables.LoadAssetAsync<T>(key).Result;
    }

    public GameObject Instantiate(string key, Transform parent = null)
    {
        return Addressables.InstantiateAsync(key, parent).Result;
    }

    public GameObject Instantiate(string key, Vector3 position, Transform parent = null)
    {
        GameObject go = Addressables.InstantiateAsync(key, parent).Result;
        go.transform.position = position;
        return go;
    }
}

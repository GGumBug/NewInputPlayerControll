using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

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
        // var = AsyncOperationHandle Ÿ��
        var async = Addressables.InitializeAsync(); // ��� ĳ���� �ʱ�ȭ �Ѵ�.
        async.Completed += (op) =>
        {
            UpdateMode = AddressableType.ClearChache;
            Addressables.Release(async); // �۾��� ������ �������� �ؼ� ĳ���� ���ش�.
        };
    }

    void DownloadAsset()
    {
        for (int i = 0; i < keys.Length; i++)
        {
            // �ٿ�ε��� ũ�⸦ ���´�.
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
                    //Result ���� 0�̶�� �̹� �ٿ�ε� �� �����̴�.
                    //Local�� ����Ҷ��� �ٿ�ε��� ���� ��� Size�� 0�� �ȴ�.
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

    public void Load<T>(string key, Action<T> action = null)
    { 
        Addressables.LoadAssetAsync<T>(key).Completed += (op) =>
        {
            if (op.Status != AsyncOperationStatus.Succeeded)
                throw new System.Exception("Addressable Load Error");

            action?.Invoke(op.Result);
        };
    }

    public GameObject Instantiate(string key, Transform parent = null)
    {
        GameObject go = Addressables.InstantiateAsync(key, parent).Result;

        return go;
    }

    public GameObject Instantiate(string key, Vector3 position, Transform parent = null)
    {
        GameObject go = Addressables.InstantiateAsync(key, parent).Result;
        go.transform.position = position;
        return go;
    }
}

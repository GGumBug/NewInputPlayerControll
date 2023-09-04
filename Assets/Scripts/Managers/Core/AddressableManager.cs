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

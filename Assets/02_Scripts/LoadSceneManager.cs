using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadSceneManager : MonoBehaviour
{
    [SerializeField] private string sceneName = "Level01";

    public async void DownloadAndLoadAsync()
    {
        await CheckDownloadSize();
        await Task.Delay(2000);
        await LoadSceneAsync();
    }
    
    // 캐시 클리어
    public void ClearCache()
    {
        Addressables.ClearDependencyCacheAsync(sceneName);
        Debug.Log("캐시 삭제");
    }
    
    // 다운로드 사이즈 체크
    public async Task CheckDownloadSize()
    {
        // 파일 사이즈 체크
        AsyncOperationHandle<long> handle = Addressables.GetDownloadSizeAsync(sceneName);
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            long size = handle.Result / (1024*1024); // MB 변환
            Debug.Log($"다운로드 사이즈 {size} MB");
        }
        
        Addressables.Release(handle);
    }

    public async Task LoadSceneAsync()
    {
        try
        {
            var loadHandle = Addressables.LoadSceneAsync(sceneName);
            while (!loadHandle.IsDone)
            {
                Debug.Log($"Progress : {loadHandle.PercentComplete * 100} % ");
                await Task.Yield();
            }

            Debug.Log($"Status : {loadHandle.Status}");
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
    
}

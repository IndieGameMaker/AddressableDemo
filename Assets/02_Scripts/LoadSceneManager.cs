using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadSceneManager : MonoBehaviour
{
    [SerializeField] private string sceneName = "Level01";

    private async void Start()
    {
        
    }
    
    // 다운로드 사이즈 체크
    private async Task CheckDownloadSize()
    {
        // 파일 사이즈 체크
        AsyncOperationHandle<long> handle = Addressables.GetDownloadSizeAsync(sceneName);
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            long size = handle.Result / (1024*1024); // MB 변환
            Debug.Log($"다운로드 사이즈 {size} MB");
        }
    }
        
}

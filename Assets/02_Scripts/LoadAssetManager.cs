using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadAssetManager : MonoBehaviour
{
    // 어드레서블 주소
    [SerializeField] private string _assetName = "Warrior Red";
    private GameObject _warriorInstance;
    
    // 비동기 로딩시 사용할 핸들
    private AsyncOperationHandle<GameObject> _loadHandle;
    
    // 비동기 로드 메소드
    public void LoadWarriorAsync()
    {
        Addressables.LoadAssetAsync<GameObject>(_assetName).Completed +=
            (AsyncOperationHandle<GameObject> handle) =>
            {
                _loadHandle = handle;
                // 로드된 에셋의 인스턴스를 생성
                OnWarriorLoad();
            };
    }

    private void OnWarriorLoad()
    {
        if (_loadHandle.Status == AsyncOperationStatus.Succeeded)
        {
            var warrior = _loadHandle.Result;
            
            _warriorInstance = Instantiate(warrior, Vector3.zero, Quaternion.identity);
            Debug.Log("전사 생성");
        }
    }

    public void ReleaseWarrior()
    {
        // 어드레서블 메모리 해제
        Addressables.Release(_loadHandle);
        // 생성한 인스턴스 삭제
        Destroy(_warriorInstance);
    }
}

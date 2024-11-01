using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName ="Event/SceneLoadEventSO")]




//场景加载请求
//加载场景
//目标坐标
public class SceneLoadEventSO : ScriptableObject
{
    public UnityAction<GameSceneSO, Vector3, bool> LoadRequestEvent;

    public void RaiseLoadRequestEvent(GameSceneSO locationToLoad,Vector3 posToGo, bool fadeScreen)
    {
        LoadRequestEvent?.Invoke(locationToLoad, posToGo, fadeScreen);
    }
}

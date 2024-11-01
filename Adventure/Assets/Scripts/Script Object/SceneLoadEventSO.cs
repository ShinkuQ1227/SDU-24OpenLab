using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName ="Event/SceneLoadEventSO")]




//������������
//���س���
//Ŀ������
public class SceneLoadEventSO : ScriptableObject
{
    public UnityAction<GameSceneSO, Vector3, bool> LoadRequestEvent;

    public void RaiseLoadRequestEvent(GameSceneSO locationToLoad,Vector3 posToGo, bool fadeScreen)
    {
        LoadRequestEvent?.Invoke(locationToLoad, posToGo, fadeScreen);
    }
}

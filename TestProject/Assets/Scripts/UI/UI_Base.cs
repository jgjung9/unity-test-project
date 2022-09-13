using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UI 요소들이 상속받을 부모 클래스
// UI 요소의 하위 오브젝트를 받아와 enum 순서대로 묶어주는 기능 제공
// UI 요소의 하위 오브젝트를 값을 받아오는 기능 제공
public class UI_Base : MonoBehaviour
{
    // UI 요소의 하위 오브젝트를 타입별로 담을 딕셔너리
    protected Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

    // UI 요소를 enum 순서대로 묶어주는 함수
    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);

        // enum 에서 찾아온 이름들로 이름과 동일한 오브젝트를 찾아 맵핑하는 과정
        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
                objects[i] = Util.FindChild(gameObject, names[i], true);
            else
                objects[i] = Util.FindChild<T>(gameObject, names[i], true);
            
            if (objects[i] == null)
                Debug.Log($"Failed to Bind : {names[i]}");
        }
    }

    // 찾고자 하는 UI 하위 요소를 받아오는 함수
    protected T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if (_objects.TryGetValue(typeof(T), out objects))
            return objects[idx] as T;
            
        return null;
    }
}

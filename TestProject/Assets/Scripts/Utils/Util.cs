using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 모든 곳에서 자주 쓰일만한 기능을 따로 정리한 Util class
public class Util
{
    // 게임 오브젝트의 자식을 모두 찾는다  
    public static T FindChild<T>(GameObject go, string name = null, bool recursive = true) where T : UnityEngine.Object
    {
        if (go == null)
            return null;

        if (recursive)
        {
            // gameObject.GetComponentsInChildren -> 재귀적으로 모든 자식을 찾는다
            T[] components = go.GetComponentsInChildren<T>();
            for (int i = 0; i < components.Length; i++)
            {
                if (string.IsNullOrEmpty(name) || components[i].name == name)
                    return components[i];
            }
        }
        else
        {
            for (int i = 0; i < go.transform.childCount; i++)
            {
                // transform.GetChild -> 인덱스를 파라미터로 넘겨주어 depth = 1의 자식을 찾는다
                // 주의) 리턴 값이 Transform 이다
                Transform transform = go.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                        return component;
                }
            }
        }
        
        return null;
    }
    
    // FindChild 함수는 게임오브젝트는 찾을 수 없음 컴포넌트를 찾는 함수
    // 게임 오브젝트를 찾는 함수를 오버로딩
    public static GameObject FindChild(GameObject go, string name = null, bool recursive = true)
    {
        Transform transform = FindChild<Transform>(go, name, recursive);
        if (transform != null)
            return transform.gameObject;
        
        return null;
    }
}
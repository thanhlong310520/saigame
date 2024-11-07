using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner<T> : BaseMonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs = new List<Transform>();
    [SerializeField] protected Transform holder;

    private static T instance;
    public static T Instance { get => instance; }
    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only Singerton " + transform.name);
        instance = this as T;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPrefabs();
    }
    protected virtual void LoadPrefabs()
    {
        prefabs = new List<Transform>();
        if (prefabs.Count > 0) return;
        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform t in prefabObj)
        {
            prefabs.Add(t); 
        }
        Debug.Log(transform.name + " LoadPrefabs", gameObject);
        HidePrefabs();
    }
    protected virtual void HidePrefabs()
    {
        foreach (var p in prefabs)
        {
            p.gameObject.SetActive(false);  
        }
    }

    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rot)
    {
        var prefab = GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.Log("prefab not found  " + prefabName);
            return null;
        }
        Transform newPrefab = Instantiate(prefab, spawnPos, rot, holder);
        return newPrefab;
    }
    public virtual Transform GetPrefabByName(string namePrefab)
    {
        foreach(Transform t in prefabs)
        {
            if(t.name == namePrefab) return t;
        }
        return null;
    }
}

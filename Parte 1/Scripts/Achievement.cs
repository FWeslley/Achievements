using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "Achievements", menuName = "Achievements")]
public class Achievement : ScriptableObject
{
    public string id;
    public Sprite sprite;
    public string achievementName;
    public string message;
    public string description;
    public Progress progress;
     
#if UNITY_EDITOR
    void OnValidate()  
    {
        string path = AssetDatabase.GetAssetPath(this);
        id = AssetDatabase.AssetPathToGUID(path);
    }
#endif

    public void Increase(string taskName) 
    {
        foreach (var item in progress.tasks)
        {
            if(string.Equals(taskName, item.taskName))
            {
                item.currentProgressTask++;

                if (item.currentProgressTask >= item.progressTarget)
                    UnLock();

                break;
            }
        }
    }

    public void UnLock()
    {
        Debug.Log(message);
    }
}

[System.Serializable]
public class Progress
{
    public List<Task> tasks = new List<Task>();
}

[System.Serializable]
public class Task
{
    public string taskName;
    public int currentProgressTask;
    public int progressTarget;
}
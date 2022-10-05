using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class SavePlugin : MonoBehaviour
{
    [DllImport("Week3Plugin")]
    private static extern int GetID();

    [DllImport("Week3Plugin")]
    private static extern void SetID(int id);

    [DllImport("Week3Plugin")]
    private static extern Vector3 GetPosition();

    [DllImport("Week3Plugin")]
    private static extern void SetPosition(float x, float y, float z);

    [DllImport("Week3Plugin")]
    private static extern void SaveToFile(int id, float x, float y, float z);

    [DllImport("Week3Plugin")]
    private static extern void StartWriting(string fileName);

    [DllImport("Week3Plugin")]
    private static extern void EndWriting();

    PlayerCharAction inputAction;

    string m_Path;
    string fn;

    void Start()
    {
        inputAction = PlayerInputController.controller.inputAction;

        inputAction.Editor.Save.performed += cntxt => SaveItems();

        m_Path = Application.dataPath;
        fn = m_Path + "/save.txt";
        Debug.Log(fn);
    }

    void SaveItems()
    {
        StartWriting(fn);
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("SpikeBall"))
        {
            if(obj.name.Contains("SpikyBall1"))
            {
                SaveToFile(1, obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);
            }
            else
            {
                SaveToFile(2, obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);
            }
        }
        EndWriting();
    }

    void Update()
    {
        
    }

}

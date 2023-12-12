using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowerSc : MonoBehaviour
{
    public static PathFollowerSc Instance;
    public List<GameObject> paths;
    int index;
    int lastIndex;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }
    private void Start()
    {
        lastIndex = paths.Count-1;
    }

    public void ChangePathPosition()
    {
        if(index >= paths.Count)
        {
            index = 0;
        }
        if (lastIndex <= 0)
        {
            lastIndex = paths.Count;
        }

        paths[index].transform.position = paths[lastIndex].transform.position + new Vector3(0f,0f,1000f);


        index++;
        lastIndex--;
    }

}

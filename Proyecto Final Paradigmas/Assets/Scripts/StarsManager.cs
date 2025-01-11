using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsManager : MonoBehaviour
{
    public Image[] stars;
    public int level;

    void Update()
    {

        for (int i = 0; i < stars.Length; i++)
        {
            if (i < level)
            {
                stars[i].color = Color.yellow;
            }
            else
            {
                stars[i].color = Color.black;
            }
        }
    }

    public void SetLevel(int newLevel)
    {
        level = newLevel;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextList : MonoBehaviour
{
    [TextArea]
    public string[] contents;
    private int index = 0;
    public float time = 3;

    public void showContentsIndex(int index)
    {
        TextManager.Instance.TextSetting(time, contents[index]);
    }

    public void showContent()
    {
        TextManager.Instance.TextSetting(time, contents[index]);
        if(index < contents.Length)
            index++;
    }
}

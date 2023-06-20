using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUi : MonoBehaviour
{
    public int powerLeft = 0;
    public Text text;

    public void setText(int x)
    {
        text.text = x.ToString();
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager inst;

    void Awake()
    {
        inst = this;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string nameItem;
    public int id;
    [HideInInspector]
    public int countItem;
    public bool isStackable;
    [Multiline]
    public string DescriptionItem;
    public string pathIcon;
    public string pathPrefab;
}

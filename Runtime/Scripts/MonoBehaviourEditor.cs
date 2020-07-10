#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MonoBehaviour), true)]
public class MonoBehaviourEditor : Editor
{
    private void OnEnable()
    {
        SkillCanvas.instance = FindObjectOfType<SkillCanvas>();
    }
}

#endif
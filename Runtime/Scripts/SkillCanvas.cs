using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MM.Attributes;
using MM.Libraries.UI;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(PrefabListPanel))]
public class SkillCanvas : MonoBehaviour
{
    private static List<ISkillable> m_skillables;
    public static List<ISkillable> skillables
    {
        get
        {
            if (m_skillables == null)
                m_skillables = FindObjectsOfType<MonoBehaviour>().OfType<ISkillable>().OrderBy(o => o.skillableIndex).ToList();
            
            return m_skillables;
        }
        set { m_skillables = value; }
    }


    #region Callback Methodes
    /*
     *
     *  Callback Methodes
     * 
     */
    
    public static SkillCanvas instance { get; private set; }
    void Awake()
    {
        #region Singleton

        // Singleton
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        #endregion
    }

    void Start()
    {
        skillables = FindObjectsOfType<MonoBehaviour>().OfType<ISkillable>().OrderBy(o => o.skillableIndex).ToList();
        
        if (!Application.isPlaying)    // BC: ExecuteAllways
            return;
    }

    void OnEnable()
    {
        GetComponent<PrefabListPanel>().OnStartSetup += OnStartSetup;
        
        if (!Application.isPlaying)    // BC: ExecuteAllways
            return;
    }

    void OnDisable()
    {
        GetComponent<PrefabListPanel>().OnStartSetup -= OnStartSetup;
        
        if (!Application.isPlaying)    // BC: ExecuteAllways
            return;
    }

    void OnStartSetup(IPrefabListChild[] _children)
    {
        for (int i = 0; i < _children.Length; i++)
            ((SkillPanel)_children[i]).SetupVariables(i);
    }

    void Update()
    {
        #if UNITY_EDITOR
        PrefabListPanel _plp = GetComponent<PrefabListPanel>();
        skillables = FindObjectsOfType<MonoBehaviour>().OfType<ISkillable>().OrderBy(o => o.skillableIndex).ToList();
        if (_plp.amount != skillables.Count)
        {
            _plp.amount = skillables.Count;
            _plp.RegenerateChildren(Application.isEditor);
        }
        #endif
        
        if (!Application.isPlaying)    // BC: ExecuteAllways
            return;
    }

    #endregion

    #region Gameplay Methodes
    /*
     *
     *  Gameplay Methodes
     *
     */

    #endregion

    #region Helper Methodes
    /*
     *
     *  Helper Methodes
     * 
     */

    #endregion
}

public enum SkillType
{
    [StringValue("None")]
    None,
    [StringValue("Crafting")]
    Crafting,
    [StringValue("Building")]
    Building,
    [StringValue("Foraging")]
    Foraging,
    [StringValue("Farming")]
    Farming,
    [StringValue("Hunting")]
    Hunting,
    [StringValue("Experience")]
    Experience,
}

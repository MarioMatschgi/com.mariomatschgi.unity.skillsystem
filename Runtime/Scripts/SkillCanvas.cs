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
    public SkillListData skillListData;

    private List<ISkillable> m_skillables;
    private List<ISkillable> skillables
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

    static SkillCanvas m_instance;
    public static SkillCanvas instance
    {
        get
        {
            // if (m_instance == null)
            //     m_instance = GameObject.FindObjectOfType<SkillCanvas>();

            return m_instance;
        }
        set { m_instance = value; }
    }

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
        skillables = FindObjectsOfType<MonoBehaviour>().OfType<ISkillable>().ToList();
        
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
        skillables = FindObjectsOfType<MonoBehaviour>().OfType<ISkillable>().ToList();
        
        #if UNITY_EDITOR
        PrefabListPanel _plp = GetComponent<PrefabListPanel>();
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

    public ISkillable GetSkillable(int _skillableIndex)
    {
        foreach (ISkillable _skillable in skillables)
        {
            if (_skillable.skillableIndex == _skillableIndex)
                return _skillable;
        }

        return null;
    }

    #endregion

    #region Helper Methodes
    /*
     *
     *  Helper Methodes
     * 
     */

    #endregion
}

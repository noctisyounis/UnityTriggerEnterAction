using UnityEngine;
using UnityEngine.Events;

public enum ContactType
{
    Tag,
    Layer
}

public class TriggerEnterAction : MonoBehaviour
{
    #region Exposed
        
    public ContactType m_contactType;
    public string m_contactTag;
    public LayerMask m_contactLayer;
    public UnityEvent onReaction;
    public bool edit;

    #endregion


    #region Unity API

    private void OnTriggerEnter(Collider other) 
    {
        if (m_contactType == ContactType.Tag && other.CompareTag(m_contactTag))
        {
            DispatchEvents();
        }

        else if(m_contactType == ContactType.Layer && m_contactLayer == (m_contactLayer | 1 << other.gameObject.layer))
        {
            DispatchEvents();
        }
    }

    #endregion


    #region Public Methods
        
    public void DispatchEvents()
    {
        onReaction?.Invoke();
    }

    #endregion
}


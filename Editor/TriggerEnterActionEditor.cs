using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TriggerEnterAction))]
[CanEditMultipleObjects]
public class TriggerEnterActionEditor : Editor
{
    SerializedProperty contactType;
    SerializedProperty contactTag;
    SerializedProperty contactLayer;
    SerializedProperty reactionEvent;
    TriggerEnterAction triggerScript;
    const int spaceInPixels = 12;

    private void OnEnable() 
    {
        triggerScript = (target as TriggerEnterAction);
        contactType = serializedObject.FindProperty("m_contactType");
        contactTag = serializedObject.FindProperty("m_contactTag");
        contactLayer = serializedObject.FindProperty("m_contactLayer");
        reactionEvent = serializedObject.FindProperty("onReaction");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        if (triggerScript.edit)
        {
            EditorGUILayout.BeginHorizontal();

            if(GUILayout.Button("Test events")) triggerScript.DispatchEvents();
            if(GUILayout.Button("Minimize")) ToggleEditionMode();

            EditorGUILayout.EndHorizontal();
            GUILayout.Space(spaceInPixels);


            EditorGUILayout.PropertyField(contactType);

            if (triggerScript.m_contactType == ContactType.Layer)
            {
                EditorGUILayout.PropertyField(contactLayer);
            }

            else if (triggerScript.m_contactType == ContactType.Tag)
            {
                EditorGUILayout.PropertyField(contactTag);
            }


            GUILayout.Space(spaceInPixels);
            EditorGUILayout.PropertyField(reactionEvent);
        }

        else
        {
            EditorGUILayout.BeginHorizontal();

            if(GUILayout.Button("Test events")) triggerScript.DispatchEvents();
            if(GUILayout.Button("Edit")) ToggleEditionMode();

            EditorGUILayout.EndHorizontal();
        }
        
        serializedObject.ApplyModifiedProperties();
    }

    private void ToggleEditionMode()
    {
        triggerScript.edit = ! triggerScript.edit;
    }
}
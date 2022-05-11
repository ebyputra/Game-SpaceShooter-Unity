using UnityEditor;

[CustomEditor(typeof(Life))]
public class LifeEditor : Editor
{
    private Life _life;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        _life = (Life) target;
        _life.useScriptable = EditorGUILayout.Toggle("Use Scriptable?", _life.useScriptable);

        if (_life.useScriptable)
        {
            _life.lifeScriptable = (ScriptableInteger) EditorGUILayout.ObjectField("Life", _life.lifeScriptable, typeof(ScriptableInteger), true);
            _life.maxLifeScriptable = (ScriptableInteger) EditorGUILayout.ObjectField("Max Life", _life.maxLifeScriptable, typeof(ScriptableInteger), true);
        }
        else
        {
            _life.life = EditorGUILayout.IntField("Life", _life.life);
            _life.maxLife = EditorGUILayout.IntField("Max   Life", _life.maxLife);
        }
    }
}
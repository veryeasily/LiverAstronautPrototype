using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Liver/Dialogue")]
public class Speaker : SerializedScriptableObject, ISpeaker {
    public Specter Specter;
    public Sprite Sprite;
    public YarnProgram YarnProgram;

    public Sprite GetSprite() {
        return Sprite ? Sprite : Specter.Sprite;
    }

    public YarnProgram GetDialogue() {
        return YarnProgram;
    }
}
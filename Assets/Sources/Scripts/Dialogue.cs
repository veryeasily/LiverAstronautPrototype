using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Liver/Dialogue")]
public class Dialogue : SerializedScriptableObject, IDialogue {
    public Sprite Sprite;
    public YarnProgram YarnProgram;

    public Sprite GetSprite() {
        return Sprite;
    }

    public YarnProgram GetDialogue() {
        return YarnProgram;
    }
}
using System;
using Yarn.Unity;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class DialogueController : SerializedMonoBehaviour {
    public Image Portrait;
    public DialogueRunner Runner;

    public void ActivateForDialogue(IDialogue dialogue) {
        Portrait.sprite = dialogue.GetSprite();
        Runner.Stop();
        Runner.Clear();
        Runner.Add(dialogue.GetDialogue());
        Runner.StartDialogue();
    }

    public void HandleDialogueStart() {
        var state = GameState.Instance;
        state.DialogueStart();
    }

    public void HandleDialogueEnd() {
        var state = GameState.Instance;
        state.DialogueEnd();
    }
}
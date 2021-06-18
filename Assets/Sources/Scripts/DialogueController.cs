using Yarn.Unity;
using Sirenix.OdinInspector;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DialogueController : SerializedMonoBehaviour {
    public Image Portrait;
    public DialogueRunner Runner;
    public Speaker StartingSpeaker;

    public void Start() {
        if (!StartingSpeaker) return;
        
        ActivateForDialogue(StartingSpeaker);
    }

    public void ActivateForDialogue(ISpeaker speaker) {
        Portrait.sprite = speaker.GetSprite();
        Runner.Stop();
        Runner.Clear();
        Runner.Add(speaker.GetDialogue());
        Runner.StartDialogue();
    }

    public void HandleDialogueStart() {
        var state = GameState.Instance;
        state.IsDialoguePlaying = true;
        state.TriggerDialogueStart();
    }

    public void HandleDialogueEnd() {
        var state = GameState.Instance;
        state.IsDialoguePlaying = false;
        state.TriggerDialogueEnd();
    }
}
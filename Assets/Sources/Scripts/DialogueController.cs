using Yarn.Unity;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class DialogueController : SerializedMonoBehaviour {
    public Image Portrait;
    public DialogueRunner Runner;
    public Dialogue StartingDialogue;

    public void Start() {
        if (!StartingDialogue) return;
        
        ActivateForDialogue(StartingDialogue);
    }

    public void ActivateForDialogue(IDialogue dialogue) {
        Portrait.sprite = dialogue.GetSprite();
        Runner.Stop();
        Runner.Clear();
        Runner.Add(dialogue.GetDialogue());
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
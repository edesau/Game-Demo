using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSequence : MonoBehaviour {
    // Prefix to text file name
    public const string ScriptLocation = "C:\\Users\\Erin\\Desktop\\Erin's Stuff\\art\\Jitterbug\\Assets\\Scripts\\Dialogue\\";

    public Text textBox;
    public Animator icon;
    public JitterMove player;

    public Font regular;
    public Font robo;

    private bool finishedReading;
    
    // Use this for initialization
    void Start () {
        // disable movement
        player.enabled = false;

        icon.enabled = false;
        finishedReading = false;

        Dialogue start = new Dialogue(ScriptLocation + "Startup");
        BootUp(start);
	}

    void Update() {
        // Delete later
        if (Input.GetKeyDown(KeyCode.F))
            finishedReading = true;

        // Translate text when T is held
        if (Input.GetKeyDown(KeyCode.T)) {
            textBox.GetComponent<Text>().font = robo;
            textBox.GetComponent<Text>().lineSpacing = 1.15f;
        }

        if (Input.GetKeyUp(KeyCode.T)) {
            textBox.GetComponent<Text>().font = regular;
            textBox.GetComponent<Text>().lineSpacing = 1.1f;
        }

        if (finishedReading) {
            // Show the advance icon when the text is done displaying
            if (!icon.enabled)
                icon.enabled = true;
            // If either shift is pressed, start the game
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
                EndSequence();
        }
    }

    /** BootUp
     *  Starts the coroutine "DisplayText"
     **/
    public void BootUp(Dialogue action) {
        IEnumerator display;
        display = DisplayText(action);
        StartCoroutine(display);
    }

    /** DisplayText
    *   A method to wait for a certain number of seconds before displaying
    *   each line of the script
    **/
    private IEnumerator DisplayText(Dialogue action) {
        while (!action.IsDoneReading()) {
            // -------------------------------------------------------- //
            string currLine = action.GetNextLine();
            int index = 0;
            // Display text character by character
            while (index < currLine.Length) {
                textBox.text += currLine[index];
                yield return new WaitForSecondsRealtime(0.015f);
                index++;
            }

            // -------------------------------------------------------- //
            if (currLine.Length != 0) {
                yield return new WaitForSecondsRealtime(0.5f);
            }
            // -------------------------------------------------------- //

            // Blink the cursor twice before advancing
            textBox.text += "_";
            yield return new WaitForSecondsRealtime(0.5f);
            textBox.text = textBox.text.Substring(0, textBox.text.Length - 1);
            yield return new WaitForSecondsRealtime(0.5f);
            textBox.text += "_";
            yield return new WaitForSecondsRealtime(0.5f);
            textBox.text = textBox.text.Substring(0, textBox.text.Length - 1);

            // -------------------------------------------------------- //

            // For formatting
            if (!action.IsDoneReading())
                textBox.text += "\n";
        }

        finishedReading = true;
        // Continue displaying the cursor until the player hits shift to advance
        while (true) {
            yield return new WaitForSecondsRealtime(0.5f);
            textBox.text += "_";
            yield return new WaitForSecondsRealtime(0.5f);
            textBox.text = textBox.text.Substring(0, textBox.text.Length - 1);
        }
    }

    /** End Sequence
     *  Destroys this canvas once the boot-up sequence is finished
     **/
    private void EndSequence() {
        StopAllCoroutines();
        Destroy(gameObject);
    }
}

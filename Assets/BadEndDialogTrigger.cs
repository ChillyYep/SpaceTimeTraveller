using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEndDialogTrigger : MonoBehaviour
{
    //public GameObject mainCharacter;
    private bool hasTrigger = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasTrigger)
        {
            if (DialogManager.instance != null)
            {
                StartCoroutine(FlipAnim());
                hasTrigger = true;
            }
        }
    }

    IEnumerator FlipAnim()
    {
        CharacterController.instance.moveable = false;
        CharacterController.instance.StopWalkAnim();

        CharacterController.instance.ShowExclam();
        yield return new WaitForSeconds(1.0f);
        CharacterController.instance.HideExclam();

        for(int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.5f);
            CharacterController.instance.Flip();
        }
        DialogManager.instance.AddUnRepeatableDialog(GlobalManager.StoryFileName.BadEnd);

        CharacterController.instance.moveable = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popup_manager : MonoBehaviour
{
    public Text name_text;
    public Text description_text;
    public Image image;
    public Animator animator;

    public void display_popup(Item item) {
        name_text.text = item.name;
        image.sprite = item.image;

        animator.SetBool("is_open", true);

        StopAllCoroutines();
        StartCoroutine(type_description(item.description));
    }

    IEnumerator type_description(string description) {
        description_text.text = "";
        foreach (char letter in description.ToCharArray()) {
            description_text.text += letter;
            yield return null;
        }
    }

    public void end_popup() {
        animator.SetBool("is_open", false);
    }
}

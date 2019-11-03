// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using UnityEngine;
using UnityEngine.EventSystems;

// UCE FIELD TABBING

public class UCE_FieldTabbing : MonoBehaviour
{
    public KeyCode hotkey = KeyCode.Tab;
    public GameObject[] tabObjects;

    private int tabCount = 0;

    // -----------------------------------------------------------------------------------
    // Start
    // Set our first tabbale object as focus.
    // -----------------------------------------------------------------------------------
    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(tabObjects[tabCount], null);
    }

    // -----------------------------------------------------------------------------------
    // Update
    // If tab is hit while active, then move to the next tabbable object.
    // -----------------------------------------------------------------------------------
    private void Update()
    {
        if (Input.GetKeyDown(hotkey))
        {
            tabCount++;
            if (tabCount >= tabObjects.Length) tabCount = 0;

            EventSystem.current.SetSelectedGameObject(tabObjects[tabCount], null);
        }
    }
}
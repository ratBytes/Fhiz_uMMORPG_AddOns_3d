// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
// small helper script that is added to character selection previews at runtime
using UnityEngine;
using Mirror;

public class SelectableCharacter : MonoBehaviour
{
    // index will be set by networkmanager when creating this script
    public int index = -1;

    
    private void OnMouseDown()
    {
        // set selection index
        ((NetworkManagerMMO)NetworkManager.singleton).selection = index;

        // show selection indicator for better feedback
        GetComponent<Player>().SetIndicatorViaParent(transform);
    }

    private void Update()
    {
        // remove indicator if not selected anymore
        if (((NetworkManagerMMO)NetworkManager.singleton).selection != index)
        {
            Player player = GetComponent<Player>();
            if (player.indicator != null)
                Destroy(player.indicator);
        }
    }
}

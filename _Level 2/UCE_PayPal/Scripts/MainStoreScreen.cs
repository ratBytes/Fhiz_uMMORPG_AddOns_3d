// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using System.Linq;
using UnityEngine;

// MainStoreScreen

public class MainStoreScreen : MonoBehaviour
{
    public StoreItemContent productSlot;
    public Transform content;

    public void OnEnable()
    {
        int productCount = UCE_Tmpl_PayPalProduct.dict.Count;
        UIUtils.BalancePrefabs(productSlot.gameObject, productCount, content);

        for (int i = 0; i < productCount; ++i)
        {
            StoreItemContent slot = content.GetChild(i).GetComponent<StoreItemContent>();
            slot.Init(UCE_Tmpl_PayPalProduct.dict.ElementAt(i).Value);
        }
    }
}
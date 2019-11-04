// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using System;
using System.Collections.Generic;

[Serializable]
public class PayPalErrorJsonResponse
{
    public string name;
    public string message;
    public string information_link;
    public string debug_id;

    public List<Detail> details;

    [Serializable]
    public class Detail
    {
        public string field;
        public string issue;
    }
}

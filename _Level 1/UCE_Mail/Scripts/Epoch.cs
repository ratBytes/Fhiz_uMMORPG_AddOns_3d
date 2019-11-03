// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using System;

public static class Epoch
{
    private static readonly DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public static long Current()
    {
        return (long)(DateTime.UtcNow - epochStart).TotalMilliseconds;
    }

    public static long DateTimeToEpoch(DateTime when)
    {
        return (long)(when - epochStart).TotalMilliseconds;
    }

    public static DateTime EpochToDateTime(long epoch)
    {
        return epochStart.AddMilliseconds(epoch);
    }
}
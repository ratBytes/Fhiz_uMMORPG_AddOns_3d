// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using System.Collections;
using Mirror;
using UnityEngine;

public partial class Entity
{
    private float rubberbandTimer;
    private Vector3 oldPosition;
    private Vector3 rubberbandPosition;
    private bool isRubberbanding;

    public void LateUpdate_Zindex()
    {
        if (isClient)
        {
            if (isRubberbanding)
            {
                float timepassed = Time.time - rubberbandTimer;
                float d = timepassed / 0.1f;
                if (timepassed < 0.1f)
                {
                    transform.position = Vector3.Lerp(oldPosition, rubberbandPosition, d);
                }
                else
                {
                    agent.Warp(rubberbandPosition);
                    isRubberbanding = false;
                }
            }
        }
    }

    [Server]
    public void ResetMovementAll()
    {
    	if (agent.hasPath)
    	{
        	agent.ResetMovement();
        	RpcResetMovement(transform.position);
    		return;
    	}
    	agent.ResetMovement();
    	
    }

    [ClientRpc]
    public void RpcResetMovement(Vector3 resetPosition)
    {
        // reset path and velocity
        //Debug.LogWarning(name + "(local=" + isLocalPlayer + ") TargetResetMovement @ " + resetPosition);
        // Debug.Log("Distance warp: " + Vector3.Distance(resetPosition, transform.position));

        rubberbandTimer = Time.time;
        oldPosition = transform.position;
        rubberbandPosition = resetPosition;
        isRubberbanding = true;
    }
}
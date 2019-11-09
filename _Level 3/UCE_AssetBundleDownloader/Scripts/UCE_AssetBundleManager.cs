// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Jacovone.AssetBundleMagic;

// ===================================================================================
// AssetBundleManager (SINGLETON)
// ===================================================================================
public class UCE_AssetBundleManager : MonoBehaviour
{

    public static UCE_AssetBundleManager singleton;

    [Header("Options")]
    public bool activeOnServer;
    public bool activeOnClient;

    [Header("Bundles")]
    public string[] bundleNames;

    [Header("Labels")]
    public string labelUncache      = "Unloading cache...";
    public string labelVersions     = "Updating versions numbers...";
    public string labelBundles      = "Starting bundle download... ";
    public string labelBundle       = "Downloading Bundle: ";

    private int index = -1;
    private AssetBundleMagic.Progress p = null;

    // -------------------------------------------------------------------------------
    // Awake
    // -------------------------------------------------------------------------------
    private void Awake()
    {
        if (singleton == null) singleton = this;
        Invoke(nameof(StartBundleManager), 1f);
    }

    // -------------------------------------------------------------------------------
    // Update
    // -------------------------------------------------------------------------------
    void Update()
    {
        if (p != null)
        {
            float fProgress = Mathf.Max(0, p.GetProgress());
            string sText = ((int)(100 * fProgress)).ToString() + "%";
            UCE_UI_AssetBundleDownloader.singleton.UpdateUI("", fProgress, sText);
        }
    }

    // ===============================================================================
    // GENERAL FUNCTIONS
    // ===============================================================================

    // -------------------------------------------------------------------------------
    // StartBundleManager
    // -------------------------------------------------------------------------------
    protected void StartBundleManager()
    {
        //UnloadBundles();
        DownloadVersions();
    }

    // -------------------------------------------------------------------------------
    // CheckBuildTarget
    // -------------------------------------------------------------------------------
    protected bool CheckBuildTarget()
    {

#if _SERVER
        if (activeOnServer) return true;
#endif

#if _CLIENT
        if (activeOnClient) return true;
#endif
        return false;

    }

    // -------------------------------------------------------------------------------
    // UnloadBundles
    // -------------------------------------------------------------------------------
    protected void UnloadBundles()
    {
        if (!CheckBuildTarget()) return;

        UCE_UI_AssetBundleDownloader.singleton.UpdateUI(labelUncache);

        AssetBundleMagic.CleanBundlesCache();

        foreach (string bundleName in bundleNames)
            AssetBundleMagic.UnloadBundle(bundleName, true);
    }

    // -------------------------------------------------------------------------------
    // DownloadVersions
    // -------------------------------------------------------------------------------
    protected void DownloadVersions()
    {

        if (!CheckBuildTarget()) return;

        UCE_UI_AssetBundleDownloader.singleton.UpdateUI(labelVersions);

        AssetBundleMagic.DownloadVersions(delegate (string versions) {
            LoadBundles();
        }, delegate (string error) {
            Debug.LogError(error);
        });
    }

    // -------------------------------------------------------------------------------
    // LoadBundles
    // -------------------------------------------------------------------------------
    protected void LoadBundles()
    {

        if (!CheckBuildTarget()) return;

        UCE_UI_AssetBundleDownloader.singleton.UpdateUI(labelBundles);



    }

    // -------------------------------------------------------------------------------
    // LoadBundle
    // -------------------------------------------------------------------------------
    protected void LoadBundle(string sBundleName)
    {

        if (!CheckBuildTarget()) return;

        UCE_UI_AssetBundleDownloader.singleton.UpdateUI(labelBundle + sBundleName);

        p = AssetBundleMagic.DownloadBundle(
                    sBundleName,
                    delegate (AssetBundle ab2) {
                        index++;
                    },
                    delegate (string error) {
                        Debug.LogError(error);
                    }
                );

    }

    // -------------------------------------------------------------------------------
}

// ===================================================================================

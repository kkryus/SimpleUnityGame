/// <summary>
/// WeaponEditor.cs
/// Author: MutantGopher
/// This script creates a custom inspector for the weapon system in Weapon.cs.
/// </summary>

using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Weapon))]
public class WeaponEditor : Editor
{
    private bool showPluginSupport = false;
    private bool showGeneral = false;
    private bool showAmmo = false;
    private bool showROF = false;
    private bool showPower = false;
    private bool showAccuracy = false;
    private bool showWarmup = false;
    private bool showRecoil = false;
    private bool showEffects = false;
    private bool showCrosshairs = false;
    private bool showAudio = false;

    public override void OnInspectorGUI()
    {
        // Get a reference to the weapon script
        Weapon weapon = (Weapon)target;

        // Weapon type
        weapon.type = (WeaponType)EditorGUILayout.EnumPopup("Weapon Type", weapon.type);

        // External tools support
        showPluginSupport = EditorGUILayout.Foldout(showPluginSupport, "3rd Party Plugin Support");
        if (showPluginSupport)
        {
            if (weapon.bloodyMessEnabled)
            {
                weapon.weaponType = EditorGUILayout.IntField("Weapon Type", weapon.weaponType);
            }
        }

        // General
        showGeneral = EditorGUILayout.Foldout(showGeneral, "General");
        if (showGeneral)
        {
            weapon.playerWeapon = EditorGUILayout.Toggle("Player's Weapon", weapon.playerWeapon);
            if (weapon.type == WeaponType.Raycast || weapon.type == WeaponType.Projectile)
                weapon.auto = (Auto)EditorGUILayout.EnumPopup("Auto Type", weapon.auto);
            weapon.weaponModel = (GameObject)EditorGUILayout.ObjectField("Weapon Model", weapon.weaponModel, typeof(GameObject), true);
            weapon.raycastStartSpot = (Transform)EditorGUILayout.ObjectField("Raycasting Point", weapon.raycastStartSpot, typeof(Transform), true);
        }



        // Power
        if (weapon.type == WeaponType.Raycast || weapon.type == WeaponType.Beam)
        {
            showPower = EditorGUILayout.Foldout(showPower, "Power");
            if (showPower)
            {
                if (weapon.type == WeaponType.Raycast)
                    weapon.power = EditorGUILayout.FloatField("Power", weapon.power);
                else
                    weapon.beamPower = EditorGUILayout.FloatField("Power", weapon.beamPower);

                weapon.forceMultiplier = EditorGUILayout.FloatField("Force Multiplier", weapon.forceMultiplier);
                weapon.range = EditorGUILayout.FloatField("Range", weapon.range);
            }
        }


        // ROF
        if (weapon.type == WeaponType.Raycast || weapon.type == WeaponType.Projectile)
        {
            showROF = EditorGUILayout.Foldout(showROF, "Rate Of Fire");
            if (showROF)
            {
                weapon.rateOfFire = EditorGUILayout.FloatField("Rate Of Fire", weapon.rateOfFire);
                weapon.delayBeforeFire = EditorGUILayout.FloatField("Delay Before Fire", weapon.delayBeforeFire);
                // Burst
                weapon.burstRate = EditorGUILayout.IntField("Burst Rate", weapon.burstRate);
                weapon.burstPause = EditorGUILayout.FloatField("Burst Pause", weapon.burstPause);
            }
        }


        // Ammo
        if (weapon.type == WeaponType.Raycast || weapon.type == WeaponType.Projectile)
        {
            showAmmo = EditorGUILayout.Foldout(showAmmo, "Ammunition");
            if (showAmmo)
            {
                weapon.infiniteAmmo = EditorGUILayout.Toggle("Infinite Ammo", weapon.infiniteAmmo);

                if (!weapon.infiniteAmmo)
                {
                    weapon.ammoCapacity = EditorGUILayout.IntField("Ammo Capacity", weapon.ammoCapacity);
                    weapon.reloadTime = EditorGUILayout.FloatField("Reload Time", weapon.reloadTime);
                    weapon.showCurrentAmmo = EditorGUILayout.Toggle("Show Current Ammo", weapon.showCurrentAmmo);
                    weapon.reloadAutomatically = EditorGUILayout.Toggle("Reload Automatically", weapon.reloadAutomatically);
                }
                weapon.shotPerRound = EditorGUILayout.IntField("Shots Per Round", weapon.shotPerRound);
            }
        }



        // Accuracy
        if (weapon.type == WeaponType.Raycast)
        {
            showAccuracy = EditorGUILayout.Foldout(showAccuracy, "Accuracy");
            if (showAccuracy)
            {
                weapon.accuracy = EditorGUILayout.FloatField("Accuracy", weapon.accuracy);
                weapon.accuracyDropPerShot = EditorGUILayout.FloatField("Accuracy Drop Per Shot", weapon.accuracyDropPerShot);
                weapon.accuracyRecoverRate = EditorGUILayout.FloatField("Accuracy Recover Rate", weapon.accuracyRecoverRate);
            }
        }


        // Warmup
        if ((weapon.type == WeaponType.Raycast || weapon.type == WeaponType.Projectile) && weapon.auto == Auto.Semi)
        {
            showWarmup = EditorGUILayout.Foldout(showWarmup, "Warmup");
            if (showWarmup)
            {
                weapon.warmup = EditorGUILayout.Toggle("Warmup", weapon.warmup);

                if (weapon.warmup)
                {
                    weapon.maxWarmup = EditorGUILayout.FloatField("Max Warmup", weapon.maxWarmup);
                    weapon.powerMultiplier = EditorGUILayout.FloatField("Power Multiplier", weapon.powerMultiplier);
                    weapon.allowCancel = EditorGUILayout.Toggle("Allow Cancel", weapon.allowCancel);
                }
            }
        }


        // Recoil
        if (weapon.type == WeaponType.Raycast || weapon.type == WeaponType.Projectile)
        {
            showRecoil = EditorGUILayout.Foldout(showRecoil, "Recoil");
            if (showRecoil)
            {
                weapon.recoil = EditorGUILayout.Toggle("Recoil", weapon.recoil);

                if (weapon.recoil)
                {
                    weapon.recoilKickBackMin = EditorGUILayout.FloatField("Recoil Move Min", weapon.recoilKickBackMin);
                    weapon.recoilKickBackMax = EditorGUILayout.FloatField("Recoil Move Max", weapon.recoilKickBackMax);
                    weapon.recoilRotationMin = EditorGUILayout.FloatField("Recoil Rotation Min", weapon.recoilRotationMin);
                    weapon.recoilRotationMax = EditorGUILayout.FloatField("Recoil Rotation Max", weapon.recoilRotationMax);
                    weapon.recoilRecoveryRate = EditorGUILayout.FloatField("Recoil Recovery Rate", weapon.recoilRecoveryRate);
                }
            }
        }


        // Shells
        showEffects = EditorGUILayout.Foldout(showEffects, "Effects");
        if (showEffects)
        {
            weapon.spitShells = EditorGUILayout.Toggle("Spit Shells", weapon.spitShells);
            if (weapon.spitShells)
            {
                weapon.shell = (GameObject)EditorGUILayout.ObjectField("Shell", weapon.shell, typeof(GameObject), false);
                weapon.shellSpitForce = EditorGUILayout.FloatField("Shell Spit Force", weapon.shellSpitForce);
                weapon.shellForceRandom = EditorGUILayout.FloatField("Force Variant", weapon.shellForceRandom);
                weapon.shellSpitTorqueX = EditorGUILayout.FloatField("X Torque", weapon.shellSpitTorqueX);
                weapon.shellSpitTorqueY = EditorGUILayout.FloatField("Y Torque", weapon.shellSpitTorqueY);
                weapon.shellTorqueRandom = EditorGUILayout.FloatField("Torque Variant", weapon.shellTorqueRandom);
                weapon.shellSpitPosition = (Transform)EditorGUILayout.ObjectField("Shell Spit Point", weapon.shellSpitPosition, typeof(Transform), true);
            }
        }

        // Crosshairs
        showCrosshairs = EditorGUILayout.Foldout(showCrosshairs, "Crosshairs");
        if (showCrosshairs)
        {
            weapon.showCrosshair = EditorGUILayout.Toggle("Show Crosshairs", weapon.showCrosshair);
            if (weapon.showCrosshair)
            {
                weapon.crosshairTexture = (Texture2D)EditorGUILayout.ObjectField("Crosshair Texture", weapon.crosshairTexture, typeof(Texture2D), false);
                weapon.crosshairLength = EditorGUILayout.IntField("Crosshair Length", weapon.crosshairLength);
                weapon.crosshairWidth = EditorGUILayout.IntField("Crosshair Width", weapon.crosshairWidth);
                weapon.startingCrosshairSize = EditorGUILayout.FloatField("Start Crosshair Size", weapon.startingCrosshairSize);
            }
        }


        // Audio
        showAudio = EditorGUILayout.Foldout(showAudio, "Audio");
        if (showAudio)
        {
            weapon.fireSound = (AudioClip)EditorGUILayout.ObjectField("Fire", weapon.fireSound, typeof(AudioClip), false);
            weapon.reloadSound = (AudioClip)EditorGUILayout.ObjectField("Reload", weapon.reloadSound, typeof(AudioClip), false);
            weapon.dryFireSound = (AudioClip)EditorGUILayout.ObjectField("Out of Ammo", weapon.dryFireSound, typeof(AudioClip), false);
        }


        // This makes the editor gui re-draw the inspector if values have changed
        if (GUI.changed)
            EditorUtility.SetDirty(target);
    }
}


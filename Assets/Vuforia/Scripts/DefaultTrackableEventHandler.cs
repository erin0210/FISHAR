/*==============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


/// <summary>
///     A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class DefaultTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
	//------------Begin Sound----------
	public AudioSource soundTarget;
	public AudioClip clipTarget;
	private AudioSource[] allAudioSources;

	//function to stop all sounds
	void StopAllAudio()
	{
		allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
		foreach (AudioSource audioS in allAudioSources)
		{
			audioS.Stop();
		}
	}

	//function to play sound
	void playSound(string ss)
	{
		clipTarget = (AudioClip)Resources.Load(ss);
		soundTarget.clip = clipTarget;
		soundTarget.loop = false;
		soundTarget.playOnAwake = false;
		soundTarget.Play();
	}

	//-----------End Sound------------


	//public Transform TextDescription1;
	//public Transform TextDescription2;
	//public Transform PanelDescription;


	#region PRIVATE_MEMBER_VARIABLES

	protected TrackableBehaviour mTrackableBehaviour;

	#endregion // PRIVATE_MEMBER_VARIABLES

	#region UNTIY_MONOBEHAVIOUR_METHODS

	protected virtual void Start ()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour> ();
		if (mTrackableBehaviour)
			mTrackableBehaviour.RegisterTrackableEventHandler (this);

		transform.localScale = Vector3.one * 10;
		//Register / add the AudioSource as object
		soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();

	}

	#endregion // UNTIY_MONOBEHAVIOUR_METHODS

	#region PUBLIC_METHODS

	/// <summary>
	///     Implementation of the ITrackableEventHandler function called when the
	///     tracking state changes.
	/// </summary>
	public void OnTrackableStateChanged (
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
			Debug.Log ("Trackable " + mTrackableBehaviour.TrackableName + " found");

			//Play Sound, IF detect an target

			if (mTrackableBehaviour.TrackableName == "LOGO_AR4_kukur")
			{
				playSound("sounds/Kukur");
			}

			if (mTrackableBehaviour.TrackableName == "LOGO_AR4_dapur")
			{
				playSound("sounds/Api(2)");
			}

			if (mTrackableBehaviour.TrackableName == "LOGO_AR4_batu_giling")
			{
				playSound("sounds/Giling");
			}

			if (mTrackableBehaviour.TrackableName == "LOGO_AR4_lampu_pam")
			{
				playSound("sounds/Lampu");
			}

			if (mTrackableBehaviour.TrackableName == "FISHAR_Logo")
			{
				playSound("sounds/fishar5");
			}


			OnTrackingFound();
		} else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
			newStatus == TrackableBehaviour.Status.NOT_FOUND) {
			Debug.Log ("Trackable " + mTrackableBehaviour.TrackableName + " lost");

			//Stop All Sounds if Target Lost
			StopAllAudio();

			OnTrackingLost();
		} else {
			// For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
			// Vuforia is starting, but tracking has not been lost or found yet
			// Call OnTrackingLost() to hide the augmentations
			OnTrackingLost ();
		}
	}

	#endregion // PUBLIC_METHODS

	#region PRIVATE_METHODS

	protected virtual void OnTrackingFound ()
	{
		// Enable child:
		foreach (Transform t in gameObject.transform) {
			t.gameObject.SetActive (true);
		}
	}


	protected virtual void OnTrackingLost ()
	{
		// Disable child:
		foreach (Transform t in gameObject.transform) {
			t.gameObject.SetActive (false);
		}

		//Evertime the target lost / no target found it will show “???” on the TextTargetName. Button, Description and Panel will invicible (inactive)

		//TextDescription1.gameObject.SetActive(false);
		//TextDescription2.gameObject.SetActive(false);
		//PanelDescription.gameObject.SetActive(false);

	}

	#endregion // PRIVATE_METHODS
}

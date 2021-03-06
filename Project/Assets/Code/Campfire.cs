﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour, IClickable
{
	public void OnClick(CharController player)
	{
		if (!player.Sitting) player.ToggleSitting(transform.position - player.transform.position);
		else player.ToggleSitting();
	}
}

﻿using Engine.Utility;
using UnityEngine;

namespace View
{
	public class Cameras
	{
		public float TranslateSpeed { get; set; }
		public float ScrollSpeed { get; set; }
		public Vector3 StartLocation { get; set; }
		public Vector3 StartRotation { get; set; }
		public float RotateSpeed { get; set; }
	}
}

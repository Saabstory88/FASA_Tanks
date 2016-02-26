/*
		 * So here is how this is going to work...
		 * 
		 * We will start by implimenting a basic tank, with a cap on either end, and a tank in the middle.
		 * To start, we will just stretch the tank to prove that we can make this work, and actually make this a thing later
		 * We will ignore texture stretching for the moment
		 * 
		 * So here's how we are going to proceed. We are first going to start off with a tank which has a center cylinder which is 1 meter long
		 * just to make things simple. So at a scale factor of one, the tank will have a length of one meter.
		 * 
		 * Obviously, this a crap way to make things work in real life, but it will let us actually test out whether the part state is persistent
		 * and work with all of the BS that symetry implies. It's a simple test case...
		 * 
		 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSPAPIExtensions;

namespace FASA_Tanks
{
	public class semiTank : PartModule //, IPartCostModifier, IPartMassModifier
	{
		//So this should let us set a scale in the GUI, defaults to 1. Don't need to load any config data yet.
		[KSPField(isPersistant = false, guiActiveEditor = true, guiName = "Length", guiFormat = "0.000", guiUnits = "m"),
		 UI_FloatEdit(scene = UI_Scene.Editor, minValue = 1.0f, incrementLarge = 2.0f, incrementSmall = 0.5f, incrementSlide = 0.001f)]
		public float tankLength = 1.0f;

		public override void OnLoad(ConfigNode node)
		{
			base.OnLoad(node);
			//Setup();
		}
		
		public override void OnSave(ConfigNode node)
		{
			//version = GetType().Assembly.GetName().Version.ToString();
			base.OnSave(node);
		}

		public void scaleTank()
		{
			part.transform.GetChild(0).localScale = new Vector3(1f, tankLength, 1f);
			Debug.Log ("Setting Scale to: " + tankLength);
		}

		public override void OnUpdate()
		{
			scaleTank();
		}

	}
}


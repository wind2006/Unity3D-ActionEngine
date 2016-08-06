﻿using UnityEngine;
using System.Collections;
using ActionEngine;

public static class VeryAwesomeAEX {
	
	public static ActionBase Create (IAEScriptContext ctx) {
		var simpleAEX = ctx.GetAEScript("$simple");
		var cube = ctx.GetTransform("$cube");
		var sphere = ctx.GetTransform("$sphere");

		return
			AE.Sequence(
				AE.Parallel(
					// You can use another AEX
					simpleAEX.Create(),
					// Basic tweens
					cube.AEMove(new Vector3(0, -3, 0), 3.5f).Easing(Easings.OutQuad),
					sphere.AEMove(new Vector3(0, 3, 0), 4.5f).Easing(Easings.OutBack)
                ),
				AE.Parallel(
					cube.AEMove(new Vector3(0, 3, 0), 2.5f).Relative(true).Easing(Easings.InBack),
					sphere.AEMove(new Vector3(0, -3, 0), 3.5f).Relative(true).Easing(Easings.OutQuad)
				),
				AE.Delay(0.5f),
				AE.Debug("All Completed!")
			);
	}

}
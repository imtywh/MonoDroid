
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;
using Android.Util;

namespace MonoDroid.Samples {

	[MonoDroid.Attributes.Sample(Label = "Guestures Test")]
	[Activity (Label = "Guestures Test")]
	public class GuestureActivity : Activity {

		private static string DebugTag = "GuestureActivity";

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);
			// Create your application here
		}

		public override bool OnTouchEvent(MotionEvent e) {
			var action = (MotionEventActions)MotionEventCompat.GetActionMasked(e);
			switch (action) {
				case MotionEventActions.Down:
					Log.Debug(DebugTag, "Action was Down");
					return true;
				case MotionEventActions.Move:
					Log.Debug(DebugTag, "Action was Move");
					return true;
				case MotionEventActions.Cancel:
					Log.Debug(DebugTag, "Action was Cancel");
					return true;
				case MotionEventActions.Outside:
					Log.Debug(DebugTag, "Action was Outside");
					return true;
				default:
					return base.OnTouchEvent(e);;
			}
		}

	}
}


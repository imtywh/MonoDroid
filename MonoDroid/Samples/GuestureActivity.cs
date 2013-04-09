
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

		private static string DebugTag = "VelocityTracker";

		private VelocityTracker _velocityTracket;

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);
			// Create your application here
			this.SetContentView(Resource.Layout.activity_gesture);
		}

		public override bool OnTouchEvent(MotionEvent e) {

			var index = e.ActionIndex;
			var action = (MotionEventActions)e.ActionMasked;
			var pointerId = e.GetPointerId(index);

			switch (action) {
				case MotionEventActions.Down:
					if (this._velocityTracket == null) {
						this._velocityTracket = VelocityTracker.Obtain();
					}
					else {
						this._velocityTracket.Clear();
					}
					this._velocityTracket.AddMovement(e);
					break;
				case MotionEventActions.Move:
					this._velocityTracket.AddMovement(e);
					this._velocityTracket.ComputeCurrentVelocity(1000);
					Log.Debug(DebugTag, "X velocity: " + VelocityTrackerCompat.GetXVelocity(this._velocityTracket, pointerId));
					Log.Debug(DebugTag, "Y velocity: " + VelocityTrackerCompat.GetYVelocity(this._velocityTracket, pointerId));
					break;
				case MotionEventActions.Cancel:
				case MotionEventActions.Up:
					this._velocityTracket.Recycle();
					break;
				default:
					break;
			}
			return true;
		}
		
	}

}


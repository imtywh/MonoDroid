
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

		private GestureDetectorCompat _detector;

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);
			// Create your application here
			this.SetContentView(Resource.Layout.activity_gesture);

			this._detector = new GestureDetectorCompat(this, new MyGestureListener());
		}

		public override bool OnTouchEvent(MotionEvent e) {
			this._detector.OnTouchEvent(e);
			return base.OnTouchEvent(e);
		}
		
	}

	class MyGestureListener : GestureDetector.SimpleOnGestureListener {

		private static string DebugTag = "MyGestureListener";

		public override bool OnDown(MotionEvent e) {
			Log.Debug(DebugTag, string.Format("OnDown: {0}", e));
			return true;
		}

		public override bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY) {
			Log.Debug(DebugTag, string.Format("OnFling: {0} {1}", e1, e2));
			return true;
		}

	}

}


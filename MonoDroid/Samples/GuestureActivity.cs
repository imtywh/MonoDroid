
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
	public class GuestureActivity : Activity, GestureDetector.IOnGestureListener, GestureDetector.IOnDoubleTapListener {

		private static string DebugTag = "GuestureActivity";

		private GestureDetectorCompat _detector;

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);
			// Create your application here
			this.SetContentView(Resource.Layout.activity_gesture);

			this._detector = new GestureDetectorCompat(this, this);
			this._detector.SetOnDoubleTapListener(this);
		}

		public override bool OnTouchEvent(MotionEvent e) {
			this._detector.OnTouchEvent(e);
			return base.OnTouchEvent(e);
		}

		#region IOnGestureListener implementation

		public bool OnDown(MotionEvent e) {
			Log.Debug(DebugTag, "OnDown: " + e.ToString());
			return true;
		}

		public bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY) {
			Log.Debug(DebugTag, "OnFling: " + e1.ToString() + e2.ToString());
			return true;
		}

		public void OnLongPress(MotionEvent e) {
			Log.Debug(DebugTag, "OnLongPress: " + e.ToString());
		}

		public bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY) {
			Log.Debug(DebugTag, "OnScroll: " + e1.ToString() + e2.ToString());
			return true;
		}

		public void OnShowPress(MotionEvent e) {
			Log.Debug(DebugTag, "OnShowPress: " + e.ToString());
		}

		public bool OnSingleTapUp(MotionEvent e) {
			Log.Debug(DebugTag, "OnSingleTapUp: " + e.ToString());
			return true;
		}

		#endregion

		#region IOnDoubleTapListener implementation
		
		public bool OnDoubleTap(MotionEvent e) {
			Log.Debug(DebugTag, "OnDoubleTap: " + e.ToString());
			return true;
		}
		
		public bool OnDoubleTapEvent(MotionEvent e) {
			Log.Debug(DebugTag, "OnDoubleTapEvent: " + e.ToString());
			return true;
		}
		
		public bool OnSingleTapConfirmed(MotionEvent e) {
			Log.Debug(DebugTag, "OnSingleTapConfirmed: " + e.ToString());
			return true;
		}
		
		#endregion

	}
}


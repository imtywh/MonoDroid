using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Views.InputMethods;

namespace MonoDroid.Samples {

	[MonoDroid.Attributes.Sample(Label = "Dialog Fragment Test")]
	public class TestDialogFragment : Android.Support.V4.App.Fragment {

		private Button _showDialogButton;

		public override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup parent, Bundle savedInstanceState) {
			var view = inflater.Inflate(Resource.Layout.fragment_dialog_test, parent, false);
			this._showDialogButton = view.FindViewById<Button>(Resource.Id.fragment_dialog_test_button_show);
			this._showDialogButton.Click += (sender, e) => this.ShowEditDialog();
			return view;
		}

		void ShowEditDialog() {
			var fm = this.Activity.SupportFragmentManager;
			var dialog = new MyDialogFragment();
			dialog.FinishEditCallback = (str) => {
				Toast.MakeText(this.Activity, "Hi, " + str, ToastLength.Short).Show();
			};
			dialog.Show(fm, "fragment_dialog_test_popup");
		}
	}

	public class MyDialogFragment : Android.Support.V4.App.DialogFragment , EditText.IOnEditorActionListener  {

		public Action<string> FinishEditCallback;

		private EditText _editText;

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			var view = inflater.Inflate(Resource.Layout.fragment_dialog_test_popup, container, false);
			this._editText = view.FindViewById<EditText>(Resource.Id.fragment_dialog_test_popup_txt_your_name);
			this.Dialog.SetTitle("Hello");

			this._editText.RequestFocus();
			this.Dialog.Window.SetSoftInputMode(SoftInput.StateVisible);
			this._editText.SetOnEditorActionListener(this);
			return view;
		}

		public bool OnEditorAction(TextView v, ImeAction actionId, KeyEvent e) {
			if (actionId == ImeAction.Done) {
				if (this.FinishEditCallback != null) {
					this.FinishEditCallback(v.Text);
				}
				this.Dismiss();
				return true;
			}
			return false;
		}
	}
}


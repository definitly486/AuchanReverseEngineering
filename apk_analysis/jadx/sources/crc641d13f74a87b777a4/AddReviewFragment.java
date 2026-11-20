package crc641d13f74a87b777a4;

import android.app.DatePickerDialog;
import android.content.DialogInterface;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.MotionEvent;
import android.view.View;
import android.widget.DatePicker;
import android.widget.TextView;
import crc64f03248cb510113f2.BaseBottomSheetDialogFragment_1;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class AddReviewFragment extends BaseBottomSheetDialogFragment_1 implements IGCUserPeer, View.OnTouchListener, DatePickerDialog.OnDateSetListener, TextView.OnEditorActionListener {
    private ArrayList refList;

    private native int n_getTheme();

    private native void n_onDateSet(DatePicker datePicker, int i, int i2, int i3);

    private native void n_onDestroyView();

    private native void n_onDismiss(DialogInterface dialogInterface);

    private native boolean n_onEditorAction(TextView textView, int i, KeyEvent keyEvent);

    private native boolean n_onTouch(View view, MotionEvent motionEvent);

    private native void n_onViewCreated(View view, Bundle bundle);

    public AddReviewFragment() {
        if (getClass() == AddReviewFragment.class) {
            TypeManager.Activate("Auchan.Android.Reviews.AddReviewFragment, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public AddReviewFragment(int i) {
        super(i);
        if (getClass() == AddReviewFragment.class) {
            TypeManager.Activate("Auchan.Android.Reviews.AddReviewFragment, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // androidx.fragment.app.DialogFragment
    public int getTheme() {
        return n_getTheme();
    }

    @Override // androidx.fragment.app.DialogFragment, androidx.fragment.app.Fragment
    public void onDestroyView() {
        n_onDestroyView();
    }

    @Override // androidx.fragment.app.Fragment
    public void onViewCreated(View view, Bundle bundle) {
        n_onViewCreated(view, bundle);
    }

    @Override // androidx.fragment.app.DialogFragment, android.content.DialogInterface.OnDismissListener
    public void onDismiss(DialogInterface dialogInterface) {
        n_onDismiss(dialogInterface);
    }

    @Override // android.view.View.OnTouchListener
    public boolean onTouch(View view, MotionEvent motionEvent) {
        return n_onTouch(view, motionEvent);
    }

    @Override // android.app.DatePickerDialog.OnDateSetListener
    public void onDateSet(DatePicker datePicker, int i, int i2, int i3) {
        n_onDateSet(datePicker, i, i2, i3);
    }

    @Override // android.widget.TextView.OnEditorActionListener
    public boolean onEditorAction(TextView textView, int i, KeyEvent keyEvent) {
        return n_onEditorAction(textView, i, keyEvent);
    }

    @Override // crc64f03248cb510113f2.BaseBottomSheetDialogFragment_1, crc64f03248cb510113f2.BaseBottomSheetDialogFragment, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64f03248cb510113f2.BaseBottomSheetDialogFragment_1, crc64f03248cb510113f2.BaseBottomSheetDialogFragment, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}

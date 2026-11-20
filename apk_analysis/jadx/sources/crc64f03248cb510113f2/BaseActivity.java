package crc64f03248cb510113f2;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import androidx.appcompat.app.AppCompatActivity;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public abstract class BaseActivity extends AppCompatActivity implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onCreate(Bundle bundle);

    private native void n_onNewIntent(Intent intent);

    private native void n_onRequestPermissionsResult(int i, String[] strArr, int[] iArr);

    private native void n_onResume();

    private native void n_onUserInteraction();

    private native void n_setContentView(int i);

    private native void n_setContentView(View view);

    private native void n_setContentView(View view, ViewGroup.LayoutParams layoutParams);

    public BaseActivity() {
        if (getClass() == BaseActivity.class) {
            TypeManager.Activate("Auchan.Android.Base.BaseActivity, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public BaseActivity(int i) {
        super(i);
        if (getClass() == BaseActivity.class) {
            TypeManager.Activate("Auchan.Android.Base.BaseActivity, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // androidx.fragment.app.FragmentActivity, androidx.activity.ComponentActivity, androidx.core.app.ComponentActivity, android.app.Activity
    public void onCreate(Bundle bundle) {
        n_onCreate(bundle);
    }

    @Override // androidx.appcompat.app.AppCompatActivity, androidx.activity.ComponentActivity, android.app.Activity
    public void setContentView(View view, ViewGroup.LayoutParams layoutParams) {
        n_setContentView(view, layoutParams);
    }

    @Override // androidx.appcompat.app.AppCompatActivity, androidx.activity.ComponentActivity, android.app.Activity
    public void setContentView(View view) {
        n_setContentView(view);
    }

    @Override // androidx.appcompat.app.AppCompatActivity, androidx.activity.ComponentActivity, android.app.Activity
    public void setContentView(int i) {
        n_setContentView(i);
    }

    @Override // androidx.activity.ComponentActivity, android.app.Activity
    public void onNewIntent(Intent intent) {
        n_onNewIntent(intent);
    }

    @Override // androidx.fragment.app.FragmentActivity, android.app.Activity
    public void onResume() {
        n_onResume();
    }

    @Override // androidx.fragment.app.FragmentActivity, androidx.activity.ComponentActivity, android.app.Activity
    public void onRequestPermissionsResult(int i, String[] strArr, int[] iArr) {
        n_onRequestPermissionsResult(i, strArr, iArr);
    }

    @Override // android.app.Activity
    public void onUserInteraction() {
        n_onUserInteraction();
    }

    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}

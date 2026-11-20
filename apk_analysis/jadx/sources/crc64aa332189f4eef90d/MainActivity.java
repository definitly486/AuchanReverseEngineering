package crc64aa332189f4eef90d;

import android.os.Bundle;
import crc64f03248cb510113f2.BaseActivity;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class MainActivity extends BaseActivity implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onCreate(Bundle bundle);

    private native void n_onDestroy();

    private native void n_onRequestPermissionsResult(int i, String[] strArr, int[] iArr);

    private native void n_onResume();

    public MainActivity() {
        if (getClass() == MainActivity.class) {
            TypeManager.Activate("Auchan.Android.MainActivity, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public MainActivity(int i) {
        super(i);
        if (getClass() == MainActivity.class) {
            TypeManager.Activate("Auchan.Android.MainActivity, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // crc64f03248cb510113f2.BaseActivity, androidx.fragment.app.FragmentActivity, androidx.activity.ComponentActivity, androidx.core.app.ComponentActivity, android.app.Activity
    public void onCreate(Bundle bundle) {
        n_onCreate(bundle);
    }

    @Override // androidx.appcompat.app.AppCompatActivity, androidx.fragment.app.FragmentActivity, android.app.Activity
    public void onDestroy() {
        n_onDestroy();
    }

    @Override // crc64f03248cb510113f2.BaseActivity, androidx.fragment.app.FragmentActivity, android.app.Activity
    public void onResume() {
        n_onResume();
    }

    @Override // crc64f03248cb510113f2.BaseActivity, androidx.fragment.app.FragmentActivity, androidx.activity.ComponentActivity, android.app.Activity
    public void onRequestPermissionsResult(int i, String[] strArr, int[] iArr) {
        n_onRequestPermissionsResult(i, strArr, iArr);
    }

    @Override // crc64f03248cb510113f2.BaseActivity, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64f03248cb510113f2.BaseActivity, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}

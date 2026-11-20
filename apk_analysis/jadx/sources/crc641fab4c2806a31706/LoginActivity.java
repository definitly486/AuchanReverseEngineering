package crc641fab4c2806a31706;

import android.os.Bundle;
import crc64f03248cb510113f2.BaseActivity;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class LoginActivity extends BaseActivity implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onBackPressed();

    private native void n_onCreate(Bundle bundle);

    public LoginActivity() {
        if (getClass() == LoginActivity.class) {
            TypeManager.Activate("Auchan.Android.Authorization.LoginActivity, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public LoginActivity(int i) {
        super(i);
        if (getClass() == LoginActivity.class) {
            TypeManager.Activate("Auchan.Android.Authorization.LoginActivity, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // crc64f03248cb510113f2.BaseActivity, androidx.fragment.app.FragmentActivity, androidx.activity.ComponentActivity, androidx.core.app.ComponentActivity, android.app.Activity
    public void onCreate(Bundle bundle) {
        n_onCreate(bundle);
    }

    @Override // androidx.activity.ComponentActivity, android.app.Activity
    public void onBackPressed() {
        n_onBackPressed();
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

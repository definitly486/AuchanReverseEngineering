package ru.myauchan.droid;

import android.content.Intent;
import android.os.Bundle;
import crc64f03248cb510113f2.BaseActivity;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes4.dex */
public class StartActivity extends BaseActivity implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onCreate(Bundle bundle);

    private native void n_onNewIntent(Intent intent);

    private native void n_onStop();

    public StartActivity() {
        if (getClass() == StartActivity.class) {
            TypeManager.Activate("Auchan.Android.StartActivity, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public StartActivity(int i) {
        super(i);
        if (getClass() == StartActivity.class) {
            TypeManager.Activate("Auchan.Android.StartActivity, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // crc64f03248cb510113f2.BaseActivity, androidx.fragment.app.FragmentActivity, androidx.activity.ComponentActivity, androidx.core.app.ComponentActivity, android.app.Activity
    public void onCreate(Bundle bundle) {
        n_onCreate(bundle);
    }

    @Override // crc64f03248cb510113f2.BaseActivity, androidx.activity.ComponentActivity, android.app.Activity
    public void onNewIntent(Intent intent) {
        n_onNewIntent(intent);
    }

    @Override // androidx.appcompat.app.AppCompatActivity, androidx.fragment.app.FragmentActivity, android.app.Activity
    public void onStop() {
        n_onStop();
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

package crc6468b6408a11370c2f;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class WebAuthenticatorIntermediateActivity extends Activity implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onCreate(Bundle bundle);

    private native void n_onNewIntent(Intent intent);

    private native void n_onResume();

    private native void n_onSaveInstanceState(Bundle bundle);

    public WebAuthenticatorIntermediateActivity() {
        if (getClass() == WebAuthenticatorIntermediateActivity.class) {
            TypeManager.Activate("Microsoft.Maui.Authentication.WebAuthenticatorIntermediateActivity, Microsoft.Maui.Essentials", "", this, new Object[0]);
        }
    }

    @Override // android.app.Activity
    public void onCreate(Bundle bundle) {
        n_onCreate(bundle);
    }

    @Override // android.app.Activity
    public void onResume() {
        n_onResume();
    }

    @Override // android.app.Activity
    public void onNewIntent(Intent intent) {
        n_onNewIntent(intent);
    }

    @Override // android.app.Activity
    public void onSaveInstanceState(Bundle bundle) {
        n_onSaveInstanceState(bundle);
    }

    @Override // mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}

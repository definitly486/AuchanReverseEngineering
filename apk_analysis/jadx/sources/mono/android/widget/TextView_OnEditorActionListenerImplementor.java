package mono.android.widget;

import android.view.KeyEvent;
import android.widget.TextView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class TextView_OnEditorActionListenerImplementor implements IGCUserPeer, TextView.OnEditorActionListener {
    private ArrayList refList;

    private native boolean n_onEditorAction(TextView textView, int i, KeyEvent keyEvent);

    public TextView_OnEditorActionListenerImplementor() {
        if (getClass() == TextView_OnEditorActionListenerImplementor.class) {
            TypeManager.Activate("Android.Widget.TextView+IOnEditorActionListenerImplementor, Mono.Android", "", this, new Object[0]);
        }
    }

    @Override // android.widget.TextView.OnEditorActionListener
    public boolean onEditorAction(TextView textView, int i, KeyEvent keyEvent) {
        return n_onEditorAction(textView, i, keyEvent);
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

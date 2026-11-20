package mono.android.widget;

import android.widget.RadioGroup;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class RadioGroup_OnCheckedChangeListenerImplementor implements IGCUserPeer, RadioGroup.OnCheckedChangeListener {
    private ArrayList refList;

    private native void n_onCheckedChanged(RadioGroup radioGroup, int i);

    public RadioGroup_OnCheckedChangeListenerImplementor() {
        if (getClass() == RadioGroup_OnCheckedChangeListenerImplementor.class) {
            TypeManager.Activate("Android.Widget.RadioGroup+IOnCheckedChangeListenerImplementor, Mono.Android", "", this, new Object[0]);
        }
    }

    @Override // android.widget.RadioGroup.OnCheckedChangeListener
    public void onCheckedChanged(RadioGroup radioGroup, int i) {
        n_onCheckedChanged(radioGroup, i);
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

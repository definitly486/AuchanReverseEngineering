package mono.com.redmadrobot.inputmask;

import com.redmadrobot.inputmask.MaskedTextChangedListener;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class MaskedTextChangedListener_ValueListenerImplementor implements IGCUserPeer, MaskedTextChangedListener.ValueListener {
    private ArrayList refList;

    private native void n_onTextChanged(boolean z, String str, String str2);

    public MaskedTextChangedListener_ValueListenerImplementor() {
        if (getClass() == MaskedTextChangedListener_ValueListenerImplementor.class) {
            TypeManager.Activate("InputMask.MaskedTextChangedListener+IValueListenerImplementor, Xamarin.Bindings.Input-Mask-Android", "", this, new Object[0]);
        }
    }

    @Override // com.redmadrobot.inputmask.MaskedTextChangedListener.ValueListener
    public void onTextChanged(boolean z, String str, String str2) {
        n_onTextChanged(z, str, str2);
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

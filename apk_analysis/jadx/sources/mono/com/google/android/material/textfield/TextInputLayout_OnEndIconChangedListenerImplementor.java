package mono.com.google.android.material.textfield;

import com.google.android.material.textfield.TextInputLayout;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class TextInputLayout_OnEndIconChangedListenerImplementor implements IGCUserPeer, TextInputLayout.OnEndIconChangedListener {
    private ArrayList refList;

    private native void n_onEndIconChanged(TextInputLayout textInputLayout, int i);

    public TextInputLayout_OnEndIconChangedListenerImplementor() {
        if (getClass() == TextInputLayout_OnEndIconChangedListenerImplementor.class) {
            TypeManager.Activate("Google.Android.Material.TextField.TextInputLayout+IOnEndIconChangedListenerImplementor, Xamarin.Google.Android.Material", "", this, new Object[0]);
        }
    }

    @Override // com.google.android.material.textfield.TextInputLayout.OnEndIconChangedListener
    public void onEndIconChanged(TextInputLayout textInputLayout, int i) {
        n_onEndIconChanged(textInputLayout, i);
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

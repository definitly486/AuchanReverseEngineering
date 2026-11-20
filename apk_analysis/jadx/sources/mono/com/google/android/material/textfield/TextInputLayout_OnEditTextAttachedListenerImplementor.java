package mono.com.google.android.material.textfield;

import com.google.android.material.textfield.TextInputLayout;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class TextInputLayout_OnEditTextAttachedListenerImplementor implements IGCUserPeer, TextInputLayout.OnEditTextAttachedListener {
    private ArrayList refList;

    private native void n_onEditTextAttached(TextInputLayout textInputLayout);

    public TextInputLayout_OnEditTextAttachedListenerImplementor() {
        if (getClass() == TextInputLayout_OnEditTextAttachedListenerImplementor.class) {
            TypeManager.Activate("Google.Android.Material.TextField.TextInputLayout+IOnEditTextAttachedListenerImplementor, Xamarin.Google.Android.Material", "", this, new Object[0]);
        }
    }

    @Override // com.google.android.material.textfield.TextInputLayout.OnEditTextAttachedListener
    public void onEditTextAttached(TextInputLayout textInputLayout) {
        n_onEditTextAttached(textInputLayout);
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

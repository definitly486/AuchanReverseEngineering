package mono.com.google.android.material.card;

import com.google.android.material.card.MaterialCardView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class MaterialCardView_OnCheckedChangeListenerImplementor implements IGCUserPeer, MaterialCardView.OnCheckedChangeListener {
    private ArrayList refList;

    private native void n_onCheckedChanged(MaterialCardView materialCardView, boolean z);

    public MaterialCardView_OnCheckedChangeListenerImplementor() {
        if (getClass() == MaterialCardView_OnCheckedChangeListenerImplementor.class) {
            TypeManager.Activate("Google.Android.Material.Card.MaterialCardView+IOnCheckedChangeListenerImplementor, Xamarin.Google.Android.Material", "", this, new Object[0]);
        }
    }

    @Override // com.google.android.material.card.MaterialCardView.OnCheckedChangeListener
    public void onCheckedChanged(MaterialCardView materialCardView, boolean z) {
        n_onCheckedChanged(materialCardView, z);
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

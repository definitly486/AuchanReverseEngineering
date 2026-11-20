package crc6433eabb2f1deddbd5;

import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class StoreReviewImplementation implements IGCUserPeer, OnCompleteListener {
    private ArrayList refList;

    private native void n_onComplete(Task task);

    public StoreReviewImplementation() {
        if (getClass() == StoreReviewImplementation.class) {
            TypeManager.Activate("Plugin.StoreReview.StoreReviewImplementation, Plugin.StoreReview", "", this, new Object[0]);
        }
    }

    @Override // com.google.android.gms.tasks.OnCompleteListener
    public void onComplete(Task task) {
        n_onComplete(task);
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

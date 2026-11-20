package crc6459efab142bb48047;

import androidx.recyclerview.widget.RecyclerView;
import crc64f03248cb510113f2.ObservableRecyclerAdapter_2;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class EndlessRecyclerAdapter_1 extends ObservableRecyclerAdapter_2 implements IGCUserPeer {
    private ArrayList refList;

    private native int n_getItemCount();

    private native void n_onAttachedToRecyclerView(RecyclerView recyclerView);

    private native void n_onBindViewHolder(RecyclerView.ViewHolder viewHolder, int i);

    public EndlessRecyclerAdapter_1() {
        if (getClass() == EndlessRecyclerAdapter_1.class) {
            TypeManager.Activate("Auchan.Android.Common.UiUtils.EndlessRecyclerAdapter`1, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // crc64f03248cb510113f2.ObservableRecyclerAdapter_2, androidx.recyclerview.widget.RecyclerView.Adapter
    public int getItemCount() {
        return n_getItemCount();
    }

    @Override // crc64f03248cb510113f2.ObservableRecyclerAdapter_2, androidx.recyclerview.widget.RecyclerView.Adapter
    public void onAttachedToRecyclerView(RecyclerView recyclerView) {
        n_onAttachedToRecyclerView(recyclerView);
    }

    @Override // crc64f03248cb510113f2.ObservableRecyclerAdapter_2, androidx.recyclerview.widget.RecyclerView.Adapter
    public void onBindViewHolder(RecyclerView.ViewHolder viewHolder, int i) {
        n_onBindViewHolder(viewHolder, i);
    }

    @Override // crc64f03248cb510113f2.ObservableRecyclerAdapter_2, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64f03248cb510113f2.ObservableRecyclerAdapter_2, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}

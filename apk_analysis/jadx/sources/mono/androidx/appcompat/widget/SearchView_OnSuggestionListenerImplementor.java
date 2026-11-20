package mono.androidx.appcompat.widget;

import androidx.appcompat.widget.SearchView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class SearchView_OnSuggestionListenerImplementor implements IGCUserPeer, SearchView.OnSuggestionListener {
    private ArrayList refList;

    private native boolean n_onSuggestionClick(int i);

    private native boolean n_onSuggestionSelect(int i);

    public SearchView_OnSuggestionListenerImplementor() {
        if (getClass() == SearchView_OnSuggestionListenerImplementor.class) {
            TypeManager.Activate("AndroidX.AppCompat.Widget.SearchView+IOnSuggestionListenerImplementor, Xamarin.AndroidX.AppCompat", "", this, new Object[0]);
        }
    }

    @Override // androidx.appcompat.widget.SearchView.OnSuggestionListener
    public boolean onSuggestionClick(int i) {
        return n_onSuggestionClick(i);
    }

    @Override // androidx.appcompat.widget.SearchView.OnSuggestionListener
    public boolean onSuggestionSelect(int i) {
        return n_onSuggestionSelect(i);
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

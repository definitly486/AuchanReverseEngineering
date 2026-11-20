package crc642fccddcc0800cb0f;

import android.os.Bundle;
import android.view.View;
import com.yandex.mapkit.geometry.Point;
import com.yandex.mapkit.map.MapObject;
import com.yandex.mapkit.map.MapObjectTapListener;
import crc64f03248cb510113f2.BaseToolbarFragment_1;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class StoresFragment extends BaseToolbarFragment_1 implements IGCUserPeer, MapObjectTapListener {
    private ArrayList refList;

    private native void n_onCreate(Bundle bundle);

    private native void n_onHiddenChanged(boolean z);

    private native boolean n_onMapObjectTap(MapObject mapObject, Point point);

    private native void n_onStart();

    private native void n_onStop();

    private native void n_onViewCreated(View view, Bundle bundle);

    public StoresFragment() {
        if (getClass() == StoresFragment.class) {
            TypeManager.Activate("Auchan.Android.Profile.Stores.StoresFragment, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public StoresFragment(int i) {
        super(i);
        if (getClass() == StoresFragment.class) {
            TypeManager.Activate("Auchan.Android.Profile.Stores.StoresFragment, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // crc64f03248cb510113f2.BaseFragment_1, androidx.fragment.app.Fragment
    public void onCreate(Bundle bundle) {
        n_onCreate(bundle);
    }

    @Override // androidx.fragment.app.Fragment
    public void onViewCreated(View view, Bundle bundle) {
        n_onViewCreated(view, bundle);
    }

    @Override // crc64f03248cb510113f2.BaseFragment_1, androidx.fragment.app.Fragment
    public void onStart() {
        n_onStart();
    }

    @Override // crc64f03248cb510113f2.BaseFragment_1, androidx.fragment.app.Fragment
    public void onStop() {
        n_onStop();
    }

    @Override // crc64f03248cb510113f2.BaseFragment_1, androidx.fragment.app.Fragment
    public void onHiddenChanged(boolean z) {
        n_onHiddenChanged(z);
    }

    @Override // com.yandex.mapkit.map.MapObjectTapListener
    public boolean onMapObjectTap(MapObject mapObject, Point point) {
        return n_onMapObjectTap(mapObject, point);
    }

    @Override // crc64f03248cb510113f2.BaseToolbarFragment_1, crc64f03248cb510113f2.BaseFragment_1, crc64f03248cb510113f2.BaseFragmentWithViewModel, crc64f03248cb510113f2.BaseFragment, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64f03248cb510113f2.BaseToolbarFragment_1, crc64f03248cb510113f2.BaseFragment_1, crc64f03248cb510113f2.BaseFragmentWithViewModel, crc64f03248cb510113f2.BaseFragment, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}

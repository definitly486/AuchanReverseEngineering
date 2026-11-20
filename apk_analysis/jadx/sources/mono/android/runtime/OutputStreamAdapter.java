package mono.android.runtime;

import java.io.OutputStream;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class OutputStreamAdapter extends OutputStream implements IGCUserPeer {
    private ArrayList refList;

    private native void n_close();

    private native void n_flush();

    private native void n_write(int i);

    private native void n_write(byte[] bArr);

    private native void n_write(byte[] bArr, int i, int i2);

    public OutputStreamAdapter() {
        if (getClass() == OutputStreamAdapter.class) {
            TypeManager.Activate("Android.Runtime.OutputStreamAdapter, Mono.Android", "System.IO.Stream, System.Private.CoreLib", this, new Object[0]);
        }
    }

    @Override // java.io.OutputStream, java.io.Closeable, java.lang.AutoCloseable
    public void close() {
        n_close();
    }

    @Override // java.io.OutputStream, java.io.Flushable
    public void flush() {
        n_flush();
    }

    @Override // java.io.OutputStream
    public void write(byte[] bArr) {
        n_write(bArr);
    }

    @Override // java.io.OutputStream
    public void write(byte[] bArr, int i, int i2) {
        n_write(bArr, i, i2);
    }

    @Override // java.io.OutputStream
    public void write(int i) {
        n_write(i);
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

package mono.android.runtime;

import java.io.InputStream;
import java.util.ArrayList;
import mono.android.IGCUserPeer;

/* JADX INFO: loaded from: classes3.dex */
public class InputStreamAdapter extends InputStream implements IGCUserPeer {
    private ArrayList refList;

    private native void n_close();

    private native int n_read();

    private native int n_read(byte[] bArr);

    private native int n_read(byte[] bArr, int i, int i2);

    @Override // java.io.InputStream, java.io.Closeable, java.lang.AutoCloseable
    public void close() {
        n_close();
    }

    @Override // java.io.InputStream
    public int read() {
        return n_read();
    }

    @Override // java.io.InputStream
    public int read(byte[] bArr) {
        return n_read(bArr);
    }

    @Override // java.io.InputStream
    public int read(byte[] bArr, int i, int i2) {
        return n_read(bArr, i, i2);
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

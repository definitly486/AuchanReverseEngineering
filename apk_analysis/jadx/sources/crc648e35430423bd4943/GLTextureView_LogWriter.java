package crc648e35430423bd4943;

import java.io.Writer;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class GLTextureView_LogWriter extends Writer implements IGCUserPeer {
    private ArrayList refList;

    private native void n_close();

    private native void n_flush();

    private native void n_write(char[] cArr, int i, int i2);

    public GLTextureView_LogWriter() {
        if (getClass() == GLTextureView_LogWriter.class) {
            TypeManager.Activate("SkiaSharp.Views.Android.GLTextureView+LogWriter, SkiaSharp.Views.Android", "", this, new Object[0]);
        }
    }

    @Override // java.io.Writer, java.io.Closeable, java.lang.AutoCloseable
    public void close() {
        n_close();
    }

    @Override // java.io.Writer, java.io.Flushable
    public void flush() {
        n_flush();
    }

    @Override // java.io.Writer
    public void write(char[] cArr, int i, int i2) {
        n_write(cArr, i, i2);
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

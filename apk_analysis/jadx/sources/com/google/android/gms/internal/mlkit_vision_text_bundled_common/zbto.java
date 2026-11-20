package com.google.android.gms.internal.mlkit_vision_text_bundled_common;

import okhttp3.internal.http2.Settings;

/* JADX INFO: compiled from: com.google.mlkit:text-recognition-bundled-common@@17.0.0 */
/* JADX INFO: loaded from: classes2.dex */
final class zbto {
    private final Object zba;
    private final int zbb;

    zbto(Object obj, int i) {
        this.zba = obj;
        this.zbb = i;
    }

    public final boolean equals(Object obj) {
        if (!(obj instanceof zbto)) {
            return false;
        }
        zbto zbtoVar = (zbto) obj;
        return this.zba == zbtoVar.zba && this.zbb == zbtoVar.zbb;
    }

    public final int hashCode() {
        return (System.identityHashCode(this.zba) * Settings.DEFAULT_INITIAL_WINDOW_SIZE) + this.zbb;
    }
}

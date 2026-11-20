package com.google.android.gms.internal.mlkit_vision_barcode_bundled;

import okhttp3.internal.http2.Settings;

/* JADX INFO: compiled from: com.google.mlkit:barcode-scanning@@17.3.0 */
/* JADX INFO: loaded from: classes.dex */
final class zzdr {
    private final Object zza;
    private final int zzb;

    zzdr(Object obj, int i) {
        this.zza = obj;
        this.zzb = i;
    }

    public final boolean equals(Object obj) {
        if (!(obj instanceof zzdr)) {
            return false;
        }
        zzdr zzdrVar = (zzdr) obj;
        return this.zza == zzdrVar.zza && this.zzb == zzdrVar.zzb;
    }

    public final int hashCode() {
        return (System.identityHashCode(this.zza) * Settings.DEFAULT_INITIAL_WINDOW_SIZE) + this.zzb;
    }
}

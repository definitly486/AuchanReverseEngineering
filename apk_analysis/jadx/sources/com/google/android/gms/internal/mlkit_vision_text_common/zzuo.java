package com.google.android.gms.internal.mlkit_vision_text_common;

/* JADX INFO: compiled from: com.google.android.gms:play-services-mlkit-text-recognition-common@@19.1.0 */
/* JADX INFO: loaded from: classes2.dex */
public final class zzuo {
    private static zzuo zza;

    private zzuo() {
    }

    public static synchronized zzuo zza() {
        try {
            if (zza == null) {
                zza = new zzuo();
            }
        } catch (Throwable th) {
            throw th;
        }
        return zza;
    }
}

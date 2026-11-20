package com.google.android.gms.common.internal;

import android.os.IBinder;

/* JADX INFO: compiled from: com.google.android.gms:play-services-basement@@18.7.1 */
/* JADX INFO: loaded from: classes.dex */
public final class zzu extends com.google.android.gms.internal.common.zza implements ICancelToken {
    zzu(IBinder iBinder) {
        super(iBinder, "com.google.android.gms.common.internal.ICancelToken");
    }

    @Override // com.google.android.gms.common.internal.ICancelToken
    public final void cancel() {
        zzC(2, zza());
    }
}

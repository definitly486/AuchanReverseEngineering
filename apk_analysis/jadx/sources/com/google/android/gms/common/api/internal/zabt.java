package com.google.android.gms.common.api.internal;

import android.os.IBinder;
import com.google.android.gms.common.api.Status;

/* JADX INFO: compiled from: com.google.android.gms:play-services-base@@18.7.2 */
/* JADX INFO: loaded from: classes.dex */
public final class zabt extends com.google.android.gms.internal.base.zaa implements IStatusCallback {
    zabt(IBinder iBinder) {
        super(iBinder, "com.google.android.gms.common.api.internal.IStatusCallback");
    }

    @Override // com.google.android.gms.common.api.internal.IStatusCallback
    public final void onResult(Status status) {
        throw null;
    }
}

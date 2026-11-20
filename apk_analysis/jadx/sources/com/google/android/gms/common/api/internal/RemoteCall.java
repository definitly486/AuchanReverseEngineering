package com.google.android.gms.common.api.internal;

import com.google.android.gms.common.annotation.KeepForSdk;

/* JADX INFO: compiled from: com.google.android.gms:play-services-base@@18.7.2 */
/* JADX INFO: loaded from: classes.dex */
@KeepForSdk
public interface RemoteCall<T, U> {
    @KeepForSdk
    void accept(T t, U u);
}

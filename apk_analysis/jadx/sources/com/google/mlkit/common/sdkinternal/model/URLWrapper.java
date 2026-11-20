package com.google.mlkit.common.sdkinternal.model;

import com.google.android.gms.common.annotation.KeepForSdk;
import java.net.URL;
import java.net.URLConnection;

/* JADX INFO: compiled from: com.google.mlkit:common@@18.11.0 */
/* JADX INFO: loaded from: classes3.dex */
@KeepForSdk
public class URLWrapper {
    private final URL zza;

    @KeepForSdk
    public URLWrapper(String str) {
        this.zza = new URL(str);
    }

    @KeepForSdk
    public URLConnection openConnection() {
        return this.zza.openConnection();
    }
}

package com.google.mlkit.common.sdkinternal.model;

import com.google.android.gms.common.annotation.KeepForSdk;
import java.nio.MappedByteBuffer;

/* JADX INFO: compiled from: com.google.mlkit:common@@18.11.0 */
/* JADX INFO: loaded from: classes3.dex */
@KeepForSdk
public interface RemoteModelLoaderHelper {
    @KeepForSdk
    MappedByteBuffer loadModelAtPath(String str);
}

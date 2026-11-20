package com.google.mlkit.common.sdkinternal.model;

import com.google.android.gms.common.annotation.KeepForSdk;
import java.io.File;

/* JADX INFO: compiled from: com.google.mlkit:common@@18.11.0 */
/* JADX INFO: loaded from: classes3.dex */
@KeepForSdk
public interface RemoteModelFileMover {
    @KeepForSdk
    File getModelFileDestination();

    @KeepForSdk
    File moveAllFilesFromPrivateTempToPrivateDestination(File file);
}

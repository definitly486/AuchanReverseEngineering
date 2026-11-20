package com.google.mlkit.common.sdkinternal.model;

import com.google.android.gms.common.annotation.KeepForSdk;
import com.google.mlkit.common.model.RemoteModel;
import com.google.mlkit.common.sdkinternal.ModelInfo;

/* JADX INFO: compiled from: com.google.mlkit:common@@18.11.0 */
/* JADX INFO: loaded from: classes3.dex */
@KeepForSdk
public interface ModelInfoRetrieverInterop {
    @KeepForSdk
    ModelInfo retrieveRemoteModelInfo(RemoteModel remoteModel);
}

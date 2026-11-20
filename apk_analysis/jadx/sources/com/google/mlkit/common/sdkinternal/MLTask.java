package com.google.mlkit.common.sdkinternal;

import com.google.android.gms.common.annotation.KeepForSdk;
import com.google.mlkit.common.sdkinternal.MLTaskInput;

/* JADX INFO: compiled from: com.google.mlkit:common@@18.11.0 */
/* JADX INFO: loaded from: classes3.dex */
@KeepForSdk
public abstract class MLTask<T, S extends MLTaskInput> extends ModelResource {
    public MLTask() {
    }

    @KeepForSdk
    public abstract T run(S s);

    @KeepForSdk
    protected MLTask(TaskQueue taskQueue) {
        super(taskQueue);
    }
}

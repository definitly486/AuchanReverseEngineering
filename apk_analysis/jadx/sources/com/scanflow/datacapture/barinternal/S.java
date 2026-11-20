package com.scanflow.datacapture.barinternal;

import com.scanflow.datacapture.barcode.analytics.UploadBackgroundWorker;
import java.io.File;
import kotlin.jvm.internal.Intrinsics;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

/* JADX INFO: loaded from: classes3.dex */
public final class S implements Callback {
    public final /* synthetic */ File a;
    public final /* synthetic */ UploadBackgroundWorker b;

    public S(File file, UploadBackgroundWorker uploadBackgroundWorker) {
        this.a = file;
        this.b = uploadBackgroundWorker;
    }

    @Override // retrofit2.Callback
    public final void onFailure(Call call, Throwable t) {
        Intrinsics.checkNotNullParameter(call, "call");
        Intrinsics.checkNotNullParameter(t, "t");
        this.a.delete();
    }

    @Override // retrofit2.Callback
    public final void onResponse(Call call, Response response) {
        Intrinsics.checkNotNullParameter(call, "call");
        Intrinsics.checkNotNullParameter(response, "response");
        this.a.delete();
        if (response.code() == 200) {
            UploadBackgroundWorker uploadBackgroundWorker = this.b;
            if (response.body() != null) {
                throw new ClassCastException();
            }
            uploadBackgroundWorker.getClass();
        }
    }
}

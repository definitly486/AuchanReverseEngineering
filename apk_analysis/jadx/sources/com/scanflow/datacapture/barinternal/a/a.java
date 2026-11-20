package com.scanflow.datacapture.barinternal.a;

import com.scanflow.datacapture.analytics.BackgroundWorker;
import java.io.File;
import kotlin.jvm.internal.Intrinsics;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

/* JADX INFO: loaded from: classes.dex */
public final class a implements Callback {
    public final /* synthetic */ BackgroundWorker a;
    public final /* synthetic */ File b;

    public a(BackgroundWorker backgroundWorker, File file) {
        this.a = backgroundWorker;
        this.b = file;
    }

    @Override // retrofit2.Callback
    public final void onFailure(Call call, Throwable t) {
        Intrinsics.checkNotNullParameter(call, "call");
        Intrinsics.checkNotNullParameter(t, "t");
        this.b.delete();
    }

    @Override // retrofit2.Callback
    public final void onResponse(Call call, Response response) {
        Intrinsics.checkNotNullParameter(call, "call");
        Intrinsics.checkNotNullParameter(response, "response");
        BackgroundWorker backgroundWorker = this.a;
        a$$ExternalSyntheticThrowCCEIfNotNull0.m(response.body());
        backgroundWorker.getClass();
        if (response.code() == 200) {
            this.b.delete();
        }
    }
}

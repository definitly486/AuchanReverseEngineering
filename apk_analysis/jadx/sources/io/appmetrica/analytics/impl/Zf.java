package io.appmetrica.analytics.impl;

import android.annotation.TargetApi;
import android.app.Application;
import io.appmetrica.analytics.coreapi.internal.annotations.DoNotInline;

/* JADX INFO: loaded from: classes3.dex */
@DoNotInline
@TargetApi(28)
public final class Zf implements Xf {
    @Override // io.appmetrica.analytics.impl.Xf
    public String a() {
        return Application.getProcessName();
    }
}

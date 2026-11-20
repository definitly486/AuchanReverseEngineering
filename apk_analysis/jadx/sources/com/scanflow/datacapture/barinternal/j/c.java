package com.scanflow.datacapture.barinternal.j;

import android.content.Context;
import android.net.ConnectivityManager;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class c {
    public final b a;
    public final a b;
    public final ConnectivityManager c;

    public c(Context context) {
        b factory = new b();
        a callback = new a();
        Intrinsics.checkNotNullParameter(context, "context");
        Intrinsics.checkNotNullParameter(factory, "factory");
        Intrinsics.checkNotNullParameter(callback, "callback");
        this.a = factory;
        this.b = callback;
        Object systemService = context.getSystemService("connectivity");
        Intrinsics.checkNotNull(systemService, "null cannot be cast to non-null type android.net.ConnectivityManager");
        this.c = (ConnectivityManager) systemService;
    }
}

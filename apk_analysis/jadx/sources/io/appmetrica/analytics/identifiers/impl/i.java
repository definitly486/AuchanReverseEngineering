package io.appmetrica.analytics.identifiers.impl;

import android.os.IBinder;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Lambda;

/* JADX INFO: loaded from: classes3.dex */
public final class i extends Lambda implements Function1 {
    public static final i a = new i();

    public i() {
        super(1);
    }

    @Override // kotlin.jvm.functions.Function1
    public final Object invoke(Object obj) {
        return n.a((IBinder) obj);
    }
}

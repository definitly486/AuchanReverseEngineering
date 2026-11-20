package io.appmetrica.analytics.impl;

import android.annotation.SuppressLint;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import io.appmetrica.analytics.coreapi.internal.annotations.DoNotInline;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
@DoNotInline
public final class Yf implements Xf {
    private volatile String a;

    @SuppressLint({"PrivateApi"})
    private final String b() {
        try {
            Class<?> cls = Class.forName("android.app.ActivityThread");
            Object objInvoke = cls.getMethod("getProcessName", null).invoke(cls.getMethod("currentActivityThread", null).invoke(null, null), null);
            Intrinsics.checkNotNull(objInvoke, "null cannot be cast to non-null type kotlin.String");
            return (String) objInvoke;
        } catch (Throwable th) {
            throw new RuntimeException(th);
        }
    }

    @Override // io.appmetrica.analytics.impl.Xf
    public String a() {
        if (this.a != null) {
            return this.a;
        }
        synchronized (this) {
            try {
                if (this.a == null) {
                    this.a = b();
                }
                Unit unit = Unit.INSTANCE;
            } catch (Throwable th) {
                throw th;
            }
        }
        return this.a;
    }
}

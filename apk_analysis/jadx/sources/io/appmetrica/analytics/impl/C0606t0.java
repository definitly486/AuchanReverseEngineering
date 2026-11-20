package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.coreutils.internal.AndroidUtils;
import io.appmetrica.analytics.logger.appmetrica.internal.ImportantLogger;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.t0, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0606t0 {
    public final C0526po a;
    public volatile Boolean b;
    public InterfaceC0125ab c;
    public InterfaceC0151bb d;

    public C0606t0() {
        this(new C0526po());
    }

    public final synchronized InterfaceC0125ab a(Context context, C0325i4 c0325i4) {
        try {
            if (this.c == null) {
                if (a(context)) {
                    this.c = new C0710x0();
                } else {
                    this.c = new C0580s0(context, c0325i4);
                }
            }
        } catch (Throwable th) {
            throw th;
        }
        return this.c;
    }

    public C0606t0(C0526po c0526po) {
        this.a = c0526po;
    }

    public final boolean a(Context context) {
        Boolean boolValueOf = this.b;
        if (boolValueOf == null) {
            synchronized (this) {
                try {
                    boolValueOf = this.b;
                    if (boolValueOf == null) {
                        this.a.getClass();
                        boolean z = AndroidUtils.isApiAchieved(24) && !C0526po.a(context);
                        boolValueOf = Boolean.valueOf(z);
                        this.b = boolValueOf;
                        if (z) {
                            ImportantLogger.INSTANCE.info("AppMetrica", "User is locked. So use stubs. Events will not be sent.", new Object[0]);
                        }
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        return boolValueOf.booleanValue();
    }
}

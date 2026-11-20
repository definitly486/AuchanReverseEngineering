package io.appmetrica.analytics.impl;

import android.app.Activity;
import android.content.Intent;
import io.appmetrica.analytics.coreapi.internal.backport.FunctionWithThrowable;
import io.appmetrica.analytics.coreutils.internal.system.SystemServiceUtils;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.wn, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0707wn {
    public final B0 a;
    public final ap b;
    public final C0475o c;
    public final C0550ql d;
    public final U5 e;
    public final C0772za f;

    public C0707wn(B0 b0, ap apVar, C0475o c0475o, C0550ql c0550ql, U5 u5, C0772za c0772za) {
        this.a = b0;
        this.b = apVar;
        this.c = c0475o;
        this.d = c0550ql;
        this.e = u5;
        this.f = c0772za;
    }

    public static Intent a(Activity activity) {
        return (Intent) SystemServiceUtils.accessSystemServiceSafely(activity, "getting intent", "activity", new FunctionWithThrowable() { // from class: io.appmetrica.analytics.impl.wn$$ExternalSyntheticLambda0
            @Override // io.appmetrica.analytics.coreapi.internal.backport.FunctionWithThrowable
            public final Object apply(Object obj) {
                return C0707wn.b((Activity) obj);
            }
        });
    }

    public static final Intent b(Activity activity) {
        return activity.getIntent();
    }

    public C0707wn(B0 b0, ap apVar) {
        this(b0, apVar, C0584s4.l().a(), C0584s4.l().o(), C0584s4.l().h(), C0584s4.l().k());
    }
}

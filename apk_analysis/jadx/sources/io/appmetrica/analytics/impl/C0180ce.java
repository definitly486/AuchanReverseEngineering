package io.appmetrica.analytics.impl;

import android.content.Context;
import kotlin.jvm.functions.Function1;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ce, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0180ce {
    public final Function1 a;

    public C0180ce(C0309he c0309he) {
        this.a = c0309he;
    }

    public final C0206de a(Context context, C0157bh c0157bh) {
        return new C0206de(context, c0157bh, this.a, new InterfaceC0438me() { // from class: io.appmetrica.analytics.impl.ce$$ExternalSyntheticLambda0
            @Override // io.appmetrica.analytics.impl.InterfaceC0438me
            public final InterfaceC0653ul a(I0 i0) {
                return C0180ce.a(i0);
            }
        }, EnumC0721xb.EVENT_TYPE_CURRENT_SESSION_NATIVE_CRASH_PROTOBUF, "actual", new G6());
    }

    public final C0206de b(Context context, C0157bh c0157bh) {
        return new C0206de(context, c0157bh, this.a, new InterfaceC0438me() { // from class: io.appmetrica.analytics.impl.ce$$ExternalSyntheticLambda1
            @Override // io.appmetrica.analytics.impl.InterfaceC0438me
            public final InterfaceC0653ul a(I0 i0) {
                return C0180ce.b(i0);
            }
        }, EnumC0721xb.EVENT_TYPE_PREV_SESSION_NATIVE_CRASH_PROTOBUF, "prev session", new G6());
    }

    public static final InterfaceC0653ul a(I0 i0) {
        return new C0128ae(i0.f.d);
    }

    public static final InterfaceC0653ul b(I0 i0) {
        return new Z();
    }
}

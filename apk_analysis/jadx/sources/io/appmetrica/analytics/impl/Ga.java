package io.appmetrica.analytics.impl;

import java.util.concurrent.TimeUnit;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class Ga implements InterfaceC0566rc {
    @Override // io.appmetrica.analytics.impl.InterfaceC0566rc
    public final C0615t9 a(C0769z7 c0769z7) {
        C0615t9 c0615t9 = null;
        if ((c0769z7 != null ? c0769z7.b : null) != null && c0769z7.c != null) {
            c0615t9 = new C0615t9();
            c0615t9.b = c0769z7.b.doubleValue();
            c0615t9.a = c0769z7.c.doubleValue();
            Integer num = c0769z7.d;
            if (num != null) {
                c0615t9.g = num.intValue();
            }
            Integer num2 = c0769z7.e;
            if (num2 != null) {
                c0615t9.e = num2.intValue();
            }
            Integer num3 = c0769z7.f;
            if (num3 != null) {
                c0615t9.d = num3.intValue();
            }
            Integer num4 = c0769z7.g;
            if (num4 != null) {
                c0615t9.f = num4.intValue();
            }
            Long l = c0769z7.h;
            if (l != null) {
                c0615t9.c = TimeUnit.MILLISECONDS.toSeconds(l.longValue());
            }
            String str = c0769z7.i;
            if (str != null) {
                if (Intrinsics.areEqual(str, "gps")) {
                    c0615t9.h = 1;
                } else if (Intrinsics.areEqual(str, "network")) {
                    c0615t9.h = 2;
                }
            }
            String str2 = c0769z7.j;
            if (str2 != null) {
                c0615t9.i = str2;
            }
        }
        return c0615t9;
    }
}

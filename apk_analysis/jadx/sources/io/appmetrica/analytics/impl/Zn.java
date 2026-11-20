package io.appmetrica.analytics.impl;

import java.util.ArrayList;

/* JADX INFO: loaded from: classes3.dex */
public abstract class Zn {
    /* JADX WARN: Code duplicated, block: B:16:0x0041  */
    public static Yn a(Throwable th, int i, int i2) {
        StackTraceElement[] stackTrace;
        Yn ynA;
        String name = th.getClass().getName();
        String message = th.getMessage();
        try {
            stackTrace = th.getStackTrace();
        } catch (Throwable unused) {
            stackTrace = new StackTraceElement[0];
        }
        ArrayList arrayList = new ArrayList(stackTrace.length);
        for (StackTraceElement stackTraceElement : stackTrace) {
            arrayList.add(new Ul(stackTraceElement));
        }
        Throwable cause = th.getCause();
        ArrayList arrayList2 = null;
        if (cause == null) {
            ynA = null;
        } else {
            if (i2 >= i) {
                cause = null;
            }
            if (cause != null) {
                ynA = a(cause, 30, i2 + 1);
            } else {
                ynA = null;
            }
        }
        if (i2 < i) {
            Throwable[] suppressed = th.getSuppressed();
            arrayList2 = new ArrayList(suppressed.length);
            for (Throwable th2 : suppressed) {
                arrayList2.add(a(th2, 1, i2));
            }
        }
        return new Yn(name, message, arrayList, ynA, arrayList2);
    }
}

package io.appmetrica.analytics.impl;

import android.content.Context;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import java.util.HashMap;
import kotlin.jvm.internal.Intrinsics;
import kotlin.jvm.internal.Reflection;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.va, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0668va {
    public static volatile C0668va c;
    public final Context a;
    public final HashMap b = new HashMap();

    public C0668va(Context context) {
        this.a = context;
    }

    public static final C0668va a(Context context) {
        if (c == null) {
            synchronized (Reflection.getOrCreateKotlinClass(C0668va.class)) {
                try {
                    if (c == null) {
                        c = new C0668va(context);
                    }
                    Unit unit = Unit.INSTANCE;
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        C0668va c0668va = c;
        if (c0668va != null) {
            return c0668va;
        }
        Intrinsics.throwUninitializedPropertyAccessException("INSTANCE");
        return null;
    }

    public final synchronized R9 b(String str) {
        Object r9;
        try {
            HashMap map = this.b;
            r9 = map.get(str);
            if (r9 == null) {
                r9 = new R9(this.a, str);
                map.put(str, r9);
            }
        } catch (Throwable th) {
            throw th;
        }
        return (R9) r9;
    }

    public final synchronized void a(String str) {
        this.b.remove(str);
    }
}

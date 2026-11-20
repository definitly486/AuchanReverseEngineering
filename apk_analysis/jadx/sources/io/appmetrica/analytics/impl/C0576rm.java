package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.coreutils.internal.services.SafePackageManager;
import io.appmetrica.analytics.networktasks.internal.BaseRequestConfig;
import java.util.Map;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.rm, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0576rm extends AbstractC0172c6 {
    public final Q3 b;

    public C0576rm(Context context, String str) {
        this(context, str, new SafePackageManager(), Ka.k().f());
    }

    /* JADX WARN: Multi-variable type inference failed */
    @Override // io.appmetrica.analytics.impl.AbstractC0172c6, io.appmetrica.analytics.networktasks.internal.BaseRequestConfig.ComponentLoader, io.appmetrica.analytics.networktasks.internal.BaseRequestConfig.RequestConfigLoader
    /* JADX INFO: renamed from: b, reason: merged with bridge method [inline-methods] */
    public final C0602sm load(C0146b6 c0146b6) {
        C0602sm c0602sm = (C0602sm) super.load(c0146b6);
        C0706wm c0706wm = c0146b6.a;
        c0602sm.d = c0706wm.f;
        c0602sm.e = c0706wm.g;
        C0551qm c0551qm = (C0551qm) c0146b6.componentArguments;
        String str = c0551qm.a;
        if (str != null) {
            c0602sm.f = str;
            c0602sm.g = c0551qm.b;
        }
        Map<String, String> map = c0551qm.c;
        c0602sm.h = map;
        c0602sm.i = (I3) this.b.a(new I3(map, EnumC0406l8.d));
        C0551qm c0551qm2 = (C0551qm) c0146b6.componentArguments;
        c0602sm.k = c0551qm2.d;
        c0602sm.j = c0551qm2.e;
        C0706wm c0706wm2 = c0146b6.a;
        c0602sm.l = c0706wm2.p;
        c0602sm.m = c0706wm2.r;
        long j = c0706wm2.v;
        if (c0602sm.n == 0) {
            c0602sm.n = j;
        }
        return c0602sm;
    }

    @Override // io.appmetrica.analytics.networktasks.internal.BaseRequestConfig.ComponentLoader
    public final BaseRequestConfig createBlankConfig() {
        return new C0602sm();
    }

    public C0576rm(Context context, String str, SafePackageManager safePackageManager, Q3 q3) {
        super(context, str, safePackageManager);
        this.b = q3;
    }

    public final C0602sm a() {
        return new C0602sm();
    }
}

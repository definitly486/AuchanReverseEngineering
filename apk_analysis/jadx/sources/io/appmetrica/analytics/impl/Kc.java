package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.coreutils.internal.services.PackageManagerUtils;
import io.appmetrica.analytics.coreutils.internal.time.TimePassedChecker;
import io.appmetrica.analytics.internal.CounterConfigurationReporterType;

/* JADX INFO: loaded from: classes3.dex */
public final class Kc extends C0455n5 {
    public final W6 w;

    public Kc(Context context, C0706wm c0706wm, C0274g5 c0274g5, F4 f4, W6 w6, AbstractC0403l5 abstractC0403l5) {
        this(context, c0274g5, f4, new C0424m0(), new TimePassedChecker(), new Mc(context, c0274g5, f4, abstractC0403l5, c0706wm, new Gc(w6), Ka.k().w().d(), PackageManagerUtils.getAppVersionCodeInt(context), Ka.k().w(), Ka.k().l(), new Ac()), w6);
    }

    @Override // io.appmetrica.analytics.impl.C0455n5, io.appmetrica.analytics.impl.InterfaceC0383kb, io.appmetrica.analytics.impl.InterfaceC0203db
    public final synchronized void a(F4 f4) {
        super.a(f4);
        this.w.a(f4.i);
    }

    @Override // io.appmetrica.analytics.impl.C0455n5, io.appmetrica.analytics.impl.InterfaceC0203db
    public final CounterConfigurationReporterType b() {
        return CounterConfigurationReporterType.MAIN;
    }

    public Kc(Context context, C0274g5 c0274g5, F4 f4, C0424m0 c0424m0, TimePassedChecker timePassedChecker, Mc mc, W6 w6) {
        super(context, c0274g5, c0424m0, timePassedChecker, mc, f4);
        C0563r9 c0563r9K = k();
        c0563r9K.a(EnumC0721xb.EVENT_TYPE_REGULAR, new Qg(c0563r9K.a()));
        this.w = w6;
        Ka.k().x().onMainReporterCreated(new Mk(this, f4));
    }
}

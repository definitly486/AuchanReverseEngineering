package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.coreutils.internal.services.PackageManagerUtils;
import io.appmetrica.analytics.coreutils.internal.time.TimePassedChecker;
import io.appmetrica.analytics.internal.CounterConfigurationReporterType;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.kk, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0392kk extends C0455n5 {
    public C0392kk(Context context, C0706wm c0706wm, C0274g5 c0274g5, F4 f4, InterfaceC0649uh interfaceC0649uh, AbstractC0403l5 abstractC0403l5, C0248f5 c0248f5) {
        this(context, c0274g5, new C0424m0(), new TimePassedChecker(), new C0585s5(context, c0274g5, f4, abstractC0403l5, c0706wm, interfaceC0649uh, Ka.k().w().d(), PackageManagerUtils.getAppVersionCodeInt(context), Ka.k().l(), c0248f5), f4);
    }

    @Override // io.appmetrica.analytics.impl.C0455n5, io.appmetrica.analytics.impl.InterfaceC0203db
    public final CounterConfigurationReporterType b() {
        return CounterConfigurationReporterType.SELF_SDK;
    }

    public C0392kk(Context context, C0274g5 c0274g5, C0424m0 c0424m0, TimePassedChecker timePassedChecker, C0585s5 c0585s5, F4 f4) {
        super(context, c0274g5, c0424m0, timePassedChecker, c0585s5, f4);
    }
}

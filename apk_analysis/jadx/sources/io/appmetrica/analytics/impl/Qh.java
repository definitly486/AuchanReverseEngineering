package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.coreutils.internal.services.PackageManagerUtils;
import io.appmetrica.analytics.coreutils.internal.time.TimePassedChecker;

/* JADX INFO: loaded from: classes3.dex */
public final class Qh extends C0455n5 {
    public final String w;
    public final W6 x;

    public Qh(Context context, C0274g5 c0274g5, F4 f4, W6 w6, C0706wm c0706wm, AbstractC0403l5 abstractC0403l5, M9 m9) {
        this(context, c0274g5, new C0424m0(), new TimePassedChecker(), new C0585s5(context, c0274g5, f4, abstractC0403l5, c0706wm, new Lh(w6), Ka.k().w().d(), PackageManagerUtils.getAppVersionCodeInt(context), Ka.k().l(), m9), w6, f4);
    }

    @Override // io.appmetrica.analytics.impl.C0455n5, io.appmetrica.analytics.impl.InterfaceC0383kb, io.appmetrica.analytics.impl.InterfaceC0203db
    public final synchronized void a(F4 f4) {
        super.a(f4);
        this.x.a(this.w, f4.i);
    }

    public Qh(Context context, C0274g5 c0274g5, C0424m0 c0424m0, TimePassedChecker timePassedChecker, C0585s5 c0585s5, W6 w6, F4 f4) {
        super(context, c0274g5, c0424m0, timePassedChecker, c0585s5, f4);
        this.w = c0274g5.b();
        this.x = w6;
    }
}

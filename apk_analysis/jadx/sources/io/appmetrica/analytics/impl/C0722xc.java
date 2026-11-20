package io.appmetrica.analytics.impl;

import android.os.Bundle;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import io.appmetrica.analytics.coreutils.internal.services.FrameworkDetector;
import kotlin.jvm.functions.Function0;
import kotlin.jvm.internal.Lambda;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.xc, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0722xc extends Lambda implements Function0 {
    public final /* synthetic */ C0748yc a;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public C0722xc(C0748yc c0748yc) {
        super(0);
        this.a = c0748yc;
    }

    /* JADX WARN: Code duplicated, block: B:11:0x0039  */
    @Override // kotlin.jvm.functions.Function0
    public final Object invoke() {
        Pc c0258ff;
        C0748yc c0748yc = this.a;
        Qc qc = c0748yc.f;
        L9 l9 = c0748yc.b;
        Zg zg = c0748yc.a;
        F4 f4 = c0748yc.c;
        C0544qf c0544qf = c0748yc.d;
        qc.getClass();
        if (FrameworkDetector.isNative()) {
            C0305ha c0305haI = Ka.I.i();
            Bundle applicationMetaData = c0305haI.d.getApplicationMetaData(c0305haI.a);
            if (StringUtils.isNullOrEmpty(applicationMetaData != null ? applicationMetaData.getString("io.appmetrica.analytics.plugin_id") : null)) {
                c0258ff = new C0412le();
            } else {
                c0258ff = new C0258ff(l9, zg, f4, c0544qf);
            }
        } else {
            c0258ff = new C0258ff(l9, zg, f4, c0544qf);
        }
        return c0258ff.a();
    }
}

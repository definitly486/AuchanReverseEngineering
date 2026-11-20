package io.appmetrica.analytics.impl;

import android.content.Intent;
import io.appmetrica.analytics.coreapi.internal.backport.Consumer;
import io.appmetrica.analytics.coreapi.internal.servicecomponents.batteryinfo.BatteryInfo;
import io.appmetrica.analytics.coreapi.internal.servicecomponents.batteryinfo.ChargeType;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.d3, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0195d3 implements Consumer {
    public final /* synthetic */ C0220e3 a;

    public C0195d3(C0220e3 c0220e3) {
        this.a = c0220e3;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.backport.Consumer
    public final void consume(Object obj) {
        Intent intent = (Intent) obj;
        BatteryInfo batteryInfo = this.a.b;
        ChargeType chargeType = batteryInfo == null ? null : batteryInfo.chargeType;
        this.a.getClass();
        BatteryInfo batteryInfoA = C0220e3.a(intent);
        this.a.b = batteryInfoA;
        if (chargeType != batteryInfoA.chargeType) {
            this.a.a.execute(new C0169c3(this, batteryInfoA));
        }
    }
}

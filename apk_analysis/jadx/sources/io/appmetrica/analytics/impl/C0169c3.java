package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.servicecomponents.batteryinfo.BatteryInfo;
import io.appmetrica.analytics.coreapi.internal.servicecomponents.batteryinfo.ChargeType;
import io.appmetrica.analytics.coreapi.internal.servicecomponents.batteryinfo.ChargeTypeChangeListener;
import io.appmetrica.analytics.coreutils.internal.executors.SafeRunnable;
import java.util.ArrayList;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.c3, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0169c3 extends SafeRunnable {
    public final /* synthetic */ BatteryInfo a;
    public final /* synthetic */ C0195d3 b;

    public C0169c3(C0195d3 c0195d3, BatteryInfo batteryInfo) {
        this.b = c0195d3;
        this.a = batteryInfo;
    }

    @Override // io.appmetrica.analytics.coreutils.internal.executors.SafeRunnable
    public final void runSafety() {
        C0220e3 c0220e3 = this.b.a;
        ChargeType chargeType = this.a.chargeType;
        ChargeType chargeType2 = C0220e3.d;
        synchronized (c0220e3) {
            ArrayList arrayList = c0220e3.c;
            int size = arrayList.size();
            int i = 0;
            while (i < size) {
                Object obj = arrayList.get(i);
                i++;
                ((ChargeTypeChangeListener) obj).onChargeTypeChanged(chargeType);
            }
        }
    }
}

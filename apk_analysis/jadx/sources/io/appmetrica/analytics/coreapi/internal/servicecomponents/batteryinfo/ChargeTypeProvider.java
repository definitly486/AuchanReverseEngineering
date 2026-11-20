package io.appmetrica.analytics.coreapi.internal.servicecomponents.batteryinfo;

/* JADX INFO: loaded from: classes3.dex */
public interface ChargeTypeProvider {
    Integer getBatteryLevel();

    ChargeType getChargeType();

    void registerChargeTypeListener(ChargeTypeChangeListener chargeTypeChangeListener);
}

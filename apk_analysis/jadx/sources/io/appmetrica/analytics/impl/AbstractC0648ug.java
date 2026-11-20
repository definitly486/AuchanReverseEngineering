package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.services.telephony.CellularNetworkTypeExtractor;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ug, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public abstract /* synthetic */ class AbstractC0648ug {
    public static /* synthetic */ String a(int i) {
        if (i == 1) {
            return CellularNetworkTypeExtractor.UNKNOWN_NETWORK_TYPE_VALUE;
        }
        if (i == 2) {
            return "gpl";
        }
        if (i == 3) {
            return "hms-content-provider";
        }
        throw null;
    }

    public static /* synthetic */ String b(int i) {
        if (i == 1) {
            return "UNKNOWN";
        }
        if (i != 2) {
            return i != 3 ? "null" : "HMS";
        }
        return "GP";
    }
}

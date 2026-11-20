package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.servicecomponents.ServiceModuleCounterReport;

/* JADX INFO: loaded from: classes3.dex */
public final class Kk {
    public static C0249f6 a(ServiceModuleCounterReport serviceModuleCounterReport) {
        String value;
        C0249f6 c0249f6 = new C0249f6("", "", 0);
        c0249f6.d = serviceModuleCounterReport.getType();
        String name = serviceModuleCounterReport.getName();
        if (name != null) {
            c0249f6.a = name;
        }
        if (serviceModuleCounterReport.getValueBytes() == null && (value = serviceModuleCounterReport.getValue()) != null) {
            c0249f6.b = value;
        }
        byte[] valueBytes = serviceModuleCounterReport.getValueBytes();
        if (valueBytes != null) {
            c0249f6.setValueBytes(valueBytes);
        }
        return c0249f6;
    }
}

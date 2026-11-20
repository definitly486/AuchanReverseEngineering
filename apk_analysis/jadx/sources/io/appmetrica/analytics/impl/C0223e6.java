package io.appmetrica.analytics.impl;

import android.os.Bundle;
import android.os.Parcel;
import android.os.Parcelable;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import io.appmetrica.analytics.coreutils.internal.collection.CollectionUtils;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.e6, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0223e6 implements Parcelable.Creator {
    @Override // android.os.Parcelable.Creator
    public final Object createFromParcel(Parcel parcel) {
        G9 g9;
        Bundle bundle = parcel.readBundle(T6.class.getClassLoader());
        if (bundle.containsKey("CounterReport.Source")) {
            int i = bundle.getInt("CounterReport.Source");
            G9[] g9ArrValues = G9.values();
            int length = g9ArrValues.length;
            int i2 = 0;
            while (true) {
                if (i2 >= length) {
                    g9 = G9.NATIVE;
                    break;
                }
                g9 = g9ArrValues[i2];
                if (g9.a == i) {
                    break;
                }
                i2++;
            }
        } else {
            g9 = null;
        }
        C0249f6 c0249f6 = new C0249f6("", "", 0);
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        c0249f6.d = bundle.getInt("CounterReport.Type", -1);
        c0249f6.e = bundle.getInt("CounterReport.CustomType");
        c0249f6.b = StringUtils.ifIsNullToDef(bundle.getString("CounterReport.Value"), "");
        c0249f6.c = bundle.getString("CounterReport.Environment");
        c0249f6.a = bundle.getString("CounterReport.Event");
        c0249f6.f = C0249f6.a(bundle);
        c0249f6.g = bundle.getInt("CounterReport.TRUNCATED");
        c0249f6.h = bundle.getString("CounterReport.ProfileID");
        c0249f6.i = bundle.getLong("CounterReport.CreationElapsedRealtime");
        c0249f6.j = bundle.getLong("CounterReport.CreationTimestamp");
        c0249f6.k = Aa.a(Integer.valueOf(bundle.getInt("CounterReport.UniquenessStatus")));
        c0249f6.l = g9;
        c0249f6.m = bundle.getBundle("CounterReport.Payload");
        c0249f6.n = bundle.containsKey("CounterReport.AttributionIdChanged") ? Boolean.valueOf(bundle.getBoolean("CounterReport.AttributionIdChanged")) : null;
        c0249f6.o = bundle.containsKey("CounterReport.OpenId") ? Integer.valueOf(bundle.getInt("CounterReport.OpenId")) : null;
        c0249f6.p = CollectionUtils.bundleToMap(bundle.getBundle("CounterReport.Extras"));
        return c0249f6;
    }

    @Override // android.os.Parcelable.Creator
    public final Object[] newArray(int i) {
        return new C0249f6[i];
    }
}

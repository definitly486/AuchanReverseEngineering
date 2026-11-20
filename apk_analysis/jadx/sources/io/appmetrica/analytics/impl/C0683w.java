package io.appmetrica.analytics.impl;

import android.content.Context;
import android.os.Bundle;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.w, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0683w implements InterfaceC0709x {
    public final Context a;

    public C0683w(Context context) {
        this.a = context;
    }

    public final String a() {
        C0584s4 c0584s4L = C0584s4.l();
        Context context = this.a;
        C0305ha c0305ha = c0584s4L.u;
        if (c0305ha == null) {
            synchronized (c0584s4L) {
                try {
                    c0305ha = c0584s4L.u;
                    if (c0305ha == null) {
                        c0305ha = new C0305ha(context);
                        c0584s4L.u = c0305ha;
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        Bundle applicationMetaData = c0305ha.d.getApplicationMetaData(c0305ha.a);
        if (applicationMetaData != null) {
            return applicationMetaData.getString("io.appmetrica.analytics.plugin_supported_ad_revenue_sources");
        }
        return null;
    }
}

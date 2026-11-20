package io.appmetrica.analytics.impl;

import android.os.Bundle;
import io.appmetrica.analytics.coreutils.internal.services.FrameworkDetector;
import io.appmetrica.analytics.modulesapi.internal.client.adrevenue.AdRevenueConstants;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.atomic.AtomicBoolean;
import kotlin.jvm.internal.Intrinsics;
import org.json.JSONObject;

/* JADX INFO: loaded from: classes3.dex */
public final class Oc implements Z8 {
    public final Zg a;
    public final C0544qf b;
    public final String c = "activation_unlock_event_sending";
    public final AtomicBoolean d;

    public Oc(Zg zg, F4 f4, C0544qf c0544qf) {
        this.a = zg;
        this.b = c0544qf;
        this.d = new AtomicBoolean(c0544qf.a(false) || a(f4));
    }

    public final void a(String str) {
        try {
            C0263fk c0263fk = Dj.a;
            String str2 = this.c;
            JSONObject jSONObjectPut = new JSONObject().put(AdRevenueConstants.SOURCE_KEY, str).put("framework", FrameworkDetector.framework());
            C0305ha c0305haI = Ka.I.i();
            Bundle applicationMetaData = c0305haI.d.getApplicationMetaData(c0305haI.a);
            JSONObject jSONObjectPut2 = jSONObjectPut.put("appmetrica_plugin_id", applicationMetaData != null ? applicationMetaData.getString("io.appmetrica.analytics.plugin_id") : null);
            Dk dk = Ka.I.D;
            String string = jSONObjectPut2.put("activation_offset", TimeUnit.SECONDS.convert(dk.a.currentTimeMillis() - dk.b, TimeUnit.MILLISECONDS)).toString();
            c0263fk.getClass();
            c0263fk.a(new C0212dk(str2, string));
        } catch (Throwable unused) {
        }
    }

    @Override // io.appmetrica.analytics.impl.Z8
    public final boolean b() {
        String str;
        if (!this.d.get() && (str = ((C0727xh) this.a.a()).m) != null && !Intrinsics.areEqual(str, "629a824d-c717-4ba5-bc0f-3f3968554d01") && this.d.compareAndSet(false, true)) {
            this.b.b(true);
            a("activation");
        }
        return this.d.get();
    }

    public final void a() {
        if (this.d.compareAndSet(false, true)) {
            this.b.b(true);
            a("timer");
        }
    }

    public static boolean a(F4 f4) {
        String str = f4.a;
        return (str == null || Intrinsics.areEqual(str, "629a824d-c717-4ba5-bc0f-3f3968554d01")) ? false : true;
    }
}

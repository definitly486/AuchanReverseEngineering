package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.text.Charsets;
import io.appmetrica.analytics.coreutils.internal.parsing.JsonUtils;
import io.appmetrica.analytics.coreutils.internal.time.TimeProvider;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import java.util.Map;
import org.json.JSONObject;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ca, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0176ca extends AbstractC0131ah {
    public final C0202da b;

    public C0176ca(C0455n5 c0455n5, TimeProvider timeProvider) {
        super(c0455n5);
        this.b = new C0202da(c0455n5, timeProvider);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0131ah
    public final boolean a(C0249f6 c0249f6) {
        long jOptLong;
        C0202da c0202da = this.b;
        W9 w9 = c0202da.a.t().B;
        Long lValueOf = w9 != null ? Long.valueOf(w9.a) : null;
        if (lValueOf != null) {
            Po po = c0202da.a.t;
            synchronized (po) {
                jOptLong = po.a.a().optLong("external_attribution_window_start", -1L);
            }
            if (jOptLong < 0) {
                jOptLong = c0202da.b.currentTimeMillis();
                c0202da.a.t.a(jOptLong);
            }
            if (c0202da.b.currentTimeMillis() - jOptLong <= lValueOf.longValue()) {
                V9 v9 = (V9) MessageNano.mergeFrom(new V9(), c0249f6.getValueBytes());
                int i = v9.a;
                String str = new String(v9.b, Charsets.UTF_8);
                String str2 = this.b.a.c.k().get(Integer.valueOf(i));
                if (str2 != null) {
                    try {
                        if (JsonUtils.isEqualTo(new JSONObject(str), new JSONObject(str2))) {
                            this.a.m.info("Ignoring attribution of type `" + AbstractC0253fa.a(i) + "` with value `" + str + "` since it is not new", new Object[0]);
                            return true;
                        }
                    } catch (Throwable unused) {
                    }
                }
                C0202da c0202da2 = this.b;
                Map<Integer, String> mapK = c0202da2.a.c.k();
                mapK.put(Integer.valueOf(i), str);
                c0202da2.a.c.b(mapK);
                this.a.m.info("Handling attribution of type `" + AbstractC0253fa.a(i) + '`', new Object[0]);
                return false;
            }
        }
        this.a.m.info("Ignoring attribution since out of collecting interval", new Object[0]);
        return true;
    }
}

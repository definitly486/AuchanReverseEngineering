package io.appmetrica.analytics.impl;

import android.util.Base64;
import android.util.Pair;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import io.appmetrica.analytics.coreutils.internal.WrapUtils;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import java.util.HashMap;
import java.util.Iterator;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.d4, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0196d4 extends C0249f6 {
    public HashMap q;
    public C0499on r;
    public C0421ln s;
    public C0421ln t;
    public C0505p3 u;
    public C0499on v;

    public C0196d4(PublicLogger publicLogger) {
        this("", "", 0, 0, publicLogger);
    }

    public static C0249f6 b(String str, String str2) {
        C0249f6 c0249f6 = new C0249f6("", 0);
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        c0249f6.d = 5376;
        c0249f6.a(str, str2);
        return c0249f6;
    }

    public static C0249f6 n() {
        C0249f6 c0249f6 = new C0249f6("", 0);
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        c0249f6.d = 5632;
        return c0249f6;
    }

    public static C0249f6 o() {
        C0249f6 c0249f6 = new C0249f6("", 0);
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        c0249f6.d = 40961;
        return c0249f6;
    }

    public final void a(String str, String str2, EnumC0170c4 enumC0170c4) {
        if (StringUtils.equalsNullSafety(str, str2)) {
            this.q.remove(enumC0170c4);
        } else {
            this.q.put(enumC0170c4, Integer.valueOf(StringUtils.getUTF8Bytes(str).length - StringUtils.getUTF8Bytes(str2).length));
        }
        Iterator it = this.q.values().iterator();
        int iIntValue = 0;
        while (it.hasNext()) {
            iIntValue += ((Integer) it.next()).intValue();
        }
        this.g = iIntValue;
    }

    @Override // io.appmetrica.analytics.impl.C0249f6
    public final void c(String str) {
        C0499on c0499on = this.v;
        c0499on.getClass();
        this.h = c0499on.a(str);
    }

    public final String d(String str) {
        C0499on c0499on = this.r;
        c0499on.getClass();
        String strA = c0499on.a(str);
        a(str, strA, EnumC0170c4.NAME);
        return strA;
    }

    public final String e(String str) {
        C0421ln c0421ln = this.s;
        c0421ln.getClass();
        String strA = c0421ln.a(str);
        a(str, strA, EnumC0170c4.VALUE);
        return strA;
    }

    public final C0196d4 f(String str) {
        C0421ln c0421ln = this.t;
        c0421ln.getClass();
        String strA = c0421ln.a(str);
        a(str, strA, EnumC0170c4.VALUE);
        this.b = strA;
        return this;
    }

    public final HashMap<EnumC0170c4, Integer> p() {
        return this.q;
    }

    @Override // io.appmetrica.analytics.impl.C0249f6, io.appmetrica.analytics.coreapi.internal.event.CounterReportApi
    public final void setName(String str) {
        this.a = d(str);
    }

    @Override // io.appmetrica.analytics.impl.C0249f6, io.appmetrica.analytics.coreapi.internal.event.CounterReportApi
    public final void setValue(String str) {
        this.b = e(str);
    }

    @Override // io.appmetrica.analytics.impl.C0249f6, io.appmetrica.analytics.coreapi.internal.event.CounterReportApi
    public final void setValueBytes(byte[] bArr) {
        a(bArr);
    }

    public C0196d4(String str, int i, PublicLogger publicLogger) {
        this("", str, i, publicLogger);
    }

    public C0196d4(String str, String str2, int i, PublicLogger publicLogger) {
        this(str, str2, i, 0, publicLogger);
    }

    public C0196d4(int i, PublicLogger publicLogger, long j) {
        this("", "", i, publicLogger);
        b(j);
    }

    public C0196d4(byte[] bArr, String str, int i, PublicLogger publicLogger) {
        this.q = new HashMap();
        a(publicLogger);
        a(bArr);
        this.a = d(str);
        setType(i);
    }

    public final C0196d4 a(HashMap<EnumC0170c4, Integer> map) {
        this.q = map;
        return this;
    }

    public final void a(PublicLogger publicLogger) {
        this.r = new C0499on(1000, "event name", publicLogger);
        this.s = new C0421ln(245760, "event value", publicLogger);
        this.t = new C0421ln(1024000, "event extended value", publicLogger);
        this.u = new C0505p3(245760, "event value bytes", publicLogger);
        this.v = new C0499on(200, "user profile id", publicLogger);
    }

    public final void a(byte[] bArr) {
        C0505p3 c0505p3 = this.u;
        c0505p3.getClass();
        byte[] bArrA = c0505p3.a(bArr);
        EnumC0170c4 enumC0170c4 = EnumC0170c4.VALUE;
        if (bArr.length != bArrA.length) {
            this.q.put(enumC0170c4, Integer.valueOf(bArr.length - bArrA.length));
        } else {
            this.q.remove(enumC0170c4);
        }
        Iterator it = this.q.values().iterator();
        int iIntValue = 0;
        while (it.hasNext()) {
            iIntValue += ((Integer) it.next()).intValue();
        }
        this.g = iIntValue;
        super.setValueBytes(bArrA);
    }

    public static C0249f6 a(Ao ao) {
        C0249f6 c0249f6O = o();
        c0249f6O.setValue(new String(Base64.encode(MessageNano.toByteArray(ao), 0)));
        return c0249f6O;
    }

    public static C0196d4 a(PublicLogger publicLogger, C0185cj c0185cj) {
        int length;
        C0196d4 c0196d4 = new C0196d4(publicLogger);
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        c0196d4.d = 40976;
        C0133aj c0133aj = new C0133aj();
        c0133aj.b = c0185cj.a.currency.getCurrencyCode().getBytes();
        c0133aj.f = c0185cj.a.priceMicros;
        c0133aj.c = StringUtils.stringToBytesForProtobuf(new C0499on(200, "revenue productID", c0185cj.e).a(c0185cj.a.productID));
        c0133aj.a = ((Integer) WrapUtils.getOrDefault(c0185cj.a.quantity, 1)).intValue();
        C0421ln c0421ln = c0185cj.b;
        String str = c0185cj.a.payload;
        c0421ln.getClass();
        c0133aj.d = StringUtils.stringToBytesForProtobuf(c0421ln.a(str));
        if (Do.a(c0185cj.a.receipt)) {
            Vi vi = new Vi();
            String str2 = (String) c0185cj.c.a(c0185cj.a.receipt.data);
            length = !StringUtils.equalsNullSafety(c0185cj.a.receipt.data, str2) ? c0185cj.a.receipt.data.length() : 0;
            String str3 = (String) c0185cj.d.a(c0185cj.a.receipt.signature);
            vi.a = StringUtils.stringToBytesForProtobuf(str2);
            vi.b = StringUtils.stringToBytesForProtobuf(str3);
            c0133aj.e = vi;
        } else {
            length = 0;
        }
        Pair pair = new Pair(MessageNano.toByteArray(c0133aj), Integer.valueOf(length));
        c0196d4.b = c0196d4.e(new String(Base64.encode((byte[]) pair.first, 0)));
        c0196d4.g = ((Integer) pair.second).intValue();
        return c0196d4;
    }

    public C0196d4(byte[] bArr, String str, int i, PublicLogger publicLogger, long j) {
        this(bArr, str, i, publicLogger);
        b(j);
    }

    public C0196d4(String str, String str2, int i, int i2, PublicLogger publicLogger) {
        this.q = new HashMap();
        a(publicLogger);
        this.b = e(str);
        this.a = d(str2);
        setType(i);
        setCustomType(i2);
    }

    public static C0196d4 a(PublicLogger publicLogger, F f) {
        C0196d4 c0196d4 = new C0196d4(publicLogger);
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        c0196d4.d = 40977;
        com.scanflow.datacapture.barinternal.kotlin.Pair pairA = f.a();
        c0196d4.b = c0196d4.e(new String(Base64.encode((byte[]) pairA.getFirst(), 0)));
        c0196d4.g = ((Integer) pairA.getSecond()).intValue();
        return c0196d4;
    }
}

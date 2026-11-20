package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.Pair;
import com.scanflow.datacapture.barinternal.kotlin.TuplesKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.MapsKt;
import com.scanflow.datacapture.barinternal.kotlin.text.Charsets;
import io.appmetrica.analytics.AdRevenue;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.LinkedHashMap;
import java.util.Map;
import kotlin.jvm.functions.Function1;

/* JADX INFO: loaded from: classes3.dex */
public final class F {
    public final AdRevenue a;
    public final boolean b;
    public final InterfaceC0631u c;
    public final C0499on d;
    public final C0421ln e;

    public F(AdRevenue adRevenue, boolean z, C0681vn c0681vn, PublicLogger publicLogger) {
        this.a = adRevenue;
        this.b = z;
        this.c = c0681vn;
        this.d = new C0499on(100, "ad revenue strings", publicLogger);
        this.e = new C0421ln(30720, "ad revenue payload", publicLogger);
    }

    public final Pair a() {
        Map linkedHashMap;
        C0579s c0579s = new C0579s();
        int length = 0;
        for (Pair pair : CollectionsKt.listOf((Object[]) new Pair[]{TuplesKt.to(this.a.adNetwork, new C0735y(c0579s)), TuplesKt.to(this.a.adPlacementId, new C0761z(c0579s)), TuplesKt.to(this.a.adPlacementName, new A(c0579s)), TuplesKt.to(this.a.adUnitId, new B(c0579s)), TuplesKt.to(this.a.adUnitName, new C(c0579s)), TuplesKt.to(this.a.precision, new D(c0579s)), TuplesKt.to(this.a.currency.getCurrencyCode(), new E(c0579s))})) {
            String str = (String) pair.getFirst();
            Function1 function1 = (Function1) pair.getSecond();
            C0499on c0499on = this.d;
            c0499on.getClass();
            String strA = c0499on.a(str);
            byte[] bArrStringToBytesForProtobuf = StringUtils.stringToBytesForProtobuf(str);
            byte[] bArrStringToBytesForProtobuf2 = StringUtils.stringToBytesForProtobuf(strA);
            function1.invoke(bArrStringToBytesForProtobuf2);
            length += bArrStringToBytesForProtobuf.length - bArrStringToBytesForProtobuf2.length;
        }
        Integer num = (Integer) G.a.get(this.a.adType);
        c0579s.d = num != null ? num.intValue() : 0;
        r rVar = new r();
        BigDecimal bigDecimal = this.a.adRevenue;
        BigInteger bigInteger = P7.a;
        int i = -bigDecimal.scale();
        BigInteger bigIntegerUnscaledValue = bigDecimal.unscaledValue();
        while (true) {
            if (bigIntegerUnscaledValue.compareTo(P7.a) <= 0 && bigIntegerUnscaledValue.compareTo(P7.b) >= 0) {
                break;
            }
            bigIntegerUnscaledValue = bigIntegerUnscaledValue.divide(BigInteger.TEN);
            i++;
        }
        Pair pair2 = TuplesKt.to(Long.valueOf(bigIntegerUnscaledValue.longValue()), Integer.valueOf(i));
        long jLongValue = ((Number) pair2.getFirst()).longValue();
        int iIntValue = ((Number) pair2.getSecond()).intValue();
        rVar.a = jLongValue;
        rVar.b = iIntValue;
        c0579s.b = rVar;
        Map<String, String> map = this.a.payload;
        InterfaceC0631u interfaceC0631u = this.c;
        if (map == null || (linkedHashMap = MapsKt.toMutableMap(map)) == null) {
            linkedHashMap = new LinkedHashMap();
        }
        String strB = Cb.b(interfaceC0631u.a(linkedHashMap));
        C0421ln c0421ln = this.e;
        c0421ln.getClass();
        byte[] bArrStringToBytesForProtobuf3 = StringUtils.stringToBytesForProtobuf(c0421ln.a(strB));
        c0579s.k = bArrStringToBytesForProtobuf3;
        int length2 = (StringUtils.stringToBytesForProtobuf(strB).length - bArrStringToBytesForProtobuf3.length) + length;
        if (this.b) {
            EnumC0605t[] enumC0605tArr = EnumC0605t.a;
            c0579s.a = "autocollected".getBytes(Charsets.UTF_8);
        }
        return TuplesKt.to(MessageNano.toByteArray(c0579s), Integer.valueOf(length2));
    }
}

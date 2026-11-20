package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.TuplesKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.MapsKt;
import io.appmetrica.analytics.coreapi.internal.data.ProtobufConverter;
import io.appmetrica.analytics.ndkcrashesapi.internal.NativeCrashSource;
import java.util.Map;

/* JADX INFO: loaded from: classes3.dex */
public final class Yd implements ProtobufConverter {
    public static final Xd a = new Xd();
    public static final Map b = MapsKt.mapOf(TuplesKt.to(NativeCrashSource.UNKNOWN, 0), TuplesKt.to(NativeCrashSource.CRASHPAD, 3));

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0404l6 fromModel(C0231ee c0231ee) {
        C0404l6 c0404l6 = new C0404l6();
        c0404l6.f = 1;
        C0378k6 c0378k6 = new C0378k6();
        c0378k6.a = c0231ee.a;
        C0482o6 c0482o6 = new C0482o6();
        Integer num = (Integer) b.get(c0231ee.b.a);
        if (num != null) {
            c0482o6.a = num.intValue();
        }
        String str = c0231ee.b.b;
        if (str == null) {
            str = "";
        }
        c0482o6.b = str;
        c0378k6.b = c0482o6;
        c0404l6.g = c0378k6;
        return c0404l6;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        throw new UnsupportedOperationException();
    }

    public final C0231ee a(C0404l6 c0404l6) {
        throw new UnsupportedOperationException();
    }
}

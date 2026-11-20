package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.Converter;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class A7 implements Converter {
    public final Ge a;

    /* JADX WARN: Multi-variable type inference failed */
    public A7() {
        this(null, 1, 0 == true ? 1 : 0);
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final E7 fromModel(C0769z7 c0769z7) {
        E7 e7 = new E7();
        Boolean bool = c0769z7.a;
        if (bool != null) {
            e7.a = this.a.fromModel(bool).intValue();
        }
        Double d = c0769z7.c;
        if (d != null) {
            e7.c = d.doubleValue();
        }
        Double d2 = c0769z7.b;
        if (d2 != null) {
            e7.b = d2.doubleValue();
        }
        Long l = c0769z7.h;
        if (l != null) {
            e7.h = l.longValue();
        }
        Integer num = c0769z7.f;
        if (num != null) {
            e7.f = num.intValue();
        }
        Integer num2 = c0769z7.e;
        if (num2 != null) {
            e7.e = num2.intValue();
        }
        Integer num3 = c0769z7.g;
        if (num3 != null) {
            e7.g = num3.intValue();
        }
        Integer num4 = c0769z7.d;
        if (num4 != null) {
            e7.d = num4.intValue();
        }
        String str = c0769z7.i;
        if (str != null) {
            e7.i = str;
        }
        String str2 = c0769z7.j;
        if (str2 != null) {
            e7.j = str2;
        }
        return e7;
    }

    public A7(Ge ge) {
        this.a = ge;
    }

    public /* synthetic */ A7(Ge ge, int i, DefaultConstructorMarker defaultConstructorMarker) {
        this((i & 1) != 0 ? new Ge() : ge);
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0769z7 toModel(E7 e7) {
        if (e7 == null) {
            return new C0769z7(null, null, null, null, null, null, null, null, null, null);
        }
        E7 e8 = new E7();
        Boolean boolA = this.a.a(e7.a);
        double d = e7.c;
        Double dValueOf = Double.valueOf(d);
        if (d == e8.c) {
            dValueOf = null;
        }
        double d2 = e7.b;
        Double dValueOf2 = !(d2 == e8.b) ? Double.valueOf(d2) : null;
        long j = e7.h;
        Long lValueOf = j != e8.h ? Long.valueOf(j) : null;
        int i = e7.f;
        Integer numValueOf = i != e8.f ? Integer.valueOf(i) : null;
        int i2 = e7.e;
        Integer numValueOf2 = i2 != e8.e ? Integer.valueOf(i2) : null;
        int i3 = e7.g;
        Integer numValueOf3 = i3 != e8.g ? Integer.valueOf(i3) : null;
        int i4 = e7.d;
        Integer numValueOf4 = i4 != e8.d ? Integer.valueOf(i4) : null;
        String str = e7.i;
        String str2 = !Intrinsics.areEqual(str, e8.i) ? str : null;
        String str3 = e7.j;
        return new C0769z7(boolA, dValueOf2, dValueOf, numValueOf4, numValueOf2, numValueOf, numValueOf3, lValueOf, str2, !Intrinsics.areEqual(str3, e8.j) ? str3 : null);
    }
}

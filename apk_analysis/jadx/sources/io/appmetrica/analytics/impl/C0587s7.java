package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.ProtobufConverter;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import java.util.Arrays;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.s7, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0587s7 implements ProtobufConverter {
    public final Ge a;
    public final A7 b;

    /* JADX WARN: Multi-variable type inference failed */
    public C0587s7() {
        this(null, 0 == true ? 1 : 0, 3, 0 == true ? 1 : 0);
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final D7 fromModel(C0639u7 c0639u7) {
        D7 d7 = new D7();
        Integer num = c0639u7.a;
        if (num != null) {
            d7.a = num.intValue();
        }
        String str = c0639u7.b;
        if (str != null) {
            d7.b = StringUtils.correctIllFormedString(str);
        }
        String str2 = c0639u7.c;
        if (str2 != null) {
            d7.c = StringUtils.correctIllFormedString(str2);
        }
        Long l = c0639u7.d;
        if (l != null) {
            d7.d = l.longValue();
        }
        C0769z7 c0769z7 = c0639u7.e;
        if (c0769z7 != null) {
            d7.e = this.b.fromModel(c0769z7);
        }
        String str3 = c0639u7.f;
        if (str3 != null) {
            d7.f = str3;
        }
        String str4 = c0639u7.g;
        if (str4 != null) {
            d7.g = str4;
        }
        Long l2 = c0639u7.h;
        if (l2 != null) {
            d7.h = l2.longValue();
        }
        Integer num2 = c0639u7.i;
        if (num2 != null) {
            d7.i = num2.intValue();
        }
        Integer num3 = c0639u7.j;
        if (num3 != null) {
            d7.j = num3.intValue();
        }
        String str5 = c0639u7.k;
        if (str5 != null) {
            d7.k = str5;
        }
        EnumC0175c9 enumC0175c9 = c0639u7.l;
        if (enumC0175c9 != null) {
            d7.l = enumC0175c9.a;
        }
        String str6 = c0639u7.m;
        if (str6 != null) {
            d7.m = str6;
        }
        Aa aa = c0639u7.n;
        if (aa != null) {
            d7.n = aa.a;
        }
        G9 g9 = c0639u7.o;
        if (g9 != null) {
            d7.o = g9.a;
        }
        Boolean bool = c0639u7.p;
        if (bool != null) {
            d7.p = this.a.fromModel(bool).intValue();
        }
        Integer num4 = c0639u7.q;
        if (num4 != null) {
            d7.q = num4.intValue();
        }
        byte[] bArr = c0639u7.r;
        if (bArr != null) {
            d7.r = bArr;
        }
        return d7;
    }

    public C0587s7(Ge ge, A7 a7) {
        this.a = ge;
        this.b = a7;
    }

    public /* synthetic */ C0587s7(Ge ge, A7 a7, int i, DefaultConstructorMarker defaultConstructorMarker) {
        this((i & 1) != 0 ? new Ge() : ge, (i & 2) != 0 ? new A7(null, 1, null) : a7);
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0639u7 toModel(D7 d7) {
        G9 g9;
        D7 d8 = new D7();
        int i = d7.a;
        Integer numValueOf = i != d8.a ? Integer.valueOf(i) : null;
        String str = d7.b;
        String str2 = !Intrinsics.areEqual(str, d8.b) ? str : null;
        String str3 = d7.c;
        String str4 = !Intrinsics.areEqual(str3, d8.c) ? str3 : null;
        long j = d7.d;
        Long lValueOf = j != d8.d ? Long.valueOf(j) : null;
        C0769z7 model = this.b.toModel(d7.e);
        String str5 = d7.f;
        String str6 = !Intrinsics.areEqual(str5, d8.f) ? str5 : null;
        String str7 = d7.g;
        String str8 = !Intrinsics.areEqual(str7, d8.g) ? str7 : null;
        long j2 = d7.h;
        Long lValueOf2 = Long.valueOf(j2);
        if (j2 == d8.h) {
            lValueOf2 = null;
        }
        int i2 = d7.i;
        Integer numValueOf2 = i2 != d8.i ? Integer.valueOf(i2) : null;
        int i3 = d7.j;
        Integer numValueOf3 = i3 != d8.j ? Integer.valueOf(i3) : null;
        String str9 = d7.k;
        String str10 = !Intrinsics.areEqual(str9, d8.k) ? str9 : null;
        int i4 = d7.l;
        Integer numValueOf4 = Integer.valueOf(i4);
        if (i4 == d8.l) {
            numValueOf4 = null;
        }
        EnumC0175c9 enumC0175c9A = numValueOf4 != null ? EnumC0175c9.a(Integer.valueOf(numValueOf4.intValue())) : null;
        String str11 = d7.m;
        String str12 = !Intrinsics.areEqual(str11, d8.m) ? str11 : null;
        int i5 = d7.n;
        Integer numValueOf5 = Integer.valueOf(i5);
        if (i5 == d8.n) {
            numValueOf5 = null;
        }
        Aa aaA = numValueOf5 != null ? Aa.a(Integer.valueOf(numValueOf5.intValue())) : null;
        int i6 = d7.o;
        Integer numValueOf6 = Integer.valueOf(i6);
        if (i6 == d8.o) {
            numValueOf6 = null;
        }
        if (numValueOf6 != null) {
            int iIntValue = numValueOf6.intValue();
            G9[] g9ArrValues = G9.values();
            int length = g9ArrValues.length;
            int i7 = 0;
            while (true) {
                if (i7 < length) {
                    g9 = g9ArrValues[i7];
                    G9[] g9Arr = g9ArrValues;
                    if (g9.a == iIntValue) {
                        break;
                    }
                    i7++;
                    g9ArrValues = g9Arr;
                } else {
                    g9 = G9.NATIVE;
                    break;
                }
            }
        } else {
            g9 = null;
        }
        Boolean boolA = this.a.a(d7.p);
        int i8 = d7.q;
        Integer numValueOf7 = i8 != d8.q ? Integer.valueOf(i8) : null;
        byte[] bArr = d7.r;
        return new C0639u7(numValueOf, str2, str4, lValueOf, model, str6, str8, lValueOf2, numValueOf2, numValueOf3, str10, enumC0175c9A, str12, aaA, g9, boolA, numValueOf7, !Arrays.equals(bArr, d8.r) ? bArr : null);
    }
}

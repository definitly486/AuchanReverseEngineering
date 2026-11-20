package io.appmetrica.analytics.impl;

import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class G5 {
    public final String a;

    public G5(String str) {
        this.a = str;
    }

    public final String a() {
        return this.a;
    }

    public final String b() {
        return this.a;
    }

    public final boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        return (obj instanceof G5) && Intrinsics.areEqual(this.a, ((G5) obj).a);
    }

    public final int hashCode() {
        return this.a.hashCode();
    }

    public final String toString() {
        return "ConstantModuleEntryPointProvider(className=" + this.a + ')';
    }

    public final G5 a(String str) {
        return new G5(str);
    }

    public static G5 a(G5 g5, String str, int i, Object obj) {
        if ((i & 1) != 0) {
            str = g5.a;
        }
        g5.getClass();
        return new G5(str);
    }
}

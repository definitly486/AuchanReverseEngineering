package io.appmetrica.analytics.impl;

import java.util.Map;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class I3 implements InterfaceC0432m8 {
    public final Map a;
    public final EnumC0406l8 b;

    public I3(Map<String, String> map, EnumC0406l8 enumC0406l8) {
        this.a = map;
        this.b = enumC0406l8;
    }

    public final I3 a(Map<String, String> map, EnumC0406l8 enumC0406l8) {
        return new I3(map, enumC0406l8);
    }

    public final Map<String, String> b() {
        return this.a;
    }

    public final EnumC0406l8 c() {
        return this.b;
    }

    public final Map<String, String> d() {
        return this.a;
    }

    public final boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof I3)) {
            return false;
        }
        I3 i3 = (I3) obj;
        return Intrinsics.areEqual(this.a, i3.a) && this.b == i3.b;
    }

    public final int hashCode() {
        Map map = this.a;
        return this.b.hashCode() + ((map == null ? 0 : map.hashCode()) * 31);
    }

    public final String toString() {
        return "Candidate(clids=" + this.a + ", source=" + this.b + ')';
    }

    public static I3 a(I3 i3, Map map, EnumC0406l8 enumC0406l8, int i, Object obj) {
        if ((i & 1) != 0) {
            map = i3.a;
        }
        if ((i & 2) != 0) {
            enumC0406l8 = i3.b;
        }
        i3.getClass();
        return new I3(map, enumC0406l8);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0432m8
    public final EnumC0406l8 a() {
        return this.b;
    }
}

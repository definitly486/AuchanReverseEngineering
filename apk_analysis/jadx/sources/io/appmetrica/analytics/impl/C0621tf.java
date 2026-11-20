package io.appmetrica.analytics.impl;

import java.util.Set;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.tf, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0621tf extends Sd implements To {
    public static final C0595sf d = new C0595sf("LOCATION_TRACKING_ENABLED", null);
    public static final C0595sf e = new C0595sf("PREF_KEY_OFFSET", null);
    public static final C0595sf f = new C0595sf("UNCHECKED_TIME", null);
    public static final C0595sf g = new C0595sf("STATISTICS_RESTRICTED_IN_MAIN", null);
    public static final C0595sf h = new C0595sf("NEXT_REPORT_SEND_ATTEMPT_NUMBER", null);
    public static final C0595sf i = new C0595sf("NEXT_LOCATION_SEND_ATTEMPT_NUMBER", null);
    public static final C0595sf j = new C0595sf("NEXT_STARTUP_SEND_ATTEMPT_NUMBER", null);
    public static final C0595sf k = new C0595sf("LAST_REPORT_SEND_ATTEMPT_TIME", null);
    public static final C0595sf l = new C0595sf("LAST_LOCATION_SEND_ATTEMPT_TIME", null);
    public static final C0595sf m = new C0595sf("LAST_STARTUP_SEND_ATTEMPT_TIME", null);
    public static final C0595sf n = new C0595sf("SATELLITE_PRELOAD_INFO_CHECKED", null);
    public static final C0595sf o = new C0595sf("SATELLITE_CLIDS_CHECKED", null);
    public static final C0595sf p = new C0595sf("VITAL_DATA", null);
    public static final C0595sf q = new C0595sf("LAST_KOTLIN_VERSION_SEND_TIME", null);
    public static final C0595sf r = new C0595sf("ADV_IDENTIFIERS_TRACKING_ENABLED", null);

    public C0621tf(InterfaceC0280gb interfaceC0280gb) {
        super(interfaceC0280gb);
    }

    public final long a(int i2) {
        return this.a.getLong(e.b, i2);
    }

    public final C0621tf b(long j2) {
        return (C0621tf) d(e.b, j2);
    }

    public final void c(boolean z) {
        d(g.b, z).flushAsync();
    }

    public final C0621tf d(boolean z) {
        return (C0621tf) d(f.b, z);
    }

    public final boolean e() {
        return this.a.getBoolean(d.b, false);
    }

    public final void f(boolean z) {
        d(d.b, z).flushAsync();
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0569rf, io.appmetrica.analytics.impl.Ol, io.appmetrica.analytics.impl.To
    public final void flushAsync() {
        this.a.flushAsync();
    }

    public final void g() {
        d(o.b, true).flushAsync();
    }

    public final void h() {
        d(n.b, true).flushAsync();
    }

    public final boolean i() {
        return this.a.getBoolean(n.b, false);
    }

    public final boolean j() {
        return this.a.getBoolean(o.b, false);
    }

    public final C0621tf a(long j2) {
        return (C0621tf) d(q.b, j2);
    }

    public final boolean b(boolean z) {
        return this.a.getBoolean(f.b, z);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0569rf
    public final Set<String> c() {
        return this.a.b();
    }

    public final Boolean d() {
        C0595sf c0595sf = g;
        if (!this.a.a(c0595sf.b)) {
            return null;
        }
        return Boolean.valueOf(this.a.getBoolean(c0595sf.b, true));
    }

    public final void e(boolean z) {
        d(r.b, z).flushAsync();
    }

    public final long f() {
        return this.a.getLong(q.b, 0L);
    }

    @Override // io.appmetrica.analytics.impl.Sd
    public final String g(String str) {
        return new C0595sf(str, null).b;
    }

    @Override // io.appmetrica.analytics.impl.To
    public final void a(String str) {
        d(p.b, str).flushAsync();
    }

    @Override // io.appmetrica.analytics.impl.To
    public final String b() {
        return this.a.getString(p.b, null);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0569rf, io.appmetrica.analytics.impl.To
    public final void a() {
        super.a();
    }

    public final C0621tf b(EnumC0490oe enumC0490oe, int i2) {
        C0595sf c0595sf;
        int iOrdinal = enumC0490oe.ordinal();
        if (iOrdinal == 0) {
            c0595sf = h;
        } else if (iOrdinal != 1) {
            c0595sf = iOrdinal != 2 ? null : j;
        } else {
            c0595sf = i;
        }
        return c0595sf != null ? (C0621tf) d(c0595sf.b, i2) : this;
    }

    public final boolean a(boolean z) {
        return this.a.getBoolean(r.b, z);
    }

    public final int a(EnumC0490oe enumC0490oe, int i2) {
        C0595sf c0595sf;
        int iOrdinal = enumC0490oe.ordinal();
        if (iOrdinal == 0) {
            c0595sf = h;
        } else if (iOrdinal != 1) {
            c0595sf = iOrdinal != 2 ? null : j;
        } else {
            c0595sf = i;
        }
        if (c0595sf == null) {
            return i2;
        }
        return this.a.getInt(c0595sf.b, i2);
    }

    public final C0621tf b(EnumC0490oe enumC0490oe, long j2) {
        C0595sf c0595sf;
        int iOrdinal = enumC0490oe.ordinal();
        if (iOrdinal == 0) {
            c0595sf = k;
        } else if (iOrdinal != 1) {
            c0595sf = iOrdinal != 2 ? null : m;
        } else {
            c0595sf = l;
        }
        return c0595sf != null ? (C0621tf) d(c0595sf.b, j2) : this;
    }

    public final long a(EnumC0490oe enumC0490oe, long j2) {
        C0595sf c0595sf;
        int iOrdinal = enumC0490oe.ordinal();
        if (iOrdinal == 0) {
            c0595sf = k;
        } else if (iOrdinal != 1) {
            c0595sf = iOrdinal != 2 ? null : m;
        } else {
            c0595sf = l;
        }
        if (c0595sf == null) {
            return j2;
        }
        return this.a.getLong(c0595sf.b, j2);
    }
}

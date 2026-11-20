package io.appmetrica.analytics.impl;

import android.content.Context;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import io.appmetrica.analytics.coreutils.internal.system.SystemPropertiesHelper;
import java.io.File;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.s4, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0584s4 {
    public static volatile C0584s4 y;
    public final J6 a;
    public final V7 b;
    public final C0325i4 c;
    public final S1 d;
    public final C0475o e;
    public final C0550ql f;
    public final U5 g;
    public final C0423m h;
    public final Cn i;
    public Pd j;
    public final C0606t0 k;
    public volatile C0506p4 l;
    public final C0437md m;
    public volatile C0517pf n;
    public volatile C0517pf o;
    public C0573rj p;
    public final B0 q;
    public final X1 r;
    public final C0772za s;
    public volatile C0192d0 t;
    public volatile C0305ha u;
    public volatile Y7 v;
    public volatile C0610t4 w;
    public volatile C0472nm x;

    public C0584s4(J6 j6, C0475o c0475o, C0325i4 c0325i4) {
        this(j6, c0475o, c0325i4, new C0423m(c0475o));
    }

    public static C0584s4 l() {
        if (y == null) {
            synchronized (C0584s4.class) {
                try {
                    if (y == null) {
                        y = new C0584s4(new J6(), new C0475o(), new C0325i4());
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        return y;
    }

    public final C0475o a() {
        return this.e;
    }

    public final C0517pf b(Context context) {
        C0517pf c0517pf;
        C0517pf c0517pf2 = this.n;
        if (c0517pf2 != null) {
            return c0517pf2;
        }
        synchronized (this) {
            try {
                c0517pf = this.n;
                if (c0517pf == null) {
                    C0610t4 c0610t4E = e(context);
                    new C0428m4(c(context)).a(context);
                    C0517pf c0517pf3 = new C0517pf(c0610t4E.a(context));
                    this.n = c0517pf3;
                    c0517pf = c0517pf3;
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        return c0517pf;
    }

    public final C0606t0 c() {
        return this.k;
    }

    public final C0472nm d(Context context) {
        C0472nm c0472nm;
        C0472nm c0472nm2 = this.x;
        if (c0472nm2 != null) {
            return c0472nm2;
        }
        synchronized (this) {
            try {
                c0472nm = this.x;
                if (c0472nm == null) {
                    c0472nm = new C0472nm(context, b(context));
                    this.x = c0472nm;
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        return c0472nm;
    }

    public final S1 e() {
        return this.d;
    }

    public final X1 f() {
        return this.r;
    }

    public final C0325i4 g() {
        return this.c;
    }

    public final U5 h() {
        return this.g;
    }

    public final J6 i() {
        return this.a;
    }

    public final V7 j() {
        return this.b;
    }

    public final C0772za k() {
        return this.s;
    }

    public final C0506p4 m() {
        C0506p4 c0506p4;
        C0506p4 c0506p5 = this.l;
        if (c0506p5 != null) {
            return c0506p5;
        }
        synchronized (this) {
            try {
                c0506p4 = this.l;
                if (c0506p4 == null) {
                    c0506p4 = new C0506p4();
                    this.l = c0506p4;
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        return c0506p4;
    }

    public final J6 n() {
        return this.a;
    }

    public final C0550ql o() {
        return this.f;
    }

    public C0584s4(J6 j6, C0475o c0475o, C0325i4 c0325i4, C0423m c0423m) {
        this(j6, new V7(), c0325i4, c0423m, new S1(), c0475o, new C0550ql(c0475o, c0423m), new U5(c0475o), new Cn(), new C0606t0());
    }

    public final synchronized Pd a(Context context) {
        try {
            if (this.j == null) {
                this.j = new Pd(context, new Eo());
            }
        } catch (Throwable th) {
            throw th;
        }
        return this.j;
    }

    public final C0517pf c(Context context) {
        C0517pf c0517pf;
        C0517pf c0517pf2 = this.o;
        if (c0517pf2 != null) {
            return c0517pf2;
        }
        synchronized (this) {
            try {
                c0517pf = this.o;
                if (c0517pf == null) {
                    C0517pf c0517pf3 = new C0517pf(e(context).b(context));
                    this.o = c0517pf3;
                    c0517pf = c0517pf3;
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        return c0517pf;
    }

    public final C0610t4 e(Context context) {
        C0610t4 c0610t4;
        File file;
        C0610t4 c0610t5 = this.w;
        if (c0610t5 != null) {
            return c0610t5;
        }
        synchronized (this) {
            c0610t4 = this.w;
            if (c0610t4 == null) {
                String systemProperty = SystemPropertiesHelper.readSystemProperty("ro.yndx.metrica.db.dir");
                String systemProperty2 = SystemPropertiesHelper.readSystemProperty("debug.yndx.iaa.db.dir");
                if (StringsKt.isBlank(systemProperty)) {
                    systemProperty = systemProperty2;
                }
                if (!StringsKt.isBlank(systemProperty)) {
                    file = new File(systemProperty, context.getPackageName());
                    try {
                        file.mkdirs();
                    } catch (Exception unused) {
                        file = null;
                    }
                    c0610t4 = new C0610t4(file);
                    this.w = c0610t4;
                }
                file = null;
                c0610t4 = new C0610t4(file);
                this.w = c0610t4;
            }
        }
        return c0610t4;
    }

    public C0584s4(J6 j6, V7 v7, C0325i4 c0325i4, C0423m c0423m, S1 s1, C0475o c0475o, C0550ql c0550ql, U5 u5, Cn cn, C0606t0 c0606t0) {
        this.m = new C0437md();
        this.q = new B0();
        this.r = new X1();
        this.s = new C0772za();
        new U7();
        this.v = new Y7();
        this.a = j6;
        this.b = v7;
        this.c = c0325i4;
        this.h = c0423m;
        this.d = s1;
        this.e = c0475o;
        this.f = c0550ql;
        this.g = u5;
        this.i = cn;
        this.k = c0606t0;
    }

    public final B0 d() {
        return this.q;
    }

    public final C0192d0 b() {
        C0192d0 c0192d0;
        C0192d0 c0192d1 = this.t;
        if (c0192d1 != null) {
            return c0192d1;
        }
        synchronized (this) {
            try {
                c0192d0 = this.t;
                if (c0192d0 == null) {
                    c0192d0 = new C0192d0(this.q, this.f, this.c);
                    this.t = c0192d0;
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        return c0192d0;
    }
}

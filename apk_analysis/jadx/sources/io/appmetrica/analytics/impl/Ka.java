package io.appmetrica.analytics.impl;

import android.content.Context;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import io.appmetrica.analytics.coreapi.internal.data.ProtobufStateStorage;
import io.appmetrica.analytics.coreapi.internal.executors.IHandlerExecutor;
import io.appmetrica.analytics.coreapi.internal.identifiers.PlatformIdentifiers;
import io.appmetrica.analytics.coreapi.internal.system.PermissionExtractor;
import io.appmetrica.analytics.coreutils.internal.ReferenceHolder;
import io.appmetrica.analytics.coreutils.internal.reflection.ReflectionUtils;
import io.appmetrica.analytics.coreutils.internal.services.SafePackageManager;
import io.appmetrica.analytics.coreutils.internal.services.UtilityServiceProvider;
import io.appmetrica.analytics.coreutils.internal.services.WaitForActivationDelayBarrier;
import io.appmetrica.analytics.coreutils.internal.system.SystemPropertiesHelper;
import io.appmetrica.analytics.locationapi.internal.LocationClient;
import java.io.File;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class Ka {
    public static volatile Ka I;
    public volatile C0305ha C;
    public Pk H;
    public final Context a;
    public volatile C0778zg b;
    public volatile W6 c;
    public volatile C0220e3 e;
    public volatile Bj f;
    public volatile W g;
    public volatile C0452n2 h;
    public volatile PlatformIdentifiers i;
    public volatile Nf j;
    public volatile Q3 k;
    public volatile C0621tf l;
    public volatile So m;
    public volatile C0651uj n;
    public volatile C0152bc o;
    public Rl p;
    public volatile Ok r;
    public volatile InterfaceC0281gc w;
    public volatile En x;
    public volatile Nl y;
    public volatile Pd z;
    public final Ja q = new Ja();
    public final C0437md s = new C0437md();
    public final C0489od t = new C0489od();
    public final C0758ym u = new C0758ym();
    public final C0678vk v = new C0678vk();
    public final C0335ie A = new C0335ie();
    public final UtilityServiceProvider B = new UtilityServiceProvider();
    public final Dk D = new Dk();
    public final ReferenceHolder E = new ReferenceHolder();
    public final Nk F = new Nk();
    public final C0345j G = new C0345j();
    public final Bk d = new Bk();

    public Ka(Context context) {
        this.a = context;
    }

    public static void a(Context context) {
        if (I == null) {
            synchronized (Ka.class) {
                try {
                    if (I == null) {
                        I = new Ka(context.getApplicationContext());
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
    }

    public static Ka k() {
        return I;
    }

    public final C0758ym A() {
        return this.u;
    }

    public final Pk B() {
        Pk pk;
        File file;
        Pk pk2 = this.H;
        if (pk2 != null) {
            return pk2;
        }
        synchronized (this) {
            pk = this.H;
            if (pk == null) {
                Context context = this.a;
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
                    pk = new Pk(file);
                    this.H = pk;
                }
                file = null;
                pk = new Pk(file);
                this.H = pk;
            }
        }
        return pk;
    }

    public final En C() {
        En en;
        En en2 = this.x;
        if (en2 != null) {
            return en2;
        }
        synchronized (this) {
            try {
                en = this.x;
                if (en == null) {
                    en = new En(this.a);
                    this.x = en;
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        return en;
    }

    public final synchronized So D() {
        try {
            if (this.m == null) {
                this.m = new So(this.a);
            }
        } catch (Throwable th) {
            throw th;
        }
        return this.m;
    }

    public final void E() {
        if (this.j == null) {
            synchronized (this) {
                try {
                    if (this.j == null) {
                        InterfaceC0318hn interfaceC0318hnA = C0292gn.a(C0725xf.class);
                        Context context = this.a;
                        AbstractC0343in abstractC0343in = (AbstractC0343in) interfaceC0318hnA;
                        ProtobufStateStorage<Object> protobufStateStorageA = abstractC0343in.a(context, abstractC0343in.a(context));
                        C0725xf c0725xf = (C0725xf) protobufStateStorageA.read();
                        this.j = new Nf(this.a, protobufStateStorageA, new Ef(), new C0673vf(c0725xf), new Mf(), new Df(this.a), new If(k().y()), new C0751yf(), c0725xf, "[PreloadInfoStorage]");
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
    }

    public final C0345j b() {
        return this.G;
    }

    public final W c() {
        W w;
        W w2 = this.g;
        if (w2 != null) {
            return w2;
        }
        synchronized (this) {
            try {
                w = this.g;
                if (w == null) {
                    w = new W(this.a, this.d.g(), this.u.a());
                    this.u.a(w);
                    this.g = w;
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        return w;
    }

    public final C0452n2 d() {
        C0452n2 c0452n2;
        C0452n2 c0452n3 = this.h;
        if (c0452n3 != null) {
            return c0452n3;
        }
        synchronized (this) {
            try {
                c0452n2 = this.h;
                if (c0452n2 == null) {
                    c0452n2 = new C0452n2(this.a, AbstractC0478o2.a());
                    this.h = c0452n2;
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        return c0452n2;
    }

    public final C0608t2 e() {
        return l().b;
    }

    public final Q3 f() {
        if (this.k == null) {
            synchronized (this) {
                try {
                    if (this.k == null) {
                        InterfaceC0318hn interfaceC0318hnA = C0292gn.a(J3.class);
                        Context context = this.a;
                        AbstractC0343in abstractC0343in = (AbstractC0343in) interfaceC0318hnA;
                        ProtobufStateStorage<Object> protobufStateStorageA = abstractC0343in.a(context, abstractC0343in.a(context));
                        this.k = new Q3(this.a, protobufStateStorageA, new R3(), new E3(), new U3(), new C0365jj(this.a), new S3(y()), new F3(), (J3) protobufStateStorageA.read(), "[ClidsInfoStorage]");
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        return this.k;
    }

    public final Context g() {
        return this.a;
    }

    public final W6 h() {
        if (this.c == null) {
            synchronized (this) {
                try {
                    if (this.c == null) {
                        this.c = new W6(new V6(y()));
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        return this.c;
    }

    public final C0305ha i() {
        C0305ha c0305ha;
        C0305ha c0305ha2 = this.C;
        if (c0305ha2 != null) {
            return c0305ha2;
        }
        synchronized (this) {
            try {
                c0305ha = this.C;
                if (c0305ha == null) {
                    c0305ha = new C0305ha(this.a);
                    this.C = c0305ha;
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        return c0305ha;
    }

    public final PermissionExtractor j() {
        Nl nl = this.y;
        if (nl != null) {
            return nl;
        }
        synchronized (this) {
            try {
                Nl nl2 = this.y;
                if (nl2 != null) {
                    return nl2;
                }
                Nl nl3 = new Nl(p().c.getAskForPermissionStrategy());
                this.y = nl3;
                return nl3;
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    public final C0152bc l() {
        C0152bc c0152bc;
        C0152bc c0152bc2 = this.o;
        if (c0152bc2 != null) {
            return c0152bc2;
        }
        synchronized (this) {
            try {
                c0152bc = this.o;
                if (c0152bc == null) {
                    c0152bc = new C0152bc(new C0143b3(this.a, this.d.a()), new C0608t2());
                    this.o = c0152bc;
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        return c0152bc;
    }

    public final InterfaceC0281gc m() {
        InterfaceC0281gc c0333ic;
        InterfaceC0281gc interfaceC0281gc = this.w;
        if (interfaceC0281gc != null) {
            return interfaceC0281gc;
        }
        synchronized (this) {
            try {
                c0333ic = this.w;
                if (c0333ic == null) {
                    Context context = this.a;
                    LocationClient locationClient = (LocationClient) ReflectionUtils.loadAndInstantiateClassWithDefaultConstructor("io.appmetrica.analytics.location.internal.LocationClientImpl", LocationClient.class);
                    c0333ic = locationClient == null ? new C0333ic() : new C0307hc(context, new C0488oc(), locationClient);
                    this.w = c0333ic;
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        return c0333ic;
    }

    public final InterfaceC0281gc n() {
        return m();
    }

    public final C0489od o() {
        return this.t;
    }

    public final Ok p() {
        Ok ok;
        Ok ok2 = this.r;
        if (ok2 != null) {
            return ok2;
        }
        synchronized (this) {
            try {
                ok = this.r;
                if (ok == null) {
                    ok = new Ok();
                    this.r = ok;
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        return ok;
    }

    public final Pd q() {
        Pd pd;
        Pd pd2 = this.z;
        if (pd2 != null) {
            return pd2;
        }
        synchronized (this) {
            try {
                pd = this.z;
                if (pd == null) {
                    pd = new Pd(this.a, new Fo());
                    this.z = pd;
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        return pd;
    }

    public final C0335ie r() {
        return this.A;
    }

    public final PlatformIdentifiers s() {
        PlatformIdentifiers platformIdentifiers;
        PlatformIdentifiers platformIdentifiers2 = this.i;
        if (platformIdentifiers2 != null) {
            return platformIdentifiers2;
        }
        synchronized (this) {
            try {
                platformIdentifiers = this.i;
                if (platformIdentifiers == null) {
                    platformIdentifiers = new PlatformIdentifiers(c(), d());
                    this.i = platformIdentifiers;
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        return platformIdentifiers;
    }

    public final Nf t() {
        E();
        return this.j;
    }

    public final C0778zg u() {
        Bg ya;
        if (this.b == null) {
            synchronized (this) {
                try {
                    if (this.b == null) {
                        Context context = this.a;
                        SafePackageManager safePackageManager = new SafePackageManager();
                        Ka ka = I;
                        IHandlerExecutor iHandlerExecutorG = ka.d.g();
                        Oo oo = ka.D().c;
                        String installerPackageName = safePackageManager.getInstallerPackageName(context, context.getPackageName());
                        if (Intrinsics.areEqual(installerPackageName, "com.android.vending")) {
                            ya = new Na(context, iHandlerExecutorG);
                        } else {
                            ya = Intrinsics.areEqual(installerPackageName, "com.huawei.appmarket") ? new Ya(context) : new C0750ye(installerPackageName);
                        }
                        this.b = new C0778zg(new T9(new C0262fj(new C0713x3(ya, new Uo(oo))), iHandlerExecutorG));
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        return this.b;
    }

    public final C0651uj v() {
        C0651uj c0651uj;
        C0651uj c0651uj2 = this.n;
        if (c0651uj2 != null) {
            return c0651uj2;
        }
        synchronized (this) {
            try {
                c0651uj = this.n;
                if (c0651uj == null) {
                    c0651uj = new C0651uj(this.a);
                    this.n = c0651uj;
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        return c0651uj;
    }

    public final Bk w() {
        return this.d;
    }

    public final Nk x() {
        return this.F;
    }

    public final C0621tf y() {
        if (this.l == null) {
            synchronized (this) {
                try {
                    if (this.l == null) {
                        this.l = new C0621tf(B().d(this.a));
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        return this.l;
    }

    public final synchronized X2 z() {
        try {
            if (this.p == null) {
                Rl rl = new Rl(this.a);
                this.p = rl;
                this.u.a(rl);
            }
        } catch (Throwable th) {
            throw th;
        }
        return this.p;
    }

    public final WaitForActivationDelayBarrier a() {
        return this.B.getActivationBarrier();
    }
}

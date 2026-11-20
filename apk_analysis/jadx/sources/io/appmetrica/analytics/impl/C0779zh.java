package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.WrapUtils;
import io.appmetrica.analytics.coreutils.internal.services.SafePackageManager;
import io.appmetrica.analytics.coreutils.internal.time.SystemTimeProvider;
import io.appmetrica.analytics.coreutils.internal.time.TimeProvider;
import org.json.JSONObject;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.zh, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0779zh extends AbstractC0131ah {
    public final Nf b;
    public final Po c;
    public final SafePackageManager d;
    public final TimeProvider e;

    public C0779zh(C0455n5 c0455n5) {
        this(c0455n5, c0455n5.u(), Ka.k().t(), new SafePackageManager(), new SystemTimeProvider());
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0131ah
    public final boolean a(C0249f6 c0249f6) {
        C0455n5 c0455n5 = this.a;
        if (!this.c.d()) {
            C0249f6 c0249f6A = ((C0727xh) c0455n5.k.a()).e ? C0249f6.a(c0249f6, EnumC0721xb.EVENT_TYPE_APP_UPDATE) : C0249f6.a(c0249f6, EnumC0721xb.EVENT_TYPE_INIT);
            JSONObject jSONObject = new JSONObject();
            try {
                jSONObject.put("appInstaller", (String) WrapUtils.getOrDefault(this.d.getInstallerPackageName(c0455n5.a, c0455n5.b.a), ""));
                Nf nf = this.b;
                nf.h.a(nf.a);
                jSONObject.put("preloadInfo", ((Kf) nf.c()).b());
            } catch (Throwable unused) {
            }
            c0249f6A.setValue(jSONObject.toString());
            E9 e9 = c0455n5.n;
            e9.a(c0249f6A, C0393kl.a(e9.c.b(c0249f6A), c0249f6A.i));
            Po po = this.c;
            synchronized (po) {
                JSONObject jSONObjectA = po.a.a();
                if (!jSONObjectA.optBoolean("init_event_done", false)) {
                    po.a.a(jSONObjectA.put("init_event_done", true));
                }
                Qo qo = po.a;
                Qo.a(qo.a);
                Qo.a(qo.b);
            }
            this.c.a(this.e.currentTimeMillis());
        }
        return false;
    }

    public C0779zh(C0455n5 c0455n5, Po po, Nf nf, SafePackageManager safePackageManager, SystemTimeProvider systemTimeProvider) {
        super(c0455n5);
        this.c = po;
        this.b = nf;
        this.d = safePackageManager;
        this.e = systemTimeProvider;
    }
}

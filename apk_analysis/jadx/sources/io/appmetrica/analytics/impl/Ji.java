package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.WrapUtils;
import io.appmetrica.analytics.coreutils.internal.logger.LoggerStorage;
import io.appmetrica.analytics.internal.CounterConfiguration;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;
import java.util.Collection;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Set;
import org.json.JSONArray;

/* JADX INFO: loaded from: classes3.dex */
public final class Ji {
    public final V4 a;
    public final C0396ko b;
    public final Li c;
    public final C0554r0 d;
    public InterfaceC0291gm e;
    public final C0522pk f;

    public Ji(C0554r0 c0554r0, C0396ko c0396ko, V4 v4, C0522pk c0522pk) {
        this(c0554r0, c0396ko, v4, c0522pk, new Li(c0554r0, c0522pk));
    }

    public final void a(Ih ih) {
        Sh sh = ih.e;
        InterfaceC0291gm interfaceC0291gm = this.e;
        if (interfaceC0291gm != null) {
            sh.b.setUuid(((C0265fm) interfaceC0291gm).g());
        } else {
            sh.getClass();
        }
        this.c.a(ih);
    }

    public final void b(String str) {
        Wf wf = this.a.a;
        synchronized (wf) {
            wf.a.put("PROCESS_CFG_INSTALL_REFERRER_SOURCE", str);
        }
    }

    public Ji(C0554r0 c0554r0, C0396ko c0396ko, V4 v4, C0522pk c0522pk, Li li) {
        this.d = c0554r0;
        this.a = v4;
        this.b = c0396ko;
        this.f = c0522pk;
        this.c = li;
    }

    public final void a(C0265fm c0265fm) {
        this.e = c0265fm;
        this.a.b.setUuid(c0265fm.g());
    }

    public final void a(Boolean bool, Boolean bool2, Boolean bool3, Boolean bool4) {
        if (Do.a(bool)) {
            this.a.b.setLocationTracking(bool.booleanValue());
        }
        if (Do.a(bool2)) {
            this.a.b.setDataSendingEnabled(bool2.booleanValue());
        }
        if (Do.a(bool3)) {
            this.a.b.setAdvIdentifiersTracking(bool3.booleanValue(), bool4.booleanValue());
        }
        C0249f6 c0249f6A = C0249f6.a();
        V4 v4 = this.a;
        a(a(c0249f6A, v4), v4, 1, (Map) null);
    }

    public final void a(C0249f6 c0249f6, Sh sh, int i, Map map) {
        String str;
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        this.d.b();
        if (!Do.a(map)) {
            c0249f6.setValue(Cb.b(map));
            a(c0249f6, sh);
        }
        Wf wf = new Wf(sh.a);
        CounterConfiguration counterConfiguration = new CounterConfiguration(sh.b);
        W8 w8 = sh.c;
        synchronized (sh) {
            str = sh.f;
        }
        a(new Ih(c0249f6, false, i, null, new Sh(wf, counterConfiguration, w8, str)));
    }

    public static C0249f6 a(C0249f6 c0249f6, Sh sh) {
        if (Q9.a.contains(Integer.valueOf(c0249f6.d))) {
            c0249f6.c = sh.d();
        }
        return c0249f6;
    }

    public final void a(List list) {
        Wf wf = this.a.a;
        synchronized (wf) {
            wf.a.put("PROCESS_CFG_CUSTOM_HOSTS", Do.a((Collection) list) ? null : new JSONArray((Collection) list).toString());
        }
    }

    public final void a(HashMap map) {
        Wf wf = this.a.a;
        synchronized (wf) {
            wf.a.put("PROCESS_CFG_CLIDS", Cb.b(map));
        }
    }

    public final void a(String str) {
        Wf wf = this.a.a;
        synchronized (wf) {
            wf.a.put("PROCESS_CFG_DISTRIBUTION_REFERRER", str);
        }
    }

    public final Ih a(C0344io c0344io, Sh sh) {
        String str;
        String str2;
        this.d.b();
        C0396ko c0396ko = this.b;
        c0396ko.getClass();
        Yn yn = c0344io.a;
        if (yn == null) {
            str = "";
        } else {
            str = (String) WrapUtils.getOrDefault(yn.a, "");
        }
        byte[] bArrFromModel = c0396ko.a.fromModel(c0344io);
        PublicLogger orCreatePublicLogger = LoggerStorage.getOrCreatePublicLogger(sh.b.getApiKey());
        Set set = Q9.a;
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        C0196d4 c0196d4 = new C0196d4(bArrFromModel, str, 5891, orCreatePublicLogger);
        c0196d4.c = sh.d();
        HashMap map = c0196d4.q;
        Wf wf = new Wf(sh.a);
        CounterConfiguration counterConfiguration = new CounterConfiguration(sh.b);
        W8 w8 = sh.c;
        synchronized (sh) {
            str2 = sh.f;
        }
        return new Ih(c0196d4, true, 1, map, new Sh(wf, counterConfiguration, w8, str2));
    }
}

package io.appmetrica.analytics.impl;

import android.content.Context;
import android.text.TextUtils;
import android.util.SparseArray;
import com.scanflow.datacapture.barinternal.kotlin.NoWhenBranchMatchedException;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import io.appmetrica.analytics.AdRevenue;
import io.appmetrica.analytics.ModuleEvent;
import io.appmetrica.analytics.Revenue;
import io.appmetrica.analytics.coreutils.internal.WrapUtils;
import io.appmetrica.analytics.coreutils.internal.io.Base64Utils;
import io.appmetrica.analytics.coreutils.internal.logger.LoggerStorage;
import io.appmetrica.analytics.ecommerce.ECommerceEvent;
import io.appmetrica.analytics.internal.CounterConfiguration;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;
import io.appmetrica.analytics.plugins.IPluginReporter;
import io.appmetrica.analytics.plugins.PluginErrorDetails;
import io.appmetrica.analytics.profile.UserProfile;
import io.appmetrica.analytics.profile.UserProfileUpdate;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Iterator;
import java.util.Map;
import java.util.Set;
import java.util.TreeMap;
import org.json.JSONObject;

/* JADX INFO: loaded from: classes3.dex */
public abstract class V2 implements InterfaceC0177cb {
    public static final HashSet n = new HashSet(Arrays.asList(1, 13));
    public static final T2 o = new T2();
    protected final Context a;
    protected final Sh b;
    protected final PublicLogger c;
    protected final C0370jo d;
    protected final Ng e;
    protected final N6 f;
    public final C0243f0 g;
    protected final Ji h;
    public Kb i;
    public final Xf j;
    public final C0305ha k;
    public final C0232ef l;
    public final C0681vn m;

    public V2(Context context, Ji ji, Sh sh, C0305ha c0305ha, J6 j6, C0370jo c0370jo, Ng ng, N6 n6, C0243f0 c0243f0, C0232ef c0232ef) {
        Context applicationContext = context.getApplicationContext();
        this.a = applicationContext;
        this.h = ji;
        this.b = sh;
        this.k = c0305ha;
        this.d = c0370jo;
        this.e = ng;
        this.f = n6;
        this.g = c0243f0;
        this.l = c0232ef;
        PublicLogger orCreatePublicLogger = LoggerStorage.getOrCreatePublicLogger(sh.b().getApiKey());
        this.c = orCreatePublicLogger;
        if (AbstractC0401l3.a(sh.b().isLogEnabled())) {
            orCreatePublicLogger.setEnabled(true);
        }
        this.j = j6;
        this.m = new C0681vn(applicationContext);
    }

    public void a(String str, String str2) {
        if (TextUtils.isEmpty(str)) {
            this.c.warning("Invalid Error Environment (key,value) pair: (%s,%s).", str, str2);
            return;
        }
        this.c.info("Put error environment pair <%s, %s>", str, str2);
        Sh sh = this.b;
        synchronized (sh) {
            W8 w8 = sh.c;
            w8.b.b(w8.a, str, str2);
        }
    }

    public final void b(Map<String, String> map) {
        if (Do.a((Map) map)) {
            return;
        }
        for (Map.Entry<String, String> entry : map.entrySet()) {
            a(entry.getKey(), entry.getValue());
        }
    }

    public final void c(String str) {
        if (this.b.f()) {
            return;
        }
        this.h.d.c();
        Kb kb = this.i;
        kb.a.removeCallbacks(kb.c, kb.b.b.b.getApiKey());
        this.b.e = true;
        Ji ji = this.h;
        PublicLogger publicLogger = this.c;
        Set set = Q9.a;
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        C0196d4 c0196d4 = new C0196d4("", str, 3, 0, publicLogger);
        Sh sh = this.b;
        ji.getClass();
        ji.a(Ji.a(c0196d4, sh), sh, 1, (Map) null);
    }

    @Override // io.appmetrica.analytics.IReporter
    public final void clearAppEnvironment() {
        String str;
        this.c.info("Clear app environment", new Object[0]);
        Ji ji = this.h;
        Sh sh = this.b;
        ji.getClass();
        C0249f6 c0249f6N = C0196d4.n();
        Wf wf = new Wf(sh.a);
        CounterConfiguration counterConfiguration = new CounterConfiguration(sh.b);
        W8 w8 = sh.c;
        synchronized (sh) {
            str = sh.f;
        }
        ji.a(new Ih(c0249f6N, false, 1, null, new Sh(wf, counterConfiguration, w8, str)));
    }

    public final void d(String str) {
        this.h.d.b();
        Kb kb = this.i;
        Kb.a(kb.a, kb.b, kb.c);
        Ji ji = this.h;
        PublicLogger publicLogger = this.c;
        Set set = Q9.a;
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        C0196d4 c0196d4 = new C0196d4("", str, 6400, 0, publicLogger);
        Sh sh = this.b;
        ji.getClass();
        ji.a(Ji.a(c0196d4, sh), sh, 1, (Map) null);
        this.b.e = false;
    }

    @Override // io.appmetrica.analytics.IReporter
    public final IPluginReporter getPluginExtension() {
        return this;
    }

    public String j() {
        return "[BaseReporter]";
    }

    public void k() {
        String str;
        Kf kf;
        Ji ji = this.h;
        Sh sh = this.b;
        ji.getClass();
        Of of = sh.d;
        synchronized (sh) {
            str = sh.f;
        }
        PublicLogger orCreatePublicLogger = LoggerStorage.getOrCreatePublicLogger(sh.b.getApiKey());
        Set set = Q9.a;
        JSONObject jSONObject = new JSONObject();
        if (of != null && (kf = of.a) != null) {
            try {
                jSONObject.put("preloadInfo", kf.c());
            } catch (Throwable unused) {
            }
        }
        String string = jSONObject.toString();
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        C0196d4 c0196d4 = new C0196d4(string, "", 6144, 0, orCreatePublicLogger);
        c0196d4.c(str);
        ji.a(Ji.a(c0196d4, sh), sh, 1, (Map) null);
    }

    @Override // io.appmetrica.analytics.IReporter
    public final void pauseSession() {
        this.c.info("Pause session", new Object[0]);
        c(null);
    }

    @Override // io.appmetrica.analytics.IReporter
    public final void putAppEnvironmentValue(String str, String str2) {
        String str3;
        if (TextUtils.isEmpty(str)) {
            this.c.warning("Invalid App Environment (key,value) pair: (%s,%s).", str, str2);
            return;
        }
        this.c.info("Put app environment: <%s, %s>", str, str2);
        Ji ji = this.h;
        Sh sh = this.b;
        ji.getClass();
        C0249f6 c0249f6B = C0196d4.b(str, str2);
        Wf wf = new Wf(sh.a);
        CounterConfiguration counterConfiguration = new CounterConfiguration(sh.b);
        W8 w8 = sh.c;
        synchronized (sh) {
            str3 = sh.f;
        }
        ji.a(new Ih(c0249f6B, false, 1, null, new Sh(wf, counterConfiguration, w8, str3)));
    }

    @Override // io.appmetrica.analytics.IReporter
    public final void reportAdRevenue(AdRevenue adRevenue) {
        reportAdRevenue(adRevenue, false);
    }

    @Override // io.appmetrica.analytics.IReporter
    public final void reportAnr(Map<Thread, StackTraceElement[]> map) {
        StackTraceElement[] stackTraceElementArrB;
        C0269g0 c0269g0 = new C0269g0(new C0295h0(this, map));
        Ia ia = new Ia();
        J6 j6 = C0584s4.l().a;
        Thread threadA = c0269g0.a();
        Map mapC = null;
        try {
            stackTraceElementArrB = c0269g0.b();
            if (stackTraceElementArrB == null) {
                try {
                    stackTraceElementArrB = threadA.getStackTrace();
                } catch (SecurityException unused) {
                }
            }
        } catch (SecurityException unused2) {
            stackTraceElementArrB = null;
        }
        On on = (On) ia.apply(threadA, stackTraceElementArrB);
        ArrayList arrayList = new ArrayList();
        TreeMap treeMap = new TreeMap(new Tn());
        try {
            mapC = c0269g0.c();
        } catch (SecurityException unused3) {
        }
        if (mapC != null) {
            treeMap.putAll(mapC);
        }
        for (Map.Entry entry : treeMap.entrySet()) {
            Thread thread = (Thread) entry.getKey();
            if (thread != threadA && thread != null) {
                arrayList.add((On) ia.apply(thread, (StackTraceElement[]) entry.getValue()));
            }
        }
        a(new X(on, arrayList, j6.a()));
    }

    @Override // io.appmetrica.analytics.IReporter
    public final void reportECommerce(ECommerceEvent eCommerceEvent) {
        String str;
        this.c.info("E-commerce event received: " + eCommerceEvent.getPublicDescription(), new Object[0]);
        Ji ji = this.h;
        Sh sh = this.b;
        ji.getClass();
        for (Qi qi : eCommerceEvent.toProto()) {
            C0196d4 c0196d4 = new C0196d4(LoggerStorage.getOrCreatePublicLogger(sh.b.getApiKey()));
            EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
            c0196d4.d = 41000;
            c0196d4.b = c0196d4.e(Base64Utils.compressBase64(MessageNano.toByteArray((MessageNano) qi.a)));
            c0196d4.g = qi.b.getBytesTruncated();
            Wf wf = new Wf(sh.a);
            CounterConfiguration counterConfiguration = new CounterConfiguration(sh.b);
            W8 w8 = sh.c;
            synchronized (sh) {
                str = sh.f;
            }
            ji.a(new Ih(c0196d4, false, 1, null, new Sh(wf, counterConfiguration, w8, str)));
        }
    }

    @Override // io.appmetrica.analytics.IReporter
    public final void reportError(String str, Throwable th) {
        Mg mg = new Mg(str, a(th));
        Ji ji = this.h;
        byte[] byteArray = MessageNano.toByteArray(this.e.fromModel(mg));
        PublicLogger publicLogger = this.c;
        Set set = Q9.a;
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        C0196d4 c0196d4 = new C0196d4(byteArray, str, 5892, publicLogger);
        Sh sh = this.b;
        ji.getClass();
        ji.a(Ji.a(c0196d4, sh), sh, 1, (Map) null);
        this.c.info("Error received: %s", WrapUtils.wrapToTag(str));
    }

    @Override // io.appmetrica.analytics.IReporter
    public final void reportEvent(String str) {
        this.c.info("Event received: " + WrapUtils.wrapToTag(str), new Object[0]);
        Ji ji = this.h;
        PublicLogger publicLogger = this.c;
        Set set = Q9.a;
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        C0196d4 c0196d4 = new C0196d4("", str, 1, 0, publicLogger);
        Sh sh = this.b;
        ji.getClass();
        ji.a(Ji.a(c0196d4, sh), sh, 1, (Map) null);
    }

    @Override // io.appmetrica.analytics.IReporter
    public final void reportRevenue(Revenue revenue) {
        String str;
        C0159bj c0159bj = U2.a;
        c0159bj.getClass();
        Io ioA = c0159bj.a(revenue);
        if (!ioA.a) {
            this.c.warning("Passed revenue is not valid. Reason: " + ioA.b, new Object[0]);
            return;
        }
        Ji ji = this.h;
        C0185cj c0185cj = new C0185cj(revenue, this.c);
        Sh sh = this.b;
        ji.getClass();
        C0196d4 c0196d4A = C0196d4.a(LoggerStorage.getOrCreatePublicLogger(sh.b.getApiKey()), c0185cj);
        Wf wf = new Wf(sh.a);
        CounterConfiguration counterConfiguration = new CounterConfiguration(sh.b);
        W8 w8 = sh.c;
        synchronized (sh) {
            str = sh.f;
        }
        ji.a(new Ih(c0196d4A, false, 1, null, new Sh(wf, counterConfiguration, w8, str)));
        this.c.info("Revenue received for productID: " + WrapUtils.wrapToTag(revenue.productID) + " of quantity: " + WrapUtils.wrapToTag(revenue.quantity) + " with price (in micros): " + revenue.priceMicros + " " + revenue.currency, new Object[0]);
    }

    @Override // io.appmetrica.analytics.IReporter
    public final void reportUnhandledException(Throwable th) {
        C0344io c0344ioA = AbstractC0422lo.a(th, new X(null, null, this.j.a()), null, (String) this.k.b.a(), (Boolean) this.k.c.a());
        Ji ji = this.h;
        ji.a(ji.a(c0344ioA, this.b));
        this.c.info("Unhandled exception received: " + c0344ioA, new Object[0]);
    }

    @Override // io.appmetrica.analytics.IReporter
    public final void reportUserProfile(UserProfile userProfile) {
        String str;
        C0682vo c0682vo = new C0682vo(C0682vo.c);
        Iterator<UserProfileUpdate<? extends InterfaceC0708wo>> it = userProfile.getUserProfileUpdates().iterator();
        while (it.hasNext()) {
            InterfaceC0708wo userProfileUpdatePatcher = it.next().getUserProfileUpdatePatcher();
            userProfileUpdatePatcher.a(this.c);
            userProfileUpdatePatcher.a(c0682vo);
        }
        Ao ao = new Ao();
        ArrayList arrayList = new ArrayList();
        for (int i = 0; i < c0682vo.a.size(); i++) {
            SparseArray sparseArray = c0682vo.a;
            Iterator it2 = ((HashMap) sparseArray.get(sparseArray.keyAt(i))).values().iterator();
            while (it2.hasNext()) {
                arrayList.add((C0734xo) it2.next());
            }
        }
        ao.a = (C0734xo[]) arrayList.toArray(new C0734xo[arrayList.size()]);
        Io ioA = o.a(ao);
        if (!ioA.a) {
            this.c.warning("UserInfo wasn't sent because " + ioA.b, new Object[0]);
            return;
        }
        Ji ji = this.h;
        Sh sh = this.b;
        ji.getClass();
        C0249f6 c0249f6A = C0196d4.a(ao);
        Wf wf = new Wf(sh.a);
        CounterConfiguration counterConfiguration = new CounterConfiguration(sh.b);
        W8 w8 = sh.c;
        synchronized (sh) {
            str = sh.f;
        }
        ji.a(new Ih(c0249f6A, false, 1, null, new Sh(wf, counterConfiguration, w8, str)));
        this.c.info("User profile received", new Object[0]);
    }

    @Override // io.appmetrica.analytics.IReporter
    public final void resumeSession() {
        d(null);
        this.c.info("Resume session", new Object[0]);
    }

    @Override // io.appmetrica.analytics.IReporter, io.appmetrica.analytics.IModuleReporter
    public final void sendEventsBuffer() {
        this.c.info("Send event buffer", new Object[0]);
        Ji ji = this.h;
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        PublicLogger publicLogger = this.c;
        Set set = Q9.a;
        C0196d4 c0196d4 = new C0196d4("", "", 256, 0, publicLogger);
        Sh sh = this.b;
        ji.getClass();
        ji.a(Ji.a(c0196d4, sh), sh, 1, (Map) null);
    }

    @Override // io.appmetrica.analytics.IReporter
    public final void setDataSendingEnabled(boolean z) {
        this.b.b.setDataSendingEnabled(z);
        this.c.info("Updated data sending enabled: %s", Boolean.valueOf(z));
    }

    @Override // io.appmetrica.analytics.IModuleReporter
    public final void setSessionExtra(String str, byte[] bArr) {
        Ji ji = this.h;
        PublicLogger publicLogger = this.c;
        Set set = Q9.a;
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        C0196d4 c0196d4 = new C0196d4("", (String) null, 8193, 0, publicLogger);
        if (bArr == null) {
            bArr = new byte[0];
        }
        c0196d4.p = Collections.singletonMap(str, bArr);
        Sh sh = this.b;
        ji.getClass();
        ji.a(Ji.a(c0196d4, sh), sh, 1, (Map) null);
    }

    @Override // io.appmetrica.analytics.IReporter
    public final void setUserProfileID(String str) {
        String str2;
        Ji ji = this.h;
        Sh sh = this.b;
        ji.getClass();
        C0196d4 c0196d4 = new C0196d4(LoggerStorage.getOrCreatePublicLogger(sh.b.getApiKey()));
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        c0196d4.d = 40962;
        c0196d4.c(str);
        c0196d4.b = c0196d4.e(str);
        Wf wf = new Wf(sh.a);
        CounterConfiguration counterConfiguration = new CounterConfiguration(sh.b);
        W8 w8 = sh.c;
        synchronized (sh) {
            str2 = sh.f;
        }
        ji.a(new Ih(c0196d4, false, 1, null, new Sh(wf, counterConfiguration, w8, str2)));
        this.c.info("Set user profile ID: " + WrapUtils.wrapToTag(str), new Object[0]);
    }

    @Override // io.appmetrica.analytics.IModuleReporter
    public final void reportAdRevenue(AdRevenue adRevenue, boolean z) {
        String str;
        Ji ji = this.h;
        F f = new F(adRevenue, z, this.m, this.c);
        Sh sh = this.b;
        ji.getClass();
        C0196d4 c0196d4A = C0196d4.a(LoggerStorage.getOrCreatePublicLogger(sh.b.getApiKey()), f);
        Wf wf = new Wf(sh.a);
        CounterConfiguration counterConfiguration = new CounterConfiguration(sh.b);
        W8 w8 = sh.c;
        synchronized (sh) {
            str = sh.f;
        }
        ji.a(new Ih(c0196d4A, false, 1, null, new Sh(wf, counterConfiguration, w8, str)));
        this.c.info("AdRevenue Received: AdRevenue{adRevenue=" + adRevenue.adRevenue + ", currency='" + WrapUtils.wrapToTag(adRevenue.currency.getCurrencyCode()) + "', adType=" + WrapUtils.wrapToTag(adRevenue.adType) + ", adNetwork='" + WrapUtils.wrapToTag(adRevenue.adNetwork) + "', adUnitId='" + WrapUtils.wrapToTag(adRevenue.adUnitId) + "', adUnitName='" + WrapUtils.wrapToTag(adRevenue.adUnitName) + "', adPlacementId='" + WrapUtils.wrapToTag(adRevenue.adPlacementId) + "', adPlacementName='" + WrapUtils.wrapToTag(adRevenue.adPlacementName) + "', precision='" + WrapUtils.wrapToTag(adRevenue.precision) + "', payload=" + Cb.b(adRevenue.payload) + ", autoCollected=" + z + "}", new Object[0]);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0177cb
    public final void b(String str, String str2) {
        this.c.info("Event received: " + WrapUtils.wrapToTag(str) + ". With value: " + WrapUtils.wrapToTag(str2), new Object[0]);
        Ji ji = this.h;
        PublicLogger publicLogger = this.c;
        Set set = Q9.a;
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        C0196d4 c0196d4 = new C0196d4(str2, str, 1, 0, publicLogger);
        c0196d4.l = G9.JS;
        Sh sh = this.b;
        ji.getClass();
        ji.a(Ji.a(c0196d4, sh), sh, 1, (Map) null);
    }

    public final void a(Map<String, String> map) {
        if (Do.a((Map) map)) {
            return;
        }
        for (Map.Entry<String, String> entry : map.entrySet()) {
            putAppEnvironmentValue(entry.getKey(), entry.getValue());
        }
    }

    @Override // io.appmetrica.analytics.IReporter
    public final void reportEvent(String str, String str2) {
        this.c.info("Event received: " + WrapUtils.wrapToTag(str) + ". With value: " + WrapUtils.wrapToTag(str2), new Object[0]);
        Ji ji = this.h;
        PublicLogger publicLogger = this.c;
        Set set = Q9.a;
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        C0196d4 c0196d4 = new C0196d4(str2, str, 1, 0, publicLogger);
        Sh sh = this.b;
        ji.getClass();
        ji.a(Ji.a(c0196d4, sh), sh, 1, (Map) null);
    }

    @Override // io.appmetrica.analytics.IReporter
    public final void reportError(String str, String str2) {
        reportError(str, str2, (Throwable) null);
    }

    public final C0344io a(Throwable th) {
        Throwable th2;
        StackTraceElement[] stackTrace;
        if (th == null) {
            stackTrace = null;
            th2 = null;
        } else if (th instanceof C0116a2) {
            stackTrace = th.getStackTrace();
            th2 = null;
        } else {
            th2 = th;
            stackTrace = null;
        }
        return AbstractC0422lo.a(th2, new X(null, null, this.j.a()), stackTrace != null ? Arrays.asList(stackTrace) : null, (String) this.k.b.a(), (Boolean) this.k.c.a());
    }

    @Override // io.appmetrica.analytics.IReporter
    public final void reportError(String str, String str2, Throwable th) {
        M6 m6 = new M6(new Mg(str2, a(th)), str);
        Ji ji = this.h;
        byte[] byteArray = MessageNano.toByteArray(this.f.fromModel(m6));
        PublicLogger publicLogger = this.c;
        Set set = Q9.a;
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        C0196d4 c0196d4 = new C0196d4(byteArray, str2, 5896, publicLogger);
        Sh sh = this.b;
        ji.getClass();
        ji.a(Ji.a(c0196d4, sh), sh, 1, (Map) null);
        this.c.info("Error received: id: %s, message: %s", WrapUtils.wrapToTag(str), WrapUtils.wrapToTag(str2));
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0177cb
    public final void b(String str) {
        Ji ji = this.h;
        C0249f6 c0249f6A = C0249f6.a(str);
        Sh sh = this.b;
        ji.getClass();
        ji.a(Ji.a(c0249f6A, sh), sh, 1, (Map) null);
    }

    @Override // io.appmetrica.analytics.plugins.IPluginReporter
    public final void reportUnhandledException(PluginErrorDetails pluginErrorDetails) {
        C0344io c0344ioA = this.l.a(pluginErrorDetails);
        Ji ji = this.h;
        Yn yn = c0344ioA.a;
        String str = yn != null ? (String) WrapUtils.getOrDefault(yn.a, "") : "";
        byte[] byteArray = MessageNano.toByteArray(this.d.fromModel(c0344ioA));
        PublicLogger publicLogger = this.c;
        Set set = Q9.a;
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        C0196d4 c0196d4 = new C0196d4(byteArray, str, 5891, publicLogger);
        Sh sh = this.b;
        ji.getClass();
        ji.a(Ji.a(c0196d4, sh), sh, 1, (Map) null);
        this.c.info("Crash from plugin received: %s", WrapUtils.wrapToTag(pluginErrorDetails.getMessage()));
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0177cb
    public final boolean b() {
        return this.b.f();
    }

    @Override // io.appmetrica.analytics.IReporter
    public final void reportEvent(String str, Map<String, Object> map) {
        Ji ji = this.h;
        PublicLogger publicLogger = this.c;
        Set set = Q9.a;
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        ji.a(new C0196d4("", str, 1, 0, publicLogger), this.b, 1, map);
        PublicLogger publicLogger2 = this.c;
        StringBuilder sb = new StringBuilder("Event received: ");
        sb.append(WrapUtils.wrapToTag(str));
        sb.append(". With value: ");
        sb.append(WrapUtils.wrapToTag(map == null ? null : map.toString()));
        publicLogger2.info(sb.toString(), new Object[0]);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0435mb, io.appmetrica.analytics.impl.InterfaceC0540qb
    public final void a(C0344io c0344io) {
        pauseSession();
        Ji ji = this.h;
        Ih ihA = ji.a(c0344io, this.b);
        Sh sh = ihA.e;
        InterfaceC0291gm interfaceC0291gm = ji.e;
        if (interfaceC0291gm != null) {
            sh.b.setUuid(((C0265fm) interfaceC0291gm).g());
        } else {
            sh.getClass();
        }
        ji.c.b(ihA);
        this.c.info("Unhandled exception received: " + c0344io, new Object[0]);
    }

    @Override // io.appmetrica.analytics.plugins.IPluginReporter
    public final void reportError(PluginErrorDetails pluginErrorDetails, String str) {
        C0344io c0344ioA;
        C0232ef c0232ef = this.l;
        if (pluginErrorDetails != null) {
            c0344ioA = c0232ef.a(pluginErrorDetails);
        } else {
            c0232ef.getClass();
            c0344ioA = null;
        }
        Mg mg = new Mg(str, c0344ioA);
        Ji ji = this.h;
        byte[] byteArray = MessageNano.toByteArray(this.e.fromModel(mg));
        PublicLogger publicLogger = this.c;
        Set set = Q9.a;
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        C0196d4 c0196d4 = new C0196d4(byteArray, str, 5896, publicLogger);
        Sh sh = this.b;
        ji.getClass();
        ji.a(Ji.a(c0196d4, sh), sh, 1, (Map) null);
        this.c.info("Error from plugin received: %s", WrapUtils.wrapToTag(str));
    }

    @Override // io.appmetrica.analytics.IModuleReporter
    public final void reportEvent(ModuleEvent moduleEvent) {
        G9 g9;
        if (n.contains(Integer.valueOf(moduleEvent.getType()))) {
            return;
        }
        PublicLogger publicLogger = this.c;
        Set set = Q9.a;
        String value = moduleEvent.getValue();
        String name = moduleEvent.getName();
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        C0196d4 c0196d4 = new C0196d4(value, name, 8192, moduleEvent.getType(), publicLogger);
        int i = Y8.a[moduleEvent.getCategory().ordinal()];
        if (i == 1) {
            g9 = G9.NATIVE;
        } else {
            if (i != 2) {
                throw new NoWhenBranchMatchedException();
            }
            g9 = G9.SYSTEM;
        }
        c0196d4.l = g9;
        c0196d4.c = Cb.b(moduleEvent.getEnvironment());
        if (moduleEvent.getExtras() != null) {
            c0196d4.p = moduleEvent.getExtras();
        }
        this.h.a(c0196d4, this.b, moduleEvent.getServiceDataReporterType(), moduleEvent.getAttributes());
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0435mb, io.appmetrica.analytics.impl.InterfaceC0321i0
    public final void a(X x) {
        C0217e0 c0217e0 = new C0217e0(x, (String) this.k.b.a(), (Boolean) this.k.c.a());
        Ji ji = this.h;
        byte[] byteArray = MessageNano.toByteArray(this.g.fromModel(c0217e0));
        PublicLogger publicLogger = this.c;
        Set set = Q9.a;
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        C0196d4 c0196d4 = new C0196d4(byteArray, "", 5968, publicLogger);
        Sh sh = this.b;
        ji.getClass();
        String str = null;
        ji.a(Ji.a(c0196d4, sh), sh, 1, (Map) null);
        PublicLogger publicLogger2 = this.c;
        StringBuilder sb = new StringBuilder("ANR was reported ");
        On on = x.a;
        if (on != null) {
            str = "Thread[name=" + on.a + ",tid={" + on.c + ", priority=" + on.b + ", group=" + on.d + "}] at " + CollectionsKt.joinToString$default(on.f, "\n", null, null, 0, null, null, 62, null);
        }
        sb.append(str);
        publicLogger2.info(sb.toString(), new Object[0]);
    }

    @Override // io.appmetrica.analytics.plugins.IPluginReporter
    public final void reportError(String str, String str2, PluginErrorDetails pluginErrorDetails) {
        C0344io c0344ioA;
        C0232ef c0232ef = this.l;
        if (pluginErrorDetails != null) {
            c0344ioA = c0232ef.a(pluginErrorDetails);
        } else {
            c0232ef.getClass();
            c0344ioA = null;
        }
        M6 m6 = new M6(new Mg(str2, c0344ioA), str);
        Ji ji = this.h;
        byte[] byteArray = MessageNano.toByteArray(this.f.fromModel(m6));
        PublicLogger publicLogger = this.c;
        Set set = Q9.a;
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        C0196d4 c0196d4 = new C0196d4(byteArray, str2, 5896, publicLogger);
        Sh sh = this.b;
        ji.getClass();
        ji.a(Ji.a(c0196d4, sh), sh, 1, (Map) null);
        this.c.info("Error with identifier: %s from plugin received: %s", str, WrapUtils.wrapToTag(str2));
    }
}

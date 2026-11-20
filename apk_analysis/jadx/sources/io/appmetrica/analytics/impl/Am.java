package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.collection.CollectionUtils;
import io.appmetrica.analytics.networktasks.internal.RetryPolicyConfig;
import java.util.Collections;
import java.util.List;
import java.util.Map;

/* JADX INFO: loaded from: classes3.dex */
public final class Am {
    public final Map A;
    public final W9 B;
    public final String a;
    public final List b;
    public final String c;
    public final String d;
    public final String e;
    public final List f;
    public final List g;
    public final List h;
    public final Map i;
    public final String j;
    public final String k;
    public final String l;
    public final C4 m;
    public final long n;
    public final boolean o;
    public final boolean p;
    public final String q;
    public final Xm r;
    public final Se s;
    public final RetryPolicyConfig t;
    public final long u;
    public final long v;
    public final boolean w;
    public final C0609t3 x;
    public final C0764z2 y;
    public final Tm z;

    public Am(C0784zm c0784zm) {
        this.a = c0784zm.a;
        List list = c0784zm.b;
        this.b = list == null ? null : CollectionUtils.unmodifiableListCopy(list);
        this.c = c0784zm.c;
        this.d = c0784zm.d;
        this.e = c0784zm.e;
        List list2 = c0784zm.f;
        this.f = list2 == null ? null : CollectionUtils.unmodifiableListCopy(list2);
        List list3 = c0784zm.g;
        this.g = list3 == null ? null : CollectionUtils.unmodifiableListCopy(list3);
        List list4 = c0784zm.h;
        this.h = list4 == null ? null : CollectionUtils.unmodifiableListCopy(list4);
        Map map = c0784zm.i;
        this.i = map != null ? CollectionUtils.unmodifiableMapCopy(map) : null;
        this.j = c0784zm.j;
        this.k = c0784zm.k;
        this.m = c0784zm.m;
        this.s = c0784zm.n;
        this.n = c0784zm.o;
        this.o = c0784zm.p;
        this.l = c0784zm.l;
        this.p = c0784zm.q;
        this.q = c0784zm.r;
        this.r = c0784zm.s;
        this.u = c0784zm.t;
        this.v = c0784zm.u;
        this.w = c0784zm.v;
        RetryPolicyConfig retryPolicyConfig = c0784zm.w;
        if (retryPolicyConfig == null) {
            Nm nm = new Nm();
            this.t = new RetryPolicyConfig(nm.w, nm.x);
        } else {
            this.t = retryPolicyConfig;
        }
        this.x = c0784zm.x;
        this.y = c0784zm.y;
        this.z = c0784zm.z == null ? new Tm(AbstractC0122a8.b.a) : c0784zm.z;
        this.A = c0784zm.A == null ? Collections.EMPTY_MAP : c0784zm.A;
        this.B = c0784zm.B;
    }

    public final C0784zm a(C4 c4) {
        C0784zm c0784zm = new C0784zm(c4);
        c0784zm.a = this.a;
        c0784zm.f = this.f;
        c0784zm.g = this.g;
        c0784zm.j = this.j;
        c0784zm.b = this.b;
        c0784zm.c = this.c;
        c0784zm.d = this.d;
        c0784zm.e = this.e;
        c0784zm.h = this.h;
        c0784zm.i = this.i;
        c0784zm.k = this.k;
        c0784zm.l = this.l;
        c0784zm.q = this.p;
        c0784zm.o = this.n;
        c0784zm.p = this.o;
        c0784zm.r = this.q;
        c0784zm.n = this.s;
        c0784zm.t = this.u;
        c0784zm.u = this.v;
        c0784zm.s = this.r;
        c0784zm.v = this.w;
        c0784zm.w = this.t;
        c0784zm.x = this.x;
        c0784zm.y = this.y;
        c0784zm.z = this.z;
        c0784zm.A = this.A;
        c0784zm.B = this.B;
        return c0784zm;
    }

    public final String toString() {
        return "StartupStateModel{uuid='" + this.a + "', reportUrls=" + this.b + ", getAdUrl='" + this.c + "', reportAdUrl='" + this.d + "', certificateUrl='" + this.e + "', hostUrlsFromStartup=" + this.f + ", hostUrlsFromClient=" + this.g + ", diagnosticUrls=" + this.h + ", customSdkHosts=" + this.i + ", encodedClidsFromResponse='" + this.j + "', lastClientClidsForStartupRequest='" + this.k + "', lastChosenForRequestClids='" + this.l + "', collectingFlags=" + this.m + ", obtainTime=" + this.n + ", hadFirstStartup=" + this.o + ", startupDidNotOverrideClids=" + this.p + ", countryInit='" + this.q + "', statSending=" + this.r + ", permissionsCollectingConfig=" + this.s + ", retryPolicyConfig=" + this.t + ", obtainServerTime=" + this.u + ", firstStartupServerTime=" + this.v + ", outdated=" + this.w + ", cacheControl=" + this.x + ", attributionConfig=" + this.y + ", startupUpdateConfig=" + this.z + ", modulesRemoteConfigs=" + this.A + ", externalAttributionConfig=" + this.B + '}';
    }
}

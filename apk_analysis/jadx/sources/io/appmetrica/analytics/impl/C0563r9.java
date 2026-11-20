package io.appmetrica.analytics.impl;

import java.util.HashMap;
import java.util.LinkedList;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.r9, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0563r9 extends AbstractC0130ag {
    public final Ei a;
    public final HashMap b;
    public final H4 c;

    public C0563r9(C0455n5 c0455n5) {
        Ei ei = new Ei(c0455n5);
        this.a = ei;
        this.c = new H4(ei);
        this.b = a(c0455n5);
    }

    public final HashMap a(C0455n5 c0455n5) {
        HashMap map = new HashMap();
        map.put(EnumC0721xb.EVENT_TYPE_ACTIVATION, new C0294h(this.a, c0455n5.b));
        map.put(EnumC0721xb.EVENT_TYPE_START, new Vl(this.a));
        map.put(EnumC0721xb.EVENT_TYPE_REGULAR, new Pg(this.a));
        Eb eb = new Eb(this.a);
        map.put(EnumC0721xb.EVENT_TYPE_EXCEPTION_USER_PROTOBUF, eb);
        map.put(EnumC0721xb.EVENT_TYPE_EXCEPTION_USER_CUSTOM_PROTOBUF, eb);
        map.put(EnumC0721xb.EVENT_TYPE_SEND_REFERRER, eb);
        map.put(EnumC0721xb.EVENT_TYPE_CUSTOM_EVENT, eb);
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_SET_SESSION_EXTRA;
        Ei ei = this.a;
        map.put(enumC0721xb, new Ql(ei, ei.t));
        map.put(EnumC0721xb.EVENT_TYPE_APP_OPEN, new Wg(this.a));
        map.put(EnumC0721xb.EVENT_TYPE_PURGE_BUFFER, new C0440mg(this.a));
        map.put(EnumC0721xb.EVENT_TYPE_CURRENT_SESSION_NATIVE_CRASH_PROTOBUF, new K6(this.a));
        map.put(EnumC0721xb.EVENT_TYPE_PREV_SESSION_NATIVE_CRASH_PROTOBUF, new Qf(this.a));
        map.put(EnumC0721xb.EVENT_TYPE_EXCEPTION_UNHANDLED_FROM_FILE, new C0474no(this.a));
        map.put(EnumC0721xb.EVENT_TYPE_PREV_SESSION_EXCEPTION_UNHANDLED_FROM_FILE, new Rf(this.a));
        map.put(EnumC0721xb.EVENT_TYPE_EXCEPTION_UNHANDLED_PROTOBUF, new C0448mo(this.a));
        map.put(EnumC0721xb.EVENT_TYPE_ANR, eb);
        EnumC0721xb enumC0721xb2 = EnumC0721xb.EVENT_TYPE_APP_ENVIRONMENT_UPDATED;
        Ei ei2 = this.a;
        map.put(enumC0721xb2, new Ql(ei2, ei2.e));
        EnumC0721xb enumC0721xb3 = EnumC0721xb.EVENT_TYPE_APP_ENVIRONMENT_CLEARED;
        Ei ei3 = this.a;
        map.put(enumC0721xb3, new Ql(ei3, ei3.f));
        map.put(EnumC0721xb.EVENT_TYPE_SEND_USER_PROFILE, eb);
        EnumC0721xb enumC0721xb4 = EnumC0721xb.EVENT_TYPE_SET_USER_PROFILE_ID;
        Ei ei4 = this.a;
        map.put(enumC0721xb4, new Ql(ei4, ei4.k));
        map.put(EnumC0721xb.EVENT_TYPE_SEND_REVENUE_EVENT, eb);
        map.put(EnumC0721xb.EVENT_TYPE_SEND_AD_REVENUE_EVENT, eb);
        map.put(EnumC0721xb.EVENT_TYPE_CLEANUP, eb);
        map.put(EnumC0721xb.EVENT_TYPE_SEND_ECOMMERCE_EVENT, eb);
        map.put(EnumC0721xb.EVENT_TYPE_WEBVIEW_SYNC, eb);
        map.put(EnumC0721xb.EVENT_CLIENT_EXTERNAL_ATTRIBUTION, new Z9(this.a));
        return map;
    }

    public final void a(EnumC0721xb enumC0721xb, Oa oa) {
        this.b.put(enumC0721xb, oa);
    }

    public final Ei a() {
        return this.a;
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0130ag
    public final AbstractC0538q9 a(int i) {
        LinkedList linkedList = new LinkedList();
        EnumC0721xb enumC0721xbA = EnumC0721xb.a(i);
        H4 h4 = this.c;
        if (h4 != null) {
            h4.a(enumC0721xbA, linkedList);
        }
        Oa oa = (Oa) this.b.get(enumC0721xbA);
        if (oa != null) {
            oa.a(linkedList);
        }
        return new C0511p9(linkedList);
    }

    public final Oa a(EnumC0721xb enumC0721xb) {
        return (Oa) this.b.get(enumC0721xb);
    }
}

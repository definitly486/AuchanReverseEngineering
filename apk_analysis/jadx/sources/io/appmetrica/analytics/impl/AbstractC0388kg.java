package io.appmetrica.analytics.impl;

import android.util.SparseArray;
import java.util.Calendar;
import java.util.Collections;
import java.util.GregorianCalendar;
import java.util.HashMap;
import java.util.Map;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.kg, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AbstractC0388kg {
    public static final Map a;
    public static final SparseArray b;
    public static final Map c;
    public static final Map d;

    static {
        HashMap map = new HashMap();
        EnumC0523pl enumC0523pl = EnumC0523pl.FOREGROUND;
        map.put(enumC0523pl, 0);
        EnumC0523pl enumC0523pl2 = EnumC0523pl.BACKGROUND;
        map.put(enumC0523pl2, 1);
        a = Collections.unmodifiableMap(map);
        SparseArray sparseArray = new SparseArray();
        sparseArray.put(0, enumC0523pl);
        sparseArray.put(1, enumC0523pl2);
        b = sparseArray;
        HashMap map2 = new HashMap();
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_INIT;
        map2.put(enumC0721xb, 1);
        EnumC0721xb enumC0721xb2 = EnumC0721xb.EVENT_TYPE_REGULAR;
        map2.put(enumC0721xb2, 4);
        EnumC0721xb enumC0721xb3 = EnumC0721xb.EVENT_TYPE_SEND_REFERRER;
        map2.put(enumC0721xb3, 5);
        EnumC0721xb enumC0721xb4 = EnumC0721xb.EVENT_TYPE_ALIVE;
        map2.put(enumC0721xb4, 7);
        EnumC0721xb enumC0721xb5 = EnumC0721xb.EVENT_TYPE_EXCEPTION_UNHANDLED_PROTOBUF;
        map2.put(enumC0721xb5, 26);
        EnumC0721xb enumC0721xb6 = EnumC0721xb.EVENT_TYPE_PREV_SESSION_EXCEPTION_UNHANDLED_FROM_FILE;
        map2.put(enumC0721xb6, 26);
        EnumC0721xb enumC0721xb7 = EnumC0721xb.EVENT_TYPE_EXCEPTION_UNHANDLED_FROM_FILE;
        map2.put(enumC0721xb7, 26);
        EnumC0721xb enumC0721xb8 = EnumC0721xb.EVENT_TYPE_ANR;
        map2.put(enumC0721xb8, 25);
        EnumC0721xb enumC0721xb9 = EnumC0721xb.EVENT_TYPE_PREV_SESSION_NATIVE_CRASH_PROTOBUF;
        map2.put(enumC0721xb9, 26);
        EnumC0721xb enumC0721xb10 = EnumC0721xb.EVENT_TYPE_CURRENT_SESSION_NATIVE_CRASH_PROTOBUF;
        map2.put(enumC0721xb10, 26);
        EnumC0721xb enumC0721xb11 = EnumC0721xb.EVENT_TYPE_EXCEPTION_USER_PROTOBUF;
        map2.put(enumC0721xb11, 27);
        EnumC0721xb enumC0721xb12 = EnumC0721xb.EVENT_TYPE_EXCEPTION_USER_CUSTOM_PROTOBUF;
        map2.put(enumC0721xb12, 27);
        EnumC0721xb enumC0721xb13 = EnumC0721xb.EVENT_TYPE_FIRST_ACTIVATION;
        map2.put(enumC0721xb13, 13);
        EnumC0721xb enumC0721xb14 = EnumC0721xb.EVENT_TYPE_START;
        map2.put(enumC0721xb14, 2);
        EnumC0721xb enumC0721xb15 = EnumC0721xb.EVENT_TYPE_APP_OPEN;
        map2.put(enumC0721xb15, 16);
        EnumC0721xb enumC0721xb16 = EnumC0721xb.EVENT_TYPE_APP_UPDATE;
        map2.put(enumC0721xb16, 17);
        EnumC0721xb enumC0721xb17 = EnumC0721xb.EVENT_TYPE_PERMISSIONS;
        map2.put(enumC0721xb17, 18);
        EnumC0721xb enumC0721xb18 = EnumC0721xb.EVENT_TYPE_APP_FEATURES;
        map2.put(enumC0721xb18, 19);
        EnumC0721xb enumC0721xb19 = EnumC0721xb.EVENT_TYPE_SEND_USER_PROFILE;
        map2.put(enumC0721xb19, 20);
        EnumC0721xb enumC0721xb20 = EnumC0721xb.EVENT_TYPE_SEND_REVENUE_EVENT;
        map2.put(enumC0721xb20, 21);
        EnumC0721xb enumC0721xb21 = EnumC0721xb.EVENT_TYPE_SEND_AD_REVENUE_EVENT;
        map2.put(enumC0721xb21, 40);
        EnumC0721xb enumC0721xb22 = EnumC0721xb.EVENT_TYPE_SEND_ECOMMERCE_EVENT;
        map2.put(enumC0721xb22, 35);
        map2.put(EnumC0721xb.EVENT_TYPE_CLEANUP, 29);
        EnumC0721xb enumC0721xb23 = EnumC0721xb.EVENT_TYPE_WEBVIEW_SYNC;
        map2.put(enumC0721xb23, 38);
        EnumC0721xb enumC0721xb24 = EnumC0721xb.EVENT_CLIENT_EXTERNAL_ATTRIBUTION;
        map2.put(enumC0721xb24, 42);
        c = Collections.unmodifiableMap(map2);
        HashMap map3 = new HashMap();
        P8 p8 = new P8();
        V8 v8 = new V8(new C0149b9());
        Q8 q8 = new Q8();
        C0583s3 c0583s3 = new C0583s3(new C0149b9());
        C0319ho c0319ho = new C0319ho(new C0149b9());
        C0285gg c0285gg = new C0285gg();
        C0459n9 c0459n9A = C0485o9.a();
        c0459n9A.b = c0285gg;
        c0459n9A.c = c0285gg;
        C0485o9 c0485o9 = new C0485o9(c0459n9A);
        C0459n9 c0459n9A2 = C0485o9.a();
        c0459n9A2.b = v8;
        C0485o9 c0485o10 = new C0485o9(c0459n9A2);
        C0459n9 c0459n9A3 = C0485o9.a();
        c0459n9A3.b = c0583s3;
        C0485o9 c0485o11 = new C0485o9(c0459n9A3);
        C0459n9 c0459n9A4 = C0485o9.a();
        c0459n9A4.b = c0319ho;
        C0485o9 c0485o12 = new C0485o9(c0459n9A4);
        C0459n9 c0459n9A5 = C0485o9.a();
        c0459n9A5.a = p8;
        C0485o9 c0485o13 = new C0485o9(c0459n9A5);
        C0459n9 c0459n9A6 = C0485o9.a();
        c0459n9A6.b = new Mo(new V8());
        C0485o9 c0485o14 = new C0485o9(c0459n9A6);
        map3.put(enumC0721xb2, c0485o10);
        C0459n9 c0459n9A7 = C0485o9.a();
        c0459n9A7.b = new C0336ig();
        map3.put(enumC0721xb3, new C0485o9(c0459n9A7));
        C0459n9 c0459n9A8 = C0485o9.a();
        c0459n9A8.a = p8;
        c0459n9A8.b = q8;
        c0459n9A8.e = new C0510p8();
        c0459n9A8.f = new C0537q8();
        map3.put(enumC0721xb4, new C0485o9(c0459n9A8));
        map3.put(enumC0721xb9, c0485o9);
        map3.put(enumC0721xb10, c0485o9);
        map3.put(enumC0721xb11, c0485o11);
        map3.put(enumC0721xb12, c0485o11);
        map3.put(enumC0721xb5, c0485o11);
        map3.put(enumC0721xb6, c0485o11);
        map3.put(enumC0721xb7, c0485o11);
        map3.put(enumC0721xb8, c0485o11);
        C0459n9 c0459n9A9 = C0485o9.a();
        c0459n9A9.a = new P8();
        c0459n9A9.b = c0583s3;
        map3.put(enumC0721xb14, new C0485o9(c0459n9A9));
        EnumC0721xb enumC0721xb25 = EnumC0721xb.EVENT_TYPE_CUSTOM_EVENT;
        C0459n9 c0459n9A10 = C0485o9.a();
        c0459n9A10.d = new C0362jg();
        map3.put(enumC0721xb25, new C0485o9(c0459n9A10));
        map3.put(enumC0721xb15, c0485o10);
        map3.put(enumC0721xb17, c0485o13);
        map3.put(enumC0721xb18, c0485o13);
        map3.put(enumC0721xb19, c0485o11);
        map3.put(enumC0721xb20, c0485o11);
        map3.put(enumC0721xb21, c0485o11);
        map3.put(enumC0721xb22, c0485o12);
        map3.put(enumC0721xb, c0485o14);
        map3.put(enumC0721xb16, c0485o14);
        map3.put(enumC0721xb13, c0485o10);
        map3.put(enumC0721xb23, c0485o10);
        map3.put(enumC0721xb24, c0485o11);
        d = Collections.unmodifiableMap(map3);
    }

    public static C9 a(Long l, Long l2, Boolean bool) {
        C9 c9 = new C9();
        if (l != null) {
            c9.a = l.longValue();
            c9.b = ((GregorianCalendar) Calendar.getInstance()).getTimeZone().getOffset(l.longValue() * 1000) / 1000;
        }
        if (l2 != null) {
            c9.c = l2.longValue();
        }
        if (bool != null) {
            c9.d = bool.booleanValue();
        }
        return c9;
    }
}

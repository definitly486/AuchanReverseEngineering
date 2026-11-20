package io.appmetrica.analytics.impl;

import androidx.fragment.app.FragmentTransaction;
import io.appmetrica.analytics.coreutils.internal.collection.CollectionUtils;
import java.util.Arrays;
import java.util.EnumSet;
import java.util.List;
import java.util.Set;

/* JADX INFO: loaded from: classes3.dex */
public abstract class Q9 {
    public static final Set a;
    public static final EnumSet b;
    public static final EnumSet c;
    public static final EnumSet d;
    public static final EnumSet e;
    public static final EnumSet f;
    public static final EnumSet g;
    public static final EnumSet h;
    public static final List i;
    public static final List j;

    static {
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_EXCEPTION_USER_PROTOBUF;
        EnumC0721xb enumC0721xb2 = EnumC0721xb.EVENT_TYPE_EXCEPTION_USER_CUSTOM_PROTOBUF;
        EnumC0721xb enumC0721xb3 = EnumC0721xb.EVENT_TYPE_EXCEPTION_UNHANDLED_PROTOBUF;
        EnumC0721xb enumC0721xb4 = EnumC0721xb.EVENT_TYPE_EXCEPTION_UNHANDLED_FROM_FILE;
        EnumC0721xb enumC0721xb5 = EnumC0721xb.EVENT_TYPE_PREV_SESSION_EXCEPTION_UNHANDLED_FROM_FILE;
        EnumC0721xb enumC0721xb6 = EnumC0721xb.EVENT_TYPE_ANR;
        a = CollectionUtils.unmodifiableSetOf(5892, 5896, 5891, 5889, 5890, 5968);
        EnumC0721xb enumC0721xb7 = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        EnumC0721xb enumC0721xb8 = EnumC0721xb.EVENT_TYPE_PURGE_BUFFER;
        EnumC0721xb enumC0721xb9 = EnumC0721xb.EVENT_TYPE_SEND_REFERRER;
        EnumC0721xb enumC0721xb10 = EnumC0721xb.EVENT_TYPE_APP_ENVIRONMENT_UPDATED;
        EnumC0721xb enumC0721xb11 = EnumC0721xb.EVENT_TYPE_APP_ENVIRONMENT_CLEARED;
        EnumC0721xb enumC0721xb12 = EnumC0721xb.EVENT_TYPE_ACTIVATION;
        EnumC0721xb enumC0721xb13 = EnumC0721xb.EVENT_TYPE_PREV_SESSION_NATIVE_CRASH_PROTOBUF;
        EnumC0721xb enumC0721xb14 = EnumC0721xb.EVENT_TYPE_SET_SESSION_EXTRA;
        b = EnumSet.of(enumC0721xb7, enumC0721xb8, enumC0721xb9, enumC0721xb10, enumC0721xb11, enumC0721xb12, enumC0721xb13, enumC0721xb5, enumC0721xb14);
        EnumC0721xb enumC0721xb15 = EnumC0721xb.EVENT_TYPE_UPDATE_FOREGROUND_TIME;
        EnumC0721xb enumC0721xb16 = EnumC0721xb.EVENT_TYPE_CURRENT_SESSION_NATIVE_CRASH_PROTOBUF;
        c = EnumSet.of(enumC0721xb15, enumC0721xb4, enumC0721xb5, enumC0721xb13, enumC0721xb16);
        EnumC0721xb enumC0721xb17 = EnumC0721xb.EVENT_TYPE_REGULAR;
        d = EnumSet.of(enumC0721xb4, enumC0721xb5, enumC0721xb3, enumC0721xb, enumC0721xb2, enumC0721xb16, enumC0721xb13, enumC0721xb17, EnumC0721xb.EVENT_CLIENT_EXTERNAL_ATTRIBUTION, EnumC0721xb.EVENT_TYPE_SEND_ECOMMERCE_EVENT, EnumC0721xb.EVENT_TYPE_SEND_REVENUE_EVENT, EnumC0721xb.EVENT_TYPE_SEND_AD_REVENUE_EVENT, enumC0721xb8, EnumC0721xb.EVENT_TYPE_INIT, EnumC0721xb.EVENT_TYPE_SEND_USER_PROFILE, EnumC0721xb.EVENT_TYPE_SET_USER_PROFILE_ID, enumC0721xb9, enumC0721xb10, enumC0721xb11, EnumC0721xb.EVENT_TYPE_FIRST_ACTIVATION, EnumC0721xb.EVENT_TYPE_START, EnumC0721xb.EVENT_TYPE_APP_OPEN, EnumC0721xb.EVENT_TYPE_APP_UPDATE, enumC0721xb6);
        e = EnumSet.of(enumC0721xb17);
        f = EnumSet.of(enumC0721xb17);
        g = EnumSet.of(enumC0721xb13);
        h = EnumSet.of(EnumC0721xb.EVENT_TYPE_ALIVE, enumC0721xb8, enumC0721xb14, enumC0721xb5, enumC0721xb13);
        i = Arrays.asList(0, 6145, Integer.valueOf(FragmentTransaction.TRANSIT_FRAGMENT_OPEN), 8224);
        j = Arrays.asList(12290);
    }
}

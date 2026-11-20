package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.SetsKt;
import io.appmetrica.analytics.StartupParamsCallback;
import io.appmetrica.analytics.coreutils.internal.time.SystemTimeProvider;
import java.util.Collection;
import java.util.Iterator;
import java.util.Map;
import java.util.Set;
import kotlin.jvm.functions.Function0;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.tm, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AbstractC0628tm {
    public static final Set a = SetsKt.setOf((Object[]) new String[]{"appmetrica_clids", StartupParamsCallback.APPMETRICA_DEVICE_ID_HASH, StartupParamsCallback.APPMETRICA_DEVICE_ID, "appmetrica_get_ad_url", "appmetrica_report_ad_url", StartupParamsCallback.APPMETRICA_UUID});
    public static final SystemTimeProvider b = new SystemTimeProvider();
    public static final T3 c = new T3();

    public static final boolean a(String str) {
        return !(str == null || str.length() == 0);
    }

    /* JADX WARN: Code duplicated, block: B:50:0x00ac A[SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:67:0x0017 A[SYNTHETIC] */
    /* JADX WARN: Failed to restore switch over string. Please report as a decompilation issue */
    public static final boolean a(C0706wm c0706wm, Collection collection, Map map, Function0 function0) {
        boolean zA;
        if (collection != null && !collection.isEmpty() && !collection.isEmpty()) {
            Iterator it = collection.iterator();
            while (it.hasNext()) {
                String str = (String) it.next();
                switch (str.hashCode()) {
                    case -1367801046:
                        if (str.equals(StartupParamsCallback.APPMETRICA_UUID)) {
                            zA = a(c0706wm.d);
                            if (!zA) {
                                return false;
                            }
                        }
                        break;
                    case 155670667:
                        if (str.equals("appmetrica_get_ad_url")) {
                            zA = a(c0706wm.i);
                            if (!zA) {
                                return false;
                            }
                        }
                        break;
                    case 299713912:
                        if (str.equals(StartupParamsCallback.APPMETRICA_DEVICE_ID_HASH)) {
                            zA = a(c0706wm.b);
                            if (!zA) {
                                return false;
                            }
                        }
                        break;
                    case 530949152:
                        if (str.equals("appmetrica_clids")) {
                            T3 t3 = c;
                            Q3 q3 = (Q3) function0.invoke();
                            t3.getClass();
                            zA = T3.a(map, c0706wm, q3);
                            if (!zA) {
                                return false;
                            }
                        }
                        break;
                    case 703740463:
                        if (str.equals("appmetrica_report_ad_url")) {
                            zA = a(c0706wm.j);
                            if (!zA) {
                                return false;
                            }
                        }
                        break;
                    case 1117383061:
                        if (str.equals(StartupParamsCallback.APPMETRICA_DEVICE_ID)) {
                            zA = a(c0706wm.a);
                            if (!zA) {
                                return false;
                            }
                        }
                        break;
                }
                if (c0706wm.w) {
                    return false;
                }
                if (b.currentTimeSeconds() > c0706wm.o + ((long) c0706wm.z.a)) {
                    return false;
                }
            }
        }
        return true;
    }
}

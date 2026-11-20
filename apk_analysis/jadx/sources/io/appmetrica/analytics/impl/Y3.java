package io.appmetrica.analytics.impl;

import android.content.Context;
import android.os.Bundle;
import io.appmetrica.analytics.AppMetrica;
import io.appmetrica.analytics.internal.CounterConfiguration;

/* JADX INFO: loaded from: classes3.dex */
public class Y3 {
    public final Wf a;
    public final CounterConfiguration b;

    public Y3(Wf wf, CounterConfiguration counterConfiguration) {
        this.a = wf;
        this.b = counterConfiguration;
    }

    public static Y3 a(Context context, Bundle bundle) {
        Wf wf;
        String str = Wf.c;
        if (bundle != null) {
            try {
                wf = (Wf) bundle.getParcelable("PROCESS_CFG_OBJ");
            } catch (Throwable unused) {
                wf = null;
            }
        } else {
            wf = null;
        }
        CounterConfiguration counterConfigurationFromBundle = CounterConfiguration.fromBundle(bundle);
        if (counterConfigurationFromBundle == null || wf == null || !context.getPackageName().equals(wf.a.getAsString("PROCESS_CFG_PACKAGE_NAME")) || wf.a.getAsInteger("PROCESS_CFG_SDK_API_LEVEL").intValue() != AppMetrica.getLibraryApiLevel()) {
            return null;
        }
        return new Y3(wf, counterConfigurationFromBundle);
    }

    public final CounterConfiguration b() {
        return this.b;
    }

    public final String toString() {
        return "ClientConfiguration{mProcessConfiguration=" + this.a + ", mCounterConfiguration=" + this.b + '}';
    }

    public final Wf a() {
        return this.a;
    }
}

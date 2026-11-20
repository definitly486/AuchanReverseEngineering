package io.appmetrica.analytics.impl;

import android.content.Context;
import android.text.TextUtils;
import io.appmetrica.analytics.coreutils.internal.io.FileUtils;
import org.json.JSONObject;

/* JADX INFO: loaded from: classes3.dex */
public final class S1 {
    public final C0694wa a;
    public boolean b;

    public S1() {
        this(new C0694wa());
    }

    public final synchronized long a(Context context) {
        String strA;
        try {
            this.a.getClass();
            strA = AbstractC0332ib.a(FileUtils.getFileFromAppStorage(context, "metrica_service_settings.dat"));
        } catch (Throwable unused) {
        }
        return !TextUtils.isEmpty(strA) ? new JSONObject(strA).optLong("delay") : 0L;
    }

    public final void b(Context context) {
        synchronized (this) {
        }
        if (this.b) {
            return;
        }
        long jA = a(context);
        if (jA > 0) {
            try {
                Thread.sleep(jA);
            } catch (Throwable unused) {
            }
        }
        this.b = true;
    }

    public S1(C0694wa c0694wa) {
        this.b = false;
        this.a = c0694wa;
    }
}

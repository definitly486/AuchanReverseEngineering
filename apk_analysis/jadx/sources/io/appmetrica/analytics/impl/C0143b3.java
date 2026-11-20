package io.appmetrica.analytics.impl;

import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import io.appmetrica.analytics.coreapi.internal.backport.Consumer;
import io.appmetrica.analytics.coreapi.internal.executors.IHandlerExecutor;
import java.util.ArrayList;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.b3, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0143b3 implements Ck {
    public final ArrayList a;
    public Intent b;
    public final Context c;
    public final W5 d;
    public final IHandlerExecutor e;

    public C0143b3(Context context, IHandlerExecutor iHandlerExecutor) {
        this(context, iHandlerExecutor, 0);
    }

    public final synchronized Intent a(Consumer<Intent> consumer) {
        this.a.add(consumer);
        return this.b;
    }

    public final void b() {
        this.b = null;
        W5 w5 = this.d;
        Context context = this.c;
        synchronized (w5) {
            if (w5.b) {
                try {
                    context.unregisterReceiver(w5.a);
                    w5.b = false;
                } catch (Throwable unused) {
                }
            }
        }
    }

    @Override // io.appmetrica.analytics.impl.Ck
    public final synchronized void onCreate() {
        Intent intentA = a();
        this.b = intentA;
        ArrayList arrayList = this.a;
        int size = arrayList.size();
        int i = 0;
        while (i < size) {
            Object obj = arrayList.get(i);
            i++;
            ((Consumer) obj).consume(intentA);
        }
    }

    @Override // io.appmetrica.analytics.impl.Ck
    public final synchronized void onDestroy() {
        this.b = null;
        b();
        ArrayList arrayList = this.a;
        int size = arrayList.size();
        int i = 0;
        while (i < size) {
            Object obj = arrayList.get(i);
            i++;
            ((Consumer) obj).consume(null);
        }
    }

    public C0143b3(Context context, IHandlerExecutor iHandlerExecutor, int i) {
        this.a = new ArrayList();
        this.b = null;
        this.c = context;
        this.e = iHandlerExecutor;
        this.d = V5.a(new G2(new C0117a3(this), iHandlerExecutor));
    }

    public final Intent a() {
        Intent intentRegisterReceiver;
        IntentFilter intentFilter = new IntentFilter("android.intent.action.BATTERY_CHANGED");
        W5 w5 = this.d;
        Context context = this.c;
        IHandlerExecutor iHandlerExecutor = this.e;
        synchronized (w5) {
            intentRegisterReceiver = null;
            try {
                intentRegisterReceiver = context.registerReceiver(w5.a, intentFilter, null, iHandlerExecutor.getHandler());
                w5.b = true;
            } catch (Throwable unused) {
            }
        }
        return intentRegisterReceiver;
    }
}

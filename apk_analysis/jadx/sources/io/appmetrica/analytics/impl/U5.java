package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.IReporter;
import io.appmetrica.analytics.coreapi.internal.lifecycle.ActivityEvent;

/* JADX INFO: loaded from: classes3.dex */
public final class U5 {
    public final C0475o a;
    public final IReporter b;
    public Context c;
    public final T5 d;

    public U5(C0475o c0475o) {
        this(c0475o, 0);
    }

    public final synchronized void a(Context context) {
        if (this.c == null) {
            Context applicationContext = context.getApplicationContext();
            this.a.a(applicationContext);
            this.a.registerListener(this.d, ActivityEvent.RESUMED, ActivityEvent.PAUSED);
            this.c = applicationContext;
        }
    }

    public U5(C0475o c0475o, IReporter iReporter) {
        this.a = c0475o;
        this.b = iReporter;
        this.d = new T5(this);
    }

    public /* synthetic */ U5(C0475o c0475o, int i) {
        this(c0475o, AbstractC0763z1.a());
    }

    public final synchronized Context a() {
        return this.c;
    }
}

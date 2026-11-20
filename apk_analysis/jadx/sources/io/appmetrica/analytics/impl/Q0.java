package io.appmetrica.analytics.impl;

import android.content.Intent;

/* JADX INFO: loaded from: classes3.dex */
public final class Q0 implements Runnable {
    public final /* synthetic */ Intent a;
    public final /* synthetic */ C0659v1 b;

    public Q0(C0659v1 c0659v1, Intent intent) {
        this.b = c0659v1;
        this.a = intent;
    }

    @Override // java.lang.Runnable
    public final void run() {
        Q7 q7 = this.b.c().b;
        Intent intent = this.a;
        q7.getClass();
        if (intent != null) {
            q7.a(intent.getDataString(), false);
        }
    }
}

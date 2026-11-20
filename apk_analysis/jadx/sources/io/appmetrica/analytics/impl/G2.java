package io.appmetrica.analytics.impl;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import io.appmetrica.analytics.coreapi.internal.backport.BiConsumer;
import io.appmetrica.analytics.coreapi.internal.executors.ICommonExecutor;

/* JADX INFO: loaded from: classes3.dex */
public final class G2 extends BroadcastReceiver {
    public final BiConsumer a;
    public final ICommonExecutor b;

    public G2(C0117a3 c0117a3, ICommonExecutor iCommonExecutor) {
        this.a = c0117a3;
        this.b = iCommonExecutor;
    }

    @Override // android.content.BroadcastReceiver
    public final void onReceive(Context context, Intent intent) {
        this.b.execute(new F2(this, context, intent));
    }
}

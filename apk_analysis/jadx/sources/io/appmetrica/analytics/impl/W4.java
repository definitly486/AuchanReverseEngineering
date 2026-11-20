package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.networktasks.internal.BaseRequestConfig;

/* JADX INFO: loaded from: classes3.dex */
public abstract class W4 extends E5 {
    public W4(BaseRequestConfig.ComponentLoader<Object, Object, C0146b6> componentLoader, C0706wm c0706wm, BaseRequestConfig.BaseRequestArguments<F4, Object> baseRequestArguments) {
        super(componentLoader, c0706wm, baseRequestArguments);
    }

    @Override // io.appmetrica.analytics.impl.E5
    public final void a(Object obj) {
        F4 f4 = (F4) obj;
        synchronized (this) {
            super.a((Object) f4);
        }
    }

    public final synchronized void a(F4 f4) {
        super.a((Object) f4);
    }
}
